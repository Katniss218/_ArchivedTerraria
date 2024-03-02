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
	
	projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;

	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 8, 0, 0, 200, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}

}