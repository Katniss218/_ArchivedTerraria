public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (Main.dayTime == false) canuse = true;
	else
	{
		canuse = false;
	}
	return canuse;
}

public void UseItem(Player player, int playerID) {
	player.AddBuff("Blood Moon", 36000, true);
}