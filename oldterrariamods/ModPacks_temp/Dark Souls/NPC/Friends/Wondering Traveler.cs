//#region Town Spawn
//public static bool TownSpawn() 
//{
//    for (int pInv = 0; pInv < 48; pInv++)
//    {
//        if (Main.player[pInv].statDefense > 0)
//        {
//            if (!NPC.AnyNPCs(Config.npcDefs.byName["Wondering Traveler"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Wondering Traveler"].type)) return true;
//        }
//    }
//    return false;
//}
//#endregion
#region Name
public void Initialize() 
{
	if(Main.chrName[npc.type] == null){ Main.chrName[npc.type] = SetName(); }
}

public string SetName() 
{
	    return "Wondering Traveler";    
}
#endregion

#region Spawn
public bool SpawnNPC(int x,int y,int PID)
{
      Player P = Main.player[PID]; //this shortens our code up from writing this line over and over.
      bool Meteor = P.zoneMeteor;
      bool Jungle = P.zoneJungle;
      bool Dungeon = P.zoneDungeon;
      bool Corruption = P.zoneEvil;
      bool Hallow = P.zoneHoly;
      bool AboveEarth  = P.position.Y < Main.worldSurface;
      bool InBrownLayer = P.position.Y >= Main.worldSurface && P.position.Y < Main.rockLayer;
      bool InGrayLayer = P.position.Y >= Main.rockLayer && P.position.Y < (Main.maxTilesY - 200)*16;
      bool InHell = P.position.Y >= (Main.maxTilesY - 200)*16;
      bool Ocean = P.position.X < 3600 || P.position.X > (Main.maxTilesX-100)*16;

      // these are all the regular stuff you get , now lets see......

	//for(int i = 0; i < Main.npc.Length; i++)

      //if(!NPC.AnyNPCs(Config.npcDefs.byName["Wondering Traveler"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Wondering Traveler"].type))

	{
      if(!NPC.AnyNPCs(Config.npcDefs.byName["Wondering Traveler"].type) && ModWorld.superHardmode && AboveEarth && Main.rand.Next(2)==1) 

		{
			Main.NewText("A wondering traveler has crossed your path... ", 175, 75, 255);
 	
			return true;
		}

      if(!NPC.AnyNPCs(Config.npcDefs.byName["Wondering Traveler"].type) && !Main.hardMode && AboveEarth && Jungle && Main.rand.Next(70)==1)

		{
			Main.NewText("A wondering traveler has entered the jungle... ", 175, 75, 255);
 	
			return true;
		}	

      if(!NPC.AnyNPCs(Config.npcDefs.byName["Wondering Traveler"].type) && Main.hardMode && Jungle && !Meteor && !Corruption && !Ocean && Main.rand.Next(50)==1) 

		{
			Main.NewText("A wondering traveler is nearby... ", 175, 75, 255);
 	
			return true;
		}


      return false;

	}
}
#endregion


#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(7);
	if(x==0)
    {
		return "Have you ever been far to the East? If you go there, look for a purple light in one of the abandoned buildings. There is a secret below there...";
    }
    if(x==1)
    {
        return "Have you ever been far to the West? The ocean has frozen over with thick mythril ice.";
    }
    if(x==2)
    {
        return "I once snuck inside the Wyvern Mage Fortress to the West. I used an Ice Wand to get to it. If you defeat the Wyvern Mage's game, you'll find a Shadow Key waiting for you in a chest.";
    }
    if(x==3)
    {
        return "I've heard that there is a secret pair of Hermes Boots hidden in the mountain near the village...";
    }
    if(x==4)
    {
        return "I've collected many things during my travels. Would you like to trade something for a few coins?";
    }
    if(x==5)
    {
        return "The way I see it, our fates appear to be intertwined. In a land brimming with Hollows, could that really be mere chance? So, what do you say? Why not help one another on this lonely journey?";
    }
    if(x==6)
    {
        return "I've been wondering this land for many years. If you look closely, you'll find treasures hidden behind almost every turn...";
    }
	return "If you're attacked during a Blood Moon, you can use the Cosmic Watch to turn night to day. You will still probably die though. ;)";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{  
	int index=0;
	chest.item[index].SetDefaults("Bowl of Soup");
	index++;
	chest.item[index].SetDefaults("Shine Potion");
	index++;
	chest.item[index].SetDefaults("Anklet of the Wind");
	index++;
	chest.item[index].SetDefaults("Compass");
	index++;
	chest.item[index].SetDefaults("Nature's Gift");
	index++;
	chest.item[index].SetDefaults("Daybloom Seeds");
	index++;
    chest.item[index].SetDefaults("Black Dye");
	index++;
	chest.item[index].SetDefaults("Black Lens");
	index++;
	chest.item[index].SetDefaults("Flaming Arrow");
	index++;
	chest.item[index].SetDefaults("Musket Ball");
	index++;
	chest.item[index].SetDefaults("Gel");
	index++;
	chest.item[index].SetDefaults("Orb of Light");
	index++;
	chest.item[index].SetDefaults("Breathing Reed");
	index++;
    chest.item[index].SetDefaults("Empty Bucket");
	index++;
    chest.item[index].SetDefaults("Gold Pickaxe");
	index++;
	chest.item[index].SetDefaults("Throwing Knife");
	index++;
	chest.item[index].SetDefaults("Silver Ring");
	index++;

if (NPC.downedBoss1) 
    {
	    chest.item[index].SetDefaults("Battle Potion");
	    index++;
            
    }



       
    if (Main.hardMode)
    {
	    chest.item[index].SetDefaults("Bloodbite Ring");
	    index++;
        chest.item[index].SetDefaults("Poisonbite Ring");
	    index++;
                
    }




  


    





}
#endregion

#region Gore
public void NPCLoot()
{
    
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Wondering Traveler Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 3", 1f, -1);
    
}
#endregion