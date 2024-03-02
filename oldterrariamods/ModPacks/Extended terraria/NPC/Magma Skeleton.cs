public bool SpawnNPC(int x, int y, int playerID)
{
	int MiddleOfRockLayer = (int)((Main.rockLayer+Main.maxTilesY*16f)/32f);
	bool CanSpawnHere = y > MiddleOfRockLayer && y < Main.maxTilesY-200;
	if (Main.hardMode)
	{
		if (CanSpawnHere && !Main.player[playerID].zoneDungeon && Main.rand.Next(10) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(4) == 0)
	{
		player.AddBuff(24, 420, false);
	}
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Helmet",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Head",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Piece",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Vert",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Piece",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Vert",1.1f,-1);
}