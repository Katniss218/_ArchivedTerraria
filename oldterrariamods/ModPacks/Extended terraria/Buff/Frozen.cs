public void Effects(Player player) 
{
	player.controlUp = false;
	player.controlDown = false;
	player.controlLeft = false;
	player.controlRight = false;
	player.controlJump = false;
	player.noItems = true;
}
public void ModifyPlayerDrawColors(Player P, ref bool OF, ref float r, ref float g, ref float b, ref float a)
{
	r *= 0.0f;
	g *= 0.639f;
}