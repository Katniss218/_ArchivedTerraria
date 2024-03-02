public void AI()
{

	projectile.AI(true);
	//projectile.rotation += 3f;
	

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{
Main.player[Main.myPlayer].AddBuff("Powerful Curse Buildup", 36000, false);
Main.player[Main.myPlayer].AddBuff(24, 300, false); //on fire!
Main.player[Main.myPlayer].AddBuff(30, 3600, false); //bleeding
Main.player[Main.myPlayer].AddBuff(33, 3600, false); //week
}



}