public void EffectsStart(Player player,int buffIndex,int buffType,int buffTime) 
{
	int LMetroid = NPC.NewNPC((int) player.position.X+(player.width/2), (int) player.position.Y+(player.height/2), "Thunder Bird", 0);
    Main.npc[LMetroid].ai[0] = player.whoAmi;
	Main.npc[LMetroid].ai[1] = buffIndex;
	Main.npc[LMetroid].netUpdate = true;
	if (Main.netMode == 2 && LMetroid < 200)
	{
	NetMessage.SendData(23, -1, -1, "", LMetroid, 0f, 0f, 0f, 0);
	}
}

public void Effects(Player player) {
	player.meleeCrit += 8;
	player.magicCrit += 8;
	player.rangedCrit += 8;
}