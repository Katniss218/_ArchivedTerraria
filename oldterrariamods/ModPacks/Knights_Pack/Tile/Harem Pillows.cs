public static void UseTile(Player player,int x , int y)
	{
		if (Player.CheckSpawn(x, y+1))
		{
			player.ChangeSpawn(x,y+1);
			Main.NewText("Spawn point set!", 255, 240, 20);
		}
		else Main.NewText("This isn't a house!");
	}

public void DestroyTile(int x, int y)
	{
	Item.NewItem(x*16,y*16,32,32,Config.itemDefs.byName["Harem Pillows"].type,1,false);
	}