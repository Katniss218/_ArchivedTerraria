public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.bloodMoon)
	{
		if (y < Main.rockLayer + 75 && y > (int)(Main.topWorld + 100f) && !Main.dayTime && !Main.player[playerID].zoneMeteor && Main.rand.Next(8) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Impaled Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Impaled Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Impaled Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Impaled Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Impaled Arm",1f,-1);
}