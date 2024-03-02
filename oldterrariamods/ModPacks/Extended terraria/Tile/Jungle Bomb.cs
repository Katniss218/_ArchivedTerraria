public void hitWire(int x, int y)
{
	if (Main.tile[x, y].type == (ushort)Config.tileDefs.ID["Jungle Bomb"])
	{
		ConvertCircle(x, y, 75f);
		Main.PlaySound(2, x * 16, y * 16, 20);
		ModWorld.Kill3x2TileForGood(x, y);
	}
}

public static void ConvertCircle(int x, int y, float r)
{
	int fx = (int)(x-r); //first x
	int fy = (int)(y-r); //first y
	int lx = (int)(x+r); //last x
	int ly = (int)(y+r); //last y
	for(int x2 = fx; x2 < lx+1; x2++)
	{
		for(int y2 = fy; y2 < ly+1; y2++)
		{
			if(Vector2.Distance(new Vector2(x2,y2),new Vector2(x,y)) <= r)
			{
				if (Main.tile[x2, y2].active && (Main.tile[x2, y2].type == 25 || Main.tile[x2, y2].type == 117))
				{
					Main.tile[x2, y2].type = 1;
					WorldGen.SquareTileFrame(x2, y2);
				}
				if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 32)
				{
					Main.tile[x2, y2].type = 69;
					WorldGen.SquareTileFrame(x2, y2);
				}
				if (Main.tile[x2, y2].active && (Main.tile[x2, y2].type == 2 || Main.tile[x2, y2].type == 23 || Main.tile[x2, y2].type == 109))
				{
					Main.tile[x2, y2].type = 60;
					WorldGen.SquareTileFrame(x2, y2);
				}
				if (Main.tile[x2, y2].active && (Main.tile[x2, y2].type == 24 || Main.tile[x2, y2].type == 110))
				{
					Main.tile[x2, y2].type = 61;
					WorldGen.SquareTileFrame(x2, y2);
				}
				if (Main.tile[x2, y2].active && (Main.tile[x2, y2].type == 112 || Main.tile[x2, y2].type == 116))
				{
					Main.tile[x2, y2].type = 53;
					WorldGen.SquareTileFrame(x2, y2);
				}
				if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 0)
				{
					Main.tile[x2, y2].type = 59;
					WorldGen.SquareTileFrame(x2, y2);
				}
				if (Main.tile[x2, y2].active && (Main.tile[x2, y2].type == 73 || Main.tile[x2, y2].type == 113))
				{
					Main.tile[x2, y2].type = 74;
					WorldGen.SquareTileFrame(x2, y2);
				}
				if (Main.tile[x2, y2].active && (Main.tile[x2, y2].type == 52 || Main.tile[x2, y2].type == 115))
				{
					Main.tile[x2, y2].type = 62;
					WorldGen.SquareTileFrame(x2, y2);
				}
			}
		}
	}
}