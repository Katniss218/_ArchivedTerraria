public void Effects(Player player) {
	player.meleeDamage += 0.1f;
	player.meleeSpeed += 0.1f;
}

public void SetBonus(Player player) {
	player.setBonus = "20% increased melee speed";
	player.meleeSpeed += 0.2f;
	player.pickSpeed += 0.2f;
}