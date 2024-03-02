public void AI()
{
	if (projectile.light > 0f)
	{
		Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.light * 0.35f, projectile.light * 1f, projectile.light * 0f);
	}
	int num10 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 75, 0f, 0f, 100, default(Color), 1f);
	if (Main.rand.Next(2) == 0)
	{
		Main.dust[num10].noGravity = true;
		Main.dust[num10].scale *= 2f;
	}
	projectile.AI(true);
}

public void Kill()
{
	if (Main.rand.Next(4) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Cursed Meteor", 1, false, 0);
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
	npc.AddBuff(39, 420, false);
}

public static void DealtPVP(double damage, Player enemyPlayer) 
{
	enemyPlayer.AddBuff(39, 420, true);
}