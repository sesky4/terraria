using System;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.GameContent.RGB;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Map;

namespace Terraria;

public class SceneState
{
	public float airLightDecay;

	public float solidLightDecay;

	public float outsideWeatherEffectIntensity;

	private float _outsideWeatherEffectIntensityBackingValue;

	private float _deerclopsBlizzardSmoothedEffect;

	private bool _disabledBlizzardGraphic;

	private bool _disabledBlizzardSound;

	private float _blizzardSoundVolume;

	private SlotId _strongBlizzardSound = SlotId.Invalid;

	private SlotId _insideBlizzardSound = SlotId.Invalid;

	private float _shimmerBrightenDelay;

	public bool skipTransitions;

	public SceneState()
	{
		Reset();
	}

	public void Reset()
	{
		airLightDecay = 1f;
		solidLightDecay = 1f;
		outsideWeatherEffectIntensity = 1f;
		_outsideWeatherEffectIntensityBackingValue = 1f;
		_deerclopsBlizzardSmoothedEffect = 0f;
		_blizzardSoundVolume = 0f;
		_shimmerBrightenDelay = 0f;
		skipTransitions = true;
	}

	public void Update(SceneMetrics metrics)
	{
		ApplyVisuals(metrics);
		MapHelper.CaptureSceneState(metrics);
		skipTransitions = false;
	}

