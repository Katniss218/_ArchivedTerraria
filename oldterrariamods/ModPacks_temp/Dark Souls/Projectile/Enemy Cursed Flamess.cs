public void AI()
{
	projectile.rotation += 3f;
	
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 75, 0, 0, 50, Color.Chartreuse, 3.0f);
	Main.dust[dust].noGravity = true;
	
	

	if (projectile.velocity.X <= 4 && projectile.velocity.Y <= 4 && projectile.velocity.X >= -4 && projectile.velocity.Y >= -4)
	{
	float accel = 2f+(Main.rand.Next(10,30)*0.001f);
	projectile.velocity.X *= accel;
	projectile.velocity.Y *= accel;
	}

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{
Main.player[Main.myPlayer].AddBuff(32, 180, false);
Main.player[Main.myPlayer].AddBuff(36, 180, false);
Main.player[Main.myPlayer].AddBuff(30, 1800, false);
Main.player[Main.myPlayer].AddBuff(13, 7600, false);
}

}