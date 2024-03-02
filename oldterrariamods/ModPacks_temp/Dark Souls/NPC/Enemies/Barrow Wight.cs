int chargeDamage = 0;
bool chargeDamageFlag = false;

//Spawns from the Surface into the Cavern, from 2/10th to 3.5/10th and again from 6.5/10th to 8/10th (Width) on Normal Mode. Also spawns in the Dungeon and in the sky in Hardmode.

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
    bool oSky = (Main.player[Main.myPlayer].position.Y <= (Main.rockLayer * 4)); 
    bool oSurface = ((Main.player[Main.myPlayer].position.Y > (Main.rockLayer * 4)) && (Main.player[Main.myPlayer].position.Y <= (Main.rockLayer * 8)));
    bool oUnderSurface = ((Main.player[Main.myPlayer].position.Y > (Main.rockLayer * 8)) && (Main.player[Main.myPlayer].position.Y < (Main.rockLayer * 13)));
    bool oUnderground = ((Main.player[Main.myPlayer].position.Y >= (Main.rockLayer * 13)) && (Main.player[Main.myPlayer].position.Y < (Main.rockLayer * 17)));
    bool oCavern = ((Main.player[Main.myPlayer].position.Y >= (Main.rockLayer * 17)) && (Main.player[Main.myPlayer].position.Y < (Main.rockLayer * 24)));
    bool oMagmaCavern = ((Main.player[Main.myPlayer].position.Y >= (Main.rockLayer * 24)) && (Main.player[Main.myPlayer].position.Y < (Main.rockLayer * 32)));
    bool oUnderworld = (Main.player[Main.myPlayer].position.Y >= (Main.rockLayer * 32));
    if (Main.player[playerID].townNPCs > 0f || Main.player[playerID].zoneMeteor) return false;
    if ((oSurface || oUnderSurface || oUnderground || oCavern) && (x > Main.maxTilesX*0.2f && x < Main.maxTilesX*0.35f || x > Main.maxTilesX*0.65f && x < Main.maxTilesX*0.8f) && Main.rand.Next(200)==1) return true;
	if (!Main.hardMode && Main.player[playerID].zoneDungeon && Main.rand.Next(120)==1) return true;
    if (!ModWorld.superHardmode && Main.hardMode && oSky && Main.rand.Next(15)==1) return true;
	if (!ModWorld.superHardmode && Main.hardMode && Main.player[playerID].zoneDungeon && Main.rand.Next(35)==1) return true;
	if (ModWorld.superHardmode && oSky && Main.rand.Next(40)==1) return true;
	if (ModWorld.superHardmode && Main.player[playerID].zoneDungeon && Main.rand.Next(125)==1) return true;
    return false;
}
#endregion


//void DealtPlayer(Player player, double damage, NPC npc)



//public void DamagePlayer(ref int damage, Player player);





#region AI
public void AI() 
{
    bool flag25 = false;
    npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (npc.ai[1] >= 10f)
    {
        npc.TargetClosest(true);



// charge forward code 
if (Main.rand.Next(2050)==1) 
        {
            chargeDamageFlag = true;
            Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
            float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
            npc.velocity.X = (float) (Math.Cos(rotation) * 11)*-1;
            npc.velocity.Y = (float) (Math.Sin(rotation) * 11)*-1;
			npc.ai[1] = 1f;
            npc.netUpdate=true;
        }
        if (chargeDamageFlag == true)
        {
            npc.damage= 115;
            chargeDamage ++;
        }
        if (chargeDamage >= 115)
        {
            chargeDamageFlag = false;
            npc.damage= 115;
            chargeDamage = 0;
        }




    }
    if (npc.justHit)
    {
       npc.ai[2] = 0f;
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
    if (npc.position.Y > Main.player[npc.target].position.Y)
    {
        npc.velocity.Y -= .05f;
    }
    if (npc.position.Y < Main.player[npc.target].position.Y)
    {
        npc.velocity.Y += .05f;
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
	float num270 = .5f;
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
	if (npc.directionY == -1 && (double)npc.velocity.Y > -2.5)
	{
		npc.velocity.Y = npc.velocity.Y - 0.04f;
		if ((double)npc.velocity.Y > 2.5)
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
		if ((double)npc.velocity.Y < -2.5)
		{
			npc.velocity.Y = -2.5f;
		}
	}
	else
	{
		if (npc.directionY == 1 && (double)npc.velocity.Y < 2.5)
		{
			npc.velocity.Y = npc.velocity.Y + 0.04f;
			if ((double)npc.velocity.Y < -2.5)
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
			if ((double)npc.velocity.Y > 2.5)
			{
				npc.velocity.Y = 2.5f;
			}
		}
	}
	Lighting.addLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.4f, 0f, 0.25f);
    return;
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
	if (npc.frameCounter >= 4.0)
	{
		npc.frame.Y = npc.frame.Y + num;
		npc.frameCounter = 0.0;
	}
	if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
	{
		npc.frame.Y = 0;
	}
	if (npc.ai[3] == 0)
	{
	    npc.alpha = 0;
	}
	else
	{
	    npc.alpha = 200;
	}
}
#endregion

#region Gore
public void NPCLoot()
{
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Barrow Wight Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Barrow Wight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Barrow Wight Gore 2", 1f, -1);

	Dust.NewDust(npc.position, npc.width, npc.height, 45, 0.3f, 0.3f, 200, default(Color), 1f);
	Dust.NewDust(npc.position, npc.height, npc.width, 45, 0.2f, 0.2f, 200, default(Color), 2f);
        Dust.NewDust(npc.position, npc.width, npc.height, 45, 0.2f, 0.2f, 200, default(Color), 2f);
	Dust.NewDust(npc.position, npc.height, npc.width, 45, 0.2f, 0.2f, 200, default(Color), 3f);
	Dust.NewDust(npc.position, npc.height, npc.width, 45, 0.2f, 0.2f, 200, default(Color), 2f);
	Dust.NewDust(npc.position, npc.width, npc.height, 45, 0.2f, 0.2f, 200, default(Color), 4f);
	Dust.NewDust(npc.position, npc.height, npc.width, 45, 0.2f, 0.2f, 200, default(Color), 4f);
	Dust.NewDust(npc.position, npc.height, npc.width, 45, 0.2f, 0.2f, 200, default(Color), 2f);
	Dust.NewDust(npc.position, npc.height, npc.width, 45, 0.2f, 0.2f, 200, default(Color), 4f);
    }
}
#endregion

#region Magic Defense
public int MagicDefenseValue() 
{ 
    return 5;
}
#endregion





public void DamagePlayer(Player player, ref int damage) //hook works!
{

	if (Main.rand.Next(2) == 0)
	{ 
				player.AddBuff(36, 1800, false); //broken armor
                player.AddBuff(10, 3600, false); //invisible         
				player.AddBuff("Curse Buildup", 36000, false); //-20 life after several hits
	}
    
	if (Main.rand.Next(4) == 0)
	{
                player.AddBuff(23, 300, false); //cursed			
	}
	
}


