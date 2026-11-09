using System.Windows.Forms;
using Microsoft.Xna.Framework;
using ReLogic.OS;
using Terraria.Testing;

namespace Terraria;

public static class FocusHelper
{
	public static bool IsSelectedApplication;

	public static bool GameplayActive
	{
		get
		{
			if (IsSelectedApplication)
			{
				return !Main.gamePaused;
			}
			return false;
		}
	}

	public static bool AllowAudioUnfocused => Main.SettingPlayWhenUnfocused;

	public static bool AllowSkyMovement => GameplayActive;

	public static bool AllowTileDrawingToEmitEffects => !WorldUpdateStepper.DrawnThisUpdate;

	public static bool AllowPlayerToEmitEffects => !WorldUpdateStepper.DrawnThisUpdate;

	public static bool AllowWorldItemsToEmitEffects => !WorldUpdateStepper.DrawnThisUpdate;

	public static bool PauseSkies => !GameplayActive;

	public static bool UpdateVisualEffects => GameplayActive;

	public static bool PauseLiquidRenderer => !GameplayActive;

	public static bool AllowMiscDustEffects => !WorldUpdateStepper.DrawnThisUpdate;

	public static bool PausePlayerBalloonAnimations
	{
		get
		{
			if (IsSelectedApplication)
			{
				if (Main.ingameOptionsWindow)
				{
					return Main.autoPause;
				}
				return false;
			}
			return true;
		}
	}

	public static bool AllowRain => GameplayActive;

	public static bool AllowCountingPlayerTime
	{
		get
		{
			bool flag = Main.gamePaused && !IsSelectedApplication;
			bool result = Main.instance.IsActive && !flag;
			if (Main.gameMenu)
			{
				result = false;
			}
			return result;
		}
	}

	public static bool UpdateBackgroundThunder
	{
		get
		{
			if (!IsSelectedApplication)
			{
				return Main.SettingPlayWhenUnfocused;
			}
			return true;
		}
	}

	public static bool AllowMusic
	{
		get
		{
			if (!IsSelectedApplication)
			{
				return AllowAudioUnfocused;
			}
			return true;
		}
	}

	public static bool PauseSounds
	{
		get
		{
			if (!GameplayActive)
			{
				return Main.netMode == 0;
			}
			return false;
		}
	}

	public static bool QuietAmbientSounds => !IsSelectedApplication;

	public static bool AllowInputProcessing => IsSelectedApplication;

	public static bool AllowInputProcessingForGamepad
	{
		get
		{
			if (!AllowInputProcessing)
			{
				return Main.AllowUnfocusedInputOnGamepad;
			}
			return true;
		}
	}

	public static bool LetStarsFallInMenu => IsSelectedApplication;

	public static bool AllowDontStarveDarknessDamage => IsSelectedApplication;

	public static bool AllowChroma => IsSelectedApplication;

	public static bool AllowTaskbarFlash => !IsSelectedApplication;

	public static void UpdateFocus(out bool wantsToPause)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Invalid comparison between Unknown and I4
		if (!AllowInputProcessing)
		{
			Main.LocalPlayer.delayUseItem = true;
		}
		IsSelectedApplication = Main.instance.IsActive;
		bool flag = !Main.SettingPlayWhenUnfocused;
		wantsToPause = !IsSelectedApplication && Main.netMode == 0 && flag;
		if (Platform.IsWindows)
		{
			Form val = Control.FromHandle(((Game)Main.instance).Window.Handle);
			bool num = (int)val.WindowState == 1;
			bool flag2 = Form.ActiveForm == val;
			IsSelectedApplication |= flag2;
			if (num)
			{
				IsSelectedApplication = false;
			}
		}
		if (!IsSelectedApplication)
		{
			if (!Platform.IsOSX)
			{
				Main.instance.IsMouseVisible = true;
			}
			return;
		}
		if (!Platform.IsOSX)
		{
			Main.instance.IsMouseVisible = false;
		}
		if (Platform.IsWindows && Main.instance.ReHideCursor)
		{
			Main.instance.IsMouseVisible = false;
			Main.instance.ReHideCursor = false;
			Platform.Get<IMouseNotifier>()?.ForceCursorHidden();
		}
	}
}
