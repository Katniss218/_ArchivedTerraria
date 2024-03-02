public static void Effects(Player player) 
{
	player.lifeRegenTime = 0;
	player.lifeRegen = -11;
	for (int j = 0; j < 6; j++)
	{
		int dust = Dust.NewDust(player.position, player.width -20, player.height, 5, 0, 0, 50, Color.White, 1.0f);
		Main.dust[dust].noGravity = true;

		int dust2 = Dust.NewDust(player.position, player.width - 20, player.height, 5, 0, 0, 50, Color.White, 1.0f);
		Main.dust[dust2].noGravity = true;
	}
}
