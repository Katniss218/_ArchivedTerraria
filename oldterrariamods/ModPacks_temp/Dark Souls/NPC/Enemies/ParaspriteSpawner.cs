public static bool SpawnNPC(int x, int y, int playerID)
{
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = !sky && (y <= Main.worldSurface);
	bool underground = !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = (y >= Main.rockLayer) && (y <= Main.rockLayer *25);
	bool undergroundJungle = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneHoly;

	if (undergroundHoly && Main.player[playerID].zoneHoly && Main.rand.Next(10) == 0)
	{
	return true;
	}

	if (Main.hardMode && sky && Main.rand.Next(5) == 0)
	{
	return true;
	}

	return false;
}








public void AI()
{
	int Random = Main.rand.Next(6);
	int Paraspawn = 0;
	if (Random == 0) Paraspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Parasprite", 0);
	if (Random == 1) Paraspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Parasprite2", 0);
	if (Random == 2) Paraspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Parasprite3", 0);
	Main.npc[Paraspawn].velocity.X = npc.velocity.X;
	npc.active = false;
}