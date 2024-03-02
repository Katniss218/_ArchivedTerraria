public bool CanUse(Player player, int playerID)
{
	if ((player.position.Y*16 >= Main.rockLayer) && (player.position.Y*16 <= Main.rockLayer *25) && player.zoneJungle)
	{
	return true;
	}
	return false;
}

public void UseItem(Player player, int playerID)
{
if (Main.netMode != 1){
	int ivy = NPC.NewNPC((int)player.position.X, (int)player.position.Y, Config.npcDefs.byName["Ivy Plant"].type, 0);
	if (Main.netMode == 2 && ivy < 200)
	{
		NetMessage.SendData(23, -1, -1, "", ivy, 0f, 0f, 0f, 0);
	}
}
}