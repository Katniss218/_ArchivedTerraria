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
	if (Main.rand.Next(2) == 0)
	{
		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Meteor", 1, false, 0);
	}
	for (int num27 = 0; num27 < 10; num27++)
	{
		Color newColor = default(Color);
		Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, newColor, 0.75f);
	}
	projectile.active = false;
}