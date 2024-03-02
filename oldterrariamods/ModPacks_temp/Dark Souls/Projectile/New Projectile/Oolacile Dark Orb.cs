public void AI()
{



Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{
Main.player[Main.myPlayer].AddBuff(22, 18000, false);
Main.player[Main.myPlayer].AddBuff(20, 18000, false);
Main.player[Main.myPlayer].AddBuff(30, 18000, false);
Main.player[Main.myPlayer].AddBuff("Blood Moon", 3600, false);

}



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
	
	if (Main.rand.Next(2)==0)
	{
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 27, 0, 0, 50, Color.Purple, 1.0f);
	Main.dust[dust].noGravity = false;
	}
	Lighting.addLight((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 0.7f, 0.2f, 0.2f);

projectile.frameCounter++;
                                if (projectile.frameCounter > 2)
                                {
                                    projectile.frame++;
                                    projectile.frameCounter = 3;
                                }
                                if (projectile.frame >= 4)
                                {
                                    projectile.frame = 0;
                                }






}