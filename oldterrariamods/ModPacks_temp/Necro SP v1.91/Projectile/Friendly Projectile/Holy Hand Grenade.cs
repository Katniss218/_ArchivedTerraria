public void Kill()
{
	if (!projectile.active)
	{
		return;
	}
	projectile.timeLeft = 0;
    {
		Main.PlaySound(30, (int)projectile.position.X, (int)projectile.position.Y, 10);
		for (int num40 = 0; num40 < 20; num40++)
		{
         Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2), 0, 0, Config.projectileID["Nuke Explosion"], 12, 8f, projectile.owner);
		}
	}
	if (projectile.owner == Main.myPlayer)
	{
		if (Main.netMode != 0)
		{
			NetMessage.SendData(29, -1, -1, "", projectile.identity, (float)projectile.owner, 0f, 0f, 0);
		}
		int num98 = -1;
		if (projectile.aiStyle == 10)
		{
			int num99 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
			int num100 = (int)(projectile.position.Y + (float)(projectile.width / 2)) / 16;
			int num101 = 0;
			int num102 = 2;
			if (!Main.tile[num99, num100].active)
			{
				WorldGen.PlaceTile(num99, num100, num101, false, true, -1, 0);
				if (Main.tile[num99, num100].active && (int)Main.tile[num99, num100].type == num101)
				{
					NetMessage.SendData(17, -1, -1, "", 1, (float)num99, (float)num100, (float)num101, 0);
				}
				else
				{
					if (num102 > 0)
					{
						num98 = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, num102, 1, false, 0);
					}
				}
			}
			else
			{
				if (num102 > 0)
				{
					num98 = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, num102, 1, false, 0);
				}
			}
		}
		if (Main.netMode == 1 && num98 >= 0)
		{
			NetMessage.SendData(21, -1, -1, "", num98, 0f, 0f, 0f, 0);
		}
	}
	projectile.active = false;
}

