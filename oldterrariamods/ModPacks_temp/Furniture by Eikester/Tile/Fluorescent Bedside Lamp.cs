public void hitWire(int x, int y)
{
	Tile tile = Main.tile[x, y];
	
	if (Main.tile[x,y].frameNumber == 0)
	{
		Main.tile[x,y].frameNumber=1;
		Main.tile[x,y].frameX=18;
	}
	else
	{
		Main.tile[x,y].frameNumber=0;
		Main.tile[x,y].frameX=0;
	}
	
	if(Main.netMode != 0)
	{
		NetMessage.SendTileSquare(-1, x, y, 1);
	}
}

public void AddLight(int i, int j, ref float R, ref float G, ref float B)
{
	if(Main.tile[i, j].frameNumber == 0)
	{
		R = 0.9f;
		G = 0.95f;
		B = 1.0f;
	}
}