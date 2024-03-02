public static void PlaceTile(int x, int y) {
	Vector2 pos = Codable.GetPos(new Vector2(x,y)); //Ensures that we have the correct tile position (top-left, I think)
	x = (int)pos.X;
	y = (int)pos.Y;
	
	int ID = Chest.CreateChest(x, y); //Create a 'Chest' instance for handling items
	Item item=new Item(); //Create a key that only works on this chest.
	item.SetDefaults("Blue Key");
	item.RunMethod("SetKey", x, y);

	Player p = Main.player[Main.myPlayer]; //Spawn the key near the player.
	int itemindex = Item.NewItem((int)p.position.X, (int) p.position.Y, p.width,p.height, item);

}
public static void UseTile(Player player, int x, int y) {
	Vector2 pos = Codable.GetPos(new Vector2(x,y)); //Ensures that we have the correct tile position (top-left, I think)
	x = (int)pos.X;
	y = (int)pos.Y;
	
	//Check player's inventory for the unique key
	bool matchKey=false;
	for(int i=0;i<48;i++) {
		if(Main.player[Main.myPlayer].inventory[i].name=="Blue Key") {
			if(Main.player[Main.myPlayer].inventory[i].RunMethod("GetKey")) {
				Vector2 vect = (Vector2)Codable.customMethodReturn;
				if(x==(int)vect.X && y==(int)vect.Y) {
					matchKey=true;
					break;
				}
			}
		}
	}
	if(!matchKey) return;
	Main.chestText = "Chest";
	int ID= Chest.FindChest(x, y);
	Main.player[Main.myPlayer].chest = ID;
	Main.playerInventory = true;
    Main.PlaySound(12, -1, -1, 1);
    Main.player[Main.myPlayer].chestX = x;
    Main.player[Main.myPlayer].chestY = y;
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