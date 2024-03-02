public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 80, color, 1.5f);
	Main.dust[dust].noGravity = true;
	projectile.AI(true);
}