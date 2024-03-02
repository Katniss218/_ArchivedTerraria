#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.player[playerID].townNPCs <= 0f && !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 33.0)) && Main.player[playerID].position.Y > ((Main.worldSurface * 12)))
    {
	    if (Main.hardMode && Main.player[playerID].position.X < ((Main.worldSurface * 150.0)) && Main.player[playerID].position.X > ((Main.worldSurface * 130.0)) && Main.rand.Next(80)==1) return true;
	    else if (Main.hardMode && Main.player[playerID].position.X > ((Main.worldSurface * 160.0)) && Main.player[playerID].position.X < ((Main.worldSurface * 175.0)) && Main.rand.Next(80)==1) return true;
        else if (Main.hardMode && Main.rand.Next(40)==1) return true;
	    return false;
    }
    return false;
}
#endregion

#region AI
public void AI()
{
	npc.TargetClosest();
	npc.netUpdate = false;
	npc.ai[1]++;
	if (npc.ai[1] >= 900 && Main.netMode != 1)
	{
		int Boomerspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Boomer", 0);
		npc.ai[1] = 20-Main.rand.Next(20);
		if (Main.netMode == 2 && Boomerspawn < 200)
		{
			NetMessage.SendData(23, -1, -1, "", Boomerspawn, 0f, 0f, 0f, 0);
		}  
}
}	
#endregion