	private void ApplyVisuals(SceneMetrics metrics)
	{
		if (Main.dedServ)
		{
			return;
		}
		Player perspectivePlayer = metrics.PerspectivePlayer;
		UpdateRGBPeriheralProbe(metrics);
		UpdateGraveyard(metrics);
		UpdateShimmer(metrics);
		UpdateLightDecay(metrics);
		ScreenObstruction.Update(this, metrics);
		ScreenDarkness.Update(this, metrics);
		MoonlordDeathDrama.Update(this, metrics);
		bool flag = metrics.ZoneRain && metrics.ZoneSnow;
		bool flag2 = metrics.TileCenter.Y > Main.maxTilesY - 320;
		bool flag3 = (double)metrics.TileCenter.Y < Main.worldSurface && metrics.ZoneDesert && !metrics.ZoneRain && !metrics.ZoneSandstorm;
		ManageSpecialBiomeVisuals("Stardust", metrics.CloseEnoughToStardustTower, metrics.ClosestNPCPosition[493] - new Vector2(0f, 10f));
		ManageSpecialBiomeVisuals("Nebula", metrics.CloseEnoughToNebulaTower, metrics.ClosestNPCPosition[507] - new Vector2(0f, 10f));
		ManageSpecialBiomeVisuals("Vortex", metrics.CloseEnoughToVortexTower, metrics.ClosestNPCPosition[422] - new Vector2(0f, 10f));
		ManageSpecialBiomeVisuals("Solar", metrics.CloseEnoughToSolarTower, metrics.ClosestNPCPosition[517] - new Vector2(0f, 10f));
		ManageSpecialBiomeVisuals("MoonLord", metrics.ClosestNPCPosition[398] != Vector2.Zero);
		bool flag4 = metrics.CloseEnoughToSolarTower || metrics.CloseEnoughToVortexTower || metrics.CloseEnoughToNebulaTower || metrics.CloseEnoughToStardustTower;
		ManageSpecialBiomeVisuals("MonolithVortex", (!flag4 && metrics.ActiveMonolithType == 0) || perspectivePlayer.vortexMonolithShader);
		ManageSpecialBiomeVisuals("MonolithNebula", (!flag4 && metrics.ActiveMonolithType == 1) || perspectivePlayer.nebulaMonolithShader);
		ManageSpecialBiomeVisuals("MonolithStardust", (!flag4 && metrics.ActiveMonolithType == 2) || perspectivePlayer.stardustMonolithShader);
		ManageSpecialBiomeVisuals("MonolithSolar", (!flag4 && metrics.ActiveMonolithType == 3) || perspectivePlayer.solarMonolithShader);
		ManageSpecialBiomeVisuals("MonolithMoonLord", (!flag4 && metrics.ActiveMonolithType == 4) || perspectivePlayer.moonLordMonolithShader);
		ManageSpecialBiomeVisuals("BloodMoon", Main.bloodMoon || metrics.BloodMoonMonolith || perspectivePlayer.bloodMoonMonolithShader);
		bool flag5 = Main.UseStormEffects && flag;
		bool flag6 = !Main.dayTime && !flag5 && Main.GraveyardVisualIntensity < 0.5f;
		ManageSpecialBiomeVisuals("Aurora", metrics.ZoneSnow && flag6);
		ManageSpecialBiomeVisuals("Blizzard", Main.UseStormEffects && flag);
		ManageSpecialBiomeVisuals("Sandstorm", Main.UseStormEffects && Sandstorm.ShowSandstormVisuals());
		bool flag7 = flag2 || flag3 || perspectivePlayer.sunScorchCounter > 0;
		ManageSpecialBiomeVisuals("HeatDistortion", Main.UseHeatDistortion && flag7);
		ManageSpecialBiomeVisuals("Graveyard", Main.GraveyardVisualIntensity > 0f);
		ManageSpecialBiomeVisuals("Sepia", Main.onlyDontStarveWorld ^ (perspectivePlayer.dontStarveShader || metrics.RadioThingMonolith));
		ManageSpecialBiomeVisuals("Noir", metrics.NoirMonolith || perspectivePlayer.noirShader);
		ManageSpecialBiomeVisuals("CRT", metrics.CRTMonolith || perspectivePlayer.CRTMonolithShader);
		ManageSpecialBiomeVisuals("Test2", metrics.RetroMonolith || perspectivePlayer.retroMonolithShader);
		ManageSpecialBiomeVisuals("WaterDistortion", Main.WaveQuality > 0);
		bool flag8 = metrics.TownNPCCount > 0 || metrics.PartyMonolithCount > 0;
		MoveTowards(ref SkyManager.Instance["Party"].Opacity, flag8 ? 1 : 0, 0.01f);
		if (Filters.Scene["Graveyard"].IsActive())
		{
			float progress = MathHelper.Lerp(0f, 0.75f, Main.GraveyardVisualIntensity);
			ScreenShaderData shader = Filters.Scene["Graveyard"].GetShader();
			shader.UseTargetPosition(metrics.Center);
			shader.UseProgress(progress);
			shader.UseIntensity(1.2f);
		}
		if (Filters.Scene["Noir"].IsActive())
		{
			float num = 0.1f;
			float num2 = Utils.Remap(Vector3.Dot(Main.tileColor.ToVector3(), new Vector3(1f / 3f)), 0.5f, 0.1f, 0f, 0.2f);
			float num3 = Utils.Remap((int)Main.worldSurface - metrics.TileCenter.Y, -40f, 40f, 0f, 1f);
			num = MathHelper.Lerp(num, num2, num3);
			float num4 = 0.15f;
			float num5 = Utils.Remap(metrics.TileCenter.Y - Main.UnderworldLayer, -40f, 40f, 0f, 1f);
			num = MathHelper.Lerp(num, num4, num5);
			Random random = new Random((int)(Main.GlobalTimeWrappedHourly * 10f));
			float x = (float)random.NextDouble();
			float y = (float)random.NextDouble();
			ScreenShaderData shader2 = Filters.Scene["Noir"].GetShader();
			shader2.UseTargetPosition(metrics.Center);
			shader2.UseIntensity(num);
			shader2.UseImageOffset(new Vector2(x, y));
		}
		if (Filters.Scene["WaterDistortion"].IsActive())
		{
			float num6 = (float)Main.maxTilesX * 0.5f - Math.Abs((float)metrics.TileCenter.X - (float)Main.maxTilesX * 0.5f);
			float num7 = 1f;
			float num8 = Math.Abs(Main.windSpeedCurrent);
			num7 += num8 * 1.25f;
			float num9 = MathHelper.Clamp(Main.maxRaining, 0f, 1f);
			num7 += num9 * 1.25f;
			float num10 = 0f - (MathHelper.Clamp((num6 - 380f) / 100f, 0f, 1f) * 0.5f - 0.25f);
			num7 += num10;
			float num11 = 1f - MathHelper.Clamp(3f * ((float)((double)metrics.TileCenter.Y - Main.worldSurface) / (float)(Main.rockLayer - Main.worldSurface)), 0f, 1f);
			num7 *= num11;
			float num12 = 0.9f - MathHelper.Clamp((float)(Main.maxTilesY - metrics.TileCenter.Y - 200) / 300f, 0f, 1f) * 0.9f;
			num7 += num12;
			num7 += (1f - num11) * 0.75f;
			num7 = MathHelper.Clamp(num7, 0f, 2.5f);
			Filters.Scene["WaterDistortion"].GetShader().UseIntensity(num7);
		}
		MoveTowards(ref _outsideWeatherEffectIntensityBackingValue, metrics.BehindBackwall ? (-0.1f) : 1.1f, 0.005f);
		outsideWeatherEffectIntensity = Utils.Clamp(_outsideWeatherEffectIntensityBackingValue, 0f, 1f);
		if (Filters.Scene["Sandstorm"].IsActive())
		{
			Filters.Scene["Sandstorm"].GetShader().UseIntensity(outsideWeatherEffectIntensity * 0.4f * Math.Min(1f, Sandstorm.Severity));
			Filters.Scene["Sandstorm"].GetShader().UseOpacity(Math.Min(1f, Sandstorm.Severity * 1.5f) * outsideWeatherEffectIntensity);
			((SimpleOverlay)Overlays.Scene["Sandstorm"]).GetShader().UseOpacity(Math.Min(1f, Sandstorm.Severity * 1.5f) * (1f - outsideWeatherEffectIntensity));
		}
		Filter filter = Filters.Scene["HeatDistortion"];
		if (filter.IsActive())
		{
			float num13 = 0f;
			if (perspectivePlayer.sunScorchCounter > 0)
			{
				float val = Utils.GetLerpValue(0f, 300f, perspectivePlayer.sunScorchCounter, clamped: true) * 4f;
				num13 = Math.Max(num13, val);
			}
			if (flag2)
			{
				float val2 = (float)(metrics.TileCenter.Y - (Main.maxTilesY - 320)) / 120f;
				val2 = Math.Min(1f, val2) * 2f;
				num13 = Math.Max(num13, val2);
			}
			else if (flag3)
			{
				Vector3 vector = Main.tileColor.ToVector3();
				float num14 = (vector.X + vector.Y + vector.Z) / 3f;
				float val3 = outsideWeatherEffectIntensity * 4f * Math.Max(0f, 0.5f - Main.cloudAlpha) * num14;
				num13 = Math.Max(num13, val3);
			}
			filter.GetShader().UseIntensity(num13);
			filter.IsHidden = num13 <= 0f;
		}
		if (!_disabledBlizzardGraphic)
		{
			try
			{
				if (flag)
				{
					float num15 = Main.cloudAlpha;
					if (Main.remixWorld)
					{
						num15 = 0.4f;
					}
					bool flag9 = NPC.IsADeerclopsNearScreen();
					MoveTowards(ref _deerclopsBlizzardSmoothedEffect, flag9 ? 1 : 0, 0.0033333334f);
					float num16 = Math.Min(1f, num15 * 2f) * outsideWeatherEffectIntensity;
					float num17 = outsideWeatherEffectIntensity * 0.4f * Math.Min(1f, num15 * 2f) * 0.9f + 0.1f;
					num17 = MathHelper.Lerp(num17, num17 * 0.5f, _deerclopsBlizzardSmoothedEffect);
					num16 = MathHelper.Lerp(num16, num16 * 0.5f, _deerclopsBlizzardSmoothedEffect);
					Filters.Scene["Blizzard"].GetShader().UseIntensity(num17);
					Filters.Scene["Blizzard"].GetShader().UseOpacity(num16);
					((SimpleOverlay)Overlays.Scene["Blizzard"]).GetShader().UseOpacity(1f - num16);
				}
			}
			catch
			{
				_disabledBlizzardGraphic = true;
			}
		}
		if (_disabledBlizzardSound)
		{
			return;
		}
		try
		{
			if (flag)
			{
				ActiveSound activeSound = SoundEngine.GetActiveSound(_strongBlizzardSound);
				ActiveSound activeSound2 = SoundEngine.GetActiveSound(_insideBlizzardSound);
				if (activeSound == null)
				{
					_strongBlizzardSound = SoundEngine.PlayTrackedSound(SoundID.BlizzardStrongLoop);
				}
				if (activeSound2 == null)
				{
					_insideBlizzardSound = SoundEngine.PlayTrackedSound(SoundID.BlizzardInsideBuildingLoop);
				}
				SoundEngine.GetActiveSound(_strongBlizzardSound);
				activeSound2 = SoundEngine.GetActiveSound(_insideBlizzardSound);
			}
			MoveTowards(ref _blizzardSoundVolume, flag ? 1 : 0, 0.01f);
			float num18 = Math.Min(1f, Main.cloudAlpha * 2f) * outsideWeatherEffectIntensity;
			ActiveSound activeSound3 = SoundEngine.GetActiveSound(_strongBlizzardSound);
			ActiveSound activeSound4 = SoundEngine.GetActiveSound(_insideBlizzardSound);
			if (_blizzardSoundVolume > 0f)
			{
				if (activeSound3 == null)
				{
					_strongBlizzardSound = SoundEngine.PlayTrackedSound(SoundID.BlizzardStrongLoop);
					activeSound3 = SoundEngine.GetActiveSound(_strongBlizzardSound);
				}
				activeSound3.Volume = num18 * _blizzardSoundVolume;
				if (activeSound4 == null)
				{
					_insideBlizzardSound = SoundEngine.PlayTrackedSound(SoundID.BlizzardInsideBuildingLoop);
					activeSound4 = SoundEngine.GetActiveSound(_insideBlizzardSound);
				}
				activeSound4.Volume = (1f - num18) * _blizzardSoundVolume;
			}
			else
			{
				if (activeSound3 != null)
				{
					activeSound3.Volume = 0f;
				}
				else
				{
					_strongBlizzardSound = SlotId.Invalid;
				}
				if (activeSound4 != null)
				{
					activeSound4.Volume = 0f;
				}
				else
				{
					_insideBlizzardSound = SlotId.Invalid;
				}
			}
		}
		catch
		{
			_disabledBlizzardSound = true;
		}
	}

