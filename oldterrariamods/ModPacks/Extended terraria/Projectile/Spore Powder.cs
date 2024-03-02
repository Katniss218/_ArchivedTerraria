public void AI()
{
	projectile.velocity *= 0.95f;
	projectile.ai[0] += 1f;
	if (projectile.ai[0] == 180f)
	{
		projectile.Kill();
	}
	if (projectile.ai[1] == 0f)
	{
		projectile.ai[1] = 1f;
		for (int k = 0; k < 30; k++)
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 44, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1f);
		}
	}
}