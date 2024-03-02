public static void Effects(Player player)
{
	bool Spawned = false;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Zoodle's Meat Boy"].type && Main.npc[num36].ai[0] == player.whoAmi)
	{
		Spawned = true;
	}
	}
	if (!Spawned)
	{
	int Bobby = NPC.NewNPC((int) player.position.X+(player.width/2), (int) player.position.Y+(player.height/2), "Zoodle's Meat Boy", 0);
    Main.npc[Bobby].ai[0] = player.whoAmi;
	Main.npc[Bobby].netUpdate = true;
	if (Main.netMode == 2 && Bobby < 200)
	{
	NetMessage.SendData(23, -1, -1, "", Bobby, 0f, 0f, 0f, 0);
	}
	}
}