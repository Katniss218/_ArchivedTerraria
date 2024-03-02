public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if (Main.player[playerID].townNPCs < 1 && Main.player[playerID].zone["Tropics"] && ModGeneric.SomeNPCs(Config.npcDefs.byName["Man of War"].type, 6) && y < Main.rockLayer + 30 && Main.tile[x, y].liquid >= 0 && Main.rand.Next(4) == 0)
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