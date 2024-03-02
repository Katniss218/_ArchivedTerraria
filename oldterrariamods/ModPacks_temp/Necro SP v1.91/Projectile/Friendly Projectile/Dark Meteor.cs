public void AI()
{
	if (projectile.light > 0f)
	{
		Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.light * 0.1f, projectile.light * 0.5f, projectile.light);
	}
	if (Main.rand.Next(5) == 0)
	{
		Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 14, 0f, 0f, 150, default(Color), 1.1f);
	}
	projectile.AI(true);
}

public void Kill()
{
	if (Main.rand.Next(4) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Dark Meteor", 1, false, 0);
	}
	for (int num28 = 0; num28 < 10; num28++)
	{
		Color newColor = default(Color);
		Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 14, 0f, 0f, 150, newColor, 1.1f);
	}
	projectile.active = false;
}