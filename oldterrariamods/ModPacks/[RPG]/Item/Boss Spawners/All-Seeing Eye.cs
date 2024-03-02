public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (player.zoneJungle) canuse = true;
	else
	{
		canuse = false;
	}
	if (NPC.AnyNPCs(Config.npcDefs.byName["Astigmatazer"].type)) canuse = false;
	return canuse;
}

public void UseItem(Player player, int playerID)
{
    if (player.zoneJungle)
    {
	NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Astigmatazer"].type);
        Main.PlaySound(15, -1, -1, 0);
    }
}
