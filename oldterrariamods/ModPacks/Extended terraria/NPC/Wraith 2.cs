public bool SpawnNPC(int x, int y, int playerID)
{
	if (ModWorld.WraithInvasion && Main.rand.Next(3) == 1) return true;
	else return false;
}