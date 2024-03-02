public bool SpawnNPC(int x, int y, int playerID)
{
	if (y > Main.rockLayer && y < Main.maxTilesY - 200 && Main.jungleTiles > 50 && !Main.player[playerID].zoneDungeon && Main.rand.Next(100) == 0)
	{
		return true;
	}
	else return false;
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Queen Bee Crown Gore",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Queen Bee Head Gore",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Queen Bee Body Gore",1f,-1);
}