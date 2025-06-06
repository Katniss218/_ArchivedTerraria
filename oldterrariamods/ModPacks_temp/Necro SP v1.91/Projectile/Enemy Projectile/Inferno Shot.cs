public void AI()
{
	projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 3)
	{
        projectile.frame = 0;
		return;
	}

	projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + (float) Math.PI;

	if (Main.rand.Next(3)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}

	if (projectile.velocity.Y < 8) projectile.velocity.Y += 0.1f;
}