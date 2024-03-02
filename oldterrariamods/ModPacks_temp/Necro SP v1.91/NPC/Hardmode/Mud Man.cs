float customAi1;
int movedTowards = 0;
int num94 = 0;
int num95 = 0;
int noJump = 0;

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Mud Man"].type)
	{
	return false;
	}
	}
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && (y >= Main.rockLayer) && (y <= Main.rockLayer *25);
	bool undergroundJungle = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneHoly;
	if (Main.hardMode && undergroundJungle)
	{
	if (Main.rand.Next(15)==1)
	{
	return true;
	}
	}
	return false;
    int closeTownNPCs = 0;
    if (!Main.bloodMoon)
    {
    Vector2 playerPosition = Main.player[playerID].position + new Vector2(Main.player[playerID].width/2,Main.player[playerID].height/2);
    for (int num36 = 0; num36 < 200; num36++)
    {
    Vector2 npcPosition = Main.npc[num36].position + new Vector2(Main.npc[num36].width/2,Main.npc[num36].height/2);
    if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(playerPosition,npcPosition) < 1500)
    {
    closeTownNPCs++;
    }
    }
    }
    if (closeTownNPCs == 1 && Main.rand.Next(3) == 0) return false;
    if (closeTownNPCs == 2 && Main.rand.Next(2) == 0) return false;
    if (closeTownNPCs == 3 && Main.rand.Next(3) <= 1) return false;
    if (closeTownNPCs >= 4) return false;
}
#endregion

#region AI
public void AI() 
{
    int num3 = 60;
    bool flag2 = false;
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
	if (npc.lavaWet)
	{
       npc.velocity.Y-=2;
	}
	int num5 = 60;
	bool flag3 = true;
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
			if (((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1)) && (noJump < 1))
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

#region Projectile
    customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (customAi1 >= 10f)
    {
        npc.TargetClosest(true);
		if (Main.rand.Next(40)==1)
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
				    int damage = 60;
				    int type = Config.projectileID["Enemy Boulder"];//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].aiStyle=1;
                      Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
    	            customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
}
}
#endregion

#region Loot
public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mud Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mud Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mud Gore 2", 1f, -1);
}
}
#endregion