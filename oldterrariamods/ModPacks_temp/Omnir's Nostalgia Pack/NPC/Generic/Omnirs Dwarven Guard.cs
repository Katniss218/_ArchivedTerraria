#region Names
public static string SetName() 
{
    int x=Main.rand.Next(10);
	if(x==0)
    {
	    return "Urbur";
    }
	if(x==1)
    {
	    return "Bafarm";
    }
	if(x==2)
    {
	    return "Kothurn";
    }
    if(x==3)
    {
	    return "Okjorn";
    }
	if(x==4)
    {
	    return "Rulik";
    }
	if(x==5)
    {
	    return "Norbirn";
    }
	if(x==6)
    {
	    return "Joulni";
    }
    if(x==7)
    {
	    return "Norta";
    }
	if(x==8)
    {
	    return "Biffidor";
    }
	if(x==9)
    {
	    return "Koroin";
    }
	return "Uorin";
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(4);
	if(x==0)
    {
		return "Here to serve.";
    }
    if(x==1)
    {
        return "I could use some ale...";
    }
    if(x==2)
    {
        return "Can't  wait until the next break.";
    }
    if(x==3)
    {
        return "Hi' ho!";
    }
	return "Nothing to report";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{
	int index=0;
}
#endregion

#region Gore
public void NPCLoot()
{
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Dwarf Gore 3", 1f, -1);
    }
}
#endregion