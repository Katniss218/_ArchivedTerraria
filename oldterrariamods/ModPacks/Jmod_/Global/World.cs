public static void KillTile(int x, int y, Player player) 
{
	if (( (int)Main.tile[x,y].type == 5 ) && ((int)Main.tile[x,y+1].type != 5)) 
	{
		if(!player.zoneEvil && !player.zoneJungle) {
			Item.NewItem((int)player.position.X, (int)player.position.Y -100, 16, 18, "Wood");
        }
		else if(player.zoneJungle) {
            if (Main.rand.Next(3) == 1) {
				 Item.NewItem((int)player.position.X, (int)player.position.Y -100, 16, 18, "Rotten Wood");
            }
            else {
				 Item.NewItem((int)player.position.X, (int)player.position.Y -100, 16, 18, "Wood");
            }
		}
	}
}