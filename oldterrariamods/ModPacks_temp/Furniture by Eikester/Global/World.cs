//#INCLUDE "pong.cs"
#INCLUDE "musicplayer.cs"
#INCLUDE "ponggame.cs"

public static bool ChangeHair = false;
public static int HairNum = 0;
public static Vector2 currentPlayerPosition = new Vector2();
public static Vector2 currentMirrorPosition = new Vector2();

public static Microsoft.Xna.Framework.Input.MouseState mouseState;
public static Microsoft.Xna.Framework.Input.MouseState oldMouseState;

//public static Pong pong = new Pong();
public static MusicPlayer radio = new MusicPlayer();

public static bool pongGameRunning = false;
public static PongGame pongGame = new PongGame(); 

public static bool NeedsToLoadRecipes = true;
public static float tick = 0.0f;

private static Func<string, Texture2D, bool> AcAchieve = null;
private static Action<int, string> AcAchievePlayer = null;
private static Action<string> AcAchieveAllPlayers = null;

// Hair Buttons
public static Rectangle btnHairPrev = new Rectangle(300, 320, 10, 14);
public static Rectangle btnHairNext = new Rectangle(380, 320, 10, 14);
	
// Color Buttons
public static Rectangle btnRedDec = new Rectangle(300, 340, 10, 14);
public static Rectangle btnRedInc = new Rectangle(380, 340, 10, 14);
public static Rectangle btnBlueDec = new Rectangle(300, 380, 10, 14);
public static Rectangle btnBlueInc = new Rectangle(380, 380, 10, 14);
public static Rectangle btnGreenDec = new Rectangle(300, 360, 10, 14);
public static Rectangle btnGreenInc = new Rectangle(380, 360, 10, 14);

//OK Button
public static Rectangle btnOk = new Rectangle(330, 400, 30, 20);	

public void Initialize(int m)
{
	currentPlayerPosition = new Vector2();
	currentMirrorPosition = new Vector2(-1, -1);
	
	//pong = new Pong();
	pongGame = new PongGame(); 
	radio = new MusicPlayer();
}

public static bool FakeLoad()
{
    Recipe R;
	
	R = new Recipe();
    R.createItem.SetDefaults("Glass");
	R.createItem.stack = 1;
    R.requiredItem[0].SetDefaults("Pearlsand Block");
	R.requiredItem[0].stack = 2;
	R.requiredTile[0] = 17;
    Config.recipeByName.Add("Pearl Glass", R);
	
	R = new Recipe();
	R.createItem.SetDefaults("Glass");
	R.createItem.stack = 1;
    R.requiredItem[0].SetDefaults("Ebonsand Block");
	R.requiredItem[0].stack = 2;
	R.requiredTile[0] = 17;
    Config.recipeByName.Add("Ebon Glass", R);
	
	R = new Recipe();
	R.createItem.SetDefaults("Crystal Storm");
	R.createItem.stack = 1;
    R.requiredItem[0].SetDefaults("Crystal Shard");
	R.requiredItem[0].stack = 30;
	R.requiredItem[1].SetDefaults("Soul of Light");
	R.requiredItem[1].stack = 20;
	R.requiredItem[2].SetDefaults("Spell Tome");
	R.requiredItem[2].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Ornate Bookcase"];
    Config.recipeByName.Add("Crystal Storm 1", R);
	
	R = new Recipe();
	R.createItem.SetDefaults("Cursed Flames");
	R.createItem.stack = 1;
    R.requiredItem[0].SetDefaults("Cursed Flame");
	R.requiredItem[0].stack = 30;
	R.requiredItem[1].SetDefaults("Soul of Night");
	R.requiredItem[1].stack = 20;
	R.requiredItem[2].SetDefaults("Spell Tome");
	R.requiredItem[2].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Ornate Bookcase"];
    Config.recipeByName.Add("Cursed Flames 1", R);

    #region what tConfig uses to load recipes from mods , copy paste it to yours

    Recipe.maxRecipes = Config.recipeByName.Values.Count+4;
    Main.recipe = new Recipe[Recipe.maxRecipes];
    Main.availableRecipe = new int[Recipe.maxRecipes];
    Main.availableRecipeY = new float[Recipe.maxRecipes];
    Recipe.numRecipes = 0;

    for (int num11 = 0; num11 < Recipe.maxRecipes; num11++)
    {
        Main.recipe[num11] = new Recipe();
        Main.availableRecipeY[num11] = (float)(65 * num11);
    }
                
    foreach (Recipe r in Config.recipeByName.Values)
    {
        if (r.createItem.type == 0) continue;
        Recipe.newRecipe = r;
        Recipe.addRecipe();
    }

    #endregion

    return false;
}

