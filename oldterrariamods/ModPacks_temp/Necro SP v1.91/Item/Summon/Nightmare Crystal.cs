public static Texture2D sun;
public static Texture2D sun2;

#region Item Used
public void UseItem(Player player, int playerID)
{
if(Main.worldName == "Nightmare"){
ModPlayer.currentWorld = "Nightmare";
}else{
ModPlayer.diamondUse = true;
ModPlayer.currentWorld = "Normal";
}

//if(!File.Exists(ModPlayer.parallelWorld)){
//ModPlayer.parallelWorld = "";
//}

if(ModPlayer.currentWorld == "Normal"){

//Save the current world state
WorldGen.saveWorld(true);

//Generate the new World
WorldGen.clearWorld();

//Main.rightWorld = 10000f;


WorldGen.generateWorld(-1);

ModPlayer.NormalWorldName  = Main.worldName;
ModPlayer.associatedWorld = Main.worldPathName;
Main.worldName = "Nightmare";

//Save it to the Worlds folder
Main.worldPathName = CreateWorldFile();

WorldGen.EveryTileFrame();

ModifyWorld();
//WorldGen.UpdateWorld();


}
//else{

//WorldGen.saveWorld(true);



//WorldGen.EveryTileFrame();

	
//}
if (WorldGen.loadFailed || !WorldGen.loadSuccess)
			{
				Main.worldName = ModPlayer.NormalWorldName;
Main.worldPathName = ModPlayer.associatedWorld;
WorldGen.playWorld();

}

player.Spawn();
ModPlayer.diamondUse = false;

}
#endregion

#region Creating New World File
private string CreateWorldFile()
{
			return string.Concat(new object[]
			{
				Main.WorldPath, 
				"\\world", 
				99, 
				".wld"
			});
}
#endregion

