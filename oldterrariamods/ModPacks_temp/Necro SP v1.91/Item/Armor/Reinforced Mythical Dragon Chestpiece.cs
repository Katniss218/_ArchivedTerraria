public static void SetBonus(Player player) {
	player.setBonus = "-2% Mana Usage, +20% movement speed, Mana regen";
	player.manaCost -= 0.02f;
    player.moveSpeed += 0.20f;
    player.manaRegenBuff=true;
    player.ShadowAura = true;
}

