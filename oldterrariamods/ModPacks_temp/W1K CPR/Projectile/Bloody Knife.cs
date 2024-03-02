public void AI()
{
	projectile.rotation += 0.1f;
	if (Main.rand.Next(4)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 5, 0, 0, 50, Color.White, 1.0f);
	Main.dust[dust].noGravity = false;
	}
	Lighting.addLight((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 0.4f, 0.1f, 0.1f);

	if (projectile.velocity.X <= 4 && projectile.velocity.Y <= 4 && projectile.velocity.X >= -4 && projectile.velocity.Y >= -4)
	{
	float accel = 1f+(Main.rand.Next(10,30)*0.001f);
	projectile.velocity.X *= accel;
	projectile.velocity.Y *= accel;
	}
}