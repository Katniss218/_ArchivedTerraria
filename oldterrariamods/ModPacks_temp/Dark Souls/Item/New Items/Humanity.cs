public void UseItem(Player player, int playerID)
{
	if (player.inventory[player.selectedItem].type == Config.itemDefs.byName["Humanity"].type && player.itemAnimation > 0 && player.statLifeMax < 400 && player.itemTime == 0)
	{
		if (player.statLifeMax <= 380)
		{
			player.statLife += 20;
			player.statLifeMax += 20;
		}
		else if (player.statLifeMax > 380)
		{
			player.statLife += 20;
			player.statLifeMax = 400;
		}
		if (Main.myPlayer == player.whoAmi)
		{
			player.HealEffect(20);
		}
	}
}
public bool CanUse(Player player, int pID)
{
	if (player.statLifeMax >= 400)
	{
		return false;
	}
	else return true;
}