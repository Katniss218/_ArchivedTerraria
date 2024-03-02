

public void DestroyTile(int x, int y)
	{
	Item.NewItem(x*16,y*16,32,32,Config.itemDefs.byName["Deathweed Hookah"].type,1,false);
	}

//Following code written by Yoraiz0r. GIVE HIM CANDY!
public void UseTile(Player P,int x,int y)
{
    int windex = -1; //weed index , not wing index this time xD
    for(int i = 0; i < 40; i++)
    {
        Item I = P.inventory[i];
        if(I.stack > 0 && I.type == Config.itemDefs.byName["Deathweed"].type)
        {
            windex = i;
            break;
        }
    }
    if(windex == -1)
    {
        Main.NewText("You don't have any deathweed to smoke.");
        return;
    }
   
    for(int i = 0; i < P.buffType.Length; i++)
    {
        if(P.buffType[i] == Config.buffID["Death Trip"] && P.buffTime[i] > 0)
        {
            Main.NewText("Smoking more right now would kill you.");
            return;
        }
    }
   
    P.inventory[windex].stack--;
    if(P.inventory[windex].stack == 0) P.inventory[windex] = new Item(); //turn the item into air if its stack reached 0
    int gore = Gore.NewGore(new Vector2(P.position.X + (P.width * 0.5f), P.position.Y + (P.height * 0.5f)), new Vector2(0f, 0f), 99, 0.8f);
    P.AddBuff("Death Trip",21600);
}