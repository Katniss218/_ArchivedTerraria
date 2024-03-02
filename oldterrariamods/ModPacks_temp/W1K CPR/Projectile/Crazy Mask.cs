public void AI()
{
	projectile.rotation += 0.3f;
	
	if (Main.player[(int)projectile.ai[0]].position.X < projectile.position.X)
	{
	if (projectile.velocity.X > -6) projectile.velocity.X -= 0.05f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.X > projectile.position.X)
	{
	if (projectile.velocity.X < 6) projectile.velocity.X += 0.05f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.Y < projectile.position.Y)
	{
	if (projectile.velocity.Y > -6) projectile.velocity.Y -= 0.05f;
	}

	if (Main.player[(int)projectile.ai[0]].position.Y > projectile.position.Y)
	{
	if (projectile.velocity.Y < 6) projectile.velocity.Y += 0.05f;
	}
	

	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}

}