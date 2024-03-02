public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode)
	{
		if (Main.player[playerID].zoneDungeon && Main.rand.Next(5) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void AI()
{
	for (int i = 0; i < npc.buffType.Length; i++)
	{
		if(npc.buffType[i] == Config.buffID["Freeze"])
		{
			npc.DelBuff(i);
			i=0;
		}
	}
	if (npc.ai[0] == 0f)
	{
		npc.TargetClosest(true);
		npc.directionY = 1;
		npc.ai[0] = 1f;
	}
	int num256 = 6;
	if (npc.ai[1] == 0f)
	{
		npc.rotation += (float)(npc.direction * npc.directionY) * 0.13f;
		if (npc.collideY)
		{
			//npc.TargetClosest(true);
			npc.ai[0] = 2f;
		}
		if (!npc.collideY && npc.ai[0] == 2f)
		{
			npc.direction = -npc.direction;
			npc.ai[1] = 1f;
			npc.ai[0] = 1f;
		}
		if (npc.collideX)
		{
			npc.TargetClosest(true);
			npc.directionY = -npc.directionY;
			npc.ai[1] = 1f;
		}
	}
	else
	{
		npc.rotation -= (float)(npc.direction * npc.directionY) * 0.13f;
		if (npc.collideX)
		{
			//npc.TargetClosest(true);
			npc.ai[0] = 2f;
		}
		if (!npc.collideX && npc.ai[0] == 2f)
		{
			//npc.TargetClosest(true);
			npc.directionY = -npc.directionY;
			npc.ai[1] = 0f;
			npc.ai[0] = 1f;
		}
		if (npc.collideY)
		{
			npc.TargetClosest(true);
			npc.direction = -npc.direction;
			npc.ai[1] = 0f;
		}
	}
	npc.velocity.X = (float)(num256 * npc.direction);
	npc.velocity.Y = (float)(num256 * npc.directionY);
	float num257 = (float)(270 - (int)Main.mouseTextColor) / 400f;
	Lighting.addLight((int)(npc.position.X + (float)(npc.width / 2)) / 16, (int)(npc.position.Y + (float)(npc.height / 2)) / 16, 0.9f, 0.3f + num257, 0.2f);
	return;
}
