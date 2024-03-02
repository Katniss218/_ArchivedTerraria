public void UseTile(Player player, int x, int y)
{
	if(Main.netMode == 0) // only Singleplayer
	{
		if(Main.tile[x, y].frameNumber == 0) // Make Day, Sun Crest
		{	
			if(!Main.dayTime)
			{
				Main.dayTime=true;
				Main.NewText("Sun is rising");
			}
			
			if(Main.time >= 0.0f && Main.time <= 27000.0f)
			{
				Main.time = 27000.0f;
				Main.NewText("Noon");
			}
			else if(Main.time > 27000.0f)
			{
				Main.time = 0.0;
				Main.NewText("Dawn");
			}
		}
		else if(Main.tile[x, y].frameNumber == 1) // Make Night, if Night toggle Bloodmoon, Moon Crest
		{	
			if(Main.dayTime) // if day
			{
				Main.dayTime=false;
				Main.time=0.0f;
				Main.NewText("Moon is rising");
			}
			else if(!Main.dayTime && !Main.bloodMoon) // if night and no bloodmoon
			{
				Main.bloodMoon=true;
				Main.NewText("A Bloodmoon is rising!", 200, 20, 20);
			}
			else if(!Main.dayTime && Main.bloodMoon)
			{
				Main.bloodMoon=false;
				Main.NewText("Look, what a beautiful Night.");
			}
		}
		else if(Main.tile[x, y].frameNumber == 2) // Spawn Stars, Star Crest
		{	
			if(!Main.dayTime)
			{
				Main.NewText("Twinkle Twinkle little Star...", 32,178,170);
                
				int num76 = 12;
                int num77 = x * 16;
                int num78 = Main.rand.Next((int) (y * 0.05)) * 16;
                Vector2 vector = new Vector2((float) num77, (float) num78);
                float speedX = Main.rand.Next(-100, 0x65);
                float speedY = Main.rand.Next(200) + 100;
                float num81 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                num81 = ((float) num76) / num81;
                speedX *= num81;
                speedY *= num81;
                Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, 12, 0x3e8, 10f, Main.myPlayer);
			}
			else
			{
				Main.NewText("Only at Night!");
			}
		}
		else if(Main.tile[x, y].frameNumber == 3) // Wind Crest
		{	
			Main.NewText("A Storm is coming!", 110,110,110);
		}
	}
	else
	{
		Main.NewText("You can't use this");
	}
}

public void KillTile(int x, int y, Player player)
{
	int index = 0;
	
	if(Main.tile[x, y].frameNumber == 0)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Sun Crest"].type);
	}
	else if(Main.tile[x, y].frameNumber == 1)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Moon Crest"].type);
	}
	else if(Main.tile[x, y].frameNumber == 2)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Star Crest"].type);
	}
	else if(Main.tile[x, y].frameNumber == 3)
	{	
		index = Item.NewItem(x * 16, y * 16 - 10, 14, 18, (int)Config.itemDefs.byName["Wind Crest"].type);
	}
	
	if(Main.netMode != 0)
	{
		NetMessage.SendData(21, -1, -1, "", index, 0f,0f,0f, 0);
	}
}