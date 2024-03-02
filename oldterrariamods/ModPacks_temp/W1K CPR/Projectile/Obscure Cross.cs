public void AI()
{
	projectile.rotation += 0.5f;

	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
	}

}