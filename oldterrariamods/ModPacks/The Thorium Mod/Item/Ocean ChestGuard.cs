public static void SetBonus(Player player) {
	if (player.breath < player.breathMax - 1)
		{
			player.breath = player.breathMax - 1;
		}
	player.ShadowAura = true;
}
