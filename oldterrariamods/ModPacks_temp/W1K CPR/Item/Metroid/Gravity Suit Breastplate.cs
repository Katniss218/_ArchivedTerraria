public static void Effects(Player player) {
	player.fireWalk = true;
	player.noKnockback = true;
}

public static void SetBonus(Player player) {
	player.setBonus = "+5 Defense, 'Obsidian Skin' effect added.";
	player.statDefense += 5;
	player.lavaImmune = true;
}