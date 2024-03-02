public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.player[playerID].zoneMeteor)
    {
	   if( Main.rand.Next(8)==1) return true;
    return false;
    }
return false;
}