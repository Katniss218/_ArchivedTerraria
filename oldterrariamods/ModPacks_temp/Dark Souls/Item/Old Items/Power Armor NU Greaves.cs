public static void Effects(Player player) {

	player.moveSpeed += 0.15f;
	player.meleeSpeed += 0.20f;
	player.waterWalk=true;
	player.fireWalk=true;
    	player.breath=10800;
	player.noKnockback = true;
	player.doubleJump = true;
	player.jumpBoost = true;
}
