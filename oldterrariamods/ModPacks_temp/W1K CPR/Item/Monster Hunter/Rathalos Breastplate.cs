public static void Effects(Player player) {
	player.meleeDamage += 0.10f;
	player.moveSpeed += 0.05f;
}

public static void SetBonus(Player player) {
	player.setBonus = "+20% Melee Damage, +10% Melee Speed";
	player.meleeDamage += 0.20f;
	player.meleeSpeed += 0.10f;
}