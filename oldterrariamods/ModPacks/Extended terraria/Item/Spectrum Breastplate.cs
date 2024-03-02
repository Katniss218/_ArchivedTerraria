public void Effects(Player player) {
	player.rangedDamage += 0.1f;
	player.rangedCrit += 3;
}

public void SetBonus(Player player) {
	player.setBonus = "7 defense and increased stats";
	player.rangedCrit += 1;
	player.magicCrit += 1;
	player.meleeCrit += 1;
	player.statDefense += 7;
	player.meleeDamage += 0.01f;
	player.magicDamage += 0.01f;
	player.rangedDamage += 0.01f;
	player.ShadowAura = true;
}