public void AI()
{
	projectile.rotation += 0.3f;
	
	if (Main.player[(int)projectile.ai[0]].position.X < projectile.position.X)
	{
	if (projectile.velocity.X > -10) projectile.velocity.X -= 0.1f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.X > projectile.position.X)
	{
	if (projectile.velocity.X < 10) projectile.velocity.X += 0.1f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.Y < projectile.position.Y)
	{
	if (projectile.velocity.Y > -10) projectile.velocity.Y -= 0.1f;
	}

	if (Main.player[(int)projectile.ai[0]].position.Y > projectile.position.Y)
	{
	if (projectile.velocity.Y < 10) projectile.velocity.Y += 0.1f;
	}
	
	if (Main.rand.Next(4)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 5, 0, 0, 50, Color.White, 1.0f);
	Main.dust[dust].noGravity = false;
	}
	Lighting.addLight((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 0.7f, 0.2f, 0.2f);
}