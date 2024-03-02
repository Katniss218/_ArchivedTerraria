#region Town Spawn
public static bool TownSpawn() 
{
    for (int pInv = 0; pInv < 48; pInv++)
    {
        if (Main.player[pInv].statDefense > 25)
        {
            if (!NPC.AnyNPCs(Config.npcDefs.byName["Dwarf"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Dwarf"].type)) return true;
        }
    }
    return false;
}
#endregion

#region Names
public void Initialize() 
{
	if(Main.chrName[npc.type] == null){ Main.chrName[npc.type] = SetName(); }
}

public static string SetName() 
{
    int x=Main.rand.Next(10);
	if(x==0)
    {
	    return "Unfoli";
    }
	if(x==1)
    {
	    return "Nollin";
    }
	if(x==2)
    {
	    return "Duroin";
    }
    if(x==3)
    {
	    return "Jloin";
    }
	if(x==4)
    {
	    return "Grefinnyr";
    }
	if(x==5)
    {
	    return "Nionwelf";
    }
	if(x==6)
    {
	    return "Kloni";
    }
    if(x==7)
    {
	    return "Fini";
    }
	if(x==8)
    {
	    return "Ofur";
    }
	if(x==9)
    {
	    return "Ofi";
    }
	return "Bompbi";
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(4);
	if(x==0)
    {
		return "I've got some contracts for sell.";
    }
    if(x==1)
    {
        return "These guards are the best.";
    }
    if(x==2)
    {
        return "How are you?";
    }
    if(x==3)
    {
        return "If you're able to defeat The Sorrow or The Destroyer, I'll have more things to sell later...";
    }
	return "I'm thristy...";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{
	int index=0;
	chest.item[index].SetDefaults("Dwarven Contract");
	index++;

	if (ModWorld.Slayed.ContainsKey("The Sorrow"))
    {
            chest.item[index].SetDefaults("Forgotten Ice Brand");
	    index++;
            chest.item[index].SetDefaults("Forgotten Murakumo");
	    index++;
            chest.item[index].SetDefaults("Forgotten Pearl Spear");
	    index++;
            
    }


    if (ModWorld.Slayed.ContainsKey("The Destroyer"))
    {
            chest.item[index].SetDefaults("Forgotten Poison Axe");
	    index++;
            chest.item[index].SetDefaults("Forgotten Swordbreaker");
	    index++;
            chest.item[index].SetDefaults("Forgotten Imp Halberd");
	    index++;
            
            
    }
}
#endregion