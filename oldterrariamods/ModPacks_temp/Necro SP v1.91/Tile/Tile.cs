private const string Nightmare_PRE="DWNightmare ";
private const string Normal_PRE="DWNormal ";

#region Add ore
public void ModifyWorld()
{
	double num3 = (double)(Main.maxTilesY * 0.3) + 10.0;
	num3 *= (double)WorldGen.genRand.Next(90, 110) * 0.005;
	double num6 = num3;
	int xcoord = 0;
	int ycoord = 0;

	Main.statusText = "Adding Corrupted Steel Ore...";
	int Amount_Of_Spawns = 350+(int)(Main.maxTilesY/5);
	for(int i=0;i<Amount_Of_Spawns;i++) AddCorruptedSteelOre();

	if(!ModGeneric.gen)
		return;
		Main.statusText = "Altering Tiles";
		string worldName = Main.worldPathName.Remove(0, (Main.WorldPath+Path.DirectorySeparatorChar).Length);
		if (worldName.StartsWith(Nightmare_PRE))
		{
			worldName = worldName.Remove(0,Nightmare_PRE.Length);
			if(worldName.EndsWith(".zip"))
			{
				worldName = worldName.Remove(worldName.Length-4);
			}
			Main.worldName = worldName;
			nightmare();
		}
		else if(worldName.StartsWith(Normal_PRE))
		{
			worldName = worldName.Remove(0,Normal_PRE.Length);
			if(worldName.EndsWith(".zip"))
			{
				worldName = worldName.Remove(worldName.Length-4);
			}
			Main.worldName = worldName;		
			Main.statusText = "Keeping the world Normal";
	}	
}

public void AddCorruptedSteelOre()
{
	int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
	double num6;
	num6 = Main.rockLayer;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 150);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(4, 6), Config.tileDefs.ID["Corrupted Steel Ore"]);
}
#endregion

#region Nightmare world
public void nightmare()
{
	NPC.downedBoss1 = true;
	NPC.downedBoss2 = true;
	NPC.downedGoblins = true;
	NPC.downedFrost = true;
    Main.hardMode = true;
	ModWorld.newWorld = "Nightmare";
	Main.statusText = "Welcome to my Nightmare";
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
			if (T.wall == 7 || T.wall == 8 || T.wall == 9 || T.wall == 10 || T.wall == 11 || T.wall == 12)
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
}

private int IT(string n)
{
	return Config.itemDefs.byName[n].type;
}
#endregion
