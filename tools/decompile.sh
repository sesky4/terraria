#!/usr/bin/env bash
#
# 一键反编译 Terraria (Terraria.exe / TerrariaServer.exe) -> decompiled/
#
# 依赖: .NET SDK (dotnet)；首次运行需要网络以还原 ilspycmd。
#
# 用法:
#   ./tools/decompile.sh            # 客户端 + 专用服务端
#   ./tools/decompile.sh client     # 只反编译客户端
#   ./tools/decompile.sh server     # 只反编译服务端
#
set -euo pipefail

ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$ROOT"

export DOTNET_ROOT="${DOTNET_ROOT:-$HOME/.dotnet}"
export DOTNET_ROLL_FORWARD=LatestMajor   # 允许 ilspycmd 运行在更新的 .NET 运行时上
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_NOLOGO=1

ILSPY_VERSION="${ILSPY_VERSION:-10.0.1.8346}"
TOOLS_DIR="$ROOT/.tools"
ILSPY_DIR="$TOOLS_DIR/ilspycmd"
STAGE="$ROOT/.decompile-stage"
OUT="$ROOT/decompiled"

log() { printf "\033[1;36m==>\033[0m %s\n" "$*"; }

# ------------------------------------------------------------ 工具准备
if [ ! -x "$ILSPY_DIR/ilspycmd" ]; then
  log "安装 ilspycmd $ILSPY_VERSION"
  mkdir -p "$TOOLS_DIR"
  dotnet tool install ilspycmd --tool-path "$ILSPY_DIR" --version "$ILSPY_VERSION"
fi
ILSPY="$ILSPY_DIR/ilspycmd"

# -------------------------------------------------------- 参考程序集桩
log "编译 FNA 参考程序集桩 (tools/refstub)"
dotnet build "$ROOT/tools/refstub/FnaStub.csproj" -c Release -o "$STAGE/refstub" --nologo -v q

# ------------------------------------------------------ 反编译单程序集
# 两遍走：
#   第一遍不带内部依赖参考，目的是把 exe 内嵌的 ReLogic.dll 等托管 DLL 释放出来；
#   第二遍把这些 DLL 作为参考传给反编译器，才能正确解析 SlotId 等类型。
decompile_asm() {
  local name="$1"
  local dir="$OUT/$name"
  local deps_dir="$STAGE/$name-deps"
  local pass1="$STAGE/$name-pass1"

  log "[$name] 第一遍：释放内嵌资源与依赖"
  rm -rf "$pass1" "$deps_dir"
  "$ILSPY" -p -o "$pass1" -r "$STAGE/refstub" "$ROOT/$name.exe" >/dev/null

  log "[$name] 收集内嵌依赖程序集"
  mkdir -p "$deps_dir"
  local f base real n=0
  for f in "$pass1"/*.dll; do
    [ -e "$f" ] || continue
    base="$(basename "$f")"
    real="${base%.dll}"
    real="${real##*.}"            # Terraria.Libraries.ReLogic.ReLogic.dll -> ReLogic.dll
    cp "$f" "$deps_dir/$real.dll"
    n=$((n + 1))
  done
  log "[$name] 内嵌依赖: $n 个"

  # 注意：ilspycmd 会按“引用所在目录”去解析依赖，所以 -r 必须指向目录本身，
  # 传单个 dll 路径会导致它到该 dll 所在目录之外去找同名依赖而报错。
  log "[$name] 第二遍：生成最终源码树 -> decompiled/$name"
  rm -rf "$dir"
  "$ILSPY" -p -o "$dir" -r "$STAGE/refstub" -r "$deps_dir" "$ROOT/$name.exe" >/dev/null

  # 产物里会再带一份内嵌资源副本，归档到 resources/ 便于查阅
  mkdir -p "$dir/resources"
  local res
  for res in "$dir"/Terraria.Libraries.*.dll "$dir"/Terraria.Localization.Content.*.json "$dir"/*.tsv; do
    [ -e "$res" ] && mv "$res" "$dir/resources/"
  done
}

TARGET="${1:-all}"
case "$TARGET" in
  client|all) decompile_asm Terraria ;;
esac
case "$TARGET" in
  server|all) decompile_asm TerrariaServer ;;
esac

# --------------------------------------------------------------- 体检
log "反编译保真度检查（Unknown result type 越少越好）"
total=0
for d in "$OUT"/*/; do
  [ -d "$d" ] || continue
  n="$(grep -rh "Unknown result type" --include="*.cs" "$d" 2>/dev/null | wc -l | tr -d " ")"
  echo "  $(basename "$d"): $n"
  total=$((total + n))
done
echo "  合计: $total"

log "完成。源码位于 decompiled/"