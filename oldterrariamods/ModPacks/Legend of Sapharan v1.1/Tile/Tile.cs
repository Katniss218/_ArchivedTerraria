public void ModifyWorld() 
{
    Main.statusText = "Generating Zircon...";
    int Amount_Of_Spawns = 100+(int)(Main.maxTilesY/5); 
    for(int i=0;i<Amount_Of_Spawns;i++) AddZircon();

    Main.statusText = "Generating Aquamarine..."; 
    for(int i=0;i<Amount_Of_Spawns;i++) AddAquamarine();
	
	Main.statusText = "Generating Turqouise..."; 
    for(int i=0;i<Amount_Of_Spawns;i++) AddTurqouise();
	
	Main.statusText = "Generating Opal..."; 
    for(int i=0;i<Amount_Of_Spawns;i++) AddOpal();
	
	Main.statusText = "Generating Garnet..."; 
    for(int i=0;i<Amount_Of_Spawns;i++) AddGarnet();
	
	Main.statusText = "Generating Lapis Lazuli..."; 
    for(int i=0;i<Amount_Of_Spawns;i++) AddLapis();
	
	Main.statusText = "Generating Sardonyx..."; 
    for(int i=0;i<Amount_Of_Spawns;i++) AddSardonyx();
	
    foreach(Chest C in Main.chest)
    {
        if (C != null)
        {
            foreach(Item I in C.item)
            {
                if (I != null && I.type == Config.itemDefs.byName["Cobalt Shield"].type)
                {
                    int random = WorldGen.genRand.Next(2);
                        if (random == 0) I.SetDefaults("Cobalt Shield");
                        if (random == 1) I.SetDefaults("Ring of Ares");
                }
				if (I != null && I.type == Config.itemDefs.byName["Handgun"].type)
                {
                    int random = WorldGen.genRand.Next(2);
                        if (random == 0) I.SetDefaults("Handgun");
                        if (random == 1) I.SetDefaults("Crescent Ring");
                }
				if (I != null && I.type == Config.itemDefs.byName["Aqua Scepter"].type)
                {
                    int random = WorldGen.genRand.Next(2);
                        if (random == 0) I.SetDefaults("Aqua Scepter");
                        if (random == 1) I.SetDefaults("Helmet of Moon");
                }
				if (I != null && I.type == Config.itemDefs.byName["Magic Missile"].type)
                {
                    int random = WorldGen.genRand.Next(2);
                        if (random == 0) I.SetDefaults("Magic Missile");
                        if (random == 1) I.SetDefaults("Breastplate of Moon");
                }
				if (I != null && I.type == Config.itemDefs.byName["Blue Moon"].type)
                {
                    int random = WorldGen.genRand.Next(2);
                        if (random == 0) I.SetDefaults("Blue Moon");
                        if (random == 1) I.SetDefaults("Greaves of Moon");
                }
				//----------------------------------------------------------
				if (I != null && I.type == Config.itemDefs.byName["Dark Lance"].type)
                {
                    int random = WorldGen.genRand.Next(2);
                        if (random == 0) I.SetDefaults("Dark Lance");
                        if (random == 1) I.SetDefaults("Soul Reaver");
                }
            }
        }
    }
}
//==========================================================================================================
public void AddZircon() 
{
    int LowX = 200;                     
    int HighX = Main.maxTilesX-200;    
    int LowY = (int)Main.worldSurface;  
    int HighY = Main.maxTilesY-200;    
    
    int X = WorldGen.genRand.Next(LowX,HighX); 
    int Y = WorldGen.genRand.Next(LowY,HighY); 

    int OreMinimumSpread = 2; 
    int OreMaximumSpread = 4; 

    int OreMinimumFrequency = 2; 
    int OreMaximumFrequency = 4; 

    int OreSpread = WorldGen.genRand.Next(OreMinimumSpread,OreMaximumSpread+1); 
    int OreFrequency = WorldGen.genRand.Next(OreMinimumFrequency,OreMaximumFrequency+1); 

    WorldGen.OreRunner(X, Y, (double)OreSpread, OreFrequency, Config.tileDefs.ID["Zircon"]);
}
//==========================================================================================================
public void AddAquamarine()
{
    int LowX = 200;                     
    int HighX = Main.maxTilesX-200;    
    int LowY = (int)Main.worldSurface;  
    int HighY = Main.maxTilesY-200;    
    
    int X = WorldGen.genRand.Next(LowX,HighX); 
    int Y = WorldGen.genRand.Next(LowY,HighY); 

    int OreMinimumSpread = 2; 
    int OreMaximumSpread = 4; 

    int OreMinimumFrequency = 2; 
    int OreMaximumFrequency = 4; 

    int OreSpread = WorldGen.genRand.Next(OreMinimumSpread,OreMaximumSpread+1); 
    int OreFrequency = WorldGen.genRand.Next(OreMinimumFrequency,OreMaximumFrequency+1); 

    WorldGen.OreRunner(X, Y, (double)OreSpread, OreFrequency, Config.tileDefs.ID["Aquamarine"]);
}
//==========================================================================================================
public void AddTurqouise() 
{
    int LowX = 200;                     
    int HighX = Main.maxTilesX-200;    
    int LowY = (int)Main.worldSurface;  
    int HighY = Main.maxTilesY-200;    
    
    int X = WorldGen.genRand.Next(LowX,HighX); 
    int Y = WorldGen.genRand.Next(LowY,HighY); 

    int OreMinimumSpread = 2; 
    int OreMaximumSpread = 4; 

    int OreMinimumFrequency = 2; 
    int OreMaximumFrequency = 4; 

    int OreSpread = WorldGen.genRand.Next(OreMinimumSpread,OreMaximumSpread+1); 
    int OreFrequency = WorldGen.genRand.Next(OreMinimumFrequency,OreMaximumFrequency+1); 

    WorldGen.OreRunner(X, Y, (double)OreSpread, OreFrequency, Config.tileDefs.ID["Turqouise"]);
}
//=======================================================================================================
public void AddOpal() 
{
    int LowX = 200;                     
    int HighX = Main.maxTilesX-200;    
    int LowY = (int)Main.worldSurface;  
    int HighY = Main.maxTilesY-200;    
    
    int X = WorldGen.genRand.Next(LowX,HighX); 
    int Y = WorldGen.genRand.Next(LowY,HighY); 

    int OreMinimumSpread = 2; 
    int OreMaximumSpread = 4; 

    int OreMinimumFrequency = 2; 
    int OreMaximumFrequency = 4; 

    int OreSpread = WorldGen.genRand.Next(OreMinimumSpread,OreMaximumSpread+1); 
    int OreFrequency = WorldGen.genRand.Next(OreMinimumFrequency,OreMaximumFrequency+1); 

    WorldGen.OreRunner(X, Y, (double)OreSpread, OreFrequency, Config.tileDefs.ID["Opal"]);
}
//=======================================================================================================
public void AddGarnet() 
{
    int LowX = 200;                     
    int HighX = Main.maxTilesX-200;    
    int LowY = (int)Main.worldSurface;  
    int HighY = Main.maxTilesY-200;    
    
    int X = WorldGen.genRand.Next(LowX,HighX); 
    int Y = WorldGen.genRand.Next(LowY,HighY); 

    int OreMinimumSpread = 2; 
    int OreMaximumSpread = 4; 

    int OreMinimumFrequency = 2; 
    int OreMaximumFrequency = 4; 

    int OreSpread = WorldGen.genRand.Next(OreMinimumSpread,OreMaximumSpread+1); 
    int OreFrequency = WorldGen.genRand.Next(OreMinimumFrequency,OreMaximumFrequency+1); 

    WorldGen.OreRunner(X, Y, (double)OreSpread, OreFrequency, Config.tileDefs.ID["Garnet"]);
}
//=======================================================================================================
public void AddLapis() 
{
    int LowX = Main.maxTilesX/2;                     
    int HighX = Main.maxTilesX-200;    
    int LowY = (int)Main.worldSurface;  
    int HighY = Main.maxTilesY-200;    
    
    int X = WorldGen.genRand.Next(LowX,HighX); 
    int Y = WorldGen.genRand.Next(LowY,HighY); 

    int OreMinimumSpread = 5; 
    int OreMaximumSpread = 15; 

    int OreMinimumFrequency = 10; 
    int OreMaximumFrequency = 20; 

    int OreSpread = WorldGen.genRand.Next(OreMinimumSpread,OreMaximumSpread+1); 
    int OreFrequency = WorldGen.genRand.Next(OreMinimumFrequency,OreMaximumFrequency+1); 

    WorldGen.OreRunner(X, Y, (double)OreSpread, OreFrequency, Config.tileDefs.ID["Lapis Lazuli"]);
}
//=======================================================================================================
public void AddSardonyx() 
{
    int LowX = 200;                     
    int HighX = Main.maxTilesX/2;    
    int LowY = (int)Main.worldSurface;  
    int HighY = Main.maxTilesY-200;    
    
    int X = WorldGen.genRand.Next(LowX,HighX); 
    int Y = WorldGen.genRand.Next(LowY,HighY); 

    int OreMinimumSpread = 5; 
    int OreMaximumSpread = 15; 

    int OreMinimumFrequency = 10; 
    int OreMaximumFrequency = 20; 

    int OreSpread = WorldGen.genRand.Next(OreMinimumSpread,OreMaximumSpread+1); 
    int OreFrequency = WorldGen.genRand.Next(OreMinimumFrequency,OreMaximumFrequency+1); 

    WorldGen.OreRunner(X, Y, (double)OreSpread, OreFrequency, Config.tileDefs.ID["Sardonyx"]);
}