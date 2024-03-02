public void UseItem(Player player, int playerID)
{
	if (player.inventory[player.selectedItem].type == Config.itemDefs.byName["Greater Life Crystal"].type && player.itemAnimation > 0 && player.statLifeMax < 1000 && player.itemTime == 0)
	{
		if (player.statLifeMax <= 900)
		{
			player.statLife += 100;
			player.statLifeMax += 100;
		}
		else if (player.statLifeMax > 900)
		{
			player.statLife += 100;
			player.statLifeMax = 1000;
		}
		if (Main.myPlayer == player.whoAmi)
		{
			player.HealEffect(100);
		}
	}
}
public bool CanUse(Player player, int pID)
{
	if (player.statLifeMax >= 1000)
	{
		return false;
	}
	else return true;
}