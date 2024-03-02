public static void Effects(Player player) {
	player.rangedDamage += 0.10f;
    player.rangedCrit += 10;
}

public static void SetBonus(Player player) {
	player.setBonus = "20% Increased Ranged Damage and Ranged Crit chance";
	player.rangedDamage += 0.20f;
    player.rangedCrit += 20;
}