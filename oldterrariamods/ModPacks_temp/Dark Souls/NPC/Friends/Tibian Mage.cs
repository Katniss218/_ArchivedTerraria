
#region Town Spawn
public static bool TownSpawn() 
{
    for (int pInv = 0; pInv < 48; pInv++)
    {
        if (Main.player[pInv].statManaMax2 > 1)
        {
            if (!NPC.AnyNPCs(Config.npcDefs.byName["Tibian Mage"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Tibian Mage"].type)) return true;
            return false;
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
    int x=Main.rand.Next(8);
	if(x==0)
    {
	    return "Asima";
    }
	if(x==1)
    {
	    return "Lea";
    }
	if(x==2)
    {
	    return "Padreia";
    }
    if(x==3)
    {
	    return "Loria";
    }
	if(x==4)
    {
	    return "Lungelen";
    }
	if(x==5)
    {
	    return "Lily";
    }
	if(x==6)
    {
	    return "Sandra";
    }
    if(x==7)
    {
	    return "Tibra";
    }
	return "Astera Tiger";
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(7);
	if(x==0)
    {
		return "Time is a force we sorcerers will master one day.";
    }
    if(x==1)
    {
        return "Any sorcerer dedicates his whole life to the study of the arcane arts.";
    }
    if(x==2)
    {
        return "Sorry, I only sell spells to sorcerers.";
    }
    if(x==3)
    {
        return "I could tell you much about all sorcerer spells, but you won't understand it. Anyway, feel free to ask me.";
    }
    if(x==4)
    {
        return "I'll teach you a very seldom spell.";
    }
    if(x==5)
    {
        return "Many call themselves a sorcerer, but only a few truly understand what that means.";
    }
    if(x==6)
    {
        return "Sorcerers are destructive. Their power lies in destruction and pain.";
    }
	return "Welcome to our humble guild, wanderer. May I be of any assistance to you?";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{
	int index=0;
    chest.item[index].SetDefaults("Wand of Darkness");
	index++;
	chest.item[index].SetDefaults("Cosmic Watch");
	index++;
    chest.item[index].SetDefaults("Red Mage Hat");
	index++;
	chest.item[index].SetDefaults("Red Mage Tunic");
	index++;
	chest.item[index].SetDefaults("Red Mage Pants");
	index++;
	chest.item[index].SetDefaults("Gel");
	index++;
    

if (NPC.downedBoss1)
    {
		chest.item[index].SetDefaults("Wand of Fire");
		index++;
	    chest.item[index].SetDefaults("Forgotten Ice Rod");
	    index++;
            chest.item[index].SetDefaults("Forgotten Ice Rod");
	    index++;
            chest.item[index].SetDefaults("Forgotten Thunder Rod");
	    index++;
    }


if (Main.hardMode)
    {
            chest.item[index].SetDefaults("Flame Strike Scroll");
	    index++;
	    chest.item[index].SetDefaults("Energy Strike Scroll");
            index++;
	    chest.item[index].SetDefaults("Death Strike Scroll");
	    index++;
	    chest.item[index].SetDefaults("Covetous Silver Serpent Ring");
	    index++;
            chest.item[index].SetDefaults("Mana Bomb");
	    index++;
    }



if (ModWorld.Slayed.ContainsKey("The Destroyer"))
    {
            chest.item[index].SetDefaults("Forgotten Stardust Rod");
	    index++;
            
            
    }



}
#endregion





#region Gore
public void NPCLoot()
{
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Mage Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Mage Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Mage Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Mage Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Mage Gore 3", 1f, -1);
    }
}
#endregion