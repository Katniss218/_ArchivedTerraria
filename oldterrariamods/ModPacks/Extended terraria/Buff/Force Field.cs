public void Effects(Player P)
{
	Rectangle playerWS = new Rectangle((int)P.Center.X - 32, (int)P.Center.Y - 32, 64, 64);
	foreach (Projectile Pr in Main.projectile)
	{
		if (!Pr.friendly)
		{
			Rectangle proj2 = ModGeneric.NewRect(Pr);
			if (proj2.Intersects(playerWS))
			{
				for (int i = 0; i < 5; i++)
				{
					int dust = Dust.NewDust(Pr.position, Pr.width, Pr.height, 15, 0f, 0f, 100, new Color(), 1f);
					Main.dust[dust].noGravity = true;
				}
				Pr.hostile = false;
				Pr.friendly = true;
				Pr.velocity.X *= -1f;
				Pr.velocity.Y *= -1f;
			}
		}
	}
	foreach (NPC N in Main.npc)
	{
		if (!N.friendly && N.aiStyle == 9)
		{
			Rectangle npc = ModGeneric.NewRect(N);
			if (npc.Intersects(playerWS))
			{
				for (int i = 0; i < 5; i++)
				{
					int dust = Dust.NewDust(N.position, N.width, N.height, 15, 0f, 0f, 100, new Color(), 1f);
					Main.dust[dust].noGravity = true;
				}
				N.friendly = true;
				N.velocity.X *= -1f;
				N.velocity.Y *= -1f;
				int b = Projectile.NewProjectile(N.position.X, N.position.Y, N.velocity.X, N.velocity.Y, Config.projectileID["Invisibling"], N.damage, 1f, 255);
				Main.projectile[b].timeLeft = N.timeLeft;
			}
		}
	}
}