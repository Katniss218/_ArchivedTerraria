int Timer = 0;

public void AI()
{
	Timer++;
	npc.velocity.Y += Main.rand.Next(-10,10)/8;
	npc.velocity.X += Main.rand.Next(-10,10)/20;
	if (Timer >= 300)
	{
	int totalParasprites = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].displayName == "Parasprite")
	{
	totalParasprites++;
	}
	}
	if (totalParasprites < 20)
	{
	int NewSprite = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "ParaspriteSpawner", 0);
	Main.npc[NewSprite].velocity.X = -npc.velocity.X*2;
	}
	Timer = 0-Main.rand.Next(300);
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