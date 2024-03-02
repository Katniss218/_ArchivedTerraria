public void UseTile(Player player, int x, int y)
{
	ModWorld.ChangeHair = !ModWorld.ChangeHair;
	
	ModWorld.currentMirrorPosition = new Vector2(x, y);
}