public void hitWire(int x, int y)
{
	if (Main.tile[x, y].type == (ushort)Config.tileDefs.ID["Hallow Bomb"])
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
	for(int i = fx; i < lx+1; i++)
	{
		for(int j = fy; j < ly+1; j++)
		{
			if(Vector2.Distance(new Vector2(i,j),new Vector2(x,y)) <= r)
			{
				if (Main.tile[i, j].active && Main.tile[i, j].type == 25)
				{
					Main.tile[i, j].type = 117;
					WorldGen.SquareTileFrame(i, j);
				}
				if (Main.tile[i, j].active && Main.tile[i, j].type == 32)
				{
					Main.tile[i, j].active = false;
				}
				if (Main.tile[i, j].active && Main.tile[i, j].type == 23)
				{
					Main.tile[i, j].type = 109;
					WorldGen.SquareTileFrame(i, j);
				}
				if (Main.tile[i, j].active && Main.tile[i, j].type == 24)
				{
					Main.tile[i, j].type = 110;
					WorldGen.SquareTileFrame(i, j);
				}
				if (Main.tile[i, j].active && Main.tile[i, j].type == 1)
				{
					Main.tile[i, j].type = 117;
					WorldGen.SquareTileFrame(i, j);
				}
				if (Main.tile[i, j].active && Main.tile[i, j].type == 2)
				{
					Main.tile[i, j].type = 109;
					WorldGen.SquareTileFrame(i, j);
				}
				if (Main.tile[i, j].active && Main.tile[i, j].type == 3)
				{
					Main.tile[i, j].type = 110;
					WorldGen.SquareTileFrame(i, j);
				}
				if (Main.tile[i, j].active && Main.tile[i, j].type == 112)
				{
					Main.tile[i, j].type = 116;
					WorldGen.SquareTileFrame(i, j);
				}
				if (Main.tile[i, j].active && Main.tile[i, j].type == 53)
				{
					Main.tile[i, j].type = 116;
					WorldGen.SquareTileFrame(i, j);
				}
			}
		}
	}
}