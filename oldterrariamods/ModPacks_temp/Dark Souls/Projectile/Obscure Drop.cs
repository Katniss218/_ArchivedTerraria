public void AI()
{
	if (projectile.velocity.Y < 0)
	{
	projectile.alpha = 50;
	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 200, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}
	}
	else
	{
	projectile.alpha = 10;
	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}
	}

	if (projectile.velocity.Y < 10) projectile.velocity.Y += 0.1f;
}