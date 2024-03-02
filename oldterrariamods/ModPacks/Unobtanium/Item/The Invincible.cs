public static void Effects(Player player) {
    player.meleeSpeed += 0.10f;
}

public static void SetBonus(Player player) {
	player.setBonus = "Boosts all statistics by 10%";
    player.meleeDamage += 0.10f;
    player.magicDamage += 0.10f;
    player.rangedDamage += 0.10f;
    player.rangedCrit += 10;
    player.meleeCrit += 10;
    player.magicCrit += 10;
    player.meleeSpeed += 0.10f;
    player.moveSpeed += 0.10f;
    player.manaCost -= 0.10f;
}