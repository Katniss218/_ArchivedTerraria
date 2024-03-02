
#region Town Spawn
public static bool TownSpawn() 
{    int oMapWidth = Main.maxTilesX * 16;
    int oMapHeight = Main.maxTilesY * 16;
    bool oSky = (Main.player[Main.myPlayer].position.Y < (oMapHeight * 0.1f));
    bool oSurface = (Main.player[Main.myPlayer].position.Y >= (oMapHeight * 0.1f) && Main.player[Main.myPlayer].position.Y < (oMapHeight * 0.2f));
    bool oUnderSurface = (Main.player[Main.myPlayer].position.Y >= (oMapHeight * 0.2f) && Main.player[Main.myPlayer].position.Y < (oMapHeight * 0.3f));
    bool oUnderground = (Main.player[Main.myPlayer].position.Y >= (oMapHeight * 0.3f) && Main.player[Main.myPlayer].position.Y < (oMapHeight * 0.4f));
    bool oCavern = (Main.player[Main.myPlayer].position.Y >= (oMapHeight * 0.4f) && Main.player[Main.myPlayer].position.Y < (oMapHeight * 0.6f));
    bool oMagmaCavern = (Main.player[Main.myPlayer].position.Y >= (oMapHeight * 0.6f) && Main.player[Main.myPlayer].position.Y < (oMapHeight * 0.8f));
    bool oUnderworld = (Main.player[Main.myPlayer].position.Y >= (oMapHeight * 0.8f));
    if (oCavern && !NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Dwarf"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Dwarf"].type)) return true;
    return false;
}
#endregion

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