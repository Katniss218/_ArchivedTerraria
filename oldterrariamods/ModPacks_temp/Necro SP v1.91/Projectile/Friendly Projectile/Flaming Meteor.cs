public void AI()
{
	if (Main.rand.Next(2) == 0)
	{
		int num3 = Main.rand.Next(2);
		if (num3 == 0)
		{
				num3 = 15;
		}
		else
		{
			num3 = 58;
		}
		Color newColor = default(Color);
		int num4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, num3, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, newColor, 0.9f);
		Dust expr_367 = Main.dust[num4];
		expr_367.velocity *= 0.25f;
	}
	projectile.AI(true);
}

public void Kill()
{
	if (Main.rand.Next(4) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Flaming Meteor", 1, false, 0);
	}
	for (int num28 = 0; num28 < 10; num28++)
	{
		Color newColor = default(Color);
		Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 14, 0f, 0f, 150, newColor, 1.1f);
	}
	projectile.active = false;
}

public static void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff(24, 300, false);
	}
}

public static void DealtPVP(double damage, Player enemyPlayer) 
{
	if (Main.rand.Next(3) == 0)
	{
		enemyPlayer.AddBuff(24, 300, true);
	}
}