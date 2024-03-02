public static void PlaceTile(int x, int y)
{
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	int ID = Chest.CreateChest(x, y);
}

public void UseTile(Player player, int x, int y)
{
	while(Main.tile[x,y].frameX>0) x--; // && Main.tile[x-1,y].type==type
	while(Main.tile[x,y].frameY>0) y--; // && Main.tile[x,y-1].type==type
	Main.chestText = "Chest";
	int ID= Chest.FindChest(x, y);
	Main.player[Main.myPlayer].chest = ID;
	Main.playerInventory = true;
        Main.PlaySound(12, -1, -1, 1);
        Main.player[Main.myPlayer].chestX = x;
        Main.player[Main.myPlayer].chestY = y;
}

public bool CanDestroyTile(int x, int y)
{
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	int ID= Chest.FindChest(x, y);
	if(ID==-1) return true;
	for(int i=0;i<Chest.maxItems;i++) {
		if(Main.chest[ID].item[i].type > 0) return false;
	}
	return true;
}

public void DestroyTile(int x, int y)
{
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	Chest.DestroyChest(x, y);
}

public static void AddLight(int x, int y, ref float red, ref float green, ref float blue) {
	red = 0.3f;
	green = 0.3f;
	blue = 0.3f;
}