public static string GetTileName(int tileType)
{
	string tileName = "";
	foreach (KeyValuePair<string, int> pair in Config.tileDefs.ID)
	{
		if (pair.Value == tileType)
		{
			return tileName = pair.Key;
		}
	}
	return "";
}

public void Save(BinaryWriter writer)
{
	if(SoundHandler.customSoundInstance[SoundHandler.soundID["Kuckucksuhrloop"]].State == Microsoft.Xna.Framework.Audio.SoundState.Playing)
		SoundHandler.customSoundInstance[SoundHandler.soundID["Kuckucksuhrloop"]].Stop();
		
	if(SoundHandler.customSoundInstance[SoundHandler.soundID["Kuckucksuhralarm"]].State == Microsoft.Xna.Framework.Audio.SoundState.Playing)
		SoundHandler.customSoundInstance[SoundHandler.soundID["Kuckucksuhralarm"]].Stop();

	try
	{
		radio.StopMusic();
	}
	catch{}
}

public void Log(string text, string file = "Furniture by Eikester.log", bool append = true) 
{
    string path = file;
	
    if (!File.Exists(path))
    {
        using (StreamWriter sw = File.CreateText(path)) 
        {
            sw.WriteLine(text);
        }	
    }
	else
	{
		if(append)
		{
			using (StreamWriter sw = File.AppendText(path)) 
			{
				sw.WriteLine(text);
			}	
		}
		else
		{
			using (StreamWriter sw = File.CreateText(path)) 
			{
				sw.WriteLine(text);
			}	
		}
	}
}

public  void KillTile(int x, int y, Player player) 
{
	int index = -1;
	
	if(Main.rand.Next(10) < 3)
	{
		if ( (int)Main.tile[x,y].type == 5 && ((int)Main.tile[x,y+1].type != 5) && player != null) 
		{
			if(!player.zoneEvil && !player.zoneJungle)
				index=Item.NewItem(x * 16, y * 16, 16, 18, "Apple");
			else if(player.zoneJungle)
				index=Item.NewItem(x * 16, y * 16, 16, 18, "Cacao Bean");
				
			if(Main.netMode == 1)
			{
				NetMessage.SendData(21, -1, -1, "", index, 0f, 0f, 0f, 0);
			}
		}
	}
	
	if ( (int)Main.tile[x,y].type == 3 && Main.tile[x,y].frameX < 108 && player != null) 
	{
		int amount = Main.rand.Next(1,4);
		
		for(int i = 0; i < amount; i++)
		{
			index=Item.NewItem(x * 16, y * 16, 16, 16, "Grass");
				
			if(Main.netMode == 1)
			{
				NetMessage.SendData(21, -1, -1, "", index, 0f, 0f, 0f, 0);
			}
		}
	}
}

public static void DrawText(SpriteBatch spriteBatch, string text, Vector2 textPos, Vector2 origin, Color color, SpriteFont font, float scale = 1.0f)
{
	spriteBatch.DrawString(font, text, new Vector2(textPos.X+1, textPos.Y+1), Color.Black, 0f, origin, scale, SpriteEffects.None, 0f);
	spriteBatch.DrawString(font, text, new Vector2(textPos.X+1, textPos.Y-1), Color.Black, 0f, origin, scale, SpriteEffects.None, 0f);
	spriteBatch.DrawString(font, text, new Vector2(textPos.X-1, textPos.Y-1), Color.Black, 0f, origin, scale, SpriteEffects.None, 0f);
	spriteBatch.DrawString(font, text, new Vector2(textPos.X-1, textPos.Y+1), Color.Black, 0f, origin, scale, SpriteEffects.None, 0f);
	
	spriteBatch.DrawString(font, text, new Vector2(textPos.X, textPos.Y), color, 0f, origin, scale, SpriteEffects.None, 0f);
}
	
