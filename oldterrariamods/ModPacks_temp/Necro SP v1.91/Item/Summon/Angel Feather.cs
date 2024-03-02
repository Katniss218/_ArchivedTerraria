public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (player.zoneHoly) canuse = true;
	else
	{
		canuse = false;
	}
	return canuse;
}

public void UseItem(Player player, int playerID)
{
    if (player.zoneHoly)
    {
	NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Arch Angel"].type);
    }
}