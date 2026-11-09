using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;

namespace Terraria.UI;

public class GameInterfaceLayer
{
	public readonly string Name;

	public InterfaceScaleType ScaleType;

	public GameInterfaceLayer(string name, InterfaceScaleType scaleType)
	{
		Name = name;
		ScaleType = scaleType;
	}

	public bool Draw()
	{
		Matrix matrix;
		if (ScaleType == InterfaceScaleType.Game)
		{
			PlayerInput.SetZoom_World();
			matrix = Main.GameViewMatrix.ZoomMatrix;
		}
		else if (ScaleType == InterfaceScaleType.UI)
		{
			PlayerInput.SetZoom_UI();
			matrix = Main.UIScaleMatrix;
		}
		else
		{
			PlayerInput.SetZoom_Unscaled();
			matrix = Matrix.Identity;
		}
		bool result = false;
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState)null, (SamplerState)null, (DepthStencilState)null, (RasterizerState)null, (Effect)null, matrix);
		try
		{
			result = DrawSelf();
		}
		catch (Exception e)
		{
			TimeLogger.DrawException(e);
		}
		Main.spriteBatch.End();
		return result;
	}

	protected virtual bool DrawSelf()
	{
		return true;
	}
}
