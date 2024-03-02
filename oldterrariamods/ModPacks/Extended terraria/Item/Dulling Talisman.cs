/*public void Effects(Player player)
{
	float num30 = 1f;
	float num31 = (float)player.statLifeMax / 1100f * 0.85f + 0.15f;
	num30 *= num31;
	player.lifeRegen += (int)Math.Round((double)num30);
	player.lifeRegenCount += player.lifeRegen;
	while (player.lifeRegenCount >= 500)
	{
		player.lifeRegenCount -= 500;
		if (player.statLife < player.statLifeMax)
		{
			player.statLife++;
		}
		if (player.statLife > player.statLifeMax)
		{
			player.statLife = player.statLifeMax;
		}
	}
	player.statDefense += 10;
}*/