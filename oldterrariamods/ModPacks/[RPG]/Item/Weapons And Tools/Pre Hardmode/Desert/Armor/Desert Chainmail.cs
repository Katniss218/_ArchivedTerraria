public void Effects(Player player) {
	player.manaCost -= 0.05f;
	player.statManaMax2 += 20;
}

public void SetBonus(Player player) {
	player.setBonus = "15% increased magic damage";
	player.magicDamage += 0.15f;
}