	private void UpdateLightDecay(SceneMetrics metrics)
	{
		float num = 1f;
		float num2 = 1f;
		num *= 1f - Main.shimmerAlpha * 0f;
		num2 *= 1f - Main.shimmerAlpha * 0.3f;
		if (Main.getGoodWorld)
		{
			if (metrics.WithinRangeOfNPC(245, 2000.0))
			{
				num *= 0.6f;
				num2 *= 0.6f;
			}
			else if (metrics.ZoneLihzhardTemple)
			{
				num *= 0.88f;
				num2 *= 0.88f;
			}
			else if (metrics.ZoneDungeon)
			{
				num *= 0.94f;
				num2 *= 0.94f;
			}
		}
		MoveTowards(ref airLightDecay, num, 0.005f);
		MoveTowards(ref solidLightDecay, num2, 0.005f);
	}

	private void UpdateShimmer(SceneMetrics metrics)
	{
		bool flag = metrics.ShimmerMonolithState == 1 || metrics.ZoneShimmer || metrics.PerspectivePlayer.shimmerMonolithShader || (metrics.PerspectivePlayer.shimmering && metrics.UndergroundForShimmering);
		if (metrics.ShimmerMonolithState == 2)
		{
			flag = false;
		}
		if (flag)
		{
			MoveTowards(ref Main.shimmerAlpha, 1f, 0.025f);
			if (Main.shimmerAlpha >= 0.5f)
			{
				MoveTowards(ref Main.shimmerDarken, 1f, 0.025f);
				_shimmerBrightenDelay = 4f;
			}
			return;
		}
		MoveTowards(ref Main.shimmerDarken, 0f, 0.05f);
		if (Main.shimmerDarken == 0f)
		{
			MoveTowards(ref _shimmerBrightenDelay, 0f, 1f);
		}
		if (_shimmerBrightenDelay == 0f)
		{
			MoveTowards(ref Main.shimmerAlpha, 0f, 0.05f);
		}
	}

