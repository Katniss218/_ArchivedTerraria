public static bool SpawnNPC(int X, int Y, int playerID)
{
    //if(Y >= Main.rockLayer) return false; //this is for being above the grey background
    if(Main.tile[X,Y].type != 53) return false; //this means 'if the tile you spawn on is not sand , dont spawn'
    if(Main.tile[X,Y-1].liquid == 0) return false; //this means if there is no water above , don't spawn
    if (Main.rand.Next(15) == 0)
    {
        NPC.NewNPC(X * 16 + 8, Y * 16, 65, 0);
    }
    if (Main.rand.Next(10) == 0)
    {
        NPC.NewNPC(X * 16 + 8, Y * 16, 67, 0);
    }
    else
    {
        NPC.NewNPC(X * 16 + 8, Y * 16, 64, 0);
    }
    return false;
}