//public static bool loaded = false;
public static void UpdateWorld()
{
	Player player = Main.player[Main.myPlayer];
	
	ModWorld.currentPlayerPosition = new Vector2(	(int)(player.position.X / 16f), 
													(int)(player.position.Y / 16f));		
	float distance = Vector2.Distance(ModWorld.currentPlayerPosition, ModWorld.currentMirrorPosition);
	
	if(distance > 5)
	{
		ModWorld.ChangeHair = false;
		currentMirrorPosition = new Vector2(-1, -1);
	}

	//if(pong != null)
	//	pong.Update(ModWorld.currentPlayerPosition);
	
	if(pongGameRunning)
		pongGame.Update();
	
	if(radio != null)
	{
		radio.Update();
	}
}

public void PostDrawTiles(SpriteBatch sb,bool solidOnly)
{   
    Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
 
    if (solidOnly)
        return;
		
	if (Main.drawToScreen)
        value = default(Vector2);
 
    int lowX = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
    int highX = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
    int lowY = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
    int highY = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
    if (lowX < 0)
    {
        lowX = 0;
    }
    if (highX > Main.maxTilesX)
    {
        highX = Main.maxTilesX;
    }
    if (lowY < 0)
    {
        lowY = 0;
    }
    if (highY > Main.maxTilesY)
    {
        highY = Main.maxTilesY;
    }
   
	for (int x = lowX - 2; x < highX + 2; x++)
    {
        for (int y = lowY; y < highY + 4; y++)
        {
			Tile tile = Main.tile[x, y];
            if(tile.type == Config.tileDefs.ID["Digital Clock"] && tile.frameX == 0 && tile.frameY == 18)
			{
				Vector2 textPos = new Vector2(x * 16 + 16, y * 16 + 10);
				Vector2 finalPos = textPos - Main.screenPosition + value;
				
				float scale = 0.5f;
				SpriteFont font = ModGeneric.fontDigital;
				
				string text = ModGeneric.GetTime();
				
				Vector2 origin = font.MeasureString(text) / 2;
				
				sb.DrawString (
					font,
					text,
					finalPos,
					Color.Red,
					0f,
					origin,
					scale, // scale
					SpriteEffects.None,
					0f
				);
			}
        }
	}
}

public static void PostDraw(SpriteBatch spriteBatch) 
{
	if(NeedsToLoadRecipes) 
		NeedsToLoadRecipes = FakeLoad();

	//if(pong != null)
	//	pong.Draw(spriteBatch);
	if(pongGameRunning)
		pongGame.Draw(spriteBatch);
	
	// text
	string text = "";
	Vector2 textPos = new Vector2();
	Vector2 fontOrigin = new Vector2();

	Player player = Main.player[Main.myPlayer];

	if(!ModWorld.ChangeHair)
		return;
		
	int maxHairStyles = 36;
		
	oldMouseState = mouseState;
	mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

	Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
	
#region Hair Buttons
	if(mouseRect.Intersects(btnHairPrev))
	{
		DrawButton(spriteBatch, new Vector2(btnHairPrev.X, btnHairPrev.Y), new Rectangle(0, 0, 10, 14), true);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouseState != mouseState)
		{
			if (player.hair > 0 ) 
			{
				player.hair -= 1;
			} 
			else 
			{
				player.hair = maxHairStyles - 1;
			}
			
			HairNum = player.hair;
		}
	}
	else
	{
		DrawButton(spriteBatch, new Vector2(btnHairPrev.X, btnHairPrev.Y), new Rectangle(0, 0, 10, 14), false);
	}
	
	if(mouseRect.Intersects(btnHairNext))
	{
		DrawButton(spriteBatch, new Vector2(btnHairNext.X, btnHairNext.Y), new Rectangle(10, 0, 10, 14), true);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouseState != mouseState)
		{
			if (player.hair < (maxHairStyles - 1) ) 
			{
				player.hair += 1;
			} 
			else 
			{
				player.hair = 0;
			}
			
			HairNum = player.hair;
		}
	}
	else
	{
		DrawButton(spriteBatch, new Vector2(btnHairNext.X, btnHairNext.Y), new Rectangle(10, 0, 10, 14), false);
	}
		
	// Draw Text "Hair" between the 2 Buttons with Black outline
	text = "Hair";
	textPos = new Vector2(345, 330);
	fontOrigin = Main.fontMouseText.MeasureString(text) / 2;
	
	DrawText(spriteBatch, text, textPos, fontOrigin, Color.White, Main.fontMouseText);
#endregion

