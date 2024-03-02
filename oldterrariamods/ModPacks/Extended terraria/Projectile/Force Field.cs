public void AI()
{
	Projectile P = projectile;
	P.rotation++;
	//P.velocity = Main.player[P.owner].velocity;
	P.Center = Main.player[P.owner].Center;
}