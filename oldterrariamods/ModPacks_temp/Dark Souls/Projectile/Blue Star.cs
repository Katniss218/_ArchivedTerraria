public void AI()
{
	projectile.rotation++;
	
	Lighting.addLight((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 0.4f, 0.1f, 0.1f);
}