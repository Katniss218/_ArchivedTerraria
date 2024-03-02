int x, y;

public void Initialize(int _x, int _y)
{
	x = _x;
	y = _y;
}

public void PlaceTile(int x, int y, int p)
{
	ModWorld.Achieve(0, "EIKESTER_COMPUTER");
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

public void UseTile(Player player, int x, int y)
{
	ModWorld.pongGame.Initialize();
	ModWorld.pongGame.IsPC = true;
	ModWorld.pongGameRunning = true;
}