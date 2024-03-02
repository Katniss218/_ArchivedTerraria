/*public void ModifyLightVision(float[] neglightvals)
{
	if (!ModPlayer.DragonMorph)
	{
		neglightvals[0] *= 0.5f;
		neglightvals[1] *= 0.5f;
	}
}*/

public void PostDraw(SpriteBatch spriteBatch)
{
	if ( Settings.GetBool("newcursor") && Main.cursorTexture != Main.goreTexture[Config.goreID["NewCursor"]] ) Main.cursorTexture = Main.goreTexture[Config.goreID["NewCursor"]];
	else if ( !Settings.GetBool("newcursor") && Main.cursorTexture == Main.goreTexture[Config.goreID["NewCursor"]] ) Main.cursorTexture = Main.goreTexture[Config.goreID["Cursor"]];
}

public void PreDrawInterface(SpriteBatch SP)
{
	foreach (NPC npc in Main.npc)
	{
		if (npc.active)
		{
			if (npc.type == Config.npcDefs.byName["Dark Shogun Mask"].type || npc.type == Config.npcDefs.byName["Dark Dragon Mask"].type || npc.type == Config.npcDefs.byName["Okiku"].type)
			{
				SP.Draw(Main.blackTileTexture,new Rectangle(0,0,Main.screenWidth,Main.screenHeight),new Color(10,0,20,0));
				break;
			}
			if (npc.type == Config.npcDefs.byName["Broken Okiku"].type)
			{
				SP.Draw(Main.blackTileTexture,new Rectangle(0,0,Main.screenWidth,Main.screenHeight),new Color(20,0,0,0));
				break;
			}
		}
	}
}

public static void DrawChain(Vector2 start, Vector2 end, string name, SpriteBatch spriteBatch)
{
	start -= Main.screenPosition;
	end -= Main.screenPosition;

	int linklength=Main.goreTexture[Config.goreID[name]].Height;
	Vector2 chain = end - start;

	float length = (float)chain.Length();
	int numlinks = (int)Math.Ceiling(length/linklength);
	Vector2[] links = new Vector2[numlinks];
	float rotation = (float)Math.Atan2(chain.Y, chain.X);

	for (int i = 0; i < numlinks; i++)
	{
		links[i] =start + chain/numlinks * i;
	}
	 
	for (int i = 0; i < numlinks; i++)
	{
		Color color = Lighting.GetColor((int)((links[i].X+Main.screenPosition.X)/16), (int)((links[i].Y+Main.screenPosition.Y)/16));
		spriteBatch.Draw(Main.goreTexture[Config.goreID[name]],
		new Rectangle((int)links[i].X, (int)links[i].Y, Main.goreTexture[Config.goreID[name]].Width, linklength), null,
		color, rotation+1.57f, new Vector2(Main.goreTexture[Config.goreID[name]].Width/2f, linklength), SpriteEffects.None, 1f);
	}
}

public static int AddWingByTextureName(string tex)
{
    Texture2D TEX = Main.goreTexture[Config.goreID[tex]];
    for (int i = 0; i < Main.wingsTexture.Length; i++)
    if (Main.wingsTexture[i] == TEX) return i;
    Array.Resize(ref Main.wingsTexture, Main.wingsTexture.Length + 1);
    Main.wingsTexture[Main.wingsTexture.Length - 1] = TEX;
    return Main.wingsTexture.Length - 1;
}

/*
// something to note with Audio.Player,
// since it uses Microsoft.Xna.Media.Player,
// only one track can be playing at any time
// tracks need to be in mp3 format - with the proper extension (.mp3)

// if you want to play multiple stuff at once
// you will need to use a SoundBank and WaveBank
// you can make these with XACT

// the music class is for playing Cue files inside a WaveBank
// static Music MyTrack;

public static bool SaveAndQuit()
{
	// stop the currently playing music
	Audio.Player.Stop();
	
	// MyTrack.Stop();
	
	// continue quitting
	return true;
}*/