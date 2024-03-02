public void PlaceTile(int x, int y, int p) 
{
	ModWorld.Achieve(0, "EIKESTER_RADIO");
}

public void UseTile(Player player, int x, int y) 
{
	RealPos(ref x,ref y);
	
	if(ModWorld.radio != null)
	{
		ModWorld.radio.radioPosition = new Vector2(x, y);
	
		ModWorld.radio.TogglePlay();
	}
}

public void RealPos(ref int x,ref int y)
{
    Vector2 pos = Codable.GetPos(new Vector2(x, y));
    x = (int)pos.X;
    y = (int)pos.Y;
}