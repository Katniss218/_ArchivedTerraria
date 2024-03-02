public static void Effects(Player player)
{
    bool Spawned = false;
    for (int num36 = 0; num36 < 200; num36++)
    {
    if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Miakoda"].type && Main.npc[num36].ai[0] == player.whoAmi)
    {
        Spawned = true;
    }
    }
    if (!Spawned)
    {
    int Miakoda = NPC.NewNPC((int) player.position.X+(player.width/2), (int) player.position.Y+(player.height/2), "Miakoda", 0);
    Main.npc[Miakoda].ai[0] = player.whoAmi;
    Main.npc[Miakoda].netUpdate = true;
    if (Main.netMode == 2 && Miakoda < 200)
    {
    NetMessage.SendData(23, -1, -1, "", Miakoda, 0f, 0f, 0f, 0);
    }
    }
}