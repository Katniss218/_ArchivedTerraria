public static bool SpawnNPC(int x, int y, int playerID) {
	if (!Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 35.0)))
    {
	if (Main.player[playerID].position.X > ((Main.worldSurface * 130.0)) && Main.rand.Next(100)==1) return true;
	else if (Main.player[playerID].position.Y > ((Main.rockLayer*10)) && Main.player[playerID].position.Y < ((Main.rockLayer * 30.0)) && Main.player[playerID].position.X > ((Main.rockLayer * 100.0)) && Main.rand.Next(15)==1) return true;
	return false;
    }
return false;
}

public void AI() {
                int num3 = 60;
                bool flag2 = false;

    npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (npc.ai[1] >= 10f)
    {
        npc.TargetClosest(true);
        if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
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
				int damage = 5; //(int) (14f * npc.scale);
				int type = Config.projectileID["Archer Bolt"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 600;
				Main.projectile[num54].aiStyle=1;
                      Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
              
			}
	        	npc.netUpdate=true;
        }
                if ((npc.velocity.Y == 0f) && (((npc.velocity.X > 0f) && (npc.direction < 0)) || ((npc.velocity.X < 0f) && (npc.direction > 0))))
                {
                    flag2 = true;
                }
                if (((npc.position.X == npc.oldPosition.X) || (npc.ai[3] >= num3)) || flag2)
                {
                    npc.ai[3]++;
                }
                else if ((Math.Abs(npc.velocity.X) > 0.9) && (npc.ai[3] > 0f))
                {
                    npc.ai[3]--;
                }
                if (npc.ai[3] > (num3 * 10))
                {
                    npc.ai[3] = 0f;
                }
                if (npc.justHit)
                {
                    npc.ai[3] = 0f;
                }
                if (npc.ai[3] == num3)
                {
                    npc.netUpdate = true;
                }
                else if ((npc.velocity.X < -1f) || (npc.velocity.X > 1f))
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity = (Vector2) (npc.velocity * 0.8f);
                    }
                }
                else if ((npc.velocity.X < 1f) && (npc.direction == 1))
                {
                    npc.velocity.X += 0.3f;
                    if (npc.velocity.X > 0.9f)
                    {
                        npc.velocity.X = 0.9f;
                    }
                }
                else if ((npc.velocity.X > -1f) && (npc.direction == -1))
                {
                    npc.velocity.X -= 0.3f;
                    if (npc.velocity.X < -0.9f)
                    {
                        npc.velocity.X = -0.9f;
                    }
                }
                if (npc.velocity.Y != 0f)
                {
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    return;
                }
                int i = (int) (((npc.position.X + (npc.width / 2)) + (15 * npc.direction)) / 16f);
                int j = (int) (((npc.position.Y + npc.height) - 15f) / 16f);
                if (Main.tile[i, j] == null)
                {
                    Main.tile[i, j] = new Tile();
                }
                if (Main.tile[i, j - 1] == null)
                {
                    Main.tile[i, j - 1] = new Tile();
                }
                if (Main.tile[i, j - 2] == null)
                {
                    Main.tile[i, j - 2] = new Tile();
                }
                if (Main.tile[i, j - 3] == null)
                {
                    Main.tile[i, j - 3] = new Tile();
                }
                if (Main.tile[i, j + 1] == null)
                {
                    Main.tile[i, j + 1] = new Tile();
                }
                if (Main.tile[i + npc.direction, j - 1] == null)
                {
                    Main.tile[i + npc.direction, j - 1] = new Tile();
                }
                if (Main.tile[i + npc.direction, j + 1] == null)
                {
                    Main.tile[i + npc.direction, j + 1] = new Tile();
                }
                bool flag3 = true;
                if ((!Main.tile[i, j - 1].active || (Main.tile[i, j - 1].type != 10)) || !flag3)
                {
                    if (((npc.velocity.X < 0f) && (npc.spriteDirection == -1)) || ((npc.velocity.X > 0f) && (npc.spriteDirection == 1)))
                    {
                        if (Main.tile[i, j - 2].active && Main.tileSolid[Main.tile[i, j - 2].type])
                        {
                            if (Main.tile[i, j - 3].active && Main.tileSolid[Main.tile[i, j - 3].type])
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
                        else if (Main.tile[i, j - 1].active && Main.tileSolid[Main.tile[i, j - 1].type])
                        {
                            npc.velocity.Y = -6f;
                            npc.netUpdate = true;
                        }
                        else if (Main.tile[i, j].active && Main.tileSolid[Main.tile[i, j].type])
                        {
                            npc.velocity.Y = -5f;
                            npc.netUpdate = true;
                        }
                        else if ((((npc.directionY < 0) && (npc.type != 0x43)) && (!Main.tile[i, j + 1].active || !Main.tileSolid[Main.tile[i, j + 1].type])) && (!Main.tile[i + npc.direction, j + 1].active || !Main.tileSolid[Main.tile[i + npc.direction, j + 1].type]))
                        {
                            npc.velocity.Y = -8f;
                            npc.velocity.X *= 1.5f;
                            npc.netUpdate = true;
                        }
                        else
                        {
                            npc.ai[1] = 0f;
                            npc.ai[2] = 0f;
                        }
                    }
                }
                else
                {
                    npc.ai[2]++;
                    npc.ai[3] = 0f;
                    if (npc.ai[2] >= 60f)
                    {
                        npc.velocity.X = 0.5f * -npc.direction;
                        npc.ai[1]++;
                        if (npc.type == 0x1b)
                        {
                            npc.ai[1]++;
                        }
                        npc.ai[2] = 0f;
                        bool flag4 = false;
                        if (npc.ai[1] >= 10f)
                        {
                            flag4 = true;
                            npc.ai[1] = 10f;
                        }
                        WorldGen.KillTile(i, j - 1, true, false, false);
                        if (((Main.netMode != 1) || !flag4) && (flag4 && (Main.netMode != 1)))
                        {
                            if (npc.type != 0x1a)
                            {
                                bool flag5 = WorldGen.OpenDoor(i, j, npc.direction);
                                if (!flag5)
                                {
                                    npc.ai[3] = num3;
                                    npc.netUpdate = true;
                                }
                                if ((Main.netMode == 2) && flag5)
                                {
                                    NetMessage.SendData(0x13, -1, -1, "", 0, (float) i, (float) j, (float) npc.direction, 0);
                                    return;
                                }
                            }
                            else
                            {
                                WorldGen.KillTile(i, j - 1, false, false, false);
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(0x11, -1, -1, "", 0, (float) i, (float) (j - 1), 0f, 0);
                                    return;
                                }
                            }
                        }
                    }
                }
}
}

public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 3", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 3", 1f, -1);
}
}