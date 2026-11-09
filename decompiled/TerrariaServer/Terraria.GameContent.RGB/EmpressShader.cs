using System;
using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;

namespace Terraria.GameContent.RGB;

public class EmpressShader : ChromaShader
{
	private static readonly Vector4[] _colors = new Vector4[12]
	{
		new Vector4(1f, 0.1f, 0.1f, 1f),
		new Vector4(1f, 0.5f, 0.1f, 1f),
		new Vector4(1f, 1f, 0.1f, 1f),
		new Vector4(0.5f, 1f, 0.1f, 1f),
		new Vector4(0.1f, 1f, 0.1f, 1f),
		new Vector4(0.1f, 1f, 0.5f, 1f),
		new Vector4(0.1f, 1f, 1f, 1f),
		new Vector4(0.1f, 0.5f, 1f, 1f),
		new Vector4(0.1f, 0.1f, 1f, 1f),
		new Vector4(0.5f, 0.1f, 1f, 1f),
		new Vector4(1f, 0.1f, 1f, 1f),
		new Vector4(1f, 0.1f, 0.5f, 1f)
	};

	[RgbProcessor(new EffectDetailLevel[] { EffectDetailLevel.High }, IsTransparent = false)]
	private void ProcessHighDetail(RgbDevice device, Fragment fragment, EffectDetailLevel quality, float time)
	{
		float num = time * 2f;
		for (int i = 0; i < fragment.Count; i++)
		{
			Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(i);
			Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(i);
			float staticNoise = NoiseHelper.GetStaticNoise(gridPositionOfIndex.X);
			float num2 = MathHelper.Max(0f, (float)Math.Cos((staticNoise + num) * ((float)Math.PI * 2f) * 0.2f));
			Vector4 a = Color.Lerp(Color.Black, Color.Indigo, 0.5f).ToVector4();
			float num3 = Math.Max(0f, (float)Math.Sin(Main.GlobalTimeWrappedHourly * 2f + canvasPositionOfIndex.X * 1f));
			num3 = 0f;
			a = Vector4.Lerp(a, new Vector4(1f, 0.1f, 0.1f, 1f), num3);
			float num4 = (num2 + canvasPositionOfIndex.X + canvasPositionOfIndex.Y) % 1f;
			if (num4 > 0f)
			{
				int num5 = (gridPositionOfIndex.X + gridPositionOfIndex.Y) % _colors.Length;
				if (num5 < 0)
				{
					num5 += _colors.Length;
				}
				Vector4 b = Main.hslToRgb(((canvasPositionOfIndex.X + canvasPositionOfIndex.Y) * 0.15f + time * 0.1f) % 1f, 1f, 0.5f).ToVector4();
				a = Vector4.Lerp(a, b, num4);
			}
			fragment.SetColor(i, a);
		}
	}

	private static void RedsVersion(Fragment fragment, float time)
	{
		time *= 3f;
		for (int i = 0; i < fragment.Count; i++)
		{
			Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(i);
			Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(i);
			float num = (NoiseHelper.GetStaticNoise(gridPositionOfIndex.X) * 7f + time * 0.4f) % 7f - canvasPositionOfIndex.Y;
			Vector4 vector = default(Vector4);
			if (num > 0f)
			{
				float t = Math.Max(0f, 1.4f - num);
				if (num < 0.4f)
				{
					t = num / 0.4f;
				}
				int num2 = (gridPositionOfIndex.X + _colors.Length + (int)(time / 6f)) % _colors.Length;
				vector = Vector4.Lerp(vector, _colors[num2], t);
			}
			fragment.SetColor(i, vector);
		}
	}
}
