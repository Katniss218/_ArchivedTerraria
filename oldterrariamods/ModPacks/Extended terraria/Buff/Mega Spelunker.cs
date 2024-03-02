public static void Effects(Player player) {
	Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
	int zeroX = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
	int tilesX = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
	int zeroY = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
	int tilesY = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
	if (zeroX < 0)
	{
		zeroX = 0;
	}
	if (tilesX > Main.maxTilesX)
	{
		tilesX = Main.maxTilesX;
	}
	if (zeroY < 0)
	{
		zeroY = 0;
	}
	if (tilesY > Main.maxTilesY)
	{
		tilesY = Main.maxTilesY;
	}
	for (int i = zeroY; i < tilesY + 4; i++)
	{
		for (int j = zeroX - 2; j < tilesX + 2; j++)
		{
			Color color = Lighting.GetColor(j, i);
			if ((Main.tile[j, i].type == 6 || Main.tile[j, i].type == 7 || Main.tile[j, i].type == 8 || Main.tile[j, i].type == 9 || Main.tile[j, i].type == 12 || Main.tile[j, i].type == 21 || Main.tile[j, i].type == 22 || Main.tile[j, i].type == 28 || Main.tile[j, i].type == 107 || Main.tile[j, i].type == 108 || Main.tile[j, i].type == 111 || Main.tile[j, i].type == Config.tileDefs.ID["Titanium Ore"] || Main.tile[j, i].type == Config.tileDefs.ID["Caesium Ore"] || Main.tile[j, i].type == Config.tileDefs.ID["Heartstone"] || Main.tile[j, i].type == Config.tileDefs.ID["Hallowed Ore"] || Main.tile[j, i].type == Config.tileDefs.ID["Corrupted Ore"] || Main.tile[j, i].type == Config.tileDefs.ID["Jungle Ore"] || Main.tile[j, i].type == Config.tileDefs.ID["Ice Block"] || Main.tile[j, i].type == Config.tileDefs.ID["Magmatic Ore"] || Main.tile[j, i].type == Config.tileDefs.ID["Ever Ice"] || Main.tile[j, i].type == Config.tileDefs.ID["Dark Matter"] || Main.tile[j, i].type == 58 || (Main.tile[j, i].type >= 63 && Main.tile[j, i].type <= 68) || Main.tileAlch[(int)Main.tile[j, i].type]))
			{
				if (color.R < Main.mouseTextColor / 2)
				{
					color.R = (byte)(Main.mouseTextColor / 2);
				}
				if (color.G < 70)
				{
					color.G = (byte)70;
				}
				if (color.B < 210)
				{
					color.B = (byte)210;
				}
				color.A = Main.mouseTextColor;
				if (!Main.gamePaused && Main.rand.Next(50) == 0)
				{
					int num10 = Dust.NewDust(new Vector2((float)(j * 16), (float)(i * 16)), 16, 16, 15, 0f, 0f, 150, default(Color), 0.8f);
					Main.dust[num10].velocity *= 0.1f;
					//Main.dust[num10].noLight = false;
				}
			}
		}
	}
}