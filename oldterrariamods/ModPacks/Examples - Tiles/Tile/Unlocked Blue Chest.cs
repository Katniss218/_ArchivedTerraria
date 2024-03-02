public static void PlaceTile(int x, int y) {
	Vector2 pos = Codable.GetPos(new Vector2(x,y)); //Ensures that we have the correct tile position (top-left, I think)
	x = (int)pos.X;
	y = (int)pos.Y;
	int ID = Chest.CreateChest(x, y);
}
public static void UseTile(Player player, int x, int y) {
	Vector2 pos = Codable.GetPos(new Vector2(x,y)); //Ensures that we have the correct tile position (top-left, I think)
	x = (int)pos.X;
	y = (int)pos.Y;
	
	Main.chestText = "Chest";
	int ID= Chest.FindChest(x, y);
	Main.player[Main.myPlayer].chest = ID;
	Main.playerInventory = true;
    Main.PlaySound(12, -1, -1, 1);
    Main.player[Main.myPlayer].chestX = x;
    Main.player[Main.myPlayer].chestY = y;
	//Note: This doesn't work in multiplayer. Probably need to send a netmessage of some sort
}
public static bool CanDestroyTile(int x, int y) {
	Vector2 pos = Codable.GetPos(new Vector2(x,y)); //Ensures that we have the correct tile position (top-left, I think)
	x = (int)pos.X;
	y = (int)pos.Y;
	
	int ID= Chest.FindChest(x, y);
	if(ID==-1) return true;
	for(int i=0;i<Chest.maxItems;i++) {
		if(Main.chest[ID].item[i].type > 0) return false;
	}
	return true; //If there are no items in the chest, then let it be destroyed
}
public static bool CanExplode(int x, int y, int projType) {
	return CanDestroyTile(x, y); //Don't want explosions hurting it either!
}
public static void KillTile(int x, int y, Player p) {
	Vector2 pos = Codable.GetPos(new Vector2(x,y)); //Ensures that we have the correct tile position (top-left, I think)
	x = (int)pos.X;
	y = (int)pos.Y;
	
	Chest.DestroyChest(x, y);
}