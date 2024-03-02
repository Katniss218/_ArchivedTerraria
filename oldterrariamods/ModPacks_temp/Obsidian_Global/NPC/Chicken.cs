public static bool SpawnNPC(int x, int y, int playerID) {
	if (!Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 5.0)) && Main.rand.Next(2)==1) return true;
    return false;
}

