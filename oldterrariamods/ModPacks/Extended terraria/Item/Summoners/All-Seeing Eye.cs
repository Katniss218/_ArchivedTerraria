public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (player.zoneHoly) canuse = true;
	else
	{
		canuse = false;
	}
	if (NPC.AnyNPCs(Config.npcDefs.byName["Cataryst"].type)) canuse = false;
	return canuse;
}

public void UseItem(Player player, int playerID)
{
    if (player.zoneHoly)
    {
	NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Cataryst"].type);
        Main.PlaySound(15, -1, -1, 0);
    }
}
