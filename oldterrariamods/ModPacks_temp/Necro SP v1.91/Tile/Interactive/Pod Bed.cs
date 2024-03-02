public static void UseTile(Player player,int x , int y)
{
	while(Main.tile[x,y].frameX>0) x--;
	while(Main.tile[x,y].frameY>0) y--;
	if (Player.CheckSpawn(x, y+1))
	{
		player.ChangeSpawn(x,y+1);
		Main.NewText("Spawn point set!", 255, 240, 20);
	}
}