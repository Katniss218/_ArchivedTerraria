int frames = 4;
public bool SpawnNPC(int x, int y, int PID)
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if (Main.player[PID].townNPCs < 1 && Main.dayTime && !Main.player[PID].zoneMeteor && !Main.player[PID].zoneDungeon && y < Main.rockLayer - 10 && y > (int)(Main.topWorld + 100f) && Main.rand.Next(7) == 0)
		{
			return true;
		}
		else return false;
	}
	return false;
}

public void AI()
{
	frames += 16;
	if (frames > 448) frames = 4;
	if (Math.Round(npc.velocity.X) == 0.0)
	{
		npc.spriteDirection = npc.direction;
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
	if (frames == 4 || frames == 68 || frames == 132 || frames == 196 || frames == 260 || frames == 324 || frames == 388)
	{
		npc.frame.Y = frames;
	}
}