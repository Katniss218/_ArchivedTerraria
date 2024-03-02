#region Loot
public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].zoneDungeon && Main.rand.Next(15)==1) 
    return true;
	return false;
}
#endregion
