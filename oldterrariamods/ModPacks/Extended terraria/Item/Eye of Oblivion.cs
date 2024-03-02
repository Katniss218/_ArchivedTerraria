public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (!Main.dayTime) canuse = true;
	else
	{
		canuse = false;
	}
	if (NPC.AnyNPCs(Config.npcDefs.byName["Oblivion Phase 1"].type) || NPC.AnyNPCs(Config.npcDefs.byName["Oblivion Head 1"].type) || NPC.AnyNPCs(Config.npcDefs.byName["Oblivion Phase 1 Dead"].type)) canuse = false;
	return canuse;
}

public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Oblivion Phase 1"].type);
    Main.PlaySound(15, -1, -1, 0);
}
