public void AI()
{
	projectile.rotation++;

	if (projectile.velocity.X <= 6 && projectile.velocity.Y <= 6 && projectile.velocity.X >= -6 && projectile.velocity.Y >= -6)
	{
	projectile.velocity.X *= 1.05f;
	projectile.velocity.Y *= 1.05f;
	}
}