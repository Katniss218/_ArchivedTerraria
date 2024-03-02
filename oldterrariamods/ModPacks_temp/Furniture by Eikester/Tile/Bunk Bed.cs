public void PlaceTile(int x,int y,int pid)
{
    RealPos(ref x,ref y); //change x and y to top left corner of tile
    Chest.CreateChest(x, y); // you only create a chest
}

public void MouseOverTile(int x,int y,Player P)
{
	int type = 0;

    //all this code does is make the chest icon appear when you put your mouse over it
    P.noThrow = 2;
    P.showItemIcon = true;
	
	if(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY == 54)
	{
		type = Config.itemDefs.byName["Chest"].type;
	}
	else
	{
		type = Config.itemDefs.byName["Bed"].type;
	}
	
    P.showItemIcon2 = type;
}

public void UseTile(Player player, int x, int y)
{
	if(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY == 54)
	{
		UseChest(player, x, y);
	}
	else
	{
		if (Player.CheckSpawn(x, y+1))
		{
			player.ChangeSpawn(x,y+1);
			Main.NewText("Spawn point set!", 255, 240, 20);
		}
		else Main.NewText("This isn't a house!");
	}
}

void UseChest(Player P,int x,int y)
{
    RealPos(ref x,ref y);

    //this code is a 1 to 1 copy of the original chest opening code
	Main.chestText = "Bunk Bed";
	
    if (Main.netMode == 1)
    {
        if (x == P.chestX && y == P.chestY && P.chest != -1)
        {
            P.chest = -1;
            Main.PlaySound(11, -1, -1, 1);
        }
        else NetMessage.SendData(31, -1, -1, "", x, (float)y, 0.0f, 0.0f, 0);
    }
    else
    {
        int chestindex = Chest.FindChest(x, y);
        if (chestindex != -1)
        {
            if (chestindex == P.chest)
            {
                P.chest = -1;
                Main.PlaySound(11, -1, -1, 1);
            }
            else
            {
                P.chest = chestindex;
                Main.playerInventory = true;
                P.chestX = x;
                P.chestY = y;

                if (chestindex != P.chest && P.chest == -1)
                    Main.PlaySound(10, -1, -1, 1);
                else
                    Main.PlaySound(12, -1, -1, 1);
            }
        }
    }
}

public bool CanDestroyTile(int x,int y)
{
    //supports CanDestroyAround against detecting itself.
    return true;
}

public bool CanDestroyAround(int x,int y,string Dir)
{
    if(Dir == "Bottom") return false; //its a chest , we don't players to be able to destroy the tiles under it
	
    return true;
}

public void PreKillTile(ref int x,ref int y,ref bool LetContinue,ref bool fail,ref bool effectOnly,ref bool noItem,Player P)
{
    //P is not null only when the player is really supposed to break the tile - this code makes it so that exact breaking always fails
    if(Main.netMode == 1 && P != null) fail = true;
}

public bool StopKillTile(int x,int y)
{
    if(Main.netMode == 1) return false;  //this code should never be called in client side , so we make sure it doesnt

    RealPos(ref x,ref y);
    if (!Chest.DestroyChest(x,y)) return true; //this tries to remove the chest , and if it fails we stop the killing of the tile
    return false;
}

public void PostKillTile(int x,int y,string at,Player P)
{
    if(P == null) return; // this code should only be called if its the player that breaks the tile
    if(at == "Fail" && Main.netMode == 1) //this here sends a message telling the server to kill the tile and then notify us its dead
    {
        NetMessage.SendData(34, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0.0f, 0.0f, 0);
    }
}

//some silly custom method to make the code a bit shorter
public void RealPos(ref int x,ref int y)
{
    Vector2 pos = Codable.GetPos(new Vector2(x, y));
    x = (int)pos.X;
    y = (int)pos.Y;
}