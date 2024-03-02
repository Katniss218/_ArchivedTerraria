public static bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.player[playerID].townNPCs <= 0f && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 16.0)) && Main.player[playerID].position.Y > ((Main.worldSurface * 6)))
    {
	    if (Main.player[playerID].position.X < ((Main.worldSurface * 45.0)) && Main.player[playerID].position.X > ((Main.worldSurface * 38.0)) && Main.rand.Next(60)==1) return true;
	    else if (Main.player[playerID].position.X > ((Main.worldSurface * 160.0)) && Main.player[playerID].position.X < ((Main.worldSurface * 167.0)) && Main.rand.Next(60)==1) return true;
	    else if (Main.hardMode && Main.rand.Next(6)==1) return true;
        return false;
    }
    return false;
}