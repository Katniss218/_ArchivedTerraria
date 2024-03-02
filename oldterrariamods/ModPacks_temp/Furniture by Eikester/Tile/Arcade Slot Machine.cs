public void PlaceTile(int x, int y, int p)
{
	ModWorld.Achieve(0, "EIKESTER_ARCADEMACHINE");
}

public void UseTile(Player player, int x, int y)
{
	ModWorld.pongGame.Initialize();
	ModWorld.pongGame.IsPC = false;
	ModWorld.pongGameRunning = true;
}