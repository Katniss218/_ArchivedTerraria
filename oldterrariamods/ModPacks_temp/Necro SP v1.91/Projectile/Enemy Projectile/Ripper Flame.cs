public void AI()
{
	if (projectile.frame < 5)
	{
	projectile.frameCounter++;
    if (projectile.frameCounter > 7)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
	}
	
	projectile.rotation += 0.3f;

	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}

}