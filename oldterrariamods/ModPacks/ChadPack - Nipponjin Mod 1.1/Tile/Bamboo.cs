public static bool KillTile(int x, int y, Player player)
{
	int index = 0;

	index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Bamboo"].type);
	index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Bamboo"].type);
	index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Bamboo"].type);
	index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Bamboo"].type);
	
	return true;
}