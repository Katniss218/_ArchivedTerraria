public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (!Main.dayTime) canuse = true;
	else
	{
		canuse = false;
	}
	return canuse;
}
public void UseItem(Player player, int playerID) { 
	if (!Main.dayTime) {
		NPC.SpawnOnPlayer(playerID, Config.npcDefs.byName["Duress"].type);
		Main.PlaySound(15, -1, -1, 0);
	}
}
