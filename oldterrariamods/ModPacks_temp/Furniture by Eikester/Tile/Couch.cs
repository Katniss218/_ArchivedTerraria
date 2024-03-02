public void UseTile(Player player, int x, int y)
{
	if (Player.CheckSpawn(x, y+1))
	{
		player.ChangeSpawn(x,y+1);
		Main.NewText("Spawn point set!", 255, 240, 20);
	}
	else Main.NewText("This isn't a house!");
}

public void MouseOverTile(int x,int y,Player P)
{
	int type = 0;

    //all this code does is make the chest icon appear when you put your mouse over it
    P.noThrow = 2;
    P.showItemIcon = true;
	
    P.showItemIcon2 = Config.itemDefs.byName["Bed"].type;
}