#region Replacing Tiles And Items
private void ModifyWorld()
{
	NPC.downedBoss1 = true;
	NPC.downedBoss2 = true;
	NPC.downedBoss3 = true;
	NPC.downedGoblins = true;
	NPC.downedFrost = true;
    Main.hardMode = true;
	for (int i = 0; i < Main.maxTilesX; i++)
	{
		for (int j = 0; j < Main.maxTilesY; j++)
		{
			Tile T = Main.tile[i, j];
			if (T == null)
				T = new Tile();
			if (T.active)
			{
				if (T.type == 0)
					T.type = (ushort)Config.tileDefs.ID["Purple Dirt"];
				if (T.type == 57)
					T.type = (ushort)Config.tileDefs.ID["Flesh Block"];
			    if (T.type == 3)
					T.type = (ushort)Config.tileDefs.ID["Grave Stones"];
			    if (T.type == 61)
					T.type = (ushort)Config.tileDefs.ID["Tall Grave Stones"];
				if (T.type == 6)
					T.type = (ushort)Config.tileDefs.ID["Demon Blood Ore"];
				if (T.type == 7)
					T.type = (ushort)Config.tileDefs.ID["Angelite"];
				if (T.type == 8)
					T.type = (ushort)Config.tileDefs.ID["Uranium Ore"];
				if (T.type == 9)
					T.type = (ushort)Config.tileDefs.ID["Nightmare Ore"];
				if (T.type == 59)
					T.type = (ushort)Config.tileDefs.ID["Blue Dirt"];
				if (T.type == 2 || T.type == 23 || T.type == 109)
					T.type = (ushort)Config.tileDefs.ID["Black Grass"];
                if (T.type == 60)
					T.type = (ushort)Config.tileDefs.ID["Blue Grass"];
				if (T.type == 25)
					T.type = (ushort)Config.tileDefs.ID["Obscure Ore"];
				if (T.type == 53 || T.type == 112 || T.type == 116)
					T.type = (ushort)Config.tileDefs.ID["Red Sand"];
				if (T.type == 52 || T.type == 115)
					T.type = (ushort)Config.tileDefs.ID["Red Vines"];
				if (T.type == 62)
					T.type = (ushort)Config.tileDefs.ID["Purple Vines"];
				if (T.type == 27 || T.type == 24 || T.type == 34)
					T.active = false;
				if (T.type == 47 || T.type == 46 || T.type == 45)
					T.type = (ushort)Config.tileDefs.ID["Angelite Brick"];
				if (T.type == 44 || T.type == 43 || T.type == 41)
					T.type = (ushort)Config.tileDefs.ID["Demon Blood Brick"];
				if (T.type == 76 || T.type == 75)
					T.type = (ushort)Config.tileDefs.ID["Nightmare Stone Brick"];
			}
			if (T.wall == 7 || T.wall == 8 || T.wall == 9 || T.wall == 10 || T.wall == 11 || T.wall == 12 || T.wall == 13)
				T.wall = (ushort)Config.wallDefs.ID["Demon Blood Brick Wall"];
			if (T.wall == 13 || T.wall == 14)
				T.wall = (ushort)Config.wallDefs.ID["Nightmare Stone Brick Wall"];
		}
	}
	int chestType=2; 
	int numAdded=0;
	for(int i=0;i<1000;i++)
	{
		Main.statusText = "Added "+numAdded+" items to chests... ("+(i/1000)+"%)";
		Chest chest = Main.chest[i];
		if(chest!=null)
		{
			int x = chest.x;
			int y = chest.y;
			if(Main.tile[x,y]!=null && Main.tile[x,y].active && Main.tile[x,y].frameX >= 36 * chestType && Main.tile[x,y].frameX <= 18+ 36 * chestType)
			{
				string[] items={"Enchanting Stone","Blackend Enchanting Stone"};
				int itemType = WorldGen.genRand.Next(items.Length);
				for(int j=0;j<Chest.maxItems;j++)
				{
					if(chest.item[j]==null || chest.item[j].type==0) 
					{
						chest.item[j] = new Item();
						chest.item[j].SetDefaults(items[itemType]);
						numAdded++;
						break;
					}
				}
			}
		}
	}	
	Main.treeTopTexture[0] = Main.tileTexture[Config.tileDefs.ID["Tree_Tops_Black"]];
	Main.treeBranchTexture[0] = Main.tileTexture[Config.tileDefs.ID["Tree_Branches_Black"]];
	Main.liquidTexture[0] = Main.tileTexture[Config.tileDefs.ID["Blood Water"]];
	Main.backgroundTexture[0] = Main.tileTexture[Config.tileDefs.ID["Lavender Sky"]];
	Main.backgroundTexture[5] = Main.tileTexture[Config.tileDefs.ID["Background_5"]];
	Main.backgroundTexture[6] = Main.tileTexture[Config.tileDefs.ID["Background_6"]];
	Main.backgroundTexture[7] = Main.tileTexture[Config.tileDefs.ID["Background_7"]];
	Main.backgroundTexture[8] = Main.tileTexture[Config.tileDefs.ID["Background_8"]];
	Main.backgroundTexture[28] = Main.tileTexture[Config.tileDefs.ID["Background_28"]];
	Main.backgroundTexture[9] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
	Main.backgroundTexture[10] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
	Main.backgroundTexture[11] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
	Main.backgroundTexture[12] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
	Main.backgroundTexture[13] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
	Main.backgroundTexture[14] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
	Main.tileTexture[0] = Main.tileTexture[Config.tileDefs.ID["Purple Dirt"]];
	Main.tileTexture[25] = Main.tileTexture[Config.tileDefs.ID["Obscure Ore"]];
	Main.tileTexture[6] = Main.tileTexture[Config.tileDefs.ID["Demon Blood Ore"]];
	Main.tileTexture[7] = Main.tileTexture[Config.tileDefs.ID["Angelite"]];
	Main.tileTexture[8] = Main.tileTexture[Config.tileDefs.ID["Uranium Ore"]];
	Main.tileTexture[9] = Main.tileTexture[Config.tileDefs.ID["Nightmare Ore"]];
	Main.tileTexture[57] = Main.tileTexture[Config.tileDefs.ID["Flesh Block"]];
	Main.tileTexture[59] = Main.tileTexture[Config.tileDefs.ID["Blue Dirt"]];
	Main.tileTexture[2] = Main.tileTexture[Config.tileDefs.ID["Black Grass"]];
	Main.tileTexture[60] = Main.tileTexture[Config.tileDefs.ID["Blue Grass"]];
	Main.tileTexture[3] = Main.tileTexture[Config.tileDefs.ID["Grave Stones"]];
	Main.tileTexture[61] = Main.tileTexture[Config.tileDefs.ID["Tall Grave Stones"]];
	Main.tileTexture[52] = Main.tileTexture[Config.tileDefs.ID["Red Vines"]];
	Main.tileTexture[62] = Main.tileTexture[Config.tileDefs.ID["Purple Vines"]];
	Main.sunTexture = Main.tileTexture[Config.tileDefs.ID["Nightmare Sun"]];
	Main.sun2Texture = Main.tileTexture[Config.tileDefs.ID["Nightmare Sun2"]];
	Main.moonTexture = Main.tileTexture[Config.tileDefs.ID["Nightmare Moon"]];
	WorldGen.EveryTileFrame();
}
#endregion