	private void ManageSpecialBiomeVisuals(string biomeName, bool inZone, Vector2 activationSource = default(Vector2), bool alwaysInstant = false)
	{
		if (SkyManager.Instance[biomeName] != null && inZone != SkyManager.Instance[biomeName].IsActive())
		{
			if (inZone)
			{
				SkyManager.Instance.Activate(biomeName, activationSource);
			}
			else
			{
				SkyManager.Instance.Deactivate(biomeName);
			}
		}
		Filter filter = Filters.Scene[biomeName];
		Overlay overlay = Overlays.Scene[biomeName];
		if (filter != null)
		{
			if (inZone != Filters.Scene[biomeName].IsActive())
			{
				if (inZone)
				{
					Filters.Scene.Activate(biomeName, activationSource);
				}
				else
				{
					filter.Deactivate();
				}
			}
			else if (inZone)
			{
				filter.GetShader().UseTargetPosition(activationSource);
			}
		}
		if (overlay != null && inZone != (Overlays.Scene[biomeName].Mode != OverlayMode.Inactive))
		{
			if (inZone)
			{
				Overlays.Scene.Activate(biomeName, activationSource);
			}
			else
			{
				overlay.Deactivate();
			}
		}
		if (alwaysInstant || skipTransitions)
		{
			if (filter != null)
			{
				filter.Opacity = (inZone ? 1f : 0f);
			}
			if (overlay != null)
			{
				overlay.Opacity = (inZone ? 1f : 0f);
			}
		}
	}

