public static void Effects(Player player)
{
	bool Spawned = false;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Ivy Chao"].type && Main.npc[num36].ai[0] == player.whoAmi)
	{
		Spawned = true;
	}
	}
	if (!Spawned)
	{
	int Chao = NPC.NewNPC((int) player.position.X+(player.width/2), (int) player.position.Y+(player.height/2), "Ivy Chao", 0);
    Main.npc[Chao].ai[0] = player.whoAmi;
	Main.npc[Chao].netUpdate = true;
	if (Main.netMode == 2 && Chao < 200)
	{
	NetMessage.SendData(23, -1, -1, "", Chao, 0f, 0f, 0f, 0);
	}
	}
}