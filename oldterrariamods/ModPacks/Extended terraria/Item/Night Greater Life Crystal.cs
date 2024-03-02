public void UseItem(Player player, int playerID)
{
	if (player.inventory[player.selectedItem].type == Config.itemDefs.byName["Night Greater Life Crystal"].type && player.itemAnimation > 0 && player.itemTime == 0)
	{
		if (player.statLifeMax == 520)
		{
			player.statLifeMax += 40;
			player.statLife += 40;
		}
		if (Main.myPlayer == player.whoAmi)
		{
			player.HealEffect(40);
		}
	}
}
public bool CanUse(Player player, int pID)
{
	return (player.statLifeMax == 520);
	/*if (player.statLifeMax > 600 || player.statLifeMax < 600)
	{
		return false;
	}
	else return true;*/
}