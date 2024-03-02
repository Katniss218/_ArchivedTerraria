public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (player.zoneEvil && Main.hardMode) canuse = true;
	else
	{
		canuse = false;
	}
	if (NPC.AnyNPCs(Config.npcDefs.byName["Armageddon Slime"].type)) canuse = false;
	return canuse;
}

public void UseItem(Player player, int playerID)
{
    if (player.zoneEvil && Main.hardMode)
    {
	NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Armageddon Slime"].type);
        Main.PlaySound(15, -1, -1, 0);
    }
}
