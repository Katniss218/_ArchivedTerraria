public bool SpawnNPC(int x, int y, int playerID) 
{
	if (!Main.dayTime)
		{
		if (Main.player[playerID].zoneEvil && y > (Main.rockLayer + 30) && y < (Main.maxTilesY - 200) && Main.rand.Next(8) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Evil Part 1",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Evil Part 2",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Evil Part 3",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Evil Part 4",1f,-1);
}

public static void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff("Sunder", 180, false);
		//player.AddBuff(23, 180, false);
	}
}