int tileX;
int tileY;
int tick3hs;
int tick3hsNeeded3 = 39000; //15 minutes
int tick3hsNeeded2 = 19500; //7,5 minutes
int tick3hsNeeded = 9750; //3,75 minutes
	static int ticksn = 600;
	static int tickshere;

public void Initialize(int x, int y){
	tileX = x;
	tileY = y;
	tickshere = 0;
}


public void UseTile(Player player, int x, int y){
	if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == Config.itemDefs.byName["Bone Meal"].type){
		if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
			if(Main.rand.Next(4)==1){
				if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				}
				if(Main.tile[x, y-1].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
					Main.tile[x, y-1].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				}
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
			}
		}
		if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
			if(Main.rand.Next(4)==1){
				if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				}
				if(Main.tile[x, y-1].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
					Main.tile[x, y-1].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				}
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
			}
		}
	}
}

public void Update(){
bool breakthis;
	int x = tileX;
	int y = tileY;
	tickshere ++;
	if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
		if(tick3hs == tick3hsNeeded){
			if(Main.rand.Next(6)==1){
				if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				}
				if(Main.tile[x, y-1].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
					Main.tile[x, y-1].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				}
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				tick3hs = 0;
			}
		}
		if(tick3hs == tick3hsNeeded2){
			if(Main.rand.Next(3)==1){
				if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				}
				if(Main.tile[x, y-1].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
					Main.tile[x, y-1].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				}
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				tick3hs = 0;
			}
		}
		if(tick3hs == tick3hsNeeded3){
				if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				}
				if(Main.tile[x, y-1].type == (byte)Config.tileDefs.ID["Tomato Plant"]){
					Main.tile[x, y-1].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				}
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Tomato Plant2"];
				tick3hs = 0;
		}
		else{
			tick3hs ++;
		}
	}
	else if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
		if(tick3hs == tick3hsNeeded){
			if(Main.rand.Next(6)==1){
				if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				}
				if(Main.tile[x, y-1].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
					Main.tile[x, y-1].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				}
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				tick3hs = 0;
			}
		}
		if(tick3hs == tick3hsNeeded2){
			if(Main.rand.Next(3)==1){
				if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				}
				if(Main.tile[x, y-1].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
					Main.tile[x, y-1].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				}
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				tick3hs = 0;
			}
		}
		if(tick3hs == tick3hsNeeded3){
				if(Main.tile[x, y+1] == null || Main.tile[x, y+1].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
					Main.tile[x, y+1].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				}
				if(Main.tile[x, y-1].type == (byte)Config.tileDefs.ID["Tomato Plant2"]){
					Main.tile[x, y-1].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				}
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Tomato Plant3"];
				tick3hs = 0;
		}
		else{
			tick3hs ++;
		}
	}
	if (Main.tile[x, y+1].type != 109 && Main.tile[x, y+1].type != 2 && Main.tile[x, y+1].type != (byte)Config.tileDefs.ID["Tomato Plant"] && Main.tile[x, y+1].type != (byte)Config.tileDefs.ID["Tomato Plant2"] && Main.tile[x, y+1].type != (byte)Config.tileDefs.ID["Tomato Plant3"]){
		breakthis = true;
	}
	else{
		breakthis = false;
	}
	if(breakthis){
		WorldGen.KillTile(x, y, false, false, false);
	}
}

public static void KillTile(int x, int y, Player player){
	int index = 0;
	if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Tomato Plant"] && Main.tile[x, y-1].type != (byte)Config.tileDefs.ID["Tomato Plant"]){
		if(tickshere < ticksn){
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato Plant Seeds"].type);
			tickshere = 0;
		}
	}
		if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Tomato Plant3"]){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato"].type);
		if(Main.rand.Next(2)==1){
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato"].type);
		}
		if(Main.rand.Next(4)==1){
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato"].type);
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato Plant Seeds"].type);
		}
		if(Main.rand.Next(8)==1){
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato"].type);
		}
		if(Main.rand.Next(16)==1){
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato"].type);
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato Plant Seeds"].type);
		}
		if(Main.rand.Next(32)==1){
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato"].type);
		}
		if(Main.rand.Next(64)==1){
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato"].type);
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Tomato Plant Seeds"].type);
		}
	}
	}

public void Load(BinaryReader R){
	try{
		tick3hs = R.ReadInt32();
		tick3hsNeeded3 = R.ReadInt32();
		tick3hsNeeded2 = R.ReadInt32();
		tick3hsNeeded = R.ReadInt32();
	}
	catch{
	}
}
public void Save(BinaryWriter W){
	W.Write(tick3hs);
	W.Write(tick3hsNeeded3);
	W.Write(tick3hsNeeded2);
	W.Write(tick3hsNeeded);
}