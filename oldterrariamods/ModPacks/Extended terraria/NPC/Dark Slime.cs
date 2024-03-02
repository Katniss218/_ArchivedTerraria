public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if ((Main.invasionType != 1 && Main.invasionType != 2) && Main.player[playerID].townNPCs < 1 && y < Main.maxTilesY - 200 && !Main.player[playerID].zoneDungeon && Main.rand.Next(9) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void NPCLoot()
{
	Dust.NewDust(npc.position, npc.height, npc.width, 4, 0.2f, 0.2f, 100, default(Color), 1f);
	Dust.NewDust(npc.position, npc.height, npc.width, 4, 0.2f, 0.2f, 100, default(Color), 1f);
	Dust.NewDust(npc.position, npc.height, npc.width, 4, 0.2f, 0.2f, 100, default(Color), 1f);
}