public void AI()
{
    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
	//Color color = new Color();
	//int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 20, color, 1.0f);
	//Main.dust[dust].noGravity = true;
	float red  = 1.0f;
	float green  = 0.0f;
	float blue  = 1.0f;

	Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), red, green, blue);
}