int buy = 16;
string name = "Restoration Potion";

public void MouseOverTile(int x,int y,Player P)
{
    P.noThrow = 2;
    P.showItemIcon = true;
	
    P.showItemIcon2 = Config.itemDefs.byName["Silver Coin"].type;
}

public void UseTile(Player player, int x, int y)
{
	if(ModGeneric.CheckCoins(player, buy))
	{
		Item i = new Item();
		i.SetDefaults(Config.itemDefs.byName[name].type);
		i.stack = 1;
		
		if(ModGeneric.HasPlaceFor(player, i))
		{
			ModGeneric.GiveItem(player, i);
			ModGeneric.RemoveCoins(player, buy);
			Main.NewText("Bought 1 '" + name + "' for " + buy + " Silver Coins!");
		}
		else
		{
			Main.NewText("Your Inventory is to full!");
		}
	}
	else
	{
		Main.NewText("You don't have enough Money, 1 '" + name + "' costs " + buy + " Silver Coins!");
	}
}