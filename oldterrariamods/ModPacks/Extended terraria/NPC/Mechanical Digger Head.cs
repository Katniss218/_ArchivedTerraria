bool TailSpawned = false;

public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if (Main.player[playerID].zoneJungle)
		{
			if (y > Main.rockLayer + 20 && y < Main.maxTilesY - 200 && Main.rand.Next(60) == 0)
			{
				return true;
			}
			else return false;
		}
		else if (!Main.player[playerID].zoneJungle)
		{
			if (y > Main.rockLayer + 20 && y < Main.maxTilesY - 200 && !Main.player[playerID].zoneDungeon && Main.rand.Next(55) == 0)
			{
				return true;
			}
			else return false;
		}
		else return false;
	}
	else return false;
}

public void AI()
{
	npc.AI(true);
	if (!TailSpawned)
	{
		int Previous = npc.whoAmI;
		for (int num36 = 1; num36 < 20; num36++)
		{
			int spawn = 0;
			if (num36 < 19)
			{
				spawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Mechanical Digger Body", npc.whoAmI);
			}
			else if (num36 == 19)
			{
				spawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Mechanical Digger Tail", npc.whoAmI);
			}
			Main.npc[spawn].realLife = npc.whoAmI;
			Main.npc[spawn].ai[2] = (float)npc.whoAmI;
			Main.npc[spawn].ai[1] = (float)Previous;
			Main.npc[Previous].ai[0] = (float)spawn;
			NetMessage.SendData(23, -1, -1, "", spawn, 0f, 0f, 0f, 0);
			Previous = spawn;
		}
		TailSpawned = true;
	}
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Mechanical Digger Head Gore",1.25f,-1);
}