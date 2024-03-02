


#region Names
public static string SetName() 
{
    int x=Main.rand.Next(4);
	if(x==0)
    {
	    return "Elane";
    }
	if(x==1)
    {
	    return "Legola";
    }
	if(x==2)
    {
	    return "Galuna";
    }
	return "Enalea";
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(7);
	if(x==0)
    {
		return "I am the local fletcher. I am selling bows, crossbows, and ammunition. Do you need anything?";
    }
    if(x==1)
    {
        return "Tibia, a green island. There it is wunderful to walk into the forests and to hunt with a bow.";
    }
    if(x==2)
    {
        return "I am paladin and fletcher.";
    }
    if(x==3)
    {
        return "We are feared warriors and good marksmen.";
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
	chest.item[index].SetDefaults("Old Crossbow");
	index++;
	chest.item[index].SetDefaults("Bolt");
	index++;
	chest.item[index].SetDefaults("Old Long Bow");
	index++;
	chest.item[index].SetDefaults("Throwing Axe");
	index++;
	chest.item[index].SetDefaults("Throwing Spear");
	index++;
	chest.item[index].SetDefaults("Old Leather Helmet");
	index++;
	chest.item[index].SetDefaults("Old Leather Armor");
	index++;
	chest.item[index].SetDefaults("Old Leather Greaves");
	index++;
	chest.item[index].SetDefaults("Old Studded Leather Helmet");
	index++;
	chest.item[index].SetDefaults("Old Studded Leather Armor");
	index++;
	chest.item[index].SetDefaults("Old Studded Leather Greaves");
	index++;
    if (NPC.downedBoss2)
    {
	    chest.item[index].SetDefaults("Royal Throwing Spear");
	    index++;
    }
    if (NPC.downedBoss3)
    {
	    chest.item[index].SetDefaults("Enchanted Throwing Spear");
	    index++;
	    chest.item[index].SetDefaults("Power Bolt");
	    index++;
    }
}
#endregion

#region Gore
public void NPCLoot()
{
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Archer Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Archer Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Archer Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Archer Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Archer Gore 3", 1f, -1);
    }
}
#endregion