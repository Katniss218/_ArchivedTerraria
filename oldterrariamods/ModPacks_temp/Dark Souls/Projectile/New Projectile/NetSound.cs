public void AI()
{
    Main.PlaySound((int)projectile.velocity.X, 
		(int)Main.player[projectile.owner].position.X, 
		(int)Main.player[projectile.owner].position.Y, 
		(int)projectile.velocity.Y);
	projectile.Kill();
}