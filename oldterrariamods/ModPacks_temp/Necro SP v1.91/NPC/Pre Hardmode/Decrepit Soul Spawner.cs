#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
    bool oSky = (y < (Main.maxTilesY * 0.1f));
    bool oSurface = (y >= (Main.maxTilesY * 0.1f) && y < (Main.maxTilesY * 0.2f));
    bool oUnderSurface = (y >= (Main.maxTilesY * 0.2f) && y < (Main.maxTilesY * 0.3f));
    bool oUnderground = (y >= (Main.maxTilesY * 0.3f) && y < (Main.maxTilesY * 0.4f));
    bool oCavern = (y >= (Main.maxTilesY * 0.4f) && y < (Main.maxTilesY * 0.6f));
    bool oMagmaCavern = (y >= (Main.maxTilesY * 0.6f) && y < (Main.maxTilesY * 0.8f));
    bool oUnderworld = (y >= (Main.maxTilesY * 0.8f));
	if (Main.player[playerID].townNPCs > 0f || Main.player[playerID].zoneDungeon || Main.player[playerID].zoneJungle || Main.player[playerID].zoneMeteor) return false;
    if (((x > Main.maxTilesX*0.3f && x < Main.maxTilesX*0.4f) || (x > Main.maxTilesX*0.7f && x < Main.maxTilesX*0.8f)) && Main.rand.Next(10)==1) return true;
    if (oCavern && x > Main.maxTilesX*0.3f && x < Main.maxTilesX*0.7f && Main.rand.Next(20)==1) return true;
    return false;
}
#endregion

#region Mob Spawn
public void AI()
{
	npc.ai[0] = Main.rand.Next(7,9);
	for (int num36 = 0; num36 < npc.ai[0]; num36++)
	{
		NPC.NewNPC((int) npc.position.X+(npc.width/2)+Main.rand.Next(-100,100), (int) npc.position.Y+(npc.height/2)+Main.rand.Next(-100,100), "Decrepit Soul", 0);
	}
	npc.active = false;
}
#endregion