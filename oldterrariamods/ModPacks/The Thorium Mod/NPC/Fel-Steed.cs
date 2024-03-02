public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.bloodMoon)
	{
		if (y < Main.rockLayer + 75 && y > (int)(Main.topWorld + 100f) && !Main.dayTime && !Main.player[playerID].zoneMeteor && Main.rand.Next(30) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Felsteed Leg 1",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Felsteed Leg 2",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Felsteed Body",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Fel Steed Head",1f,-1);
}