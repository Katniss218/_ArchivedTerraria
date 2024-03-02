public void AI()
{
	projectile.rotation++;
	
	if (projectile.velocity.X <= 6 && projectile.velocity.Y <= 6 && projectile.velocity.X >= -6 && projectile.velocity.Y >= -6)
	{
	projectile.velocity.X *= .50f;
	projectile.velocity.Y *= .50f;
	}
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 140, color, 1f);
    Main.dust[dust].noGravity = true;
}