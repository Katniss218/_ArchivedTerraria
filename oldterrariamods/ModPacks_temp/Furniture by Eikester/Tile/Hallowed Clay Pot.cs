int ticksRequired=1000;
static int minTicks = 1000; 
static int maxTicks = 1500; 
int ticks=0;
static int type = Config.tileDefs.ID["Hallowed Clay Pot"];
static int itemType = Config.itemDefs.byName["Daybloom"].type; // what item to drop
static int itemType2 = Config.itemDefs.byName["Daybloom Seeds"].type; // what item to drop
int x, y;

public int GetTicks()
{	
	return Main.rand.Next(minTicks, maxTicks);
}

public void Initialize(int _x, int _y)
{
	ticksRequired = GetTicks();
	ticks = 0;
	x = _x;
	y = _y;
}

public bool CheckTile(int x, int y)
{
	if(!Main.tile[x, y + 1].active)
	{
		return false;
	}
	return true;
}

public void UseTile(Player player, int x, int y)
{
	KillTile(x,y,player);
	// change frame back to 0
	GrowTo(x, y, 0);
}

public void KillTile(int x, int y, Player player)
{
	int index = 0;

	if(Main.tile[x,y].frameNumber == 1 || Main.tile[x,y].frameNumber == 2)
	{
		int count = Main.rand.Next(1, 4);
		for(int i = 0; i < count; i++)
		{
			index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)itemType2);
			
			if(Main.netMode != 0)
				NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
		}
	}
	else if(Main.tile[x,y].frameNumber == 3)
	{
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)itemType);
			
		if(Main.netMode != 0)
			NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
	}
}

public void GrowTo(int x, int y, int frame)
{
	int w = Config.tileDefs.width[type];
	int h = Config.tileDefs.height[type];
	
	while(Main.tile[x, y].frameX > Main.tile[x,y].frameNumber * (18 * w))x--;
	while(Main.tile[x, y].frameY > 0)y--;
	
	byte offset = 0;
	byte f = 0;
	
	for(int i = 0; i < w; i++)
	{
		for(int j = 0; j < h; j++)
		{
			f = (byte)frame;
			offset = (byte)(frame * w);
			
			Main.tile[i + x, j + y].frameNumber = f;
			Main.tile[i + x, j + y].frameX = (short)((offset + i) * 18);
			Main.tile[i + x, j + y].frameY = (short)(j * 18);
			
			if(Main.netMode != 0)
				NetMessage.SendTileSquare(-1, i + x, j + y, 1);
		}
	}
	
	ticks=0;
	ticksRequired = GetTicks();
}

public void Update() 
{
	if(Main.tile[x, y].frameNumber < 3) 
	{
		if(ticks==ticksRequired) 
		{
			// grow
			if(Main.dayTime)
				GrowTo(x, y, Main.tile[x, y].frameNumber+1);
		}
		else 
		{
			ticks++;
		}
	}
}