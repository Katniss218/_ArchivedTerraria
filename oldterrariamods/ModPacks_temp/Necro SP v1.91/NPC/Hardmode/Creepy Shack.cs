#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
    if (!Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y > ((Main.rockLayer * 25.0)))
    {
	    if (Main.player[playerID].townNPCs <= 0f && Main.player[playerID].position.X < ((Main.rockLayer * 50.0)) && Main.rand.Next(20)==1) return true;
	    else if (Main.player[playerID].townNPCs <= 0f && Main.player[playerID].position.X > ((Main.rockLayer * 150.0)) && Main.rand.Next(20)==1) return true;
	    else if (Main.bloodMoon && Main.rand.Next(10)==1) return true;
	    return false;
    }
    else if (Main.player[playerID].townNPCs <= 0f && !Main.dayTime && Main.player[playerID].position.Y > ((Main.rockLayer * 38.0)) && Main.rand.Next(16)==1) return true;
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

#region Mob Spawn
public void AI()
{
	npc.TargetClosest();
	npc.netUpdate = false;
	npc.ai[1]++;
	if (npc.ai[1] >= 600 && Main.netMode != 1)
	{
		int PileOZombiespawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Zombie Bob", 0);
		npc.ai[1] = 20-Main.rand.Next(80);
		if (Main.netMode == 2 && PileOZombiespawn < 200)
		{
			NetMessage.SendData(23, -1, -1, "", PileOZombiespawn, 0f, 0f, 0f, 0);
		}
	    int FesteringEggspawn = NPC.NewNPC((int) npc.position.X+(npc.width/3), (int) npc.position.Y+(npc.height/2), "Sleeping Mask", 0);
		npc.ai[1] = 20-Main.rand.Next(80);
		if (Main.netMode == 2 && FesteringEggspawn < 300)
		{
			NetMessage.SendData(23, -1, -1, "", FesteringEggspawn, 0f, 0f, 0f, 0);
		}        
    }
}
#endregion

#region Frame
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