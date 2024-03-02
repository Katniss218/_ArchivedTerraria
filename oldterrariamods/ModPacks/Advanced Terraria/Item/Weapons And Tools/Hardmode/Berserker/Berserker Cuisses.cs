public void Effects(Player player) {
	player.moveSpeed += 0.2f;
	player.fireWalk = true;
	player.doubleJump = true;
	player.statManaMax2 += 40;
	player.starCloak = true;
	player.meleeCrit -= 5;
	player.magicCrit -= 5;
	player.rangedCrit -= 5;
}
