public static void Effects(Player player) 
{
    player.breath += 3;
	if (player.breath > player.breathMax)
	{
		player.breath = player.breathMax;
	}
    player.breathCD = 0;
}