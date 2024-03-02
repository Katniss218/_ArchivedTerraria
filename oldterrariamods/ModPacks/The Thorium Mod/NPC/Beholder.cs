public bool SpawnNPC(int x, int y, int playerID) 
{
	if (y > Main.maxTilesY - 200 && Main.hardMode && Main.rand.Next(20) == 0)
	{
		return true;
	}
	else
	{
		return false;
	}
}
public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Beholder Eye",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Beholder Horn",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Beholder Horn",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Beholder Body",1f,-1);
}