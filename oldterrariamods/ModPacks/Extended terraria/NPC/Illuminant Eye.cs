public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.hardMode)
	{
		if (y > (Main.rockLayer + 50) && Main.holyTiles >= 100 && y < (Main.maxTilesY - 200) &&!Main.dayTime && Main.rand.Next(5) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Illuminant Eye Gore 1",1.2f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Illuminant Eye Gore 2",1.2f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Illuminant Eye Gore 3",1.2f,-1);
}