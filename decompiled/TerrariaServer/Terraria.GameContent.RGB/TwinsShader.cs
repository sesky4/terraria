using System;
using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;

namespace Terraria.GameContent.RGB;

public class TwinsShader : ChromaShader
{
	private readonly Vector4 _eyeColor;

	private readonly Vector4 _veinColor;

	private readonly Vector4 _laserColor;

	private readonly Vector4 _mouthColor;

	private readonly Vector4 _flameColor;

	private readonly Vector4 _backgroundColor;

	private static readonly Vector4[] _irisColors = new Vector4[2]
	{
		Color.Green.ToVector4(),
		Color.Blue.ToVector4()
	};

	public TwinsShader(Color eyeColor, Color veinColor, Color laserColor, Color mouthColor, Color flameColor, Color backgroundColor)
	{
		_eyeColor = eyeColor.ToVector4();
		_veinColor = veinColor.ToVector4();
		_laserColor = laserColor.ToVector4();
		_mouthColor = mouthColor.ToVector4();
		_flameColor = flameColor.ToVector4();
		_backgroundColor = backgroundColor.ToVector4();
	}

	[RgbProcessor(new EffectDetailLevel[] { EffectDetailLevel.Low })]
	private void ProcessLowDetail(RgbDevice device, Fragment fragment, EffectDetailLevel quality, float time)
	{
		for (int i = 0; i < fragment.Count; i++)
		{
			Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(i);
			Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(i);
			Vector4 a = Vector4.Lerp(_veinColor, _eyeColor, (float)Math.Sin(time + canvasPositionOfIndex.X * 4f) * 0.5f + 0.5f);
			float dynamicNoise = NoiseHelper.GetDynamicNoise(gridPositionOfIndex.X, gridPositionOfIndex.Y, time / 25f);
			dynamicNoise = Math.Max(0f, 1f - dynamicNoise * 5f);
			a = Vector4.Lerp(a, _irisColors[((gridPositionOfIndex.Y * 47 + gridPositionOfIndex.X) % _irisColors.Length + _irisColors.Length) % _irisColors.Length], dynamicNoise);
			fragment.SetColor(i, a);
		}
	}

	[RgbProcessor(new EffectDetailLevel[] { EffectDetailLevel.High })]
	private void ProcessHighDetail(RgbDevice device, Fragment fragment, EffectDetailLevel quality, float time)
	{
		if (device.Type != RgbDeviceType.Keyboard && device.Type != RgbDeviceType.Virtual)
		{
			ProcessLowDetail(device, fragment, quality, time);
			return;
		}
		bool flag = true;
		float num = time * 0.1f % 2f;
		if (num > 1f)
		{
			num = 2f - num;
			flag = false;
		}
		Vector2 vector = new Vector2(num * 7f - 3.5f, 0f) + fragment.CanvasCenter;
		for (int i = 0; i < fragment.Count; i++)
		{
			Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(i);
			Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(i);
			Vector4 vector2 = _backgroundColor;
			Vector2 vector3 = canvasPositionOfIndex - vector;
			float num2 = vector3.Length();
			if (num2 < 0.5f)
			{
				float t = 1f - MathHelper.Clamp((num2 - 0.5f + 0.2f) / 0.2f, 0f, 1f);
				float num3 = MathHelper.Clamp((vector3.X + 0.5f - 0.2f) / 0.6f, 0f, 1f);
				if (flag)
				{
					num3 = 1f - num3;
				}
				Vector4 b = Vector4.Lerp(_eyeColor, _veinColor, num3);
				float value = (float)Math.Atan2(vector3.Y, vector3.X);
				if (!flag && (float)Math.PI - Math.Abs(value) < 0.6f)
				{
					b = _mouthColor;
				}
				vector2 = Vector4.Lerp(vector2, b, t);
			}
			if (flag && gridPositionOfIndex.Y == 3 && canvasPositionOfIndex.X > vector.X)
			{
				float num4 = 1f - Math.Abs(canvasPositionOfIndex.X - vector.X * 2f - 0.5f) / 0.5f;
				vector2 = Vector4.Lerp(vector2, _laserColor, MathHelper.Clamp(num4, 0f, 1f));
			}
			else if (!flag)
			{
				Vector2 vector4 = canvasPositionOfIndex - (vector - new Vector2(1.2f, 0f));
				vector4.Y *= 3.5f;
				float num5 = vector4.Length();
				if (num5 < 0.7f)
				{
					float dynamicNoise = NoiseHelper.GetDynamicNoise(canvasPositionOfIndex, time);
					dynamicNoise = dynamicNoise * dynamicNoise * dynamicNoise;
					dynamicNoise *= 1f - MathHelper.Clamp((num5 - 0.7f + 0.3f) / 0.3f, 0f, 1f);
					vector2 = Vector4.Lerp(vector2, _flameColor, dynamicNoise);
				}
			}
			fragment.SetColor(i, vector2);
		}
	}
}
