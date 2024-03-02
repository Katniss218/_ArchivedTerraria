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
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Ultrablivion Head"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Desert Beak"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Cataryst"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Armageddon Slime"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Dragon Lord Head"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["King Sting"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Mechasting"].type);
    NPC.SpawnOnPlayer(playerID, 4);
    NPC.SpawnOnPlayer(playerID, 35);
    NPC.SpawnOnPlayer(playerID, 13);
    NPC.SpawnOnPlayer(playerID, 50);
    NPC.SpawnOnPlayer(playerID, 125);
    NPC.SpawnOnPlayer(playerID, 126);
    NPC.SpawnOnPlayer(playerID, 127);
    NPC.SpawnOnPlayer(playerID, 134);
    Main.PlaySound(15, -1, -1, 0);
}
