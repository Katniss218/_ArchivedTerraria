public void AI()
{
	projectile.rotation++;

	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}

	if (projectile.velocity.X <= 6 && projectile.velocity.Y <= 6 && projectile.velocity.X >= -6 && projectile.velocity.Y >= -6)
	{
	projectile.velocity.X *= 1.02f;
	projectile.velocity.Y *= 1.02f;
	}
}