public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (Main.player[Main.myPlayer].zoneEvil) canuse = true;
	else
	{
		canuse = false;
	}
	if (NPC.AnyNPCs(Config.npcDefs.byName["Mechanical Seiryu Head"].type)) canuse = false;
	return canuse;
}

public void UseItem(Player player, int playerID)
{
    if (Main.player[Main.myPlayer].zoneEvil)
    {
	NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Mechanical Seiryu Head"].type);
        Main.PlaySound(15, -1, -1, 0);
    }
}
