public void UseItem(Player player, int playerID)
{
	int x = (int)((Main.mouseX + Main.screenPosition.X)/16);
	int y = (int)((Main.mouseY + Main.screenPosition.Y)/16);
	if (Main.tile[x, y].active && Main.tile[x, y].type == 59)
	{
		Main.tile[x, y].type = 60;
	}
	if (Main.tile[x, y].active && Main.tile[x, y].type == 0)
	{
		Main.tile[x, y].type = 2;
	}
}