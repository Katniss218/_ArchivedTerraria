public void AI()
{
	Projectile P = projectile;
	P.ai[0]++;
	float x = P.Center.X;
	float y = P.Center.Y;
	Vector2[] pos = new Vector2[8]
	{
		new Vector2(x + (float)Main.rand.Next(12, 21), y - (float)Main.rand.Next(12, 21)), new Vector2(x + (float)Main.rand.Next(-4, 5), y - (float)Main.rand.Next(12, 21)),
		new Vector2(x - (float)Main.rand.Next(12, 21), y - (float)Main.rand.Next(12, 21)), new Vector2(x + (float)Main.rand.Next(12, 21), y + (float)Main.rand.Next(-4, 5)),
		new Vector2(x - (float)Main.rand.Next(12, 21), y + (float)Main.rand.Next(-4, 5)), new Vector2(x + (float)Main.rand.Next(12, 21), y + (float)Main.rand.Next(12, 21)),
		new Vector2(x + (float)Main.rand.Next(-4, 5), y + (float)Main.rand.Next(12, 21)), new Vector2(x - (float)Main.rand.Next(12, 21), y + (float)Main.rand.Next(12, 21))
	};
	for (int i = 0; i < 8; i++)
	{
		int D = Dust.NewDust(pos[i], P.width, P.height, 36, 0f, 0f, 100, new Color(), 1f);
		Main.dust[D].noGravity = true;
	}
	Rectangle proj = ModGeneric.NewRect(P);
	foreach (NPC N in Main.npc)
	{
		Rectangle npc = ModGeneric.NewRect(N);
		if (proj.Intersects(npc)) N.AddBuff(31, 90);
	}
	if (P.ai[0] >= 300)
	{
		for (int i = 0; i < 4; i++)
		{
			float vX = P.velocity.X + (float)Main.rand.Next(-80, 81) * 0.05f;
			float vY = P.velocity.Y + (float)Main.rand.Next(-80, 81) * 0.05f;
			int a = Projectile.NewProjectile(P.position.X, P.position.Y, vX, vY, Config.projectileID["Smogscreen 2"], P.damage, P.knockBack, P.owner);
		}
		P.ai[0] = 0;
	}
}
public bool tileCollide(Vector2 CollideVel)
{
	Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
	projectile.ai[0] += 1f;
	if (projectile.ai[0] >= 4f)
	{
		projectile.position += projectile.velocity;
		projectile.Kill();
	}
	else
	{
		if (projectile.type == Config.projDefs.byName["Smogscreen"].type && projectile.velocity.Y > 4f)
		{
			if (projectile.velocity.Y != CollideVel.Y)
			{
				projectile.velocity.Y = -CollideVel.Y * 0.8f;
			}
		}
		else
		{
			if (projectile.velocity.Y != CollideVel.Y)
			{
				projectile.velocity.Y = -CollideVel.Y;
			}
		}
		if (projectile.velocity.X != CollideVel.X)
		{
			projectile.velocity.X = -CollideVel.X;
		}
	}
	return false;
}