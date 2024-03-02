public static void SetBonus(Player player) {
	player.setBonus = "20% increase in Damage!";
	player.ShadowAura = true;
	player.meleeDamage += 0.20f;
	player.magicDamage += 0.20f;
	player.rangedDamage += 0.20f;
}

public static void Effects(Player player) {
	player.noKnockback = true;
	player.fireWalk = true;
}