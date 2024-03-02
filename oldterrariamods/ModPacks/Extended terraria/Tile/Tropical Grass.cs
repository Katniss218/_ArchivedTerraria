/*int
    X,
    Y,
    gCount = 0;
public void Initialize(int x, int y)
{
	X = x;
	Y = y;
}
public void Update()
{
	int
		x = 0,
		y = 0;
	gCount++;
	if (gCount % 600 == 0)
	{
		x = Main.rand.Next(2) == 0 ? 1 : -1;
		y = Main.rand.Next(2) == 0 ? 1 : -1;
		int
			xx = X + x,
			yy = Y + y;
		//if (Main.tile[xx, yy].type == (ushort)Config.tileDefs.ID["Tropical Mud"] && Main.tile[xx, yy].active && yy < Main.worldSurface && (!Main.tile[xx, yy - 1].active ^ !Main.tile[xx - 1, yy].active ^ !Main.tile[xx + 1, yy].active ^ !Main.tile[xx, yy + 1].active))
		if (ModWorld.CanGrowGrass(xx, yy))
		{
			Main.tile[xx, yy].type = (ushort)Config.tileDefs.ID["Tropical Grass"];
			WorldGen.SquareTileFrame(xx, yy, true);
			gCount = 0;
		}
	}
}*/


/*public int X = 0;
public int Y = 0;
//public int gcount = 0;

public void Initialize(int x, int y)
{
   X = x;
   Y = y;
}

public void Update()
{
	if (ModWorld.TropicGrassTimer == 1800 && (Y <= Main.rockLayer))
	{
		for (int a=-2; a <= 2; a++)
		{
			for (int b=-2; b <= 2; b++)
			{
				if (Main.tile[X+a,Y+b].type == Config.tileDefs.ID["Tropical Mud"] && (!Main.tile[X+a, Y+b].active || !Main.tile[X+a, Y+b].active || !Main.tile[X+a, Y+b].active || !Main.tile[X+a, Y+b].active))
				{
					Main.tile[X+a,Y+b].active = false;
					WorldGen.PlaceTile(X+a,Y+b,(ushort)Config.tileDefs.ID["Tropical Grass"]);
				}
			}
		}
	}
}
*/