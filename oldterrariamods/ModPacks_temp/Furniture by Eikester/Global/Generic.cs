public static SpriteFont fontDigital;

public void OnLoad()
{
	fontDigital = TMod.Load<SpriteFont>("fontDigital");
	
	if(fontDigital == null)
	{
		fontDigital = Main.fontItemStack;
	}
}

public static bool CheckCoins(Player p, int value, int coinType = 72)
{
	foreach(Item item in p.inventory)
	{
		if(item.type == coinType && item.stack - value >= 0)
		{
			return true;
		}
	}
	return false;
}

public static void RemoveCoins(Player p, int value, int coinType = 72)
{
	int i = 0;
	foreach(Item item in p.inventory)
	{
		if(item.type == coinType)
		{
			item.stack -= value;
			
			if(item.stack == 0)
				p.inventory[i] = new Item();
		}
		
		i++;
	}
}

public static bool HasPlaceFor(Player player, Item item) 
{
	if (player == null) 
		return false;
		
	if (item == null || item.name == null || item.name == "" || item.stack <= 0) 
		return true;
	
	int place = 0;
	for (int i = 0; i < 44; i++) 
	{
		if (player.inventory[i] == null || player.inventory[i].name == null || player.inventory[i].name == "" || player.inventory[i].stack <= 0)
		{
			place += item.maxStack;
		}
		else if (player.inventory[i].name == item.name) 
		{
			place += player.inventory[i].maxStack-player.inventory[i].stack;
		}
	}
	
	return place >= item.stack;
}

public static void GiveItem(Player player, Item item) 
{
	if (player == null) 
		return;
		
	if (item == null || item.name == null || item.name == "" || item.stack <= 0) 
		return;
	
	int give = item.stack;
	
	for (int i = 0; i < 44; i++) 
	{
		if (player.inventory[i].name == item.name) 
		{
			int diff = Math.Min(player.inventory[i].maxStack-player.inventory[i].stack,give);
			player.inventory[i].stack += diff;
			give -= diff;
		}
		if (give == 0) 
			break;
	}
	for (int i = 0; i < 44; i++) 
	{
		if (player.inventory[i] == null || player.inventory[i].name == null || player.inventory[i].name == "" || player.inventory[i].stack <= 0) 
		{
			int diff = Math.Min(item.maxStack,give);
			player.inventory[i].SetDefaults(item.name);
			player.inventory[i].stack = diff;
			give -= diff;
		}
		if (give == 0) 
			break;
	}
	
	Main.PlaySound(7,-1,-1,1);
}

public static string GetTime()
{
	string text12 = "AM";
	double num145 = Main.time;
	if (!Main.dayTime)
	{
		num145 += 54000.0;
	}
	num145 = num145 / 86400.0 * 24.0;
	double num146 = 7.5;
	num145 = num145 - num146 - 12.0;
	if (num145 < 0.0)
	{
		num145 += 24.0;
	}
	if (num145 >= 12.0)
	{
		text12 = "PM";
	}
	int num147 = (int)num145;
	double num148 = num145 - (double)num147;
	num148 = (double)((int)(num148 * 60.0));
	string text13 = string.Concat(num148);
	if (num148 < 10.0)
	{
		text13 = "0" + text13;
	}
	//if (num147 > 12)
	//{
	//	num147 -= 12;
	//}
	//if (num147 == 0)
	//{
	//	num147 = 12;
	//}
	
	string text11 = string.Concat(new object[]
	{
		num147, 
		":", 
		text13
	});
	
	return text11;
}