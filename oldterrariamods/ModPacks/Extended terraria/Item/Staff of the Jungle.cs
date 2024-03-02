public void UseItem(Player player, int playerID)
{
	if (Main.tile[Main.mouseX, Main.mouseY].active && Main.tile[Main.mouseX, Main.mouseY].type == 59)
	{
		Main.tile[Main.mouseX, Main.mouseY].type = 60;
	}
}