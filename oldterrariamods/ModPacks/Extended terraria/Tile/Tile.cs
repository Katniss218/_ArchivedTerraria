public void ModifyWorld()
{
	//ModWorld.jungleEx = WorldGen.JungleX;
	//ModWorld.DungEnt = WorldGen.dEnteranceX;
	double num3 = (double)(Main.maxTilesY * 0.3) + 10.0;
	num3 *= (double)WorldGen.genRand.Next(90, 110) * 0.005;
	double num6 = num3;
	int xcoord = 0;
	int ycoord = 0;

	Main.statusText = ModWorld.gen[0];
	int Amount_Of_Spawns3 = 200+(int)(Main.maxTilesY/10);
	for (int amount = 0; amount < Amount_Of_Spawns3; amount++)
	{
		xcoord = (WorldGen.genRand.Next(30, Main.maxTilesX - 30));
		ycoord = (WorldGen.genRand.Next(50, 150));
		ModWorld.MakeCloud(xcoord, ycoord);
		//ModWorld.CloudPlatform();
	}

	Main.statusText = ModWorld.gen[1];
	int Amount_Of_Spawns = 100+(int)(Main.maxTilesY/5);
	for(int i=0;i<Amount_Of_Spawns;i++) AddTitaniumOre();

	Main.statusText = ModWorld.gen[2];
	int Amount_Of_Spawns4 = 150+(int)(Main.maxTilesY/6);
	for(int i=0;i<Amount_Of_Spawns4;i++) AddCoalOre();

	Main.statusText = ModWorld.gen[3];
	int Amount_Of_Spawns2 = 30+(int)(Main.maxTilesY/10);
	for(int j=0;j<Amount_Of_Spawns2;j++) AddJungleOre();

	Main.statusText = ModWorld.gen[4];
	for (int i = 0; i < 3; i++)
	{
		int xc = WorldGen.genRand.Next(200, (int)(Main.maxTilesX - 200));
		int yc = WorldGen.genRand.Next((int)Main.worldSurface, (int)(Main.maxTilesY - 300));
		ModWorld.IceShrine(xc, yc);
	}

	//ModWorld.AddLavaShrine((int)(Main.maxTilesX / 2), (int)Main.worldSurface - 120);

	//ModWorld.AddLibraryK((int)(Main.maxTilesX / 2), (int)Main.worldSurface);

	Main.statusText = ModWorld.gen[5];
	for (int caesium = 0; caesium < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 5E-05); caesium++)
	{
		WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 140, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(5, 11), Config.tileDefs.ID["Caesium Ore"], true, 0f, 0f, false, true);
	}

	Main.statusText = "Generating Hellcastle...";
	ModWorld.AddHellCastle();

	for (int num236 = 0; num236 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0005); num236++)
	{
		float num237 = (float)((double)num236 / ((double)(Main.maxTilesX * Main.maxTilesY) * 0.0005));
		Main.statusText = string.Concat(new object[]
		{
			ModWorld.gen[7],
			" ",
			(int)(num237 * 100f + 1f),
			"%"
		});
		bool flag12 = false;
		int num238 = 0;
		while (!flag12)
		{
			int num239 = WorldGen.genRand.Next(1, Main.maxTilesX);
			int num240 = (int)(num6 + (double)WorldGen.genRand.Next(20, 45));
			WorldGen.Place3x2(num239, num240, Config.tileDefs.ID["Hallowed Altar"]);
			if (Main.tile[num239, num240].type == (ushort)Config.tileDefs.ID["Hallowed Altar"])
			{
				flag12 = true;
			}
			else
			{
				num238++;
				if (num238 >= 10000)
				{
					flag12 = true;
				}
			}
		}
	}

	Main.statusText = ModWorld.gen[8];
	for (int loopcounter = 0; loopcounter < Main.maxTilesX / 500; loopcounter++) {
		int i3 = WorldGen.genRand.Next((int)((double)Main.maxTilesX * 0.3), (int)((double)Main.maxTilesX * 0.7));
		int j3 = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 450);
		ModWorld.HeartStonePatch(i3, j3);
	}

	for (int loop = 0; loop < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0015); loop++)
	{
		float num58 = (float)((double)loop / ((double)(Main.maxTilesX * Main.maxTilesY) * 0.0015));
		Main.statusText = string.Concat(new object[]
		{
			ModWorld.gen[9],
			" ",
			(int)(num58 * 100f + 1f),
			"%"
		});
		for (int loopcounter2 = 0; loopcounter2 < Main.maxTilesX / 500; loopcounter2++)
		{
			int i4 = WorldGen.genRand.Next((int)((double)Main.maxTilesX * 0.3), (int)((double)Main.maxTilesX * 0.7));
			int j4 = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 450);
			for (int blaarg = 0; blaarg < 10000; blaarg++)
			{
			}
		}
	}
	for (int loopcounter2 = 0; loopcounter2 < Main.maxTilesX / 300; loopcounter2++)
	{
		int i4 = WorldGen.genRand.Next((int)((double)Main.maxTilesX * 0.3), (int)((double)Main.maxTilesX * 0.7));
		int j4 = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 450);
		ModWorld.MakeIceCave(i4, j4);
		//ModWorld.generateIceCave(i4, j4);
	}

	foreach(Chest C in Main.chest)
	{
		if (C != null)
		{
			foreach(Item I in C.item)
			{
				if (I != null && I.type == 155)
				{
					int random = WorldGen.genRand.Next(2);
					if (random == 0) I.SetDefaults("Muramasa");
					if (random == 1) I.SetDefaults("Dungeon Bow");
					I.Prefix(-1);
				}
				if (I != null && I.type == 156)
				{
					int random2 = WorldGen.genRand.Next(3);
					if (random2 == 0) I.SetDefaults("Cobalt Shield");
					if (random2 == 1) I.SetDefaults("Aquarang");
					if (random2 == 2) I.SetDefaults("Cobalt Shield");
					I.Prefix(-1);
				}
				if (I != null && I.type == 157)
				{
					int random3 = WorldGen.genRand.Next(2);
					if (random3 == 0) I.SetDefaults("Aqua Scepter");
					if (random3 == 1) I.SetDefaults("Blueshift");
					I.Prefix(-1);
				}
				if (I != null && I.type == 113)
				{
					int random4 = WorldGen.genRand.Next(2);
					if (random4 == 0) I.SetDefaults("Magic Missile");
					if (random4 == 1) I.SetDefaults("Sapphire Pickaxe");
					I.Prefix(-1);
				}
				if (I != null && I.type == 163)
				{
					int random5 = WorldGen.genRand.Next(3);
					if (random5 == 0) I.SetDefaults("Blue Moon");
					if (random5 == 1) I.SetDefaults("Aquarang");
					if (random5 == 2) I.SetDefaults("Sapphire Pickaxe");
					I.Prefix(-1);
				}
				if (I != null && I.type == 164)
				{
					int random6 = WorldGen.genRand.Next(2);
					if (random6 == 0) I.SetDefaults("Handgun");
					if (random6 == 1) I.SetDefaults("Dungeon Bow");
					I.Prefix(-1);
				}
				if (I != null && I.type == 329)
				{
					int random7 = WorldGen.genRand.Next(3);
					if (random7 == 0) I.SetDefaults("Shadow Key");
					if (random7 == 1) I.SetDefaults("Blueshift");
					if (random7 == 2) I.SetDefaults("Shadow Key");
					I.Prefix(-1);
				}
				if (I != null && I.type == 213)
				{
					int random8 = WorldGen.genRand.Next(2);
					if (random8 == 0) I.SetDefaults("Staff of Regrowth");
					if (random8 == 1) I.SetDefaults("Flower of the Jungle");
					I.Prefix(-1);
				}
			}
		}
	}
	WGReplaceChests();
	WGPlaceCustomStatues();
}


