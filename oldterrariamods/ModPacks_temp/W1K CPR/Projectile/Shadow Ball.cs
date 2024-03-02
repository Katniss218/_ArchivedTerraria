public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 52, 0, 0, 100, color, 3.0f);
	Main.dust[dust].noGravity = true;
}