public void AI()
{	
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 200, color, 3f);
    Main.dust[dust].noGravity = true;
	projectile.rotation += 0.1f;
    Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 1f, 1f, 1f);
}