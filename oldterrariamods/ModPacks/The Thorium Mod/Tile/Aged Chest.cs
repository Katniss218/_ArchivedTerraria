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
	player.showItemIcon2 = Config.itemDefs.byName["Aged Chest"].type;
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