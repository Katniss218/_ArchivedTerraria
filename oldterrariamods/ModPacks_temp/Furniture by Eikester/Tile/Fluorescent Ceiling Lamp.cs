public void hitWire(int x, int y)
{
	if(Main.tile[x, y].frameNumber == 0)
		while(Main.tile[x, y].frameX > 0)x--;
	else if(Main.tile[x, y].frameNumber == 1)
		while(Main.tile[x, y].frameX > 36)x--;
		
	while(Main.tile[x, y].frameY > 0)y--;
	
	byte offset = 0;
	byte f = 0;
	
	for(int i = 0; i < 2; i++)
	{
		for(int j = 0; j < 1; j++)
		{
			if(Main.tile[i + x, j + y].frameNumber == 0)
			{
				f = 1;
				offset = 2;
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

public void AddLight(int i, int j, ref float R, ref float G, ref float B)
{
	if(Main.tile[i, j].frameNumber == 0)
	{
		R = 0.9f;
		G = 0.95f;
		B = 1.0f;
	}
}