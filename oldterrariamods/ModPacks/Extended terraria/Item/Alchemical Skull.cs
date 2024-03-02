public void Effects(Player player) {
	player.waterWalk = true;
	player.enemySpawns = true;
	player.thorns = true;
	player.statDefense += 4;
}

public string[] Accessory()
{
    return new string[] {"6","7","8"};
}
