public static void SetBonus(Player player) {
	player.setBonus = "Your boots are glowing!";
	player.doubleJump = true;
	player.ShadowAura = true;
	player.ShadowTail = true;
	player.jumpBoost = true;
}

public static void Effects(Player player) {
	player.meleeCrit += 7;
	player.magicCrit += 7;
	player.rangedCrit += 7;
}