public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && Main.player[playerID].zoneHoly)
	{

	int closeTownNPCs = 0;
	if (!Main.bloodMoon)
	{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(Main.player[playerID].position,Main.npc[num36].position) < 1500)
	{
	closeTownNPCs++;
	}
	}
	}
	if (closeTownNPCs == 1 && Config.syncedRand.Next(3) == 0) return false;
	if (closeTownNPCs == 2 && Config.syncedRand.Next(2) == 0) return false;
	if (closeTownNPCs == 3 && Config.syncedRand.Next(3) <= 1) return false;
	if (closeTownNPCs >= 4) return false;

	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = !sky && (y <= Main.worldSurface);

	if (surface && Config.syncedRand.Next(25) == 0)
	{
	return true;
	}
	}
	return false;
}

public void AI()
{
	if (Main.netMode != 1)
	{
		int Random = Config.syncedRand.Next(3);
		int Paraspawn = 0;
		if (Random == 0) Paraspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Parasprite", 0);
		if (Random == 1) Paraspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Parasprite2", 0);
		if (Random == 2) Paraspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Parasprite3", 0);
		Main.npc[Paraspawn].velocity.X = npc.velocity.X;
		if (Main.netMode == 2 && Paraspawn < 200)
		{
			NetMessage.SendData(23, -1, -1, "", Paraspawn, 0f, 0f, 0f, 0);
		}
	}
	npc.active = false;
}