public void NPCLoot()
{
	NPC n = npc;
	int nX = (int)n.position.X;
	int nY = (int)n.position.Y;
	bool noSpecialBiome = !Main.player[Main.myPlayer].zoneJungle && !Main.player[Main.myPlayer].zoneEvil && !Main.player[Main.myPlayer].zoneHoly && !Main.player[Main.myPlayer].zoneMeteor && !Main.player[Main.myPlayer].zoneDungeon;
	bool sky = noSpecialBiome && ((int)Main.player[Main.myPlayer].position.Y  / 16 < Main.worldSurface * 0.44999998807907104);
	bool surface = !sky && ((int)Main.player[Main.myPlayer].position.Y / 16 <= Main.worldSurface); 
	bool ocean = surface && ((int)Main.player[Main.myPlayer].position.X  / 16 < 250 || (int)Main.player[Main.myPlayer].position.X  / 16 > Main.maxTilesX - 250);
	bool desert = (Main.sandTiles >= 1001);
	bool underWorld = ((int)Main.player[Main.myPlayer].position.Y / 16 > Main.maxTilesY-190);
	if (surface && Main.rand.Next(50) == 0)
	{
		Item.NewItem(nX, nY, n.width, n.height, "Summon Slogra and Gaibon", 1, false, 0);
	}
}