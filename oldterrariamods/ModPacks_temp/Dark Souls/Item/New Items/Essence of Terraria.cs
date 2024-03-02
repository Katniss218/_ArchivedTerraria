public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (!Main.dayTime) canuse = true;
	else
	{
		canuse = false;
	}
	
	return canuse;
}

public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Water Fiend Kraken"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Blight"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Gwyn"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Attraidies"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Dark Cloud"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Chaos"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Wyvern Mage Shadow"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Serris Head"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Jungle Wyvern Head"].type);
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Aquatix"].type);
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
