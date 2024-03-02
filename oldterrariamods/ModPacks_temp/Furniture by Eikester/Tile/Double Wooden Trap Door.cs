
public void hitWire(int x, int y)
{
	ushort tileClosed = (ushort)Config.tileDefs.ID["Double Wooden Trap Door Closed"];
	ushort tileOpened = (ushort)Config.tileDefs.ID["Double Wooden Trap Door Opened"];
	
	Tile tile = Main.tile[x, y];
	
	if(tile.type == tileClosed)
	{
		if(tile.frameX == 0 && tile.frameY == 0)
		{
			Main.tile[x , y].type = tileOpened;
			Main.tile[x + 1, y].type = tileOpened;
			
			if(Main.netMode != 0)
			{
				NetMessage.SendTileSquare(-1, x, y, 1);
				NetMessage.SendTileSquare(-1, x + 1, y, 1);
			}
		}
		if(tile.frameX == 18 && tile.frameY == 0)
		{
			Main.tile[x , y].type = tileOpened;
			Main.tile[x - 1, y].type = tileOpened;
			
			if(Main.netMode != 0)
			{
				NetMessage.SendTileSquare(-1, x, y, 1);
				NetMessage.SendTileSquare(-1, x - 1, y, 1);
			}
		}
	}
	else if(tile.type == tileOpened)
	{
		if(tile.frameX == 0 && tile.frameY == 0)
		{
			Main.tile[x , y].type = tileClosed;
			Main.tile[x + 1, y].type = tileClosed;
			
			if(Main.netMode != 0)
			{
				NetMessage.SendTileSquare(-1, x, y, 1);
				NetMessage.SendTileSquare(-1, x + 1, y, 1);
			}
		}
		if(tile.frameX == 18 && tile.frameY == 0)
		{
			Main.tile[x , y].type = tileClosed;
			Main.tile[x - 1, y].type = tileClosed;
			
			if(Main.netMode != 0)
			{
				NetMessage.SendTileSquare(-1, x, y, 1);
				NetMessage.SendTileSquare(-1, x - 1, y, 1);
			}
		}
	}
}