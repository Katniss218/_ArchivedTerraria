public void AI()
{
	projectile.rotation++;




if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
	{
	projectile.velocity.X *= 1.01f;
	projectile.velocity.Y *= 1.01f;
	}

	if (Main.rand.Next(2)==0)
	{

Lighting.addLight((int)projectile.position.X / 16, (int)projectile.position.Y / 16, 0f, 0.3f, 0.8f);
    return;

	}

projectile.frameCounter++;
                                if (projectile.frameCounter > 2)
                                {
                                    projectile.frame++;
                                    projectile.frameCounter = 0;
                                }
                                if (projectile.frame >= 4)
                                {
                                    projectile.frame = 0;
                                }

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{

Main.player[Main.myPlayer].AddBuff(35, 300, false);
Main.player[Main.myPlayer].AddBuff(36, 300, false);
}



}