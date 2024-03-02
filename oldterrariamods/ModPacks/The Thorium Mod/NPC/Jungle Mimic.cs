public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode)
	{
		if (y > Main.rockLayer && y < Main.maxTilesY - 50 && Main.jungleTiles > 50 && !Main.player[playerID].zoneDungeon && Main.rand.Next(20) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}

public void NPCLoot() 
{
	Gore.NewGore(npc.position,npc.velocity,"Jungle mimic L",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Jungle mimic R",1f,-1);
}