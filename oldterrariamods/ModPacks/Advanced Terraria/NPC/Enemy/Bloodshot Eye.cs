public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.bloodMoon)
	{
		if (y < Main.rockLayer + 75 && y > (int)(Main.topWorld + 100f) && !Main.dayTime && !Main.player[playerID].zoneMeteor && Main.rand.Next(6) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Bloodshot Eye Gore 1",1.2f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Bloodshot Eye Gore 2",1.2f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Bloodshot Eye Gore 3",1.2f,-1);
}