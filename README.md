# Terraria 1.4.5.8 反编译与原理剖析

本仓库把 Terraria 的托管程序集（`Terraria.exe` / `TerrariaServer.exe`）反编译成可读的 C# 源码，
并用中文文档逐层拆解它的实现原理，供第三方学习游戏引擎、模拟与渲染的工程实践。

> **版权声明**：Terraria 及其全部代码、美术、音频资源版权归 Re-Logic 所有。
> 本仓库是**私有**仓库，反编译源码仅用于个人学习与研究，不得以任何形式公开分发、商用或再发布。
> `docs/` 下的讲解文档可以独立阅读，不含大段原始代码。

---

## 仓库结构

```
Terraria.exe              原始客户端程序集（.NET Framework 4.0，FNA 26.3.0.0）
TerrariaServer.exe        原始专用服务端程序集
tools/
  refstub/                FNA 参考程序集桩（反编译用，详见下文）
  decompile.sh            一键反编译流水线
decompiled/
  Terraria/               客户端源码树（1549 个 .cs）
  TerrariaServer/         服务端源码树
    resources/            从程序集内嵌资源中导出的 DLL / JSON / TSV
docs/                     原理剖析文档（简体中文）
```

## 快速开始

```bash
./tools/decompile.sh            # 客户端 + 服务端，约 2 分钟
./tools/decompile.sh client     # 只反编译客户端
```

流水线做四件事：

1. 用 `dotnet tool install` 把 ilspycmd 装到 `.tools/`（版本锁定，不影响全局环境）。
2. 编译 `tools/refstub`，产出一个**桩版 FNA.dll**。
3. **第一遍**反编译：不带内部依赖参考，目的是把 exe 里内嵌的 `ReLogic.dll` 等托管 DLL 释放到磁盘。
4. **第二遍**反编译：把 FNA 桩和上一步释放的依赖一起作为参考喂给反编译器，得到最终源码树。

### 为什么要 FNA 桩

反编译器还原 `Vector2.Zero`、`Color.White` 这类**静态成员引用**时，必须知道
`Microsoft.Xna.Framework.Vector2` 到底有哪些静态成员。Terraria 用的是 [FNA]（XNA 的跨平台实现），
而 FNA 只以源码分发、不在 NuGet 上，本机也没有——缺少它，反编译结果会退化成满屏：

```csharp
//IL_2a7df: Unknown result type (might be due to invalid IL or missing references)
```

`tools/refstub/FnaStub.cs` 手写了一份只含类型/签名、方法体全空的 FNA API 桩。实测效果：

| 配置 | `Unknown result type` 注释数 |
| :--- | ---: |
| 无参考程序集 | 128,531 |
| + FNA 桩 | 3,486 |
| + FNA 桩 + 释放出的 `ReLogic.dll` | **465** |

这 465 处分布在 45 个文件里，过半集中在 `Terraria.Social.Steam/` 与 `Terraria.Social.WeGame/`
（共 24 个文件，Steamworks / WeGame 的 C 互操作），其余零散出现在反射、D3D 互操作、序列化桩等位置。
这些残留**不影响对游戏核心逻辑的理解**：世界生成、实体 AI、渲染、光照、网络协议都是干净还原的。

## 已知限制

反编译是**尽力而为**的还原，不是原始工程：

- **局部变量名丢失**：IL 里没有名字，反编译器会生成 `num3`、`flag2`、`val` 这类名字。
- **编译器语法糖被展开**：`foreach` 会变成显式 `GetEnumerator` 循环，`using` 会变成 `try/finally`，
  lambda 会变成 `<>c__DisplayClass` 内部类。读代码时把它们**在脑子里折叠回去**即可。
- **`async`/`await` 会还原成状态机**（`MoveNext` + `switch`）。
- `switch` 语句可能变成跳转表或 `if` 链；`?. `、字符串插值等语法糖不一定还原成糖。
- 反编译产物**不能直接编译**：依赖 FNA、ReLogic 等私有程序集的实际实现。

## 文档

从 [docs/00-总览.md](docs/00-总览.md) 开始，那里有推荐的阅读路线。

## 参考

- [FNA] —— Terraria 使用的 XNA4 兼容层
- [ILSpy / ilspycmd] —— 本仓库使用的反编译器

[FNA]: https://github.com/FNA-XNA/FNA
[ILSpy / ilspycmd]: https://github.com/icsharpcode/ILSpy