public void KillTile(int x, int y, Player player)
{
	Vector2 pos = new Vector2(x,y);
	int index = 0;

	if (Config.tileDefs.code.ContainsKey(pos))
	{
		Config.tileDefs.code.Remove(pos);
	}
	
	if(Main.tile[x, y].frameNumber == 0)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 28, 28, (int)Config.itemDefs.byName["Cobalt Shield"].type);
	}
	else if(Main.tile[x, y].frameNumber == 1)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 28, 28, (int)Config.itemDefs.byName["Obsidian Shield"].type);
	}
	else if(Main.tile[x, y].frameNumber == 2)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 28, 28, (int)Config.itemDefs.byName["Sorcerer Emblem"].type);
	}
	else if(Main.tile[x, y].frameNumber == 3)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 28, 28, (int)Config.itemDefs.byName["Warrior Emblem"].type);
	}
	else if(Main.tile[x, y].frameNumber == 4)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 28, 28, (int)Config.itemDefs.byName["Ranger Emblem"].type);
	}
	
	if(Main.netMode != 0)
	{
		NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
	}
}