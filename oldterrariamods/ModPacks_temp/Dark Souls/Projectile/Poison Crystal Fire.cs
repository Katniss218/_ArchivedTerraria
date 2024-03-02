public void AI()
{
	projectile.rotation++;
	

	if (projectile.velocity.X <= 5 && projectile.velocity.Y <= 5 && projectile.velocity.X >= -5 && projectile.velocity.Y >= -5)
	{
	projectile.velocity.X *= 1.00f;
	projectile.velocity.Y *= 1.00f;
	}


int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, Color.Red, 2.0f);
	Main.dust[dust].noGravity = false;


Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{
Main.player[Main.myPlayer].AddBuff(22, 18000, false); //darkness
Main.player[Main.myPlayer].AddBuff(30, 1800, false); //bleeding
Main.player[Main.myPlayer].AddBuff(24, 1600, false); //on fire
Main.player[Main.myPlayer].AddBuff(21, 600, false); //potion sickness
}




}