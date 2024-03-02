public static void SetBonus(Player player) {
	player.setBonus = "-5% Mana Usage, and +20% movement speed";
	player.manaCost -= 0.05f;
    player.moveSpeed += 0.20f;
}

