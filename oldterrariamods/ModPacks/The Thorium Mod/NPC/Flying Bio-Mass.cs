public bool SpawnNPC(int x, int y, int playerID)
{
	if (!Main.dayTime)
	{
		if (y > Main.rockLayer && y < Main.maxTilesY - 50 && Main.jungleTiles > 50 && !Main.player[playerID].zoneDungeon && Main.rand.Next(12) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}


public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Bio Half L",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Bio Half R",1f,-1);
}