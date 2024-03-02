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

public static void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff(30, 180, false);
		//player.AddBuff(23, 180, false);
	}
}

public void NPCLoot()
{
     	Gore.NewGore(npc.position,npc.velocity,"Flayer Body",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Flayer Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Flayer Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Flayer Head",1f,-1);
}