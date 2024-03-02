public void Effects(Player player) {
	player.moveSpeed += 0.15f;
	player.pStone = true;
	player.statManaMax2 += 80;
}

public void SetBonus(Player player) {
	player.setBonus = "5 defense and increased stats";
	player.statDefense += 5;
	player.moveSpeed += 0.05f;
	player.magicDamage += 0.05f;
	player.meleeDamage += 0.05f;
	player.rangedDamage += 0.05f;
	player.lavaImmune = true;
}