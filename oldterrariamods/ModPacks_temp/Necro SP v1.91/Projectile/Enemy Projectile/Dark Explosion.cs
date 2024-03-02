public void AI()
{
	//if (projectile.frame < 5)
	projectile.frameCounter++;
	
    if (projectile.frameCounter == 30)
    {
        projectile.frame = 1;
		projectile.alpha = 200;
    }
	
	if (projectile.frameCounter == 60)
    {
        projectile.frame = 2;
		projectile.alpha = 175;
    }
	
	if (projectile.frameCounter == 90)
    {
        projectile.frame = 3;
		projectile.alpha = 150;
    }
	if (projectile.frameCounter == 120)
    {
        projectile.frame = 4;
		projectile.alpha = 125;
    }
	if (projectile.frameCounter == 180)
    {
        projectile.frame = 5;
		projectile.alpha = 50;
		projectile.hostile = true;
		for (int num36 = 0; num36 < 20; num36++)
		{
			int dustDeath = Dust.NewDust(projectile.position, projectile.width, projectile.height, 55, Config.syncedRand.Next(-6,6), Config.syncedRand.Next(-6,6), 200, Color.White, 2f);
			Main.dust[dustDeath].noGravity = true;
		}
    }
	if (projectile.frameCounter >= 182)
    {
		projectile.active = false;
	}
	
	projectile.rotation += 0.1f;

	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, projectile.alpha, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}

}