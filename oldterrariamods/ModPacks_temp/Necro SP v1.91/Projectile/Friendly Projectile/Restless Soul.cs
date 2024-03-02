public void AI()
{
	projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 5)
	{
        projectile.frame = 0;
		return;
	}

	if (Main.rand.Next(3)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}

	if (projectile.velocity.X <= 8 && projectile.velocity.Y <= 8 && projectile.velocity.X >= -8 && projectile.velocity.Y >= -8)
	{
	projectile.velocity.X *= 1.04f;
	projectile.velocity.Y *= 1.04f;
	}
}