public void AI()
{
	if (projectile.light > 0f)
	{
		Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.light * 0.35f, projectile.light * 1f, projectile.light * 0f);
	}
	if (Main.rand.Next(20) == 0)
	{
		Color newColor = default(Color);
		Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 40, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, newColor, 0.75f);
		return;
	}
	projectile.AI(true);
}

public void Kill()
{
	if (Main.rand.Next(2) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Poisoned Meteor", 1, false, 0);
	}
	for (int num27 = 0; num27 < 10; num27++)
	{
		Color newColor = default(Color);
		Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, newColor, 0.75f);
	}
	projectile.active = false;
}

public static void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(2) == 0)
	{
		npc.AddBuff(20, 600, false);
	}
}

public static void DealtPVP(double damage, Player enemyPlayer) 
{
	if (Main.rand.Next(2) == 0)
	{
		enemyPlayer.AddBuff(20, 600, false);
	}
}