
#region Town Spawn
public static bool TownSpawn() 
{
    for (int pInv = 0; pInv < 48; pInv++)
    {
        if (Main.player[pInv].statManaMax2 > 160)
        {
            if (!NPC.AnyNPCs(Config.npcDefs.byName["Shaman Elder"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Shaman Elder"].type)) return true;
            return false;
        }
    }
    return false;
}
#endregion



#region Name
public void Initialize() 
{
	if(Main.chrName[npc.type] == null){ Main.chrName[npc.type] = SetName(); }
}

public string SetName() 
{
	    return "Shaman Elder";    
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(9);
	if(x==0)
    {
	return "Man and animal once lived in harmony, until one day a particular tribe grew a sickness of the mind. This tribe, known as the Takers, came to dominate the world, exterminating all other ways of being...";
    }
    if(x==1)
    {
        return "Arapaho once told me that all plants are our brothers and sisters. They talk to us and if we listen, we can hear them.";
    }
    if(x==2)
    {
        return "I am an animist, like the indigenous tribe who once lived in these lands were, before they were wiped out by the Takers.";
    }
    if(x==3)
    {
        return "You must never forget Red, you are not separate from nature. You are one with the whole universe.";
    }
    if(x==4)
    {
        return "The world is not a pyramid, Red, nor is man the top of it. The world is a web, and every strand of the web is connected.";
    }
    if(x==5)
    {
        return "Civilized man has grown a great sickness of the mind -- thinks he is superior to all creation. Thinks the world was made for him!";
    }
    if(x==6)
    {
        return "Apache said it is better to have less thunder in the mouth and more lightning in the hand.";
    }
    if(x==7)
    {
        return "If you are able to defeat Attraidies, come and find me. I will have something for you...";
    }
	return "Tuscarora once said they are not dead who live in the hearts they leave behind.'";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{
	int index=0;
        chest.item[index].SetDefaults("Wand of Darkness");
	index++;
	chest.item[index].SetDefaults("Wand of Fire");
	index++;
	chest.item[index].SetDefaults("Cosmic Watch");
	index++;
        chest.item[index].SetDefaults("Gel");
	index++;
    

//if (NPC.downedBoss1)
//    {
//	    chest.item[index].SetDefaults("Forgotten Ice Rod");
//	    index++;
//            chest.item[index].SetDefaults("Forgotten Ice Rod");
//	    index++;
//            chest.item[index].SetDefaults("Forgotten Thunder Rod");
//	    index++;
//    }


if (Main.hardMode)
    {
            
	    chest.item[index].SetDefaults("Covetous Silver Serpent Ring");
	    index++;
            
    }



if (ModWorld.Slayed.ContainsKey("Attraidies"))
    {
            chest.item[index].SetDefaults("Covenant of Artorias");
			index++;
			chest.item[index].SetDefaults("Abyss Scroll");
			index++;
			chest.item[index].SetDefaults("Witchking Scroll");
			index++;
            
            
    }



}
#endregion





#region Gore
public void NPCLoot()
{
                                                                                                                               
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Shaman Elder Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 3", 1f, -1);
    
}
#endregion