public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 52, 0, 0, 100, color, 2.0f);
	Main.dust[dust].noGravity = true;

	if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
	{
	projectile.velocity.X *= 1.01f;
	projectile.velocity.Y *= 1.01f;
	}
}