public int cooldown = 0;
public void Effects(Player player)
{
	cooldown++;
	if (cooldown > 20)
	{
		if (player.statLife < (int)(player.statLifeMax / 2) && player.statMana > 2)
		{
			player.statMana -= 2;
			player.statLife += 1;
		}
		if (player.statMana < 0) player.statMana = 0;
		cooldown = 0;
	}
}