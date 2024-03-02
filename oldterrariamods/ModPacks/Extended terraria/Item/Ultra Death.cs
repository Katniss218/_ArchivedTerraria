public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (!Main.dayTime && ModWorld.superHardmode) canuse = true;
	else
	{
		canuse = false;
	}
	if (NPC.AnyNPCs(Config.npcDefs.byName["Ultrablivion Head"].type)) canuse = false;
	return canuse;
}

public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Ultrablivion Head"].type);
    ModWorld.SpawnNPCOnPlayerWithoutMessage(playerID, Config.npcDefs.byName["UltrOeyeL"].type);
    ModWorld.SpawnNPCOnPlayerWithoutMessage(playerID, Config.npcDefs.byName["UltrOeyeR"].type);
    Main.PlaySound(2, -1, -1, SoundHandler.soundID["Monster Roar 2"]);
}
