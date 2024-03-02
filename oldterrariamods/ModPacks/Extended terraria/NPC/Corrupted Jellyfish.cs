public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode)
	{
		if (Main.player[playerID].townNPCs < 1 && Main.evilTiles >= 50 && Main.tile[x, y].liquid >= 0 && y > Main.rockLayer - 30 && Main.rand.Next(5) == 0)
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
	npc.AI(true);
}