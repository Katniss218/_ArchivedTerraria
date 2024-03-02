public static void SetBonus(Player player) {
	player.setBonus = "+10% Ranged Damage, +10% Movement Speed, +6 Ranged Crit";
    player.rangedDamage += 0.10f;
    player.rangedCrit += 6;
    player.moveSpeed *= 10;
    
}