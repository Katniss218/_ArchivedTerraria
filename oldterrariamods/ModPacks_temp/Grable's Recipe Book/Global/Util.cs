
/*
 * various helper functions
 */
 
 private const string LOGFILE = "recipe_book_log.txt";
 private static bool dbg_init = false;
 
 public static void DebugPrint( string s) {
	if(!dbg_init) {
		TextWriter w = new StreamWriter(LOGFILE);
		w.WriteLine(s);
		w.Close();
		dbg_init = true;
	} else {
		File.AppendAllText( LOGFILE, s + "\n");
	}
 }
 
private static bool hasclicked = false;
	
public static void BeginClick() {
	Main.player[Main.myPlayer].mouseInterface = true;
	hasclicked = false;
}

public static void ResetClick() {
	Main.player[Main.myPlayer].mouseInterface = false;
	hasclicked = true;
	// hack
	if(searchactive) {
		DeSelectSearchFilter();
	}
}

public static Vector2 GetMousePos() {	
	return new Vector2( Main.mouseX, Main.mouseY);
}

public static bool MouseInsideRect( Rectangle rect) {
	return (Main.mouseX >= rect.X && Main.mouseY >= rect.Y) && 
				//(Main.mouseX <= rect.X + rect.Width && Main.mouseY <= rect.Y + rect.Height);
				(Main.mouseX < rect.X + rect.Width && Main.mouseY < rect.Y + rect.Height);
}

public static bool MouseInsideRect( Vector2 p, int width, int height) {
	return (Main.mouseX >= p.X && Main.mouseY >= p.Y) && 				
				//(Main.mouseX <= p.X + width && Main.mouseY <= p.Y + height);
				(Main.mouseX < p.X + width && Main.mouseY < p.Y + height);
}

public static Vector2 GetCenteredTextPos( SpriteFont font, string text, Texture2D tex) {
	Vector2 sz = font.MeasureString(text);
	return new Vector2( (tex.Width / 2) - (sz.X / 2f), (tex.Height / 2) - (sz.Y / 2f));
}

private static void DrawString( SpriteBatch batch, SpriteFont font, string text, Vector2 vector, Color color)
{
	Vector2 defaultVector2 = default(Vector2);
	batch.DrawString( font, text, new Vector2(vector.X - 2, vector.Y), Color.Black, 0f, defaultVector2, 1f, SpriteEffects.None, 0f);
	batch.DrawString( font, text, new Vector2(vector.X, vector.Y - 2), Color.Black, 0f, defaultVector2, 1f, SpriteEffects.None, 0f);
	batch.DrawString( font, text, new Vector2(vector.X + 2, vector.Y), Color.Black, 0f, defaultVector2, 1f, SpriteEffects.None, 0f);
	batch.DrawString( font, text, new Vector2(vector.X, vector.Y + 2), Color.Black, 0f, defaultVector2, 1f, SpriteEffects.None, 0f);
	batch.DrawString( font, text, vector, color, 0f, defaultVector2, 1f, SpriteEffects.None, 0f);
}
	
private static void DrawString2( SpriteBatch batch, SpriteFont font, string text, Vector2 vector, Color color)
{
	batch.DrawString( font, text, vector, color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
}

public static void DrawItem( SpriteBatch batch, Item item, Vector2 pos) {
	Texture2D tex = Main.itemTexture[ item.type];
	Rectangle? src = new Rectangle?(new Rectangle(0, 0, tex.Width, tex.Height));
	
	Color alpha = item.GetAlpha(Color.White);
	Color color = item.GetColor(Color.White);
	
	if( item.color == default(Color)) {
		alpha.A = 255;
		batch.Draw( tex, pos, src, alpha, 0f, origin, 1f, SpriteEffects.None, 0f);
	} else {
		batch.Draw( tex, pos, src, alpha, 0f, origin, 1f, SpriteEffects.None, 0f);
		batch.Draw( tex, pos, src, color, 0f, origin, 1f, SpriteEffects.None, 0f);
	}
}