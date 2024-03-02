float customAi1;
int chargeDamage = 0;
bool chargeDamageFlag = false;
int holdTimer = 0;

#region AI
#region Movement
public void AI() 
{
    int num3 = 60;
    bool flag2 = false;
	int num5 = 60;
	bool flag3 = true;
	if (npc.velocity.Y == 0f && (npc.velocity.X == 0f && npc.direction < 0))
    {
        npc.velocity.Y -= 8f;
        npc.velocity.X -= 2f; 
    }
    else if (npc.velocity.Y == 0f && (npc.velocity.X == 0f && npc.direction > 0))
    {
        npc.velocity.Y -= 8f;
        npc.velocity.X += 2f; 
    }
	if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
	{
		flag2 = true;
	}
	if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)num5 || flag2)
	{
		npc.ai[3] += 1f;
	}
	else
	{
		if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
		{
			npc.ai[3] -= 1f;
		}
	}
	if (npc.ai[3] > (float)(num5 * 10))
	{
		npc.ai[3] = 0f;
	}
	if (npc.justHit)
	{
		npc.ai[3] = 0f;
	}
	if (npc.ai[3] == (float)num5)
	{
		npc.netUpdate = true;
	}
	else
	{
		if (npc.velocity.X == 0f)
		{
			if (npc.velocity.Y == 0f)
			{
				npc.ai[0] += 1f;
				if (npc.ai[0] >= 2f)
				{
					npc.direction *= -1;
					npc.spriteDirection = npc.direction;
					npc.ai[0] = 0f;
				}
			}
		}
		else
		{
			npc.ai[0] = 0f;
		}
		if (npc.direction == 0)
		{
			npc.direction = 1;
		}
	}
	if (npc.velocity.X < -1.5f || npc.velocity.X > 1.5f)
	{
		if (npc.velocity.Y == 0f)
		{
			npc.velocity *= 0.8f;
		}
	}
	else
	{
		if (npc.velocity.X < 1.5f && npc.direction == 1)
		{
			npc.velocity.X = npc.velocity.X + 0.07f;
			if (npc.velocity.X > 1.5f)
			{
				npc.velocity.X = 1.5f;
			}
		}
		else
		{
			if (npc.velocity.X > -1.5f && npc.direction == -1)
			{
				npc.velocity.X = npc.velocity.X - 0.07f;
				if (npc.velocity.X < -1.5f)
				{
					npc.velocity.X = -1.5f;
				}
			}
		}
	}
	bool flag4 = false;
	if (npc.velocity.Y == 0f)
	{
		int num29 = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
		int num30 = (int)npc.position.X / 16;
		int num31 = (int)(npc.position.X + (float)npc.width) / 16;
		for (int l = num30; l <= num31; l++)
		{
			if (Main.tile[l, num29] == null)
			{
				return;
			}
			if (Main.tile[l, num29].active && Main.tileSolid[(int)Main.tile[l, num29].type])
			{
				flag4 = true;
				break;
			}
		}
	}
	if (flag4)
	{
		int num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)(15 * npc.direction)) / 16f);
		int num33 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
		if (npc.type == 109)
		{
			num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 16) * npc.direction)) / 16f);
		}
		if (Main.tile[num32, num33] == null)
		{
			Main.tile[num32, num33] = new Tile();
		}
		if (Main.tile[num32, num33 - 1] == null)
		{
			Main.tile[num32, num33 - 1] = new Tile();
		}
		if (Main.tile[num32, num33 - 2] == null)
		{
			Main.tile[num32, num33 - 2] = new Tile();
		}
		if (Main.tile[num32, num33 - 3] == null)
		{
			Main.tile[num32, num33 - 3] = new Tile();
		}
		if (Main.tile[num32, num33 + 1] == null)
		{
			Main.tile[num32, num33 + 1] = new Tile();
		}
		if (Main.tile[num32 + npc.direction, num33 - 1] == null)
		{
			Main.tile[num32 + npc.direction, num33 - 1] = new Tile();
		}
		if (Main.tile[num32 + npc.direction, num33 + 1] == null)
		{
			Main.tile[num32 + npc.direction, num33 + 1] = new Tile();
		}
		if (Main.tile[num32, num33 - 1].active && Main.tile[num32, num33 - 1].type == 10 && flag3)
		{
			npc.ai[2] += 1f;
			npc.ai[3] = 0f;
			if (npc.ai[2] >= 60f)
			{
				npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
				npc.ai[1] += 1f;
				npc.ai[2] = 0f;
				bool flag5 = false;
				if (npc.ai[1] >= 10f)
				{
					flag5 = true;
					npc.ai[1] = 10f;
				}
				WorldGen.KillTile(num32, num33 - 1, true, false, false);
				if ((Main.netMode != 1 || !flag5) && flag5 && Main.netMode != 1)
				{
					if (npc.type == 26)
					{
						WorldGen.KillTile(num32, num33 - 1, false, false, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num32, (float)(num33 - 1), 0f, 0);
						}
					}
					else
					{
						bool flag6 = WorldGen.OpenDoor(num32, num33, npc.direction);
						if (!flag6)
						{
							npc.ai[3] = (float)num5;
							npc.netUpdate = true;
						}
						if (Main.netMode == 2 && flag6)
						{
							NetMessage.SendData(19, -1, -1, "", 0, (float)num32, (float)num33, (float)npc.direction, 0);
						}
					}
				}
			}
		}
		else
		{
			if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
			{
				if (Main.tile[num32, num33 - 2].active && Main.tileSolid[(int)Main.tile[num32, num33 - 2].type])
				{
					if (Main.tile[num32, num33 - 3].active && Main.tileSolid[(int)Main.tile[num32, num33 - 3].type])
					{
						npc.velocity.Y = -8f;
						npc.netUpdate = true;
					}
					else
					{
						npc.velocity.Y = -7f;
						npc.netUpdate = true;
					}
				}
				else
				{
					if (Main.tile[num32, num33 - 1].active && Main.tileSolid[(int)Main.tile[num32, num33 - 1].type])
					{
						npc.velocity.Y = -6f;
						npc.netUpdate = true;
					}
					else
					{
						if (Main.tile[num32, num33].active && Main.tileSolid[(int)Main.tile[num32, num33].type])
						{
							npc.velocity.Y = -5f;
							npc.netUpdate = true;
						}
						else
						{
							if (npc.directionY < 0 && npc.type != 67 && (!Main.tile[num32, num33 + 1].active || !Main.tileSolid[(int)Main.tile[num32, num33 + 1].type]) && (!Main.tile[num32 + npc.direction, num33 + 1].active || !Main.tileSolid[(int)Main.tile[num32 + npc.direction, num33 + 1].type]))
							{
								npc.velocity.Y = -8f;
								npc.velocity.X = npc.velocity.X * 1.5f;
								npc.netUpdate = true;
							}
							else
							{
								if (flag3)
								{
									npc.ai[1] = 0f;
									npc.ai[2] = 0f;
								}
							}
						}
					}
				}
			}
		}
	}
	else
	{
		if (flag3)
		{
			npc.ai[1] = 0f;
			npc.ai[2] = 0f;
		}
	}
