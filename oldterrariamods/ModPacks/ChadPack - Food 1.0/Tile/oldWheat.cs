int tileX;
int tileY;
int tickehs;
int tickehsNeeded3 = 36000; //10 minutes
int tickehsNeeded2 = 13000; //5 minutes
int tickehsNeeded = 6500; //2,5 minutes

public void Initialize(int x, int y){
	tileX = x;
	tileY = y;
}

public void UseTile(Player player, int x, int y){
	int c = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem];
	if(c.type == Config.itemDefs.byName["Bone Meal"].type){
		if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat"]){
			if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Wheat"]){
				if(Main.rand.Next(3)==1){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Wheat2"];
					Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat2"];
					tick3hs = 0;
					c.stack -= 1;
				}
			}
		}
		if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat2"]){
			if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Wheat2"]){
				if(Main.rand.Next(3)==1){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Wheat3"];
					Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat3"];
					tick3hs = 0;
					c.stack -= 1;
				}
			}
		}
	}
}

public void Update(){
	int x = tileX;
	int y = tileY;
	if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat"]){
		if(tickehs == tickehsNeeded){
			if(Main.rand.Next(6)==1){
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat2"];
				tickehs = 0;
			}
		}
		if(tickehs == tickehsNeeded2){
			if(Main.rand.Next(3)==1){
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat2"];
				tickehs = 0;
			}
		}
		if(tickehs == tickehsNeeded3){
			Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat2"];
			tickehs = 0;
		}
		else{
			tickehs ++;
		}
	}
	else if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat2"]){
		if(tickehs == tickehsNeeded){
			if(Main.rand.Next(6)==1){
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat3"];
				tickehs = 0;
			}
		}
		if(tickehs == tickehsNeeded2){
			if(Main.rand.Next(3)==1){
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat3"];
				tickehs = 0;
			}
		}
		if(tickehs == tickehsNeeded3){
			Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat3"];
			tickehs = 0;
		}
		else{
			tickehs ++;
		}
	}
}

public static void KillTile(int x, int y, Player player){
	int index = 0;
	if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat3"]){
	index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
	if(Main.rand.Next(2)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
	}
	if(Main.rand.Next(4)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat Seeds"].type);
	}
	if(Main.rand.Next(8)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
	}
	if(Main.rand.Next(16)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat Seeds"].type);
	}
	if(Main.rand.Next(32)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
	}
	if(Main.rand.Next(64)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat Seeds"].type);
	}
	}
}

public void Load(BinaryReader R){
	try{
		tickehs = R.ReadInt32();
		tickehsNeeded3 = R.ReadInt32();
		tickehsNeeded2 = R.ReadInt32();
		tickehsNeeded = R.ReadInt32();
	}
	catch{
	}
}
public void Save(BinaryWriter W){
	W.Write(tickehs);
	W.Write(tickehsNeeded3);
	W.Write(tickehsNeeded2);
	W.Write(tickehsNeeded);
}