public void AddTitaniumOre()
{
	int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
	double num6;
	num6 = Main.rockLayer;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 150);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(4, 6), Config.tileDefs.ID["Titanium Ore"]);
}

public void AddCoalOre()
{
	int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
	double num6;
	num6 = Main.rockLayer - 75f;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 150);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(3, 11), WorldGen.genRand.Next(4, 9), Config.tileDefs.ID["Coal Ore"]);
}

public void AddJungleOre()
{
	int i2 = WorldGen.genRand.Next(WorldGen.JungleX - 112, WorldGen.JungleX + 112);
	double num6;
	num6 = Main.rockLayer;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 190);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(2, 4), Config.tileDefs.ID["Jungle Ore"]);
}

public static void WGReplaceChests() {
	Main.statusText = "Replacing chests...";
	int idJungle = Config.tileDefs.ID["Jungle Chest"]; //, idHell = Config.tileDefs.ID["Hellfire Chest"];
	
	for (int i = 0; i < Main.chest.Length; i++)
	{
		Chest c = Main.chest[i];
		if (c == null || c.x < 0 || c.y < 0) continue;
		if (Main.tile[c.x,c.y].frameX/18 != 2) continue;
		
		int xMin = Math.Max(c.x-5,0), xMax = Math.Min(c.x+1+5,Main.maxTilesX-1);
		int yMin = Math.Max(c.y-5,0), yMax = Math.Min(c.y+1+5,Main.maxTilesY-1);
		
		bool isJungle = false;
		for (int y = yMin; y <= yMax; y++) for (int x = xMin; x <= xMax; x++) if (Main.tile[x,y] != null && Main.tile[x,y].active && (Main.tile[x,y].type == 60 || Main.tile[x,y].wall == 15)) {
			isJungle = true;
			goto L;
		}
		L: {}
		if (isJungle) {
			WGReplaceChest(c.x,c.y,idJungle);
			continue;
		}
		
		/*if (c.y >= WorldGen.lavaLine) {
			WGReplaceChest(c.x,c.y,idHell);
			continue;
		}*/
	}
}
public static void WGReplaceChest(int x, int y, int type) {
	for (int yy = 0; yy < 2; yy++) for (int xx = 0; xx < 2; xx++) {
		Main.tile[x+xx,y+yy].type = (ushort)type;
		Main.tile[x+xx,y+yy].frameX = (short)(xx == 0 ? 0 : 18);
		Main.tile[x+xx,y+yy].frameY = (short)(yy == 0 ? 0 : 18);
	}
}
public static void WGPlaceCustomStatues()
{
	ushort DNA = (ushort)Config.tileDefs.ID["DNA Statue"];
	ushort tome = (ushort)Config.tileDefs.ID["Tome Statue"];
	ushort hallow = (ushort)Config.tileDefs.ID["Hallow Statue"];
	ushort shell = (ushort)Config.tileDefs.ID["Shell Statue"];
	ushort skull = (ushort)Config.tileDefs.ID["Skull Statue"];
	double num3 = (double)Main.maxTilesY * 0.3;
	num3 *= (double)WorldGen.genRand.Next(90, 110) * 0.005;
	double num6 = num3;
	float num251 = (float)(Main.maxTilesX / 4200);
	int num255 = 0;
	int num256 = 0;
	while ((float)num256 < 82f * num251)
	{
		if (num255 > 41)
		{
			num255 = 0;
		}
		float num257 = (float)num256 / (200f * num251);
		Main.statusText = string.Concat(new object[]
		{
			ModWorld.gen[10],
			" ",
			(int)(num257 * 100f + 1f),
			"%"
		});
		bool flag14 = false;
		int num258 = 0;
		while (!flag14)
		{
			int num259 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
			int num260 = WorldGen.genRand.Next((int)(num6 + 100.0), Main.maxTilesY - 300);
			while (!Main.tile[num259, num260].active)
			{
				num260++;
			}
			num260--;
			int randomNum = WorldGen.genRand.Next(5);
			if (randomNum == 0)
			{
				WorldGen.PlaceTile(num259, num260, DNA, true, true, -1, 0);
			}
			if (randomNum == 1)
			{
				WorldGen.PlaceTile(num259, num260, tome, true, true, -1, 0);
			}
			if (randomNum == 2)
			{
				WorldGen.PlaceTile(num259, num260, hallow, true, true, -1, 0);
			}
			if (randomNum == 3)
			{
				WorldGen.PlaceTile(num259, num260, shell, true, true, -1, 0);
			}
			if (randomNum == 4)
			{
				WorldGen.PlaceTile(num259, num260, skull, true, true, -1, 0);
			}
			num258++;
			if (num258 >= 10)
			{
				flag14 = true;
			}
		}
		num256++;
	}
}