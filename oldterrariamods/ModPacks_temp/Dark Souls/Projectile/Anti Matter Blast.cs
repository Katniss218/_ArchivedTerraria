
public void AI()
{
	projectile.rotation++;
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X+10, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 200, Color.Red, 1f);
	Main.dust[dust].noGravity = true;

if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
	{
	projectile.velocity.X *= 1.01f;
	projectile.velocity.Y *= 1.01f;
	}






Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{

Main.player[Main.myPlayer].AddBuff(31, 300, false);
Main.player[Main.myPlayer].AddBuff(18, 300, false);
Main.player[Main.myPlayer].AddBuff(32, 300, false);
}




}

