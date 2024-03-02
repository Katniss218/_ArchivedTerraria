public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 2)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 3)
	{
        projectile.frame = 0;
		return;
	}
	if (projectile.ai[0] == 0f)
	{
		projectile.alpha -= 50;
		if (projectile.alpha <= 0)
		{
			projectile.alpha = 0;
			projectile.ai[0] = 1f;
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] += 1f;
				projectile.position += projectile.velocity * 1f;
			}
		}
	}

    Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
    Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

    if (projrec.Intersects(prec))
    {
    Main.player[Main.myPlayer].AddBuff(30, 800, false); //bleeding
    }
}
