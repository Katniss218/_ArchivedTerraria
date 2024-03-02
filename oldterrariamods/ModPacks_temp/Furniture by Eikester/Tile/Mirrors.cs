public void UseTile(Player player, int x, int y)
{
	ModWorld.ChangeHair = !ModWorld.ChangeHair;
	
	ModWorld.currentMirrorPosition = new Vector2(x, y);
}

public void KillTile(int x, int y, Player player)
{
	int index = 0;
	
	if(Main.tile[x, y].frameNumber == 0)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Iron Mirror"].type);
	}
	else if(Main.tile[x, y].frameNumber == 1)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Copper Mirror"].type);
	}
	else if(Main.tile[x, y].frameNumber == 2)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Silver Mirror"].type);
	}
	else if(Main.tile[x, y].frameNumber == 3)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Gold Mirror"].type);
	}
	
	if(Main.netMode != 0)
	{
		NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
	}
}