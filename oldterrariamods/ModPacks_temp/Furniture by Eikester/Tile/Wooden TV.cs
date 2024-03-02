public float flicker = 0.0f;

public void MouseOverTile(int x,int y,Player P)
{
    P.noThrow = 2;
    P.showItemIcon = true;
	
    P.showItemIcon2 = Config.itemDefs.byName["Remote Control"].type;
	
	if(Main.mouseRight && Main.mouseRightRelease)
	{
		int z = Zapp();
		
		ZappTo(x,y,z);
	}
}

public void PlaceTile(int x, int y, int p)
{
	ModWorld.Achieve(0, "EIKESTER_TV");
}

public bool CheckTile(int x, int y)
{
	int w = Config.tileDefs.width[Main.tile[x, y].type];
	int h = Config.tileDefs.height[Main.tile[x, y].type];
	
	while(Main.tile[x, y].frameX > Main.tile[x, y].frameNumber * (18 * w))x--;
	while(Main.tile[x, y].frameY > 0)y--;
	
	for(int i = x; i < x + w; i++)
	{
		if(!Main.tile[i, y + h].active)
		{
			//WorldGen.KillTile(x, y);
			return false;
		}
	}
	return true;
}

public int Zapp()
{
	string text = "";
	
	int r = Main.rand.Next(5);
	
	switch(r)
	{
		case 0:
			text = "";
			break;
			
		case 1:
			text = "Hey, it's your favourite show! ...wait, you've already seen this episode.";
			break;
			
		case 2:
			text = "Nothing on but infomercials";
			break;
			
		case 3: 
			text = "Two and a half Terrarian";
			break;
			
		case 4:
			text = "Yippie-Ya-Yeah Mo..fucker";
			break;
	}

	if(text != "")
		Main.NewText(text, 200, 200, 200);
		
	return r;
}

public void ZappTo(int x, int y, int frame)
{
	int size = Config.tileDefs.width[Main.tile[x,y].type];
	
	while(Main.tile[x, y].frameX > Main.tile[x,y].frameNumber * (18 * size))x--;
		
	while(Main.tile[x, y].frameY > 0)y--;
	
	byte offset = 0;
	byte f = 0;
	
	for(int i = 0; i < 3; i++)
	{
		for(int j = 0; j < 2; j++)
		{
			f = (byte)frame;
			offset = (byte)(frame * 3);
			
			Main.tile[i + x, j + y].frameNumber = f;
			Main.tile[i + x, j + y].frameX = (short)((offset + i) * 18);
			Main.tile[i + x, j + y].frameY = (short)(j * 18);
			
			if(Main.netMode != 0)
				NetMessage.SendTileSquare(-1, i + x, j + y, 1);
		}
	}
}

public void hitWire(int x, int y)
{
	if(Main.tile[x, y].frameNumber == 0)
		while(Main.tile[x, y].frameX > 0)x--;
	else if(Main.tile[x, y].frameNumber == 1)
		while(Main.tile[x, y].frameX > 54)x--;
		
	while(Main.tile[x, y].frameY > 0)y--;
	
	byte offset = 0;
	byte f = 0;
	
	for(int i = 0; i < 3; i++)
	{
		for(int j = 0; j < 2; j++)
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

public void AddLight(int i, int j, ref float R, ref float G, ref float B)
{	
	if(Main.tile[i,j].frameNumber >= 1)
	{
		R = ((float)Main.rand.Next(60,80)/255f); 
		G = ((float)Main.rand.Next(60,80)/255f);
		B = ((float)Main.rand.Next(250,350)/255f);
	}
}