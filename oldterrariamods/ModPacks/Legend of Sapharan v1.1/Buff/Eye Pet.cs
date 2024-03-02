public static void Effects(Player player)
{
	bool Spawned = false;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Eye Pet"].type && Main.npc[num36].ai[0] == player.whoAmi)
	{
		Spawned = true;
	}
	}
	if (!Spawned)
	{
	int Eye_Pet = NPC.NewNPC((int) player.position.X+(player.width/2), (int) player.position.Y+(player.height/2), "Eye Pet", 0);
    Main.npc[Eye_Pet].ai[0] = player.whoAmi;
	Main.npc[Eye_Pet].netUpdate = true;
	if (Main.netMode == 2 && Eye_Pet < 200)
	{
	NetMessage.SendData(23, -1, -1, "", Eye_Pet, 0f, 0f, 0f, 0);
	}
	}
}