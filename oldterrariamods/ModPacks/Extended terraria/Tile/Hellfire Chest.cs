public void Initialize(int x, int y)
{
	int ID = Chest.CreateChest(x, y);
}

public void PlaceTile(int x, int y, int playerId) {
	FixChestPos(ref x,ref y);
	//Chest.CreateChest(x,y);
}
public void MouseOverTile(int x,int y, Player player) {
	player.noThrow = 2;
	player.showItemIcon = true;
	player.showItemIcon2 = Config.itemDefs.byName["Hellfire Chest"].type;
}
public void UseTile(Player player, int x, int y) {
	FixChestPos(ref x,ref y);

	if (Main.netMode == 1) {
		if (x == player.chestX && y == player.chestY && player.chest != -1) {
			player.chest = -1;
			Main.PlaySound(11,-1,-1,1);
		} else NetMessage.SendData(31,-1,-1,"",x,(float)y,0f,0f,0);
	} else {
		int chestId = Chest.FindChest(x,y);
		if (chestId != -1) {
			if (chestId == player.chest) {
				player.chest = -1;
				Main.PlaySound(11,-1,-1,1);
			} else {
				player.chest = chestId;
				Main.playerInventory = true;
				player.chestX = x;
				player.chestY = y;
				Main.PlaySound(chestId != player.chest && player.chest == -1 ? 10 : 12,-1,-1,1);
			}
		}
	}
}
public bool CanDestroyTile(int x,int y) {
	return true;
}
public bool CanDestroyAround(int x, int y, string Dir) {
	if (Dir == "Bottom") return false;
	return true;
}
public void PreKillTile(ref int x, ref int y, ref bool LetContinue, ref bool fail, ref bool effectOnly, ref bool noItem, Player player) {
	if (Main.netMode == 1 && player != null) fail = true;
}
public bool StopKillTile(int x, int y) {
	if (Main.netMode == 1) return false;
	FixChestPos(ref x,ref y);
	
	if (!Chest.DestroyChest(x,y)) return true;
	return false;
}
public void PostKillTile(int x, int y, string at, Player player) {
	if (player == null) return;
	if (at == "Fail" && Main.netMode == 1) NetMessage.SendData(34, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0.0f, 0.0f, 0);
}

public void FixChestPos(ref int x,ref int y) {
	Vector2 pos = Codable.GetPos(new Vector2(x,y));
	x = (int)pos.X;
	y = (int)pos.Y;
}

/*public void PlaceTile(int x, int y) {
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	//int ID = Chest.CreateChest(x, y);
}
public void UseTile(Player player, int x, int y) {
	while(Main.tile[x,y].frameX>0) x--; // && Main.tile[x-1,y].type==type
	while(Main.tile[x,y].frameY>0) y--; // && Main.tile[x,y-1].type==type
	Main.chestText = "Hellfire Chest";
	int ID2= Chest.FindChest(x, y);
	Main.player[Main.myPlayer].chest = ID2;
	Main.playerInventory = true;
	Main.PlaySound(12, -1, -1, 1);
	Main.player[Main.myPlayer].chestX = x;
	Main.player[Main.myPlayer].chestY = y;
	//Note: This doesn't work in multiplayer. Probably need to send a netmessage of some sort
}
public bool CanDestroyTile(int x, int y) {
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	int ID2= Chest.FindChest(x, y);
	if(ID2==-1) return true;
	for(int i=0;i<Chest.maxItems;i++) {
		if(Main.chest[ID2].item[i].type > 0) return false;
	}
	return true; //If there are no items in the chest, then let it be destroyed
}
public bool CanDestroyAround(int x, int y, string Dir)
{
	if(Dir == "Bottom") return false;
	else return true;
}
public void KillTile(int x, int y, Player P) {
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	Chest.DestroyChest(x, y);
}

public void MouseOverTile(int x,int y,Player P)
{
	P.noThrow = 2;
	P.showItemIcon = true;
	P.showItemIcon2 = Config.itemDefs.byName["Hellfire Chest"].type;
}*/