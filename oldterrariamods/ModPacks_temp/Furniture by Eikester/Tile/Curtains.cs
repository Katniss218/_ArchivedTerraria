public void KillTile(int x, int y, Player player)
{
	int index = 0;
	
	if(Main.tile[x, y].frameNumber == 0)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Red Curtains"].type);
	}
	else if(Main.tile[x, y].frameNumber == 1)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Orange Curtains"].type);
	}
	else if(Main.tile[x, y].frameNumber == 2)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Yellow Curtains"].type);
	}
	else if(Main.tile[x, y].frameNumber == 3)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Green Curtains"].type);
	}
	else if(Main.tile[x, y].frameNumber == 4)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Purple Curtains"].type);
	}
	else if(Main.tile[x, y].frameNumber == 5)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Blue Curtains"].type);
	}
	else if(Main.tile[x, y].frameNumber == 6)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Pink Curtains"].type);
	}
	else if(Main.tile[x, y].frameNumber == 7)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Black Curtains"].type);
	}
	
	if(Main.netMode != 0)
	{
		NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
	}
}