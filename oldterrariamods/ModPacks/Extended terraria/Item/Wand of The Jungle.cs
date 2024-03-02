public void UseItem(Player player, int playerID)
{
	int x = (int)((Main.mouseX + Main.screenPosition.X)/16);
	int y = (int)((Main.mouseY + Main.screenPosition.Y)/16);
	for (int x2 = x - 10; x2 < x + 10; x2++)
	{
		for (int y2 = y - 10; y2 < y + 10; y2++)
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