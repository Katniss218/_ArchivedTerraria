public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].zone["Tropics"] && !Main.player[playerID].zone["Hell"] && Main.hardMode && ModWorld.superHardmode && Main.rand.Next(4) == 0)
	{
		return true;
	}
	else return false;
}