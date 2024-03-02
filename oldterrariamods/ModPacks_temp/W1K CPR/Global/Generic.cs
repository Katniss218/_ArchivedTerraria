public void OnLoad()
{
	if (Settings.GetBool("newcursor")) Main.cursorTexture = Main.goreTexture[Config.goreID["NewCursor"]];
	//else Main.cursorTexture = Main.goreTexture[Config.goreID["Cursor"]];
}