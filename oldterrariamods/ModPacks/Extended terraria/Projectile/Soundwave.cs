public bool PreDraw(SpriteBatch SB)
{
	SB.End();
	SB.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null);
	return true;
}
public void PostDraw(SpriteBatch SB)
{
	SB.End();
	SB.Begin();
}

public void AI()
{
	Projectile P = projectile;
	//P.scale = (float)(185.0819731f * (float)Math.Pow(0.9911148f, P.timeLeft));
	//if (P.scale > 11f) P.scale = 11f;
	P.scale = Math.Min(11f, (float)(185.0819731f * (float)Math.Pow(0.9911148f, P.timeLeft)));
	P.rotation = (float)Math.Atan2(P.velocity.Y, P.velocity.X);
	Vector2 pos = P.Center - new Vector2((P.width * P.scale) / 2f, (P.height * P.scale) / 2f);
	Vector2 wh = new Vector2(P.width * P.scale, P.height * P.scale);
	Rectangle R = ModGeneric.NewRectV2(pos, wh);
	foreach (NPC N in Main.npc)
	{
		if (!N.active || N.dontTakeDamage || N.friendly || N.life < 1) continue;
		Rectangle n = ModGeneric.NewRect(N);
		if (n.Intersects(R))
		{
			N.StrikeNPC(P.damage, P.knockBack, (N.Center.X < P.Center.X ? -1 : 1));
		}
	}
}