public static void SetBonus(Player player) {
	player.setBonus = "+5 Health Regen";
	player.lifeRegen +=5;
	player.ShadowAura = true;
	player.ShadowTail = true;
}

public static void Effects(Player player) {
	player.manaRegen +=2;
	player.magicDamage += 0.5f;
}