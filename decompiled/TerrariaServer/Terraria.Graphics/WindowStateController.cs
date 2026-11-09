using System.Drawing;
using System.Windows.Forms;
using ReLogic.OS;

namespace Terraria.Graphics;

public class WindowStateController
{
	public bool CanMoveWindowAcrossScreens => Platform.IsWindows;

	public string ScreenDeviceName
	{
		get
		{
			if (!Platform.IsWindows)
			{
				return "";
			}
			return Main.instance.Window.ScreenDeviceName;
		}
	}

	public void TryMovingToScreen(string screenDeviceName)
	{
		if (CanMoveWindowAcrossScreens && TryGetBounds(screenDeviceName, out var bounds) && IsVisibleOnAnyScreen(bounds))
		{
			Form val = Control.FromHandle(Main.instance.Window.Handle);
			if (WouldViewFitInScreen(((Control)val).Bounds, bounds))
			{
				val.Location = new Point(bounds.Width / 2 - ((Control)val).Width / 2 + bounds.X, bounds.Height / 2 - ((Control)val).Height / 2 + bounds.Y);
			}
		}
	}

	private bool TryGetBounds(string screenDeviceName, out Rectangle bounds)
	{
		bounds = default(Rectangle);
		Screen[] allScreens = Screen.AllScreens;
		foreach (Screen val in allScreens)
		{
			if (val.DeviceName == screenDeviceName)
			{
				bounds = val.Bounds;
				return true;
			}
		}
		return false;
	}

	private bool WouldViewFitInScreen(Rectangle view, Rectangle screen)
	{
		if (view.Width <= screen.Width)
		{
			return view.Height <= screen.Height;
		}
		return false;
	}

	private bool IsVisibleOnAnyScreen(Rectangle rect)
	{
		Screen[] allScreens = Screen.AllScreens;
		for (int i = 0; i < allScreens.Length; i++)
		{
			if (allScreens[i].WorkingArea.IntersectsWith(rect))
			{
				return true;
			}
		}
		return false;
	}
}