	private void UpdateGraveyard(SceneMetrics metrics)
	{
		float lerpValue = Utils.GetLerpValue(SceneMetrics.GraveyardTileMin, SceneMetrics.GraveyardTileMax, metrics.GraveyardTileCount, clamped: true);
		MoveTowards(ref Main.GraveyardVisualIntensity, lerpValue, 0.02f, 0.1f);
	}

	private void UpdateRGBPeriheralProbe(SceneMetrics metrics)
	{
		int highestTierBossOrEvent = 0;
		bool zoneOverworldHeight = metrics.ZoneOverworldHeight;
		if (metrics.AnyNPCs(4))
		{
			highestTierBossOrEvent = 4;
		}
		if (metrics.AnyNPCs(50))
		{
			highestTierBossOrEvent = 50;
		}
		if (zoneOverworldHeight && Main.invasionType == 1)
		{
			highestTierBossOrEvent = -1;
		}
		if (metrics.AnyNPCs(13))
		{
			highestTierBossOrEvent = 13;
		}
		if (metrics.AnyNPCs(266))
		{
			highestTierBossOrEvent = 266;
		}
		if (metrics.AnyNPCs(222))
		{
			highestTierBossOrEvent = 222;
		}
		if (metrics.AnyNPCs(35))
		{
			highestTierBossOrEvent = 35;
		}
		if (metrics.AnyNPCs(113))
		{
			highestTierBossOrEvent = 113;
		}
		if (zoneOverworldHeight && Main.invasionType == 2)
		{
			highestTierBossOrEvent = -2;
		}
		if (metrics.AnyNPCs(657))
		{
			highestTierBossOrEvent = 657;
		}
		if (metrics.AnyNPCs(126) || metrics.AnyNPCs(125))
		{
			highestTierBossOrEvent = 126;
		}
		if (metrics.AnyNPCs(134))
		{
			highestTierBossOrEvent = 134;
		}
		if (metrics.AnyNPCs(127))
		{
			highestTierBossOrEvent = 127;
		}
		if (zoneOverworldHeight && Main.invasionType == 3)
		{
			highestTierBossOrEvent = -3;
		}
		if (metrics.AnyNPCs(262))
		{
			highestTierBossOrEvent = 262;
		}
		if (metrics.AnyNPCs(245))
		{
			highestTierBossOrEvent = 245;
		}
		if (metrics.AnyNPCs(636))
		{
			highestTierBossOrEvent = 636;
		}
		if (metrics.AnyNPCs(668) && NPC.IsDeerclopsHostile())
		{
			highestTierBossOrEvent = 668;
		}
		if (DD2Event.Ongoing)
		{
			highestTierBossOrEvent = -6;
		}
		if (zoneOverworldHeight && Main.invasionType == 4)
		{
			highestTierBossOrEvent = -4;
		}
		if (metrics.AnyNPCs(439))
		{
			highestTierBossOrEvent = 439;
		}
		if (metrics.AnyNPCs(370))
		{
			highestTierBossOrEvent = 370;
		}
		if (metrics.AnyNPCs(398))
		{
			highestTierBossOrEvent = 398;
		}
		CommonConditions.Boss.HighestTierBossOrEvent = highestTierBossOrEvent;
	}

	public void MoveTowards(ref float value, float target, float amount)
	{
		MoveTowards(ref value, target, amount, amount);
	}

	public void MoveTowards(ref float value, float target, float inc, float dec)
	{
		if (skipTransitions)
		{
			value = target;
		}
		else if (value < target)
		{
			value = Math.Min(value + inc, target);
		}
		else if (value > target)
		{
			value = Math.Max(value - dec, target);
		}
	}
}
