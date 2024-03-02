
#region Town Spawn
public static bool TownSpawn() 
{
    if (!NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Black Mage"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Black Mage"].type)) return true;
    return false;
}
#endregion

#region Names
public static string SetName() 
{
    int x=Main.rand.Next(10);
	if(x==0)
    {
	    return "Delilah";
    }
	if(x==1)
    {
	    return "Gilles";
    }
	if(x==2)
    {
	    return "Gungho";
    }
    if(x==3)
    {
	    return "Homac";
    }
	if(x==4)
    {
	    return "Kokkol";
    }
	if(x==5)
    {
	    return "Koko";
    }
	if(x==6)
    {
	    return "Nina";
    }
    if(x==7)
    {
	    return "Stella";
    }
	if(x==8)
    {
	    return "Topapa";
    }
	if(x==9)
    {
	    return "Zok";
    }
	return "Vivi";
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(6);
	if(x==0)
    {
		return "Would you happen to have a rat's tail?";
    }
    if(x==1)
    {
        return "Two orbs down... 2 more to go.";
    }
    if(x==2)
    {
        return "Wanting to learn some spells?";
    }
    if(x==3)
    {
        return "Welcome.";
    }
    if(x==4)
    {
        return "Have you heard of Materia? I'd like to try some!";
    }
    if(x==5)
    {
        return "I do miss Mysidia...";
    }
	return "How do you prove that you exist...? Maybe we don't exist...";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{
	int index=0;
	chest.item[index].SetDefaults("Bolt 1 Tome");
	index++;
	chest.item[index].SetDefaults("Ice 1 Tome");
	index++;
	chest.item[index].SetDefaults("Fire 1 Tome");
	index++;
	chest.item[index].SetDefaults("Quake 1 Tome");
	index++;
	chest.item[index].SetDefaults("Bolt 2 Tome");
	index++;
	chest.item[index].SetDefaults("Ice 2 Tome");
	index++;
	chest.item[index].SetDefaults("Fire 2 Tome");
	index++;
	chest.item[index].SetDefaults("Quake 2 Tome");
	index++;
}
#endregion

#region Gore
public void NPCLoot()
{
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Black Mage Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Black Mage Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Black Mage Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Black Mage Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Black Mage Gore 3", 1f, -1);
    }
}
#endregion