float customAi1;
float customspawn1;
//Spawns in only in hardmode: Cavern, mostly in Corruption; or anywhere during a Blood Moon. Does not spawn in Meteor, or if there are more than 4 Town NPCs.

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
    bool oSky = (y < (Main.maxTilesY * 0.1f));
    bool oSurface = (y >= (Main.maxTilesY * 0.1f) && y < (Main.maxTilesY * 0.2f));
    bool oUnderSurface = (y >= (Main.maxTilesY * 0.2f) && y < (Main.maxTilesY * 0.3f));
    bool oUnderground = (y >= (Main.maxTilesY * 0.3f) && y < (Main.maxTilesY * 0.4f));
    bool oCavern = (y >= (Main.maxTilesY * 0.4f) && y < (Main.maxTilesY * 0.6f));
    bool oMagmaCavern = (y >= (Main.maxTilesY * 0.6f) && y < (Main.maxTilesY * 0.8f));
    bool oUnderworld = (y >= (Main.maxTilesY * 0.8f));
    if (Main.player[playerID].zoneEvil || Main.player[playerID].townNPCs > 4f || !Main.hardMode || Main.player[playerID].zoneMeteor) return false;
	if ((oSurface || oUnderSurface || oUnderground) && Main.rand.Next(250)==1) return true;
    else if (Main.bloodMoon && Main.rand.Next(100)==1) return true;
    return false;
}
#endregion 

