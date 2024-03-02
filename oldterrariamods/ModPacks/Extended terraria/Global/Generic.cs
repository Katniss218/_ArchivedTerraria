public static int extraSlots = 3;
public static List<int> npcList = new List<int>() { 4,10,11,12,21,31,32,33,34,45,50,58,63,64,65,71,72,73,77,85,93,95,96,97,102,103,104,110,113,114,115,116,117,118,119,125,126,133,134,135,136,139,140,141,Config.npcDefs.byName["Salmon"].type,Config.npcDefs.byName["Juggernaut"].type,Config.npcDefs.byName["Irate Bones"].type,Config.npcDefs.byName["Protector Wheel"].type,Config.npcDefs.byName["Man of War"].type,Config.npcDefs.byName["Turtle"].type };

public static Rectangle NewRect(NPC N)
{
	return new Rectangle((int)N.position.X, (int)N.position.Y, N.width, N.height);
}
public static Rectangle NewRect(Player P)
{
	return new Rectangle((int)P.position.X, (int)P.position.Y, P.width, P.height);
}
public static Rectangle NewRect(Projectile Pr)
{
	return new Rectangle((int)Pr.position.X, (int)Pr.position.Y, Pr.width, Pr.height);
}
public static Rectangle NewRectV2(Vector2 V, Vector2 WH)
{
	return new Rectangle((int)V.X, (int)V.Y, (int)WH.X, (int)WH.Y);
}

