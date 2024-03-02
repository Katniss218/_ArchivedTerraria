public void AI()
{
	projectile.rotation++;
	projectile.scale *= 1.002f;
	if (projectile.scale > 6f) projectile.scale = 6f;
	if (Main.rand.Next(2)==0)
	{
		int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 57, 0, 0, 100, Color.White, 3.0f);
		Main.dust[dust].noGravity = true;
		int dust2 = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, Color.White, 3.0f);
		Main.dust[dust2].noGravity = true;
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
	//projectile.AI(true);
}