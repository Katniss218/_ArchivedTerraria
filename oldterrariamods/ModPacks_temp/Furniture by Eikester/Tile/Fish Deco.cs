public void KillTile(int x, int y, Player player)
{
	int index = 0;
	
	if(Main.tile[x, y].frameNumber == 0)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 22, 26, (int)Config.itemDefs.byName["Goldfish Deco"].type);
	}
	else if(Main.tile[x, y].frameNumber == 1)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 22, 26, (int)Config.itemDefs.byName["Angler Fish Deco"].type);
	}
	else if(Main.tile[x, y].frameNumber == 2)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 22, 26, (int)Config.itemDefs.byName["Piranha Deco"].type);
	}
	else if(Main.tile[x, y].frameNumber == 3)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 22, 26, (int)Config.itemDefs.byName["Corrupted Goldfish Deco"].type);
	}
	
	if(Main.netMode != 0)
	{
		NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
	}
}