public void AI()
{

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{
Main.player[Main.myPlayer].AddBuff(23, 120, false); //cursed
Main.player[Main.myPlayer].AddBuff(20, 300, false); //poisoned

}


    projectile.frameCounter++;
    if (projectile.frameCounter > 2)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 4)
	{
        projectile.frame = 2;
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
			if (projectile.type == 7 && Main.myPlayer == projectile.owner)
			{
				int num14 = projectile.type;
				if (projectile.ai[1] >= 6f)
				{
					num14++;
				}
				int num15 = Projectile.NewProjectile(projectile.position.X + projectile.velocity.X + (float)(projectile.width / 2), projectile.position.Y + projectile.velocity.Y + (float)(projectile.height / 2), projectile.velocity.X, projectile.velocity.Y, num14, projectile.damage, projectile.knockBack, projectile.owner);
				Main.projectile[num15].damage = projectile.damage;
				Main.projectile[num15].ai[1] = projectile.ai[1] + 1f;
				NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
				return;
			}
		}
	}
	else
	{
		projectile.alpha += 15;
		if (projectile.alpha >= 255)
		{
			projectile.Kill();
			return;
		}
	}
}