#endregion
#region Projectiles
    holdTimer --;
    if (holdTimer < 0)
    {
        holdTimer = 0;
    }
    if(Main.netMode != 1)
    {
        customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
        if (customAi1 >= 10f)
        {
            npc.TargetClosest(true);
		    if (((npc.position.X > Main.player[npc.target].position.X && (npc.position.X - Main.player[npc.target].position.X >= 1000)) 
            || (npc.position.X < Main.player[npc.target].position.X && (Main.player[npc.target].position.X - npc.position.X >= 1000)) 
            || (npc.position.Y > Main.player[npc.target].position.Y && (npc.position.Y - Main.player[npc.target].position.Y >= 1000)) 
            || (npc.position.Y < Main.player[npc.target].position.Y && (Main.player[npc.target].position.Y - npc.position.Y >= 1000))))
            {
                npc.defense = 9999;
                if (holdTimer <= 0)
                {
                    Main.NewText("Ultima Weapon shields itself -- you're too far away!", 175, 75, 255);
                    holdTimer = 200;
                }
            }
            else
            {
                npc.defense = 40;
            }   
    /*		if (Main.rand.Next(60)==1)
            {
			    float num48 = 8f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= 0;
				    speedY *= 0;
				    int damage = 0;
				    int type = Config.projectileID["Enemy Spell Light Pillar"];//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 300;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }*/
    #region Charge
            if (Main.rand.Next(400)==1) 
            {
                chargeDamageFlag = true;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
                npc.velocity.X = (float) (Math.Cos(rotation) * 14)*-1;
                npc.velocity.Y = (float) (Math.Sin(rotation) * 14)*-1;
			    npc.ai[1] = 1f;
                npc.netUpdate=true;
            }
            if (chargeDamageFlag == true)
            {
                npc.damage= 200;
                chargeDamage ++;
            }
            if (chargeDamage >= 50)
            {
                chargeDamageFlag = false;
                npc.damage= 100;
                chargeDamage = 0;
            }
#endregion
		    if (Main.rand.Next(60)==1)
            {
			    float num48 = 22f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 100;
				    int type = Config.projectileID["Enemy Spell Great Energy Ball"];
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 100;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(80)==1)
            {
			    float num48 = 22f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 70;
				    int type = Config.projectileID["Fire Breath"];
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 100;
				    Main.projectile[num54].aiStyle=23;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(2000)==1)
            {
                float num48 = 8f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                {
                    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num51 = num48 / num51;
                    speedX *= num51;
                    speedY *= num51;
                    int damage = 50;
                    int type = Config.projectileID["Enemy Ultima"];
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
                    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(2000)==1)
            {
                float num48 = 8f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                {
                    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num51 = num48 / num51;
                    speedX *= num51;
                    speedY *= num51;
                    int damage = 50;
                    int type = Config.projectileID["Enemy Spell Gravity 3 Ball"];
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
                    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(210)==1)
            {
                float num48 = 22f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                {
                    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num51 = num48 / num51;
                    speedX *= num51;
                    speedY *= num51;
                    int damage = 100;
                    int type = Config.projectileID["Enemy Spell Fire 4 Ball"];
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                    Main.projectile[num54].aiStyle=1;
                    Main.projectile[num54].timeLeft = 400;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
                    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(210)==1)
            {
                float num48 = 22f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                {
                    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num51 = num48 / num51;
                    speedX *= num51;
                    speedY *= num51;
                    int damage = 100;
                    int type = Config.projectileID["Enemy Spell Ice 4 Ball"];
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                    Main.projectile[num54].aiStyle=1;
                    Main.projectile[num54].timeLeft = 400;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
                    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(210)==1)
            {
                float num48 = 22f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                {
                    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num51 = num48 / num51;
                    speedX *= num51;
                    speedY *= num51;
                    int damage = 100;
                    int type = Config.projectileID["Enemy Spell Lightning 4 Ball"];
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                    Main.projectile[num54].aiStyle=1;
                    Main.projectile[num54].timeLeft = 400;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
                    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
#endregion
#region Phase Through Walls
		    if ((Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
		    {
                npc.noTileCollide = false;
                npc.noGravity = false;
            }
		    if ((!Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
		    {
                npc.noTileCollide = true;
                npc.noGravity = true;
                npc.velocity.Y = 0f;
                if (npc.position.Y > Main.player[npc.target].position.Y)
                {
                    npc.velocity.Y -= 3f;
                }
                if (npc.position.Y < Main.player[npc.target].position.Y)
                {
                    npc.velocity.Y += 8f;
                }
            }
        }
#endregion
    }
    if (Main.player[npc.target].dead)
	{
	    if (npc.timeLeft > 10)
	    {
		    npc.timeLeft = 10;
		    return;
	    }
    }
}
#endregion