public bool SpawnNPC(int x, int y, int playerID)
{
	if (!Main.dayTime)
	{
		if (y > Main.rockLayer && y < Main.maxTilesY - 50 && Main.jungleTiles > 50 && !Main.player[playerID].zoneDungeon && Main.rand.Next(15) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Mud Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mud Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mud Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mud Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mud Head",1f,-1);
}