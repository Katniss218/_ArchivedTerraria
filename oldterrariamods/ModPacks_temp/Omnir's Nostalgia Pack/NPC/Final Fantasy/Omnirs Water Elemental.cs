float customAi1;
int inAirTimer=0;
//Spawns in great bodies of water, before the Cavern (Height), and before 2/10ths and after 8/10ths (Width) in Normal Mode, or anywhere (Width) in Hardmode. Does not spawn in Corruption, Dungeons, Meteor, or if there are Town NPCs.

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
    if (Main.player[playerID].townNPCs > 0f || Main.tile[x,y-1].liquid < 50 || Main.player[playerID].zoneEvil || Main.player[playerID].zoneDungeon || Main.player[playerID].zoneMeteor) return false;
    if (!Main.hardMode && (oSurface || oUnderSurface || oUnderground))
    {
	    if ((x < Main.maxTilesX*0.2f || x > Main.maxTilesX*0.8f) && Main.rand.Next(80)==1) return true;
        if (Main.tile[x,y-1].liquid > 70 && Main.rand.Next(40)==1) return true;
	    return false;
    }
    if (Main.hardMode && (oSurface || oUnderSurface || oUnderground))
    {
	    if (Main.rand.Next(20)==1) return true;
	    return false;
    }
    return false;
}
#endregion

#region AI
public void AI() 
{
    bool flag25 = false;
    if (!npc.wet)
    {
        inAirTimer++;
        if (inAirTimer >=60)
        {
            npc.life=0;
            Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 1);
            npc.NPCLoot();
            npc.netUpdate=true;
        }
    }
    else if (npc.wet)
    {
        inAirTimer=0;
    }
    if(Main.netMode != 1)
    {
        customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
        //if (customAi1 >= 10f)
        //{
        //}
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
	if (npc.frameCounter >= 3.0)
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
