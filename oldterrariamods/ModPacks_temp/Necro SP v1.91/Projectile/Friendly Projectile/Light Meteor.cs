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
	if (Main.rand.Next(6) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Light Meteor", 1, false, 0);
	}
	for (int l = 0; l < 10; l++)
	{
		Color newColor = default(Color);
		Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, newColor, 1.2f);
	}
	for (int m = 0; m < 3; m++)
	{
		Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
	}
	if (projectile.owner == Main.myPlayer)
	{
		float x = projectile.position.X + (float)Main.rand.Next(-400, 400);
		float y = projectile.position.Y - (float)Main.rand.Next(600, 900);
		Vector2 vector = new Vector2(x, y);
		float num5 = projectile.position.X + (float)(projectile.width / 2) - vector.X;
		float num6 = projectile.position.Y + (float)(projectile.height / 2) - vector.Y;
		int num7 = 22;
		float num8 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
		num8 = (float)num7 / num8;
		num5 *= num8;
		num6 *= num8;
		int num9 = projectile.damage;
		num9 = (int)((float)num9 * 0.5f);
		int num10 = Projectile.NewProjectile(x, y, num5, num6, 92, num9, projectile.knockBack, projectile.owner);
		Main.projectile[num10].ai[1] = projectile.position.Y;
		Main.projectile[num10].ai[0] = 1f;
	}
	projectile.active = false;
}

public static void DealtNPC(NPC npc, double damage, Player player)
{
	float x = npc.position.X + (float)Main.rand.Next(-400, 400);
	float y = npc.position.Y - (float)Main.rand.Next(600, 900);
	Vector2 vector = new Vector2(x, y);
	float num5 = npc.position.X + (float)(npc.width / 2) - vector.X;
	float num6 = npc.position.Y + (float)(npc.height / 2) - vector.Y;
	int num7 = 22;
	float num8 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
	num8 = (float)num7 / num8;
	num5 *= num8;
	num6 *= num8;
	int num9 = 12;
	num9 = (int)((float)num9 * 0.5f);
	int num10 = Projectile.NewProjectile(x, y, num5, num6, 92, num9, 0f, player.whoAmi);
	Main.projectile[num10].ai[1] = npc.position.Y;
	Main.projectile[num10].ai[0] = 1f;
}

public static void DealtPVP(double damage, Player enemyPlayer) 
{
	float x = enemyPlayer.position.X + (float)Main.rand.Next(-400, 400);
	float y = enemyPlayer.position.Y - (float)Main.rand.Next(600, 900);
	Vector2 vector = new Vector2(x, y);
	float num5 = enemyPlayer.position.X + (float)(enemyPlayer.width / 2) - vector.X;
	float num6 = enemyPlayer.position.Y + (float)(enemyPlayer.height / 2) - vector.Y;
	int num7 = 22;
	float num8 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
	num8 = (float)num7 / num8;
	num5 *= num8;
	num6 *= num8;
	int num9 = 12;
	num9 = (int)((float)num9 * 0.5f);
	int num10 = Projectile.NewProjectile(x, y, num5, num6, 92, num9, 0f, Main.myPlayer);
	Main.projectile[num10].ai[1] = enemyPlayer.position.Y;
	Main.projectile[num10].ai[0] = 1f;
}