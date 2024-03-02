public void UseItem(Player player, int playerID)
{
	if (player.inventory[player.selectedItem].type == Config.itemDefs.byName["Purging Stone"].type && player.itemAnimation > 0 && player.statLifeMax < 400 && player.itemTime == 0)
	{
		if (player.statLifeMax < 400)
		{
			player.statLifeMax = 400;
			
		}
		//if (player.statLifeMax == 400)
		//{
		//	player.statLife += 400;
		//}

		if (Main.myPlayer == player.whoAmi)
		{
			player.statLife += 400;
			player.HealEffect(400);
		}
	}

	 for(int num47 = 0; num47 < 10; num47++)
    {
        if (player.buffType[num47] == Config.buffID["Curse Buildup"])
        {
            player.buffType[num47] = 0;
            player.buffTime[num47] = 0;

            break;
        }
    }

	for(int num48 = 0; num48 < 10; num48++)
    {
        if (player.buffType[num48] == Config.buffID["Powerful Curse Buildup"])
        {
            player.buffType[num48] = 0;
            player.buffTime[num48] = 0;

            break;
        }
    }





}
public bool CanUse(Player player, int playerID) //was int pID
{
	if (player.statLifeMax >= 400)
	{
		return false;
	}
	else return true;
}