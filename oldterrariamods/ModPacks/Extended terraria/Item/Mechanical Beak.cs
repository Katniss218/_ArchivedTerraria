public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (!Main.dayTime) canuse = true;
	else
	{
		canuse = false;
	}
	if (NPC.AnyNPCs(Config.npcDefs.byName["Steelfang"].type)) canuse = false;
	return canuse;
}

public void UseItem(Player player, int playerID) { 
    if (Main.dayTime == false) {
	NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Steelfang"].type);
        Main.PlaySound(15, -1, -1, 0);
    }
}
