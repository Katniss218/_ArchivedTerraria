public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.player[playerID].zoneDungeon)
    {
	   if( Main.rand.Next(10)==1) return true;
    return false;
    }
return false;
}

public void AI() {
	npc.TargetClosest();
	npc.netUpdate = false;
	if(npc.justHit) {
		NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Sludge",0);
	}
	npc.ai[1]++;
	if (npc.ai[1] >= 300 && Main.netMode != 1) {
		int Wandererspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Sludge", 0);
		npc.ai[1] = 20-Main.rand.Next(30);
		if (Main.netMode == 2 && Wandererspawn < 200) {
			NetMessage.SendData(23, -1, -1, "", Wandererspawn, 0f, 0f, 0f, 0);
		}
	}
}