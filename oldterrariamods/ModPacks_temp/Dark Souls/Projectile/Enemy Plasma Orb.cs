public void AI()
{
	projectile.rotation++;

	if (Main.rand.Next(2)==0)
	{

Lighting.addLight((int)projectile.position.X / 16, (int)projectile.position.Y / 16, 15f, 0f, 0.1f);
    return;

	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 27, 0, 0, 100, Color.Green, 1.0f);
	Main.dust[dust].noGravity = true;
int pdust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 18, 0, 0, 100, Color.Green, 1.0f);
	Main.dust[pdust].noGravity = true;
	}

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

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{

Main.player[Main.myPlayer].AddBuff(33, 1200, false);
Main.player[Main.myPlayer].AddBuff(32, 1200, false);
}

}