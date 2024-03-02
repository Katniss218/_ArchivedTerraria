int Timer = 0;

public void AI()
{
	Timer++;
	npc.velocity.Y += Config.syncedRand.Next(-10,10)/8;
	npc.velocity.X += Config.syncedRand.Next(-10,10)/20;
	
	if (Timer >= 450)
	{
	int totalParasprites = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].displayName == "Parasprite")
	{
	totalParasprites++;
	}
	}
	if (totalParasprites < 20 && Main.netMode != 1)
	{
		int NewSprite = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "ParaspriteSpawner", 0);
		Main.npc[NewSprite].velocity.X = -npc.velocity.X*2;
		if (Main.netMode == 2 && NewSprite < 200)
		{
			NetMessage.SendData(23, -1, -1, "", NewSprite, 0f, 0f, 0f, 0);
		}
	}
	Timer = 0;
	}

	if (Main.netMode == 2 && npc.whoAmI < 200)
	{
		NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
	npc.AI(true);
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	npc.frameCounter += 1.0;
	if (npc.frameCounter >= 2.0)
	{
	npc.frame.Y = npc.frame.Y + num;
	npc.frameCounter = 0;
	}
	if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
	{
		npc.frame.Y = 0;
	}
	if (npc.velocity.X < 0) npc.spriteDirection = -1;
	if (npc.velocity.X > 0) npc.spriteDirection = 1;
}
