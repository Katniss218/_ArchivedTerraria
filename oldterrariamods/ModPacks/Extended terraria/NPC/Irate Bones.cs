public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode)
	{
		if (Main.player[playerID].zoneDungeon && Main.rand.Next(5) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Irate Bones Helmet",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Head",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Piece",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Vert",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Piece",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Vert",1.1f,-1);
}