

#region Town Spawn
public static bool TownSpawn() 
{
    if (!NPC.AnyNPCs(Config.npcDefs.byName["Omnirs White Mage"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["White Mage"].type)) return true;
    return false;
}
#endregion

#region Names
public static string SetName() 
{
    int x=Main.rand.Next(10);
	if(x==0)
    {
	    return "Elia";
    }
	if(x==1)
    {
	    return "Jenica";
    }
	if(x==2)
    {
	    return "KuKu";
    }
    if(x==3)
    {
	    return "Luca";
    }
	if(x==4)
    {
	    return "Mikoto";
    }
	if(x==5)
    {
	    return "Noah";
    }
	if(x==6)
    {
	    return "Ruby";
    }
    if(x==7)
    {
	    return "Sara";
    }
	if(x==8)
    {
	    return "Sarina";
    }
	if(x==9)
    {
	    return "Sherko";
    }
	return "Shiroma";
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(4);
	if(x==0)
    {
		return "Think we could find a rat's tail around here?";
    }
    if(x==1)
    {
        return "It's strange; I find problems with swords, but not hammers.";
    }
    if(x==2)
    {
        return "Are you here to learn some spells?... or to sell random junk?";
    }
    if(x==3)
    {
        return "Welcome!";
    }
	return "How do you prove that you exist...? Maybe we don't exist...";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{
	int index=0;
	chest.item[index].SetDefaults("Cure 1 Tome");
	index++;
	chest.item[index].SetDefaults("Fog Tome");
	index++;
	chest.item[index].SetDefaults("Cure 2 Tome");
	index++;
	chest.item[index].SetDefaults("Barrier Tome");
	index++;
	chest.item[index].SetDefaults("Escape Tome");
	index++;
	chest.item[index].SetDefaults("Dezone Tome");
	index++;
}
#endregion

#region Gore
public void NPCLoot()
{
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "White Mage Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "White Mage Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "White Mage Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "White Mage Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "White Mage Gore 3", 1f, -1);
    }
}
#endregion