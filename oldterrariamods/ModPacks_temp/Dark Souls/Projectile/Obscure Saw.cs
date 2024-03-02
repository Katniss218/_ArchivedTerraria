public void AI()
{
	projectile.rotation++;
	
	

	if (projectile.velocity.X <= 6 && projectile.velocity.Y <= 6 && projectile.velocity.X >= -6 && projectile.velocity.Y >= -6)
	{
	projectile.velocity.X *= 1.02f;
	projectile.velocity.Y *= 1.02f;
	}


projectile.frameCounter++;
                                if (projectile.frameCounter > 2)
                                {
                                    projectile.frame++;
                                    projectile.frameCounter = 3;
                                }
                                if (projectile.frame >= 4)
                                {
                                    projectile.frame = 0;
                                }



}