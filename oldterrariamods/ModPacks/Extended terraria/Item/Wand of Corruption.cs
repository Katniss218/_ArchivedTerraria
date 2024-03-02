public void UseItem(Player player, int playerID)
{
	int x = (int)((Main.mouseX + Main.screenPosition.X)/16);
	int y = (int)((Main.mouseY + Main.screenPosition.Y)/16);
	for (int x2 = x - 5; x2 < x + 5; x2++)
	{
		for (int y2 = y - 5; y2 < y + 5; y2++)
		{
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 117)
			{
				Main.tile[x2, y2].type = 25;
			}
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 32)
			{
				Main.tile[x2, y2].active = false;
			}
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 109)
			{
				Main.tile[x2, y2].type = 23;
			}
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 110)
			{
				Main.tile[x2, y2].type = 24;
			}
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 1)
			{
				Main.tile[x2, y2].type = 25;
			}
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 2)
			{
				Main.tile[x2, y2].type = 23;
			}
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 3)
			{
				Main.tile[x2, y2].type = 24;
			}
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 116)
			{
				Main.tile[x2, y2].type = 112;
			}
			if (Main.tile[x2, y2].active && Main.tile[x2, y2].type == 53)
			{
				Main.tile[x2, y2].type = 112;
			}
		}
	}
}