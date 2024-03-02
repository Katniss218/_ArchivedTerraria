public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if (Main.player[playerID].townNPCs < 1 && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zone["Hell"] && Main.tile[x, y].liquid >= 16 && y < (Main.maxTilesY - 200) && Main.rand.Next(15) == 0)
		{
			return true;
		}
		else if (Main.player[playerID].zone["Tropics"] && Main.rand.Next(7) == 0) return true;
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
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Salmon Gore",1f,-1);
}