bool TailSpawned = false;

public static bool SpawnNPC(int x, int y, int playerID)
{
	bool nospecialbiome = !Main.player[Main.myPlayer].zoneJungle && !Main.player[Main.myPlayer].zoneEvil && !Main.player[Main.myPlayer].zoneHoly && !Main.player[Main.myPlayer].zoneMeteor && !Main.player[Main.myPlayer].zoneDungeon;

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && !sky && !surface && !underground && !underworld && (y <= Main.rockLayer *25) && !Main.player[Main.myPlayer].zoneJungle;
	bool undergroundJungle = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneHoly;
	
	if (
			Main.player[Main.myPlayer].zoneDungeon &&
			Main.rand.Next(9)==1
		)
	{
		return true;
	}
	return false;
}

public void AI()
{
	npc.AI(true);
	if (!TailSpawned)
	{
		int Previous = npc.whoAmI;
		for (int num36 = 1; num36 < 16; num36++)
		{
			int spawn = 0;
			if (num36 < 15)
			{
				spawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Orobourous Body", npc.whoAmI);
			}
			else if (num36 == 15)
			{
				spawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Orobourous Tail", npc.whoAmI);
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