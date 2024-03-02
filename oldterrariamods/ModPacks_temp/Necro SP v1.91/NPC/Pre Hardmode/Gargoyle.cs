#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].zoneDungeon && Main.rand.Next(10)==1) 
    return true;
	return false;
}
#endregion

