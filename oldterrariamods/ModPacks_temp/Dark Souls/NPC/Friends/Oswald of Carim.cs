//#region Town Spawn
//public static bool TownSpawn() 
//{

//	for (int pInv = 0; pInv < 48; pInv++)
//	{
//		if (ModWorld.superHardmode && Main.player[pInv].statLifeMax < 340)
//		{
//			if (!NPC.AnyNPCs(Config.npcDefs.byName["Oswald of Carim"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Oswald of Carim"].type)) return true;
//		}
//	}
//	return false;
//}
//#endregion

#region Name
public void Initialize() 
{
	if(Main.chrName[npc.type] == null){ Main.chrName[npc.type] = SetName(); }
}

public string SetName() 
{
	    return "Oswald of Carim";    
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
        if(!NPC.AnyNPCs(Config.npcDefs.byName["Oswald of Carim"].type) && ModWorld.superHardmode && Main.snowTiles >= 20 && AboveEarth && Main.rand.Next(8)==1) 

		{
			Main.NewText("Oswald of Carim is nearby... ", 175, 75, 255);
 	
			return true;
		}
		
	    if(!NPC.AnyNPCs(Config.npcDefs.byName["Oswald of Carim"].type) && ModWorld.superHardmode && Main.sandTiles >= 20 && AboveEarth && Main.rand.Next(8)==1) 

		{
			Main.NewText("Oswald of Carim is nearby... ", 175, 75, 255);
 	
			return true;
		}


		for (int pInv = 0; pInv < 48; pInv++)
		{
			if(!NPC.AnyNPCs(Config.npcDefs.byName["Oswald of Carim"].type) && ModWorld.superHardmode && Main.player[pInv].statLifeMax < 320 && AboveEarth && Main.rand.Next(10)==1) 

			{
				Main.NewText("Oswald of Carim is nearby... ", 175, 75, 255);
 	
				return true;
			}
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
		return "I prefer the extremes in life. If thou desires to find me again, I take refuge in places of great cold and great heat...";
    }
    if(x==1)
    {
        return "Hahahaha...Have you suffered a bit of bad luck with those Basalisk Hunters? I have just what you need, but it'll cost you...";
    }
    if(x==2)
    {
        return "I am Oswald of Carim, the pardoner. Thou art a friend. For thee, a warm welcome. Cometh thou to confess? Or to accuse? For indeed all sin is my domain.";
    }
    if(x==3)
    {
        return "Have you spoken to the Shaman Elder? I believe he has something for you... A ring of great importance to your journey...";
    }
    if(x==4)
    {
        return "Have you spoken to the Shaman Elder? I believe he has something for you... A ring of great importance to your journey...";
    }
    if(x==5)
    {
        return "If thou desires to find me again, I take refuge in places of great cold and great heat...";
    }
    if(x==6)
    {
        return "Be wary of the Basilisk Hunters... The curse they can put on you is quite nasty...";
    }
	return "If you cannot afford these Purging Stones and are in dire need, there is a chance the Oolacile Sorcerers will drop one. The Abysmal Oolacile Sorcerer has the highest chance.";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{  
	int index=0;
	chest.item[index].SetDefaults("Purging Stone");
	index++;
	chest.item[index].SetDefaults("Bloodbite Ring");
	index++;
	chest.item[index].SetDefaults("Poisonbite Ring");
	index++;
	chest.item[index].SetDefaults("Abyss Scroll");
	index++;
	chest.item[index].SetDefaults("Witchking Scroll");
	index++;
	chest.item[index].SetDefaults("Tesla Bolt");
	index++;
	chest.item[index].SetDefaults("Demon Drug");
	index++;
    chest.item[index].SetDefaults("Armor Drug");
	index++;
            
	
//if (NPC.downedBoss1) 
//	{
//		chest.item[index].SetDefaults("Battle Potion");
//		index++;
            
//	}


    


    // if (NPC.downedBoss3)
    //{
    //    chest.item[index].SetDefaults("Forgotten Kotetsu");
    //    index++;
    //        
    //}



       
   




  


    





}
#endregion

#region Gore
public void NPCLoot()
{
    
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Oswald of Carim Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Tibian Female Knight Gore 3", 1f, -1);
		Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Blood Splat", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Blood Splat", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Blood Splat", 1f, -1);
    
}
#endregion