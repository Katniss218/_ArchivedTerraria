public void AI()
{
	Color C = new Color();
	int D = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 10, 0, 0, 100, C, 2.0f);
	Main.dust[D].noGravity = true;
}