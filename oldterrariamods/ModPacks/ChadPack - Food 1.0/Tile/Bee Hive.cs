private int HiveUses = 5;

public void UseTile(Player player, int x, int y){
	int index = 0;

	if(HiveUses >= 5){
		if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == Config.itemDefs.byName["Glass Pot"].type){
			Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
			HiveUses -= 1;
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Pot of Honey"].type);
			if(Main.netMode == 1 || Main.netMode == 0){
				Main.NewText("This hive has "+HiveUses+" uses left.", 0, 150, 0);
			}
		}
		if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == Config.itemDefs.byName["Bee"].type){
			Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
			HiveUses += 1;
			if(Main.netMode == 1 || Main.netMode == 0){
				Main.NewText("You added a bee to the hive!", 0, 150, 0);
				Main.NewText("Now the hive has "+HiveUses+" uses left!", 0, 150, 0);
			}
		}
	}
	if(HiveUses >= 2 && HiveUses <= 4){
		if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == Config.itemDefs.byName["Glass Pot"].type){
			Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
			HiveUses -= 1;
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Pot of Honey"].type);
			if(Main.netMode == 1 || Main.netMode == 0){
				Main.NewText("This hive has "+HiveUses+" uses left.", 150, 150, 0);
			}
		}
		if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == Config.itemDefs.byName["Bee"].type){
			Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
			HiveUses += 1;
			if(Main.netMode == 1 || Main.netMode == 0){
				Main.NewText("You added a bee to the hive!", 0, 150, 0);
				Main.NewText("Now the hive has "+HiveUses+" uses left!", 0, 150, 0);
			}
		}
	}
	if(HiveUses == 1){
		if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == Config.itemDefs.byName["Glass Pot"].type){
			Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Pot of Honey"].type);
			if(Main.netMode == 1 || Main.netMode == 0){
				Main.NewText("The hive broke!", 150, 0, 0);
			}
			WorldGen.KillTile(x, y); WorldGen.SquareTileFrame(x, y);
		}
		if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == Config.itemDefs.byName["Bee"].type){
			Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
			HiveUses += 1;
			if(Main.netMode == 1 || Main.netMode == 0){
				Main.NewText("You added a bee to the hive!", 0, 150, 0);
				Main.NewText("Now the hive has "+HiveUses+" uses left!", 0, 150, 0);
			}
		}
	}
}

public void Load(BinaryReader R) 
{
    HiveUses = R.ReadInt32();
}

public void Save(BinaryWriter W) 
{
    W.Write(HiveUses);
}