#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Medusa Spawner"].type)
	{
	return false;
	}
	}
	if (Main.hardMode && Main.player[playerID].zoneDungeon && Main.rand.Next(5) == 0)
	{
	return true;
	}
	return false;

    int closeTownNPCs = 0;
    if (!Main.bloodMoon)
    {
    Vector2 playerPosition = Main.player[playerID].position + new Vector2(Main.player[playerID].width/2,Main.player[playerID].height/2);
    for (int num36 = 0; num36 < 200; num36++)
    {
    Vector2 npcPosition = Main.npc[num36].position + new Vector2(Main.npc[num36].width/2,Main.npc[num36].height/2);
    if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(playerPosition,npcPosition) < 1500)
    {
    closeTownNPCs++;
    }
    }
    }
    if (closeTownNPCs == 1 && Main.rand.Next(3) == 0) return false;
    if (closeTownNPCs == 2 && Main.rand.Next(2) == 0) return false;
    if (closeTownNPCs == 3 && Main.rand.Next(3) <= 1) return false;
    if (closeTownNPCs >= 4) return false;
}
#endregion

#region AI
public void AI()
{
	npc.ai[0] = Main.rand.Next(7,9);
	for (int num36 = 0; num36 < npc.ai[0]; num36++)
	{
		NPC.NewNPC((int) npc.position.X+(npc.width/2)+Main.rand.Next(-100,100), (int) npc.position.Y+(npc.height/2)+Main.rand.Next(-100,100), "Medusa", 0);
	}
    {
		NPC.NewNPC((int) npc.position.X+(npc.width/2)+Main.rand.Next(-100,100), (int) npc.position.Y+(npc.height/2)+Main.rand.Next(-100,100), "Medusa", 0);
	}
	npc.active = false;
}
#endregion