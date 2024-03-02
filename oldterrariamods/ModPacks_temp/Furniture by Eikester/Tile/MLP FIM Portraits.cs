public void UseTile(Player player, int x, int y)
{
	Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
	
	string text = "";
	byte r = 255;
	byte g = 255;
	byte b = 255;
	
	if(tile.frameNumber == 0)
	{
		switch(Main.rand.Next(6))
		{
			case 0: text = "Okey dokey lokey!"; break;
			case 1: text = "Well, quit it! You'd better think before you laugh at the Pink...ie Pie!"; break;
			case 2: text = "FOREVERRRR!"; break;
			case 3: text = "You look like you'd be good at eating cupcakes! "; break;
			case 4: text = "Hold on a second! Eternal chaos comes with chocolate rain, guys! Chocolate rain! "; break;
			case 5: text = "Too old for free candy?! NEVER! "; break;
			case 6: text = "I never leave home without my party cannon! "; break;
		}

		r = 248; 
		g = 185; 
		b = 205;
	}
	
	if(tile.frameNumber == 4)
	{
		switch(Main.rand.Next(2))
		{
			case 0: text = "I can clear the Sky in 10 seconds flat."; break;
			case 1: text = "It needs to be 20% cooler."; break;
		}
		
		r = 158;
		g = 217;
		b = 247;
	}
	
	if(tile.frameNumber == 2)
	{
		switch(Main.rand.Next(3))
		{
			case 0: text = "What da Hay.."; break;
			case 1: text = "What in tarnation!"; break;
			case 2: text = "Don't you use your fancy mathematics to muddy the issue! "; break;
		}
		
		r = 252;
		g = 187;
		b = 95;
	}
	
	if(tile.frameNumber == 5)
	{
		switch(Main.rand.Next(3))
		{
			case 0: text = "All the ponies in this town are CRAZY!"; break;
			case 1: text = "Get back! All of you! This is my book. And I'm going to READ IT! "; break;
			case 2: text = "I'm going to do what I do best: lecture her! "; break;
		}
		
		r = 202;
		g = 170;
		b = 209;
	}
	
	if(tile.frameNumber == 3)
	{
		switch(Main.rand.Next(3))
		{
			case 0: text = "You're... GOING TO LOVE ME!!! "; break;
			case 1: text = "(squeak) "; break;
			case 2: text = "yay"; break;
		}
		
		r = 255;
		g = 247;
		b = 152;
	}
	
	if(tile.frameNumber == 1)
	{
		switch(Main.rand.Next(1))
		{
			case 0: text = "Out of all things that could happen, this is THE WORST POSSIBLE THING! "; break;
		}
		
		r = 238;
		g = 242;
		b = 245;
	}
	
	if(tile.frameNumber == 6)
	{
		switch(Main.rand.Next(1))
		{
			case 0: text = "Muffin..."; break;
		}
		
		r = 196;
		g = 201;
		b = 213;
	}
	
	Main.NewText(text, r, g, b);
}

public void KillTile(int x, int y, Player player)
{
	int index = 0;
	
	if(Main.tile[x, y].frameNumber == 0)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["MLP Portrait Pinkie Pie"].type);
	}
	else if(Main.tile[x, y].frameNumber == 1)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["MLP Portrait Rarity"].type);
	}
	else if(Main.tile[x, y].frameNumber == 2)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["MLP Portrait Applejack"].type);
	}
	else if(Main.tile[x, y].frameNumber == 3)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["MLP Portrait Fluttershy"].type);
	}
	else if(Main.tile[x, y].frameNumber == 4)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["MLP Portrait Rainbow Dash"].type);
	}
	else if(Main.tile[x, y].frameNumber == 5)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["MLP Portrait Twilight Sparkle"].type);
	}
	else if(Main.tile[x, y].frameNumber == 6)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["MLP Portrait Derpy"].type);
	}
	
	if(Main.netMode != 0)
	{
		NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
	}
}