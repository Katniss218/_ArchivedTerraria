private int bookmarkX = 0;
private int bookmarkY = 0;
private int bookmarkWorld = -1;
private bool bookmarkSet = false;
private double setTime;

public void Initialize() {
	setTime = Main.time-120.0;
}

public void UseItem(Player player, int playerID) { 
	if (!(bookmarkSet)) 
		Main.NewText("Your warp location isn't set.", 0xff, 240, 20);
	else if (bookmarkWorld != Main.worldID)
		Main.NewText("This mirror is set for a different world!", 0xff, 240, 20);
	else {


		


		Main.NewText("Picking up where you left off...", 0xff, 240, 20);
		if (CheckBookmarkLocation(bookmarkX, bookmarkY)) {
			player.position.X = (float)(bookmarkX * 16) - (float)((float)player.width / 2.0);
			player.position.Y = (float)(bookmarkY * 16) - (float)player.height;
			player.fallStart = (int)(player.position.Y / 16f);
			player.velocity.X = 0f;
			player.velocity.Y = 0f;




int pDust = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y),
									 player.width, player.height, 55, player.velocity.X, player.velocity.Y,
									 255, Color.Blue, 8.0f);
					
		int pDust2 = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y),
									 player.width, player.height, 55, player.velocity.X, player.velocity.Y,
									 255, Color.Blue, 8.0f);
					int pDust3 = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y),
									 player.width, player.height, 55, player.velocity.X, player.velocity.Y,
									 255, Color.Green, 8.0f);
					
					int pDust4 = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y),
									 player.width, player.height, 55, player.velocity.X, player.velocity.Y,
									 255, Color.Green, 8.0f);
					
					int pDust5 = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y),
									 player.width, player.height, 55, player.velocity.X, player.velocity.Y,
									 255, Color.Green, 8.0f);
					int pDust6 = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y),
									 player.width, player.height, 55, player.velocity.X, player.velocity.Y,
									 255, Color.Green, 8.0f);
					int pDust7 = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y),
									 player.width, player.height, 55, player.velocity.X, player.velocity.Y,
									 255, Color.Green, 8.0f);

				
				Main.dust[pDust].noGravity = true;


				Main.dust[pDust2].noGravity = true;


				Main.dust[pDust3].noGravity = true;

				Main.dust[pDust4].noGravity = true;

				Main.dust[pDust5].noGravity = true;

				Main.dust[pDust6].noGravity = true;

				Main.dust[pDust7].noGravity = true;





		}
		else {
			Main.NewText("Your warp location is invalid! (this is a bug; please report)", 0xff, 240, 20);
		}
	}
}

public void Effects(Player player) {


player.moveSpeed -= 2f;
player.statDefense -= 80;

    	if (!bookmarkSet) {
    		bookmarkX = GetXLocation(player);
    		bookmarkY = GetYLocation(player);
    		bookmarkWorld = Main.worldID;
    		bookmarkSet = true;
    		setTime = Main.time;
    		Main.NewText("New warp location set!", 0xff, 240, 20);
    	}
    	else {
    		double timeDif = Main.time-setTime;
    		if ( (timeDif > 120.0) || (timeDif < 0.0) ) {
        		bookmarkX = GetXLocation(player);
        		bookmarkY = GetYLocation(player);
        		bookmarkWorld = Main.worldID;
    			setTime = Main.time;
    			Main.NewText("New warp location set!", 0xff, 240, 20);
    		}
    	}
}

public void Save(BinaryWriter writer)
{
	writer.Write(bookmarkX);
	writer.Write(bookmarkY);
	writer.Write(bookmarkSet);
	writer.Write(bookmarkWorld);
}

public void Load(BinaryReader reader)
{
	bookmarkX = reader.ReadInt32();
	bookmarkY = reader.ReadInt32();
	bookmarkSet = reader.ReadBoolean();
	bookmarkWorld = reader.ReadInt32();
}

bool CheckBookmarkLocation(int x, int y) {
	if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesX - 10) {
		Main.NewText("Spawn point out of range! (bug)", 0xff, 240, 20);
		return false;
	}
	for (int i = x-1; i < x + 1; i++)
		for (int j = y - 3; j < y; j++)
		{
			if (Main.tile[i, j] == null) {
				Main.NewText("Bookmark tile null at "+i+", "+j+"!", 0xff, 240, 20);
				return false;
			}
			if (Main.tile[i, j].active && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type]) {
				WorldGen.KillTile(i, j, false, false, false);
			}
		}
	return true;
}

int GetXLocation(Player player) {
	return (int)((player.position.X + player.width/2.0 + 8.0)/16.0);
}

int GetYLocation(Player player) {
	return (int)((player.position.Y + player.height)/16.0);
}