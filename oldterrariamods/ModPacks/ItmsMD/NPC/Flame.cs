public static bool SpawnNPC(int x, int y, int playerID)
    {
    if ((y > Main.maxTilesY-190) && (Main.rand.Next(2)==0))
        {
        return true;
        } else
        {
        return false;
        }
    }