

#region Names
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
        return "Welcome.";
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
}
#endregion