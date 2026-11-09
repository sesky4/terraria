using System;
using Microsoft.Xna.Framework;
using Terraria.Enums;

namespace Terraria.GameContent;

public class DontStarveSeed
{
	public static void ModifyNightColor(ref Color bgColorToSet, ref Color moonColor)
	{
		if (Main.GetMoonPhase() != MoonPhase.Full)
		{
			float fromValue = (float)(Main.time / 32400.0);
			Color a = bgColorToSet;
			Color black = Color.Black;
			Color b = bgColorToSet;
			float t = Utils.Remap(fromValue, 0f, 0.5f, 0f, 1f);
			float t2 = Utils.Remap(fromValue, 0.5f, 1f, 0f, 1f);
			Color color = Color.Lerp(Color.Lerp(a, black, t), b, t2);
			bgColorToSet = color;
		}
	}

	public static void ModifyMinimumLightColorAtNight(ref byte minimalLight)
	{
		switch (Main.GetMoonPhase())
		{
		case MoonPhase.Empty:
			minimalLight = 1;
			break;
		case MoonPhase.QuarterAtLeft:
		case MoonPhase.QuarterAtRight:
			minimalLight = 1;
			break;
		case MoonPhase.HalfAtLeft:
		case MoonPhase.HalfAtRight:
			minimalLight = 1;
			break;
		case MoonPhase.ThreeQuartersAtLeft:
		case MoonPhase.ThreeQuartersAtRight:
			minimalLight = 1;
			break;
		case MoonPhase.Full:
			minimalLight = 45;
			break;
		}
		if (Main.bloodMoon)
		{
			minimalLight = Utils.Max(new byte[2] { minimalLight, 35 });
		}
	}

	public static void FixBiomeDarkness(ref Color bgColor, ref int R, ref int G, ref int B)
	{
		if (Main.dontStarveWorld)
		{
			R = (byte)Math.Min(bgColor.R, R);
			G = (byte)Math.Min(bgColor.G, G);
			B = (byte)Math.Min(bgColor.B, B);
		}
	}

	public static void Initialize()
	{
		Player.Hooks.OnEnterWorld += Hook_OnEnterWorld;
	}

	private static void Hook_OnEnterWorld(Player player)
	{
		player.UpdateStarvingState(withEmote: false);
	}
}
