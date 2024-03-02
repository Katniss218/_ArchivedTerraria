
#region Town Spawn
public static bool TownSpawn() 
{
    for (int pInv = 0; pInv < 48; pInv++)
    {
        if (Main.player[pInv].statDefense > 0)
        {
            if (!NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Tibian Knight"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Tibian Knight"].type)) return true;
            return false;
        }
    }
    return false;
}
#endregion

#region Names
public static string SetName() 
{
    int x=Main.rand.Next(12);
	if(x==0)
    {
	    return "Turvy";
    }
	if(x==1)
    {
	    return "Cornelia";
    }
	if(x==2)
    {
	    return "Thanita";
    }
    if(x==3)
    {
	    return "Romella";
    }
	if(x==4)
    {
	    return "Rowenna";
    }
	if(x==5)
    {
	    return "Bambi Bonecrusher";
    }
	if(x==6)
    {
	    return "Bunny Bonecrusher";
    }
    if(x==7)
    {
	    return "Blossom Bonecrusher";
    }
    if(x==8)
    {
	    return "Barbara";
    }
    if(x==9)
    {
	    return "Busty Bonecrusher";
    }
    if(x==10)
    {
	    return "Fenbala";
    }
    if(x==11)
    {
	    return "Shuana";
    }
	return "Trishna";
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(7);
	if(x==0)
    {
		return "The Bonecrusher family is ideally suited for military jobs.";
    }
    if(x==1)
    {
        return "LONG LIVE THE QUEEN!";
    }
    if(x==2)
    {
        return "Would you like to buy the general key to the town? Yeah, I bet you'd like to do that! HO, HO, HO!";
    }
    if(x==3)
    {
        return "I'm far more used to cities dominated by women.";
    }
    if(x==4)
    {
        return "Hello. Would you like to buy some of my wares?";
    }
    if(x==5)
    {
        return "Please show respect to Queen Eloise. I don't want to have to hurt you.";
    }
    if(x==6)
    {
        return "Amazons and orcs are a real threat.";
    }
	return "I'm far from home, but this isn't so bad.";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{
	int index=0;
	chest.item[index].SetDefaults("Old Sabre");
	index++;
	chest.item[index].SetDefaults("Old Rapier");
	index++;
	chest.item[index].SetDefaults("Old Axe");
	index++;
	chest.item[index].SetDefaults("Old Sword");
	index++;
	chest.item[index].SetDefaults("Old Mace");
	index++;
	chest.item[index].SetDefaults("Old Scimitar");
	index++;
	chest.item[index].SetDefaults("Old Broadsword");
	index++;
	chest.item[index].SetDefaults("Old Chain Coif");
	index++;
	chest.item[index].SetDefaults("Old Chain Armor");
	index++;
	chest.item[index].SetDefaults("Old Chain Greaves");
	index++;
	chest.item[index].SetDefaults("Ancient Brass Helmet");
	index++;
	chest.item[index].SetDefaults("Ancient Brass Armor");
	index++;
	chest.item[index].SetDefaults("Ancient Brass Greaves");
	index++;
    if (NPC.downedBoss3)
    {
	    chest.item[index].SetDefaults("Ancient Plate Helmet");
	    index++;
	    chest.item[index].SetDefaults("Ancient Plate Armor");
	    index++;
	    chest.item[index].SetDefaults("Ancient Plate Greaves");
	    index++;
	    chest.item[index].SetDefaults("Old Two Handed Sword");
	    index++;
    }
}
#endregion

#region Gore
public void NPCLoot()
{
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 3", 1f, -1);
    }
}
#endregion