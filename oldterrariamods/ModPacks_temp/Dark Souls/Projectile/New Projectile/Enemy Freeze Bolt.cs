public void AI()
{
projectile.rotation += 4f;

projectile.AI(true);




Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{

Main.player[Main.myPlayer].AddBuff("Frozen", 30, false);
Main.player[Main.myPlayer].AddBuff(32, 600, false);
}


int num40 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y, 250, default(Color), 1f);


}


						











//public void StatusPlayer(int i)
//{
//	if (Main.rand.Next(5) == 0)
//	{
//		Main.player[i].AddBuff("Freeze", 120, false);
//	}
//}

