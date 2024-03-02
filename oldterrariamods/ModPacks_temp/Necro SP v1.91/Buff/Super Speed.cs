public static void Effects(Player player, int buffIndex, int buffType, int buffTime) {
	player.moveSpeed += 0.8f;
	player.meleeSpeed += 0.5f;
	player.jumpBoost = true;
}