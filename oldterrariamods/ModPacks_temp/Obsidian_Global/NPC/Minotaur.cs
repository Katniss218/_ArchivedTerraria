public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.player[playerID].zoneDungeon && Main.hardMode)
    {
	   if( Main.rand.Next(15)==1) return true;
    return false;
    }
return false;
}
public void AI() 
{
    int num3 = 60;
    bool flag2 = false;
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
    npc.TargetClosest(true);
	if (npc.velocity.X < -1.5f || npc.velocity.X > 1.5f)
	{
		if (npc.velocity.Y == 0f)
		{
			npc.velocity *= 0.8f;
		}
	}
	else
	{
		if (npc.velocity.X < 1.1f && npc.direction == 1)
		{
			npc.velocity.X = npc.velocity.X + 0.07f;
			if (npc.velocity.X > 1.1f)
			{
				npc.velocity.X = 1.1f;
			}
		}
		else
		{
			if (npc.velocity.X > -1.1f && npc.direction == -1)
			{
				npc.velocity.X = npc.velocity.X - 0.07f;
				if (npc.velocity.X < -1.1f)
				{
					npc.velocity.X = -1.1f;
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
}



#region Gore

int k = 3;
string name = "Minotaur";

public void NPCLoot()

{
if (npc.life <= 0){
for(int i=1; i<k+1; i++){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f),  name+" Gore "+i, 1f, -1);
}
}
}
#endregion