public void UseItem(Player player, int playerID)
{
	if (player.inventory[player.selectedItem].type == Config.itemDefs.byName["Life Fruit"].type && player.itemAnimation > 0 && player.itemTime == 0)
	{
		if (player.statLifeMax == 400)
		{
			player.statLifeMax += 10;
			player.statLife += 10;
		}
		if (Main.myPlayer == player.whoAmi)
		{
			player.HealEffect(10);
		}
	}
}
