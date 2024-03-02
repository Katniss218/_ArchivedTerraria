public void UseTile(Player player, int x, int y)
{
	bool flag = false;
	
	if(Main.tile[x, y].frameNumber == 0)
	{
		foreach(Item item in Main.player[Main.myPlayer].inventory)
		{
			if(item.type == Config.itemDefs.byName["Book"].type)
			{
				item.stack -= 1;
				flag = true;
				while(Main.tile[x, y].frameX > 0)x--;
				break;
			}
		}
	}
	else if(Main.tile[x, y].frameNumber == 1)
	{
		while(Main.tile[x, y].frameX > 54)x--;
		int index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Book"].type);
		flag = true;
		
		if(Main.netMode != 0)
		{
			NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
		}
	}
	
	if(flag == false)
		return;
	
	byte offset = 0;
	byte f = 0;
	
	for(int i = 0; i < 3; i++)
	{
		for(int j = 0; j < 4; j++)
		{
			if(Main.tile[i + x, j + y].frameNumber == 0)
			{
				f = 1;
				offset = 3;
			}
			else if(Main.tile[i + x, j + y].frameNumber == 1)
			{
				f = 0;
				offset = 0;
			}
			
			Main.tile[i + x, j + y].frameNumber = f;
			Main.tile[i + x, j + y].frameX = (short)((offset + i) * 18);
			Main.tile[i + x, j + y].frameY = (short)(j * 18);
			
			if(Main.netMode != 0)
				NetMessage.SendTileSquare(-1, i + x, j + y, 1);
		}
	}
}

public void KillTile(int x, int y, Player player)
{
	int index = 0;

	if(Main.tile[x, y].frameNumber == 1)
	{
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Book"].type);
	}
	
	if(Main.netMode != 0)
	{
		NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
	}
}

public void AddLight(int i, int j, ref float R, ref float G, ref float B)
{
	R = 0.9f;
	G = 0.95f;
	B = 1.0f;
}