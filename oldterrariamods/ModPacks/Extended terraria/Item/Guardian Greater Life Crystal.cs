public void UseItem(Player player, int playerID)
{
	if (player.inventory[player.selectedItem].type == Config.itemDefs.byName["Guardian Greater Life Crystal"].type && player.itemAnimation > 0 && player.itemTime == 0)
	{
		if (player.statLifeMax == 800)
		{
			player.statLifeMax += 100;
			player.statLife += 100;
		}
		if (Main.myPlayer == player.whoAmi)
		{
			player.HealEffect(100);
		}
	}
}
public bool CanUse(Player player, int pID)
{
	return (player.statLifeMax == 800);
}