bool SpeedBoost = false;
public void AI()
{
	if (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].life <= 0)
	{
		npc.life = 0;
		npc.HitEffect(0, 10.0);
		npc.active = false;
	}
	npc.AI(true);
	foreach(NPC N in Main.npc) if (N!= null)
    {
        if(N.active && N.dontTakeDamage && N.type == Config.npcDefs.byName["Serris Head"].type)
        {
            SpeedBoost = true;
			return;
        }
		else
		{
			SpeedBoost = false;
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
	if(SpeedBoost)
	{
		if(npc.frameCounter >= 0 && npc.frameCounter < 5)
		{
			npc.frame.Y = num;
		}
		if(npc.frameCounter >= 5 && npc.frameCounter < 10)
		{
			npc.frame.Y = num*2;
		}
		if(npc.frameCounter >= 10)
		{
			npc.frameCounter = 0;
		}
	}
	else
	{
		npc.frame.Y = 0;
		npc.frameCounter = 0;
	}
}