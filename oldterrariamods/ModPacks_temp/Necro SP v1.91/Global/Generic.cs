public static readonly bool gen = true;

#region Biome Gen Custom Tiles
public void OnLoad()
{
	/*Main.colorRarity[7] = new float[3] { 255f, 255f, 0f };
	B = new Biome("Blood Dungeon", new List<int> { Config.tileDefs.ID["Demon Blood Brick"] }, new List<int> { }, 250);
	B.Validation = (P, count, nex) =>
	{
		if (count >= nex && P.position.Y > Main.worldSurface * 16)
		{
			int TX = (int)P.position.X / 16;
			int TY = (int)P.position.Y / 16;
			if (Main.tile[TX, TY].wall > 0 && !Main.wallHouse[(int)Main.tile[TX, TY].wall])
				return true;
		}
		return false;
	};
	B.AddToGame();*/
	if (ModWorld.newWorld == "Nightmare")
	{
		Biome.Biomes["Dungeon"].typesIncrease.Add(Config.tileDefs.ID["Demon Blood Brick"]);
		Biome.Biomes["Desert"].typesIncrease.Add(Config.tileDefs.ID["Red Sand"]);
		Biome.Biomes["Underworld"].typesIncrease.Add(Config.tileDefs.ID["Flesh Block"]);
	}
	if (ModPlayer.currentWorld == "Nightmare")
	{
		Biome.Biomes["Dungeon"].typesIncrease.Add(Config.tileDefs.ID["Demon Blood Brick"]);
		Biome.Biomes["Desert"].typesIncrease.Add(Config.tileDefs.ID["Red Sand"]);
		Biome.Biomes["Underworld"].typesIncrease.Add(Config.tileDefs.ID["Flesh Block"]);
	}
}
#endregion

