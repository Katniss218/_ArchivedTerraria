public void Effects(Player player)
{
	if (player.lifeRegen - 3 <= 0) player.lifeRegen = 0;
	else player.lifeRegen -= 3;
}