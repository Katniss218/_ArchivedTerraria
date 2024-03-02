







public void AI()
{
	projectile.rotation += 0.5f;
	
	if (Main.player[(int)projectile.ai[0]].position.X < projectile.position.X)
	{
	if (projectile.velocity.X > -10) projectile.velocity.X -= 0.1f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.X > projectile.position.X)
	{
	if (projectile.velocity.X < 10) projectile.velocity.X += 0.1f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.Y < projectile.position.Y)
	{
	if (projectile.velocity.Y > -10) projectile.velocity.Y -= 0.1f;
	}

	if (Main.player[(int)projectile.ai[0]].position.Y > projectile.position.Y)
	{
	if (projectile.velocity.Y < 10) projectile.velocity.Y += 0.1f;
	}
	
	if (Main.rand.Next(4)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X+10, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 200, Color.Red, 1f);
	Main.dust[dust].noGravity = true;
	}
	Lighting.addLight((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 0.7f, 0.2f, 0.2f);




Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{





Main.player[Main.myPlayer].AddBuff(31, 180, false);
Main.player[Main.myPlayer].AddBuff(18, 180, false);
Main.player[Main.myPlayer].AddBuff(23, 180, false);
}



}