public static void Effects(Player player)
{
	bool Spawned = false;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Aku-Aku"].type && Main.npc[num36].ai[0] == player.whoAmi)
	{
		Spawned = true;
	}
	}
	if (!Spawned)
	{
	int Aku_Aku = NPC.NewNPC((int) player.position.X+(player.width/2), (int) player.position.Y+(player.height/2), "Aku-Aku", 0);
    Main.npc[Aku_Aku].ai[0] = player.whoAmi;
	Main.npc[Aku_Aku].netUpdate = true;
	if (Main.netMode == 2 && Aku_Aku < 200)
	{
	NetMessage.SendData(23, -1, -1, "", Aku_Aku, 0f, 0f, 0f, 0);
	}
	}
}