public void OnLoad()
{
	Main.tileMerge[Config.tileDefs.ID["Ice Block"]][1] = true;
	Main.tileMerge[1][Config.tileDefs.ID["Ice Block"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Tropical Grass"]][Config.tileDefs.ID["Tropical Mud"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Tropical Mud"]][Config.tileDefs.ID["Tropical Grass"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Tropic Stone"]][Config.tileDefs.ID["Tropical Mud"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Tropical Mud"]][Config.tileDefs.ID["Tropic Stone"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Impervious Brick"]][Config.tileDefs.ID["Impervious Brick 2"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Impervious Brick 2"]][Config.tileDefs.ID["Impervious Brick"]] = true;
	Main.tileMerge[147][Config.tileDefs.ID["Ice Block"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Ice Block"]][147] = true;
	Main.tileMerge[Config.tileDefs.ID["Tropic Stone"]][1] = true;
	Main.tileMerge[1][Config.tileDefs.ID["Tropic Stone"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Hallowed Ore"]][Config.tileDefs.ID["Hallowstone Block"]] = true;
	Main.tileMerge[Config.tileDefs.ID["Hallowstone Block"]][Config.tileDefs.ID["Hallowed Ore"]] = true;
	Main.colorRarityMax = 8;
	Main.colorRarity[7] = new float[3] { 210f, 210f, 50f };
	Main.colorRarity[8] = new float[3] { 110f, 255f, 48f };
	Biome.Biomes["Ocean"].TileValid = (x, y, pid) =>
	{
	    return NPC.SpawnWater && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) && (Main.tile[x, y].type == 53 || Main.tile[x, y].type == 116 || Main.tile[x, y].type == t("Black Sand"));
	};

	Biome.Biomes["Overworld"].TileValid = (x, y, pid) =>
	{
	    Player P = Main.player[pid];
	    if (P.zone["Corruption"])
            return false;
	    if (P.zone["Hallow"])
            return false;
	    if (P.zone["Jungle"])
            return false;
	    if (P.zone["Meteor"])
            return false;
	    if (P.zone["Dungeon"])
            return false;
	    if (P.zone["RockLayer"])
            return false;
	    if (P.zone["DirtLayer"])
            return false;
	    if (P.zone["Ocean"])
            return false;
	    if (P.zone["Hell"])
            return false;
	    if (P.zone["Glowshroom"])
            return false;
	    if (P.zone["Tropics"])
            return false;
	    if (P.zone["Comet"])
            return false;
	    if (P.zone["Ice Cave"])
            return false;
	    if (P.zone["Hellcastle"])
            return false;
	    if (P.zone["Sky Fortress"])
            return false;
	    return true;
	};

	Biome B = new Biome("Comet", new List<int> {t("Ever Ice")}, new List<int> { }, 50);
	B.SetBiomeMusic(Biome.MusicPriority.High, 2, true);
	B.AddToGame();

	B = new Biome("Tropics", new List<int> { t("Black Sand"), t("Tropical Mud"), t("Tropical Grass"), t("Tropic Stone") }, new List<int> { }, 80);
	B.SetBiomeMusic(Biome.MusicPriority.Med, 7, true);
	B.AddToGame();

	B = new Biome("Ice Cave", new List<int> { t("Ice Block") }, new List<int> { }, 50);
	B.AddToGame();

	B = new Biome("Hellcastle", new List<int> { t("Impervious Brick"), t("Resistant Wood") }, new List<int> { }, 100);
	B.TileValid = (x, y, pid) =>
        {
            return y < Main.maxTilesX - 200 && (Main.tile[x, y].type == t("Impervious Brick") || Main.tile[x, y].type == t("Resistant Wood"));
        };
	B.AddToGame();

	B = new Biome("Sky Fortress", new List<int> { t("Reinforced Glass"), t("Hallowstone Block") }, new List<int> { }, 100);
	B.TileValid = (x, y, pid) =>
        {
            return y < 200 && (Main.tile[x, y].type == t("Reinforced Glass") || Main.tile[x, y].type == t("Hallowstone Block"));
        };
	B.AddToGame();

	B = new Biome("Clouds", new List<int> { t("Cloud") }, new List<int> { }, 20);
	B.TileValid = (x, y, pid) =>
        {
            return y < 200 && Main.tile[x, y].type == t("Cloud");
        };
	B.AddToGame();
}

public static bool SomeNPCs(int Type, int numberOf)
{
	int counter = 0;
	if (numberOf <= 0) return false;
	for (int i = 0; i < Main.npc.Length; i++)
	{
		if (Main.npc[i].active && Main.npc[i].type == Type)
		{
			if (counter <= numberOf)
			{
				if (counter == numberOf)
				{
					return false;
				}
				else counter++;
			}
		}
	}
	return true;
}

public void UpdateSpawn(Player P)
{
	if (Main.netMode == 2) return;
	if (ModWorld.WraithInvasion)
	{
		NPC.spawnRate = 30;
		NPC.maxSpawns = 20;
		for (int k = 0; k < 50; k++)
		{
			if (Main.npc[k].townNPC) continue;
			if (Main.npc[k] == null) continue;
			int NT = Main.npc[k].type;
			if (NT != Config.npcDefs.byName["Armored Wraith 2"].type && NT != Config.npcDefs.byName["Wraith Archer 2"].type && NT != Config.npcDefs.byName["Wraith 2"].type)
			{
				Main.npc[k].active = false;
			}
		}
	}
	if (P.zone["Tropics"] && P != null)
	{
		NPC.spawnRate = 50;
		NPC.maxSpawns = 15;
		for (int k = 0; k < 50; k++)
		{
			if (Main.npc[k].townNPC) continue;
			if (Main.npc[k] == null) continue;
			//if (!Main.player[Main.myPlayer].zone["Tropics"]) continue;
			int NT = Main.npc[k].type;
			Rectangle npcRect = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
			Rectangle screen = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			if (npcRect.Intersects(screen)) continue;
			if (!npcList.Contains(NT))
			{
				Main.npc[k].active = false;
			}
		}
	}
	if (P.zone["Comet"] && P != null)
	{
		NPC.spawnRate = 40;
		NPC.maxSpawns = 15;
		for (int k = 0; k < 50; k++)
		{
			if (Main.npc[k].townNPC) continue;
			if (Main.npc[k] == null) continue;
			//if (!Main.player[Main.myPlayer].zone["Comet"]) continue;
			int NT = Main.npc[k].type;
			Rectangle npcRect = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
			Rectangle screen = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			if (npcRect.Intersects(screen)) continue;
			if (NT != Config.npcDefs.byName["Comet Tail"].type && NT != 127 && NT != 128 && NT != 129 && NT != 130 && NT != 131 && NT != 134 && NT != 135 && NT != 136)
			{
				Main.npc[k].active = false;
			}
		}
	}
	if (P.zone["Hellcastle"] && P != null)
	{
		NPC.spawnRate = 50;
		NPC.maxSpawns = 15;
		for (int k = 0; k < 50; k++)
		{
			if (Main.npc[k].townNPC) continue;
			if (Main.npc[k] == null) continue;
			//if (!Main.player[Main.myPlayer].zone["Hellcastle"]) continue;
			int NT = Main.npc[k].type;
			Rectangle npcRect = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
			Rectangle screen = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			if (npcRect.Intersects(screen)) continue;
			if (NT != Config.npcDefs.byName["Gargoyle"].type && NT != 60 && NT != Config.npcDefs.byName["Blaze"].type && NT != Config.npcDefs.byName["Flame Bat"].type && NT != Config.npcDefs.byName["Blaze Orb"].type && NT != 113 && NT != 114 && NT != 115 && NT != 116 && NT != 117 && NT != 118 && NT != 119)
			{
				Main.npc[k].active = false;
			}
		}
	}
}

public static int t(string n) {
    return Config.tileDefs.ID[n];
}