public void ModifyWorld() 
{
{
foreach(Chest C in Main.chest)
		{
			if (C != null)
			{
				foreach(Item I in C.item)
				{
					if (I != null && I.type == Config.itemDefs.byName["Band of Regeneration"].type)
					{
                    int random = WorldGen.genRand.Next(4);
                        if (random == 0) I.SetDefaults("Azure Gauntlet");
                        if (random == 1) I.SetDefaults("Jade Gauntlet");
                        if (random == 2) I.SetDefaults("Crimson Gauntlet");
                        if (random == 3) I.SetDefaults("Band of Regeneration");
					}
				}
			}
		}
foreach(Chest C in Main.chest)
		{
			if (C != null)
			{
				foreach(Item I in C.item)
				{
					if (I != null && I.type == Config.itemDefs.byName["Spear"].type)
					{
                    int random = WorldGen.genRand.Next(4);
                        if (random == 0) I.SetDefaults("Spear");
                        if (random == 1) I.SetDefaults("Cloth Hat");
                        if (random == 2) I.SetDefaults("Cloth Shirt");
                        if (random == 3) I.SetDefaults("Cloth Boots");
					}
				}
			}
		}
foreach(Chest C in Main.chest)
		{
			if (C != null)
			{
				foreach(Item I in C.item)
				{
					if (I != null && I.type == Config.itemDefs.byName["Enchanted Boomerang"].type)
					{
                    int random = WorldGen.genRand.Next(7);
                        if (random == 0) I.SetDefaults("Enchanted Boomerang");
                        if (random == 1) I.SetDefaults("Shiny Object");
                        if (random == 2) I.SetDefaults("Demonic Rune");
                        if (random == 3) I.SetDefaults("Tiara");
                        if (random == 4) I.SetDefaults("Black Heart");
						if (random == 5) I.SetDefaults("Flare Gun");
						if (random == 6) I.SetDefaults("Dragon Bell");
                
					}
				}
			}
		}
	}
    Main.statusText = "Adding My Ores..."; //feel free to tweak
    int Amount_Of_Spawns = 75+(int)(Main.maxTilesY/5); //feel free to tweak
    for(int i=0;i<Amount_Of_Spawns;i++) AddMyOres();
	
	Main.statusText = "Adding My Ores..."; //feel free to tweak
    int Amount_Of_Spawns2 = 150+(int)(Main.maxTilesY/5); //feel free to tweak
    for(int i=0;i<Amount_Of_Spawns2;i++) AddSmoothCoal();
	
	Main.statusText = "Adding My Ores..."; //feel free to tweak
    int Amount_Of_Spawns3 = 100+(int)(Main.maxTilesY/5); //feel free to tweak
    for(int i=0;i<Amount_Of_Spawns3;i++) AddAged();
	
	Main.statusText = "Adding My Ores..."; //feel free to tweak
    int Amount_Of_Spawns4 = 50+(int)(Main.maxTilesY/5); //feel free to tweak
    for(int i=0;i<Amount_Of_Spawns4;i++) AddMag();
}
public void AddMyOres() 
{
    int LowX = 200;                     //after ocean on left edge of map
    int HighX = Main.maxTilesX-200;     //before ocean on right edge of map
    int LowY = (int)Main.worldSurface;  //where the brown background and the sky background meets
    int HighY = Main.maxTilesY-200;     //where hell and the grey background meets
    
    int X = WorldGen.genRand.Next(LowX,HighX); //don't touch
    int Y = WorldGen.genRand.Next(LowY,HighY); //don't touch

    int OreMinimumSpread = 5; //feel free to tweak
    int OreMaximumSpread = 6; //feel free to tweak

    int OreMinimumFrequency = 5; //feel free to tweak
    int OreMaximumFrequency = 6; //feel free to tweak

    int OreSpread = WorldGen.genRand.Next(OreMinimumSpread,OreMaximumSpread+1); //don't touch
    int OreFrequency = WorldGen.genRand.Next(OreMinimumFrequency,OreMaximumFrequency+1); //don't touch

    WorldGen.OreRunner(X, Y, (double)OreSpread, OreFrequency, Config.tileDefs.ID["Thorium"]);
}

public void AddMag()
{
	int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
	double num6;
	num6 = Main.rockLayer;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 150);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(4, 6), Config.tileDefs.ID["Magma Ore"]);
}

public void AddSmoothCoal()
{
	int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
	double num6;
	num6 = Main.rockLayer - 30f;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 150);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(3, 11), WorldGen.genRand.Next(4, 9), Config.tileDefs.ID["Smooth Coal"]);
}

public void AddAged()
{
	int i2 = WorldGen.genRand.Next(WorldGen.JungleX - 75, WorldGen.JungleX + 75);
	double num6;
	num6 = Main.rockLayer;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 190);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(2, 4), Config.tileDefs.ID["Aged Cobalt"]);
}