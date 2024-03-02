#region Town Spawn
public static bool TownSpawn() 
{
    for (int pInv = 0; pInv < 48; pInv++)
    {
        if (Main.player[pInv].statDefense > 0)
        {
            if (!NPC.AnyNPCs(Config.npcDefs.byName["Solaire of Astora"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Solaire of Astora"].type)) return true;
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
	    return "Solaire of Astora";    
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(7);
	if(x==0)
    {
		return "Dark Souls possess great powers, but also great responsibilities.";
    }
    if(x==1)
    {
        return "Praise the sun!";
    }
    if(x==2)
    {
        return "Oh, hello there. I will stay behind, to gaze at the sun. The sun is a wondrous body. Like a magnificent father! If only I could be so grossly incandescent!";
    }
    if(x==3)
    {
        return "Of course, we are not the only ones engaged in this.";
    }
    if(x==4)
    {
        return "Would you like to buy some of my wares?";
    }
    if(x==5)
    {
        return "The way I see it, our fates appear to be intertwined. In a land brimming with Hollows, could that really be mere chance? So, what do you say? Why not help one another on this lonely journey?";
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
	chest.item[index].SetDefaults("Old Broadsword");
	index++;
        chest.item[index].SetDefaults("Old Morning Star");
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
        chest.item[index].SetDefaults("Corrupted Tooth");
	index++;
        chest.item[index].SetDefaults("Forgotten Metal Knuckles");
	index++;

if (NPC.downedBoss1)
    {
	    chest.item[index].SetDefaults("Old Two Handed Sword");
	    index++;
            
    }


    if (NPC.downedBoss2)
    {
	    chest.item[index].SetDefaults("Forgotten Long Sword");
	    index++;
            chest.item[index].SetDefaults("Forgotten Kaiser Knuckles");
	    index++;
    }


     if (NPC.downedBoss3)
    {
	    chest.item[index].SetDefaults("Forgotten Kotetsu");
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