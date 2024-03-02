public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if (Main.moonPhase == 0)
		{
			if (Main.player[playerID].townNPCs < 1 && !Main.dayTime && !Main.player[playerID].zoneDungeon && y < Main.rockLayer - 10 && y > (int)(Main.topWorld + 100f) && Main.rand.Next(20) == 0)
			{
				return true;
			}
			else return false;
		}
		else if (Main.moonPhase != 0)
		{
			if (Main.player[playerID].townNPCs < 1 && !Main.dayTime && !Main.player[playerID].zoneDungeon && y < Main.rockLayer - 10 && y > (int)(Main.topWorld + 100f) && Main.rand.Next(35) == 0)
			{
				return true;
			}
			else return false;
		}
		else return false;
	}
	else return false;
}

public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Vampire Harpy Head",1.3f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Vampire Harpy Wing",1.3f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Vampire Harpy Wing",1.3f,-1);
}

public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(7) == 0)
	{
		player.AddBuff("Slowed Life Regeneration", 1200, false);
	}
}