#region AI
public void AI() 
{
    bool flag25 = false;
    if(Main.netMode != 1)
    {
        customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
        if (customAi1 >= 10f)
        {
            npc.TargetClosest(true);
            if ((customspawn1 < 2) && Main.rand.Next(500)==1)
	        {
		        int Spawned = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Omnirs Vampire", 0);
		        Main.npc[Spawned].velocity.Y = -8;
		        Main.npc[Spawned].velocity.X = Main.rand.Next(-10,10)/10;
		        npc.ai[0] = 20-Main.rand.Next(80);
                customspawn1 += 1f;
		        if (Main.netMode == 2)
		        {
		            NetMessage.SendData(23, -1, -1, "", Spawned, 0f, 0f, 0f, 0);
		        }
	        }
		    if (Main.rand.Next(250)==1)
	        {
	            npc.ai[3] = 1;
	            npc.life += 40;
                if(npc.life > npc.lifeMax) npc.life = npc.lifeMax;
			    customAi1 = 1f;
                npc.netUpdate=true;
            }
		    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))           
            {
		        if (Main.rand.Next(80)==1)
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
				        int damage = 30;
				        int type = Config.projectileID["Enemy Spell Great Energy Ball"];//44;//0x37; //14;
				        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				        Main.projectile[num54].timeLeft = 100;
				        Main.projectile[num54].aiStyle=1;
                            Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				        customAi1 = 1f;
                    }
                    npc.netUpdate=true;
                }
		        if (Main.rand.Next(150)==1)
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
				        int damage = 80;//(int) (14f * npc.scale);
				        int type = Config.projectileID["Enemy Spell Sudden Death Ball"];//44;//0x37; //14;
				        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				        Main.projectile[num54].timeLeft = 100;
				        Main.projectile[num54].aiStyle=23;
                            Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				        customAi1 = 1f;
                    }
                    npc.netUpdate=true;
                }
                if (Main.rand.Next(130)==1)
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
				        int damage = 10;//(int) (14f * npc.scale);
				        int type = Config.projectileID["Enemy Spell Fireball Ball"];//44;//0x37; //14;
				        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				        Main.projectile[num54].timeLeft = 100;
				        Main.projectile[num54].aiStyle=23;
                            Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				        customAi1 = 1f;
                    }
                    npc.netUpdate=true;
                }   
            }
        }
    }
    if (npc.justHit)
    {
       npc.ai[2] = 0f;
        customAi1 = 1f;
	}
	if (npc.ai[2] >= 0f)
	{
		int num258 = 16;
		bool flag26 = false;
		bool flag27 = false;
		if (npc.position.X > npc.ai[0] - (float)num258 && npc.position.X < npc.ai[0] + (float)num258)
		{
		    flag26 = true;
		}
		else
		{
		   if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
		    {
				flag26 = true;
		    }
		}
		num258 += 24;
		if (npc.position.Y > npc.ai[1] - (float)num258 && npc.position.Y < npc.ai[1] + (float)num258)
		{
			flag27 = true;
		}
		if (flag26 && flag27)
		{
			npc.ai[2] += 1f;
			if (npc.ai[2] >= 30f && num258 == 16)
			{
				flag25 = true;
			}
			if (npc.ai[2] >= 60f)
			{
				npc.ai[2] = -200f;
				npc.direction *= -1;
				npc.velocity.X = npc.velocity.X * -1f;
				npc.collideX = false;
			}
		}
		else
		{
			npc.ai[0] = npc.position.X;
			npc.ai[1] = npc.position.Y;
			npc.ai[2] = 0f;
		}
		npc.TargetClosest(true);
	}
	else
	{
		npc.ai[2] += 1f;
		if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2))
		{
			npc.direction = -1;
		}
		else
		{
		    npc.direction = 1;
		}
	}
	int num259 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
	int num260 = (int)((npc.position.Y + (float)npc.height) / 16f);
	bool flag28 = true;
	bool flag29 = false;
	int num261 = 3;
	for (int num269 = num260; num269 < num260 + num261; num269++)
	{
		if (Main.tile[num259, num269] == null)
		{
			Main.tile[num259, num269] = new Tile();
		}
		if ((Main.tile[num259, num269].active && Main.tileSolid[(int)Main.tile[num259, num269].type]) || Main.tile[num259, num269].liquid > 0)
		{
			if (num269 <= num260 + 1)
			{
				flag29 = true;
		    }
			flag28 = false;
		    break;
		}
	}
	if (flag25)
	{
		flag29 = false;
	    flag28 = true;
	}
	if (flag28)
	{
		npc.velocity.Y = npc.velocity.Y + 0.1f;
		if (npc.velocity.Y > 3f)
		{
		    npc.velocity.Y = 3f;
        }
	}
	else
	{
		if (npc.directionY < 0 && npc.velocity.Y > 0f)
		{
			npc.velocity.Y = npc.velocity.Y - 0.1f;
		}
		if (npc.velocity.Y < -4f)
		{
			npc.velocity.Y = -4f;
		}
	}
	if (npc.collideX)
	{
		npc.velocity.X = npc.oldVelocity.X * -0.4f;
		if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
		{
			npc.velocity.X = 1f;
		}
		if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
		{
			npc.velocity.X = -1f;
		}
	}
	if (npc.collideY)
	{
		npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
		if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
		{
			npc.velocity.Y = 1f;
		}
		if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
		{
			npc.velocity.Y = -1f;
		}
	}
	float num270 = 2f;
	if (npc.direction == -1 && npc.velocity.X > -num270)
	{
		npc.velocity.X = npc.velocity.X - 0.1f;
		if (npc.velocity.X > num270)
		{
			npc.velocity.X = npc.velocity.X - 0.1f;
		}
		else
		{
			if (npc.velocity.X > 0f)
			{
				npc.velocity.X = npc.velocity.X + 0.05f;
			}
		}
		if (npc.velocity.X < -num270)
		{
			npc.velocity.X = -num270;
		}
	}
	else
	{
		if (npc.direction == 1 && npc.velocity.X < num270)
		{
			npc.velocity.X = npc.velocity.X + 0.1f;
			if (npc.velocity.X < -num270)
			{
				npc.velocity.X = npc.velocity.X + 0.1f;
			}
			else
		    {
				if (npc.velocity.X < 0f)
				{
					npc.velocity.X = npc.velocity.X - 0.05f;
				}
			}
			if (npc.velocity.X > num270)
			{
				npc.velocity.X = num270;
			}
		}
	}
	if (npc.directionY == -1 && (double)npc.velocity.Y > -1.5)
	{
		npc.velocity.Y = npc.velocity.Y - 0.04f;
		if ((double)npc.velocity.Y > 1.5)
		{
			npc.velocity.Y = npc.velocity.Y - 0.05f;
		}
		else
		{
			if (npc.velocity.Y > 0f)
			{
				npc.velocity.Y = npc.velocity.Y + 0.03f;
			}
		}
		if ((double)npc.velocity.Y < -1.5)
		{
			npc.velocity.Y = -1.5f;
		}
	}
	else
	{
		if (npc.directionY == 1 && (double)npc.velocity.Y < 1.5)
		{
			npc.velocity.Y = npc.velocity.Y + 0.04f;
			if ((double)npc.velocity.Y < -1.5)
			{
				npc.velocity.Y = npc.velocity.Y + 0.05f;
			}
			else
			{
				if (npc.velocity.Y < 0f)
				{
					npc.velocity.Y = npc.velocity.Y - 0.03f;
				}
			}
			if ((double)npc.velocity.Y > 1.5)
			{
				npc.velocity.Y = 1.5f;
			}
		}
	}
	Lighting.addLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.4f, 0f, 0.25f);
    return;
}
#endregion

#region Gore
public void NPCLoot()
{
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Braindeath Gore 1", 1.3f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Braindeath Gore 1", 1.3f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Braindeath Gore 1", 1.3f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Braindeath Gore 1", 1.3f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Braindeath Gore 2", 1.3f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Braindeath Gore 3", 1.3f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Braindeath Gore 4", 1.3f, -1);
    }
}
#endregion

#region Frames
public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	if (npc.velocity.X < 0)
	{
	npc.spriteDirection = -1;
	}
	else
	{
	npc.spriteDirection = 1;
	}
	npc.rotation = npc.velocity.X * 0.08f;
	npc.frameCounter += 1.0;
	if (npc.frameCounter >= 8.0)
	{
		npc.frame.Y = npc.frame.Y + num;
		npc.frameCounter = 0.0;
	}
	if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
	{
		npc.frame.Y = 0;
	}
}
#endregion

