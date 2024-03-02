public static void Effects(Player player) {
	player.fireWalk = true;
}

public static void SetBonus(Player player) {
	player.setBonus = "+10% Movement Speed, 'Obsidian Skin' effect added.";
	player.moveSpeed += 0.1f;
	player.lavaImmune = true;
}