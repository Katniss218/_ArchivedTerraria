public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (!Main.dayTime)
	{
		if (!NPC.downedBoss3) canuse = false;
		else canuse = true;
	}
	else
	{
		canuse = false;
	}
	return canuse;
}

public void UseItem(Player player, int playerID) { 
	if (!Main.dayTime)
	{
		NPC.SpawnOnPlayer(playerID, 35);
		Main.PlaySound(15, -1, -1, 0);
	}
}
