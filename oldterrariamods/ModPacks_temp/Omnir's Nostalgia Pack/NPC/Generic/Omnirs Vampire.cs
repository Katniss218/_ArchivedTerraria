//Spawns during Blood moons or in the Dungeon.

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
    if (!Main.hardMode)
    {
	    if (Main.bloodMoon && Main.rand.Next(500)==1) return true;
	    else if (Main.player[playerID].townNPCs <= 0f && Main.player[playerID].zoneDungeon && Main.rand.Next(800)==1) return true;
        return false;
    }
    else if (Main.hardMode)
    {
	    if (Main.bloodMoon && Main.rand.Next(5)==1) return true;
	    else if (Main.player[playerID].townNPCs <= 0f && Main.player[playerID].zoneDungeon && Main.rand.Next(30)==1) return true;
	    return false;
    }
    return false;
}
#endregion
