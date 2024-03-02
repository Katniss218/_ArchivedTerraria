public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X+20, (float) projectile.position.Y+17), projectile.width, projectile.height, 27, 0, 0, 100, color, 3.0f);
	Main.dust[dust].noGravity = true;

}