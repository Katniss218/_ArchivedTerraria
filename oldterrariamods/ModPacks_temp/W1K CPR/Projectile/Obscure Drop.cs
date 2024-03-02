public void AI()
{	
	if (projectile.velocity.Y < 0)
	{
	projectile.alpha = 200;
	if (Main.rand.Next(3)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 200, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}
	projectile.hostile = false;
	}
	else
	{
	projectile.alpha = 10;
	if (Main.rand.Next(3)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}
	projectile.hostile = true;
	}

	projectile.velocity.X *= 0.99f;
	if (projectile.velocity.Y < 8) projectile.velocity.Y += 0.1f;
}