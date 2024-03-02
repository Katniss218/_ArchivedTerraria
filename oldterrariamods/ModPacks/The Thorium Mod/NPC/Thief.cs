public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.bloodMoon)
	{
		if (y < Main.rockLayer + 75 && y > (int)(Main.topWorld + 100f) && !Main.dayTime && !Main.player[playerID].zoneMeteor && Main.rand.Next(10) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Thief Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Thief Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Thief Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Thief Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Thief Arm",1f,-1);
}