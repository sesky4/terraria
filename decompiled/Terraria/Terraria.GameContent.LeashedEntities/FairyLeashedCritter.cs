using Microsoft.Xna.Framework;

namespace Terraria.GameContent.LeashedEntities;

public class FairyLeashedCritter : FlyerLeashedCritter
{
	public new static FairyLeashedCritter Prototype = new FairyLeashedCritter();

	public FairyLeashedCritter()
	{
		minWaitTime = 30;
		maxWaitTime = 90;
		maxFlySpeed = 1.1f;
		acceleration = 0.05f;
		rotationScalar = 0.25f;
		brakeDuration = 30;
	}

	protected override void VisualEffects()
	{
		base.VisualEffects();
		Color a = Color.HotPink;
		Color b = Color.LightPink;
		int num = 4;
		if (npcType == 584)
		{
			a = Color.LimeGreen;
			b = Color.LightSeaGreen;
		}
		if (npcType == 585)
		{
			a = Color.RoyalBlue;
			b = Color.LightBlue;
		}
		if ((int)Main.timeForVisualEffects % 4 == 0 && Main.rand.Next(4) != 0)
		{
			position += netOffset;
			Dust dust = Dust.NewDustDirect(base.Center - new Vector2(4f) + Main.rand.NextVector2Circular(2f, 2f), num, num, 278, 0f, 0f, 200, Color.Lerp(a, b, Main.rand.NextFloat()), 0.65f);
			dust.velocity *= 0f;
			dust.velocity += velocity * 0.3f;
			dust.noGravity = true;
			dust.noLight = true;
			position -= netOffset;
		}
		Lighting.AddLight(base.Center, a.ToVector3() * 0.7f);
	}
}
