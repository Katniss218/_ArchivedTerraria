public void AI()
{
	if (Config.syncedRand.Next(2)==0)
	{
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 57, npc.velocity.X, npc.velocity.Y, 230, Color.White, 1f);
    Main.dust[dust].noGravity = true;
	}

	//npc.rotation += 0.3f;
    //npc.ai[0]; // Player's ID
	
	npc.target = (int) npc.ai[0];
	
	bool buffOn = false;
	for(int num36 = 0; num36 < 10; num36++)
	{
		if (Main.player[npc.target].buffType[num36] == Config.buffDefs.ID["Metroid"])
		{
		buffOn = true;
		if (Main.player[npc.target].buffTime[num36] < 590)
		{
		Main.player[npc.target].buffTime[num36] = 600;
		}
		}
	}
	if (!buffOn)
	{
	npc.active = false;
	}
	
	if (Main.player[npc.target].position.X+100 < npc.position.X || Main.player[npc.target].position.X-100 > npc.position.X || Main.player[npc.target].position.Y+100 < npc.position.Y || Main.player[npc.target].position.Y-100 > npc.position.Y)
	{
	if (Main.player[npc.target].position.X+100 < npc.position.X)
	{
	if (npc.velocity.X > -10) {npc.velocity.X -= 0.6f;}
	}
	else if (Main.player[npc.target].position.X-100 > npc.position.X)
	{
	if (npc.velocity.X < 10) {npc.velocity.X += 0.6f;}
	}
	if (Main.player[npc.target].position.Y+100 < npc.position.Y)
	{
	if (npc.velocity.Y > -10) npc.velocity.Y -= 0.6f;
	}
	else if (Main.player[npc.target].position.Y-100 > npc.position.Y)
	{
	if (npc.velocity.Y < 10) npc.velocity.Y += 0.6f;
	}
	}
	else
	{
	npc.velocity.X *= 0.94f; npc.velocity.Y *= 0.94f;
	npc.ai[2]++;
	if (npc.ai[2] == 60)
	{
	npc.velocity.X += Config.syncedRand.Next(-5,5);
	npc.velocity.Y += Config.syncedRand.Next(-5,5);
	npc.ai[2] = 0;
	}
	}
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
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