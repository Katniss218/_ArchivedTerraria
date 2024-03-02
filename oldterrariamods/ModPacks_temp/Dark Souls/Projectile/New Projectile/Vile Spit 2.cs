public void AI()
{
	for (int num168 = 0; num168 < 2; num168++)
	{
		int num171 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 18, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 80, default(Color), 1.3f);
		Main.dust[num171].velocity *= 0.3f;
		Main.dust[num171].noGravity = true;
	}
	Rectangle thisProj = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
	foreach (Player P in Main.player)
	{
		Rectangle weapon = new Rectangle((int)P.itemLocation.X, (int)P.itemLocation.Y, P.inventory[P.selectedItem].width, P.inventory[P.selectedItem].height);
		if (weapon.Intersects(thisProj)) projectile.Kill();
	}
	/*foreach (Projectile Pr in Main.projectile)
	{
		if (Pr.type != Config.projDefs.byName["Vile Spit 2"].type && Pr.active && projectile.active)
		{
			Rectangle killingProj = new Rectangle((int)Pr.position.X, (int)Pr.position.Y, Pr.width, Pr.height);
			if (thisProj.Intersects(killingProj)) projectile.Kill();
		}
	}*/
	projectile.AI(true);
}
public bool tileCollide(Vector2 CollideVel)
{
		if (Main.netMode != 1)
		{
			int num163 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
			int num164 = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;
			int num165 = 8;
			for (int num166 = num163 - num165; num166 <= num163 + num165; num166++)
			{
				for (int num167 = num164 - num165; num167 < num164 + num165; num167++)
				{
					if ((double)(Math.Abs(num166 - num163) + Math.Abs(num167 - num164)) < (double)num165 * 0.5)
					{
						if (Main.tile[num166, num167].type == 2)
						{
							Main.tile[num166, num167].type = 23;
							WorldGen.SquareTileFrame(num166, num167, true);
							if (Main.netMode == 2)
							{
								NetMessage.SendTileSquare(-1, num166, num167, 1);
							}
						}
						else
						{
							if (Main.tile[num166, num167].type == 1)
							{
								Main.tile[num166, num167].type = 25;
								WorldGen.SquareTileFrame(num166, num167, true);
								if (Main.netMode == 2)
								{
									NetMessage.SendTileSquare(-1, num166, num167, 1);
								}
							}
							else
							{
								if (Main.tile[num166, num167].type == 53)
								{
									Main.tile[num166, num167].type = 112;
									WorldGen.SquareTileFrame(num166, num167, true);
									if (Main.netMode == 2)
									{
										NetMessage.SendTileSquare(-1, num166, num167, 1);
									}
								}
								else
								{
									if (Main.tile[num166, num167].type == 109)
									{
										Main.tile[num166, num167].type = 23;
										WorldGen.SquareTileFrame(num166, num167, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendTileSquare(-1, num166, num167, 1);
										}
									}
									else
									{
										if (Main.tile[num166, num167].type == 117)
										{
											Main.tile[num166, num167].type = 25;
											WorldGen.SquareTileFrame(num166, num167, true);
											if (Main.netMode == 2)
											{
												NetMessage.SendTileSquare(-1, num166, num167, 1);
											}
										}
										else
										{
											if (Main.tile[num166, num167].type == 116)
											{
												Main.tile[num166, num167].type = 112;
												WorldGen.SquareTileFrame(num166, num167, true);
												if (Main.netMode == 2)
												{
													NetMessage.SendTileSquare(-1, num166, num167, 1);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	projectile.active = false;
	return false;
}

public void Kill()
{
	Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 9);
	projectile.active = false;
}