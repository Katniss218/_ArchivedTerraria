public static bool SpawnNPC(int x, int y, int playerID)
{
	if (!Main.dayTime)
	{
	
	if (!Main.bloodMoon)
	{
	int closeTownNPCs = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(Main.player[playerID].position,Main.npc[num36].position) < 1500)
	{
	closeTownNPCs++;
	}
	}
	if (closeTownNPCs == 1 && Main.rand.Next(3) == 0) return false;
	if (closeTownNPCs == 2 && Main.rand.Next(2) == 0) return false;
	if (closeTownNPCs == 3 && Main.rand.Next(3) <= 1) return false;
	if (closeTownNPCs >= 4) return false;
	}
	
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && (y >= Main.rockLayer) && (y <= Main.rockLayer *25);

	if (surface && Main.rand.Next(50) == 0)
	{
	Main.NewText("The Guide orders Pizza.", 175, 75, 255);
	return true;
	}
	}
	return false;
}

public void AI()
{
	for (int i=-1; i<=1; i++)
	{
		if (Main.tile[(int)(npc.Center.X/16f)+i,(int)(npc.Center.Y/16f)].type == 10)
		{
			bool flag6 = WorldGen.OpenDoor((int)(npc.Center.X/16f)+i, (int)(npc.Center.Y/16f), npc.direction);
			if (Main.netMode == 2 && flag6)
			{
				NetMessage.SendData(19, -1, -1, "", 0, (float)((int)(npc.Center.X/16f)+i), (float)((int)(npc.Center.Y/16f)), (float)npc.direction, 0);
			}
		}
	}
	npc.AI(true);
}