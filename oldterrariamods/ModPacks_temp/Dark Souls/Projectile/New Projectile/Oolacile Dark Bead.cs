public void AI()
{
	projectile.rotation += 4f;
	if (Main.rand.Next(2)==0) // 
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 27, 0, 0, 50, Color.Purple, 2.0f);
	Main.dust[dust].noGravity = false;
	}
	Lighting.addLight((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 0.4f, 0.1f, 0.1f);

	if (projectile.velocity.X <= 4 && projectile.velocity.Y <= 4 && projectile.velocity.X >= -4 && projectile.velocity.Y >= -4)
	{
	float accel = 2f+(Main.rand.Next(10,30)*0.5f);
	projectile.velocity.X *= accel;
	projectile.velocity.Y *= accel;
	}
}