public bool SpawnNPC(int x, int y, int playerID) 
{
	if (y > Main.maxTilesY - 200 && Main.rand.Next(5) == 0)
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
    Gore.NewGore(npc.position,npc.velocity,"Robot Piece",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Robot Piece",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Robot Piece",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Robot Piece",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Robot Piece",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Robot Piece",1f,-1);
}