public void AI()
{
	projectile.rotation += 0.1f;

	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}


	if (projectile.velocity.X <= 4 && projectile.velocity.Y <= 4 && projectile.velocity.X >= -4 && projectile.velocity.Y >= -4)
	{
	float accel = 1f+(Main.rand.Next(10,30)*0.001f);
	projectile.velocity.X *= accel;
	projectile.velocity.Y *= accel;
	}
}