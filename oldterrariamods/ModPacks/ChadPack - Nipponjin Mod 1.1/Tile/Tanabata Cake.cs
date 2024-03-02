public void UseTile(Player player, int x, int y)
{
	player.statLife += 15;
	player.AddBuff(26, 600, false);
	WorldGen.KillTile(x, y); WorldGen.SquareTileFrame(x, y);/*{
	}*/
}