#region Red Color Buttons
	if(mouseRect.Intersects(btnRedInc))
	{
		DrawButton(spriteBatch, new Vector2(btnRedInc.X, btnRedInc.Y), new Rectangle(10, 0, 10, 14), true);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		{
			if (player.hairColor.R < 255)
			{
				player.hairColor.R += 1;
			}
		}
	}
	else
	{
		DrawButton(spriteBatch, new Vector2(btnRedInc.X, btnRedInc.Y), new Rectangle(10, 0, 10, 14), false);
	}
	
	if(mouseRect.Intersects(btnRedDec))
	{
		DrawButton(spriteBatch, new Vector2(btnRedDec.X, btnRedDec.Y), new Rectangle(0, 0, 10, 14), true);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		{
			if (player.hairColor.R > 0) 
			{
				player.hairColor.R -= 1;
			}
		}
	}
	else
	{
		DrawButton(spriteBatch, new Vector2(btnRedDec.X, btnRedDec.Y), new Rectangle(0, 0, 10, 14), false);
	}
		
	text = "R: " + player.hairColor.R.ToString();
	textPos = new Vector2(345, 350);
	fontOrigin = Main.fontMouseText.MeasureString(text) / 2;
	
	DrawText(spriteBatch, text, textPos, fontOrigin, Color.White, Main.fontMouseText);
#endregion

#region Green Color Buttons
	if(mouseRect.Intersects(btnGreenInc))
	{
		DrawButton(spriteBatch, new Vector2(btnGreenInc.X, btnGreenInc.Y), new Rectangle(10, 0, 10, 14), true);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		{
			if (player.hairColor.G < 255)
			{
				player.hairColor.G += 1;
			}
		}
	}
	else
	{
		DrawButton(spriteBatch, new Vector2(btnGreenInc.X, btnGreenInc.Y), new Rectangle(10, 0, 10, 14), false);
	}
	
	if(mouseRect.Intersects(btnGreenDec))
	{
		DrawButton(spriteBatch, new Vector2(btnGreenDec.X, btnGreenDec.Y), new Rectangle(0, 0, 10, 14), true);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		{
			if (player.hairColor.G > 0) 
			{
				player.hairColor.G -= 1;
			}
		}
	}
	else
	{
		DrawButton(spriteBatch, new Vector2(btnGreenDec.X, btnGreenDec.Y), new Rectangle(0, 0, 10, 14), false);
	}
		
	text = "G: " + player.hairColor.G.ToString();
	textPos = new Vector2(345, 370);
	fontOrigin = Main.fontMouseText.MeasureString(text) / 2;
	
	DrawText(spriteBatch, text, textPos, fontOrigin, Color.White, Main.fontMouseText);
#endregion

#region Blue Color Buttons
	if(mouseRect.Intersects(btnBlueInc))
	{
		DrawButton(spriteBatch, new Vector2(btnBlueInc.X, btnBlueInc.Y), new Rectangle(10, 0, 10, 14), true);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		{
			if (player.hairColor.B < 255)
			{
				player.hairColor.B += 1;
			}
		}
	}
	else
	{
		DrawButton(spriteBatch, new Vector2(btnBlueInc.X, btnBlueInc.Y), new Rectangle(10, 0, 10, 14), false);
	}
	
	if(mouseRect.Intersects(btnBlueDec))
	{
		DrawButton(spriteBatch, new Vector2(btnBlueDec.X, btnBlueDec.Y), new Rectangle(0, 0, 10, 14), true);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		{
			if (player.hairColor.B > 0) 
			{
				player.hairColor.B -= 1;
			}
		}
	}
	else
	{
		DrawButton(spriteBatch, new Vector2(btnBlueDec.X, btnBlueDec.Y), new Rectangle(0, 0, 10, 14), false);
	}
		
	text = "B: " + player.hairColor.B.ToString();
	textPos = new Vector2(345, 390);
	fontOrigin = Main.fontMouseText.MeasureString(text) / 2;
	
	DrawText(spriteBatch, text, textPos, fontOrigin, Color.White, Main.fontMouseText);
#endregion

#region OK Button
    text = "OK";
	textPos = new Vector2(340, 410);
	fontOrigin = Main.fontMouseText.MeasureString(text) / 2;
    	if(mouseRect.Intersects(btnOk))
	{
		DrawButton(spriteBatch, new Vector2(btnOk.X, btnOk.Y), new Rectangle(0, 0, 12, 20), false);
	
		if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouseState != mouseState)
		{
            ModWorld.ChangeHair = false;
		}
	DrawText(spriteBatch, text, textPos, fontOrigin, Color.Yellow, Main.fontMouseText);
	}
    	else
	{
		DrawButton (spriteBatch, new Vector2(btnOk.X, btnOk.Y), new Rectangle(0, 0, 12, 20), true);
        DrawText(spriteBatch, text, textPos, fontOrigin, Color.White, Main.fontMouseText);
	}



#endregion
}

public static void DrawButton(SpriteBatch spriteBatch, Vector2 pos, Rectangle textureRect, bool hover)
{
	Color hoverColor = Color.White;
	
	if(hover)
		hoverColor = Color.Yellow;
	else
		hoverColor = Color.White;

	spriteBatch.Draw(Main.goreTexture[Config.goreID["arrows"]], pos, new Rectangle?(textureRect), hoverColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
}

#region achieve
    public static void ExternalInitAchievementsDelegates(
    Action<string, string, string, string, string, int, Texture2D, bool> AddAchievement,
    Action<string[], int> ConfigNetMode,
    Action<string[], int> ConfigDifficulty,
    Action<string[], int> ConfigHardmode,
    Action<string, object, Func<object, object, string>> ConfigProgress,
    Func<string, bool> GetAchieved,
    Func<string, Texture2D, bool> Achieve,
    Action<int, string> AchievePlayer,
    Action<string> AchieveAllPlayers,
    Func<string, object[]> GetProgress,
    Func<string, object, Texture2D, bool> SetProgress,
    Func<string, object, Texture2D, bool> Progress,
    Action<int, string, object> ProgressPlayer,
    Action<string, object> ProgressAllPlayers,
    Func<string, object[]> GetAchievementInfo)
    {
        AcAchieve = Achieve;
        AcAchievePlayer = AchievePlayer;
        AcAchieveAllPlayers = AchieveAllPlayers;

        string
            s,
            cat,
            mainCat = "Furniture and Decorations",
            subCat = "Multimedia",
            div = "->",
            catHeader = mainCat + div + subCat,
            headerNdiv = catHeader + div,
            mainS = "EIKESTER",
            Sdiv = "_",
            mainNdiv = mainS + Sdiv;

        cat = catHeader;
		
        s = mainNdiv + "TV"; AddAchievement(s, cat, "Couch Potatoe", "Craft and Place a TV!", null, 10, SetTexture("Wooden TV"), false);
		s = mainNdiv + "WALKMAN"; AddAchievement(s, cat, "Music to go", "Equip a Walkman!", null, 10, SetTexture("Walkman"), false);
		s = mainNdiv + "RADIO"; AddAchievement(s, cat, "Please don't stop the Music..", "Craft and Place a Radio!", null, 10, SetTexture("Radio"), false);
		s = mainNdiv + "COMPUTER"; AddAchievement(s, cat, "To slow for Crysis 3 but.. Pong!", "Craft and Place a PC!", null, 10, SetTexture("Computerdesk"), false);
		s = mainNdiv + "ARCADEMACHINE"; AddAchievement(s, cat, "Lets play Pong!", "Craft and Place a Arcade Machine!", null, 10, SetTexture("Arcade Slot Machine"), false);
		s = mainNdiv + "PONGPROFI"; AddAchievement(s, cat, "Winner", "Win a Pong Game against CPU!", null, 10, SetTexture("Arcade Slot Machine"), false);
	
	}
	public static Texture2D SetTexture(string name)
	{
		Texture2D texture;
		try
		{
			texture = Main.itemTexture[Config.itemDefs.byName[name].type];
		}
		catch(Exception)
		{
			texture = null;
		}
		
		return texture;
	}
    public static void ExternalInitAchievements() { }
    public static void Achieve(int type, string ac, Texture2D tex = null, int PID = -1)
    {
        if (type == 0)
        {
            if (AcAchieve == null)
                return;
            else
                AcAchieve(ac, tex);
        }
        else if (type == 1)
        {
            if (AcAchievePlayer == null)
                return;
            else
                AcAchievePlayer(PID, ac);
        }
        else if (type == 2)
        {
            if (AcAchieveAllPlayers == null)
                return;
            else
                AcAchieveAllPlayers(ac);
        }
        else
            return;
    }
    #endregion