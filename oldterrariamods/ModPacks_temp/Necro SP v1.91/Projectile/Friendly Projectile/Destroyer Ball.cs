public void AI()
{
	projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
	Lighting.addLight((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 2f, 0.4f, 4f);
}