public static bool Added = false;
public static int WingIndex = 0;
public static int modId;
public static int modIndex=0;

public void ModifyWorld()
{
    foreach(Chest C in Main.chest)
    {
        if (C != null)
        {
            foreach(Item I in C.item)
            {
                if (I != null && I.type == Config.itemDefs.byName["Angel Statue"].type)
                {
                    int random = WorldGen.genRand.Next(7);
                        if (random == 0) I.SetDefaults("Enchanted Boomerang");
                        if (random == 1) I.SetDefaults("Shiny Object");
                        if (random == 2) I.SetDefaults("Demonic Rune");
                        if (random == 3) I.SetDefaults("Tiara");
                        if (random == 4) I.SetDefaults("Black Heart");
						if (random == 5) I.SetDefaults("Flare Gun");
						if (random == 6) I.SetDefaults("Dragon Bell");
                }
            }
        }
    }
}

public void Initialize()
{

if(Added)
    {
        return;
    }
    Texture2D mytex=Main.goreTexture[Config.goreID["Dragon Wings"]];
    foreach(Texture2D T in Main.wingsTexture)
    {
        if(mytex == T)
        {
            Added = true;
            break;
        }
    }
    if(!Added)
    {
        Added = true;
        Texture2D[] wingsTextureNew = new Texture2D[Main.wingsTexture.Length+1];
        for (int i = 0; i < Main.wingsTexture.Length; i++)
        {
            wingsTextureNew[i]=Main.wingsTexture[i];
        }
        wingsTextureNew[Main.wingsTexture.Length] = mytex;
        Main.wingsTexture = wingsTextureNew;
        WingIndex = Main.wingsTexture.Length-1;
    }
}