public static int attraidies;
public static bool superHardmode;
public static bool CheckingMyCollision;
public static int gwyn;
public static bool theEnd;

#region Attraidies
//Avalon code that says when Attraidies dies, initiate hardmode. Needs code in boss NPCLoot to work.  
public static void Attraidies()
{

if (attraidies >= 1 || !ModWorld.superHardmode)
	{
		ModWorld.InitiateSuperHardmode();
	}
}
#endregion

#region gwyn
//Avalon code that says when Attraidies dies, initiate hardmode. Needs code in boss NPCLoot to work.  
public static void Gwyn()
{

if (gwyn >= 1 || !ModWorld.theEnd)
	{
		ModWorld.InitiateTheEnd();
	}
}
#endregion

#region The End
//Avalon code to initiate The End
public static void InitiateTheEnd()
{
	if (!ModWorld.theEnd)
	{
			if (Main.netMode == 0)
			{
				Main.NewText("The portal from The Abyss has closed!"); 
				Main.NewText("The world has been healed. You have inherited the fire of this world! ");
			    
			}
			else if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, "The portal from The Abyss has closed!", 255, 255f, 60f, 0f, 0);
				NetMessage.SendData(25, -1, -1, "The world has been healed. You have inherited the fire of this world!...", 255, 244f, 140f, 140f, 0);
			
			}
		
			Main.hardMode = false;
			ModWorld.superHardmode = false;
			ModWorld.theEnd = true;
		
		
	}
    else if (ModWorld.theEnd)
   {
			
   		  if (Main.netMode == 0)
   		  {
			 Main.NewText("You have vanquished the final guardian...");
   			 Main.NewText("The portal from The Abyss remains closed. All is at peace..."); 
			
			
   		  }
   		  else if (Main.netMode == 2)
   		  {
			 NetMessage.SendData(25, -1, -1, "You have vanquished the final guardian...", 255, 255f, 60f, 0f, 0);
   			 NetMessage.SendData(25, -1, -1, "The portal from The Abyss remains closed. All is at peace...", 255, 255f, 60f, 0f, 0);
   		  }

   		  ModWorld.superHardmode = false;
   		  Main.hardMode = false;
   		  ModWorld.theEnd = true;

    }
		
}
#endregion 

#region SuperHardmode
//Avalon code to initiate SuperHardmode
public static void InitiateSuperHardmode()
{
	if (!ModWorld.superHardmode)
	{
		if (Main.netMode == 0)
		{
			Main.NewText("A portal from The Abyss has been opened!"); 
			Main.NewText("Artorias, the Ancient Knight of the Abyss has entered this world!...");
			Main.NewText("You must seek out the Shaman Elder...");
		}
		else if (Main.netMode == 2)
		{
			NetMessage.SendData(25, -1, -1, "A portal from The Abyss has been opened!", 255, 255f, 60f, 0f, 0);
			NetMessage.SendData(25, -1, -1, "Artorias, the Ancient Knight of the Abyss has entered this world!...", 255, 244f, 140f, 140f, 0);
			NetMessage.SendData(25, -1, -1, "You must seek out the Shaman Elder...", 255, 255f, 60f, 0f, 0);
		}
		
		Main.hardMode = true;
		ModWorld.superHardmode = true;
		ModWorld.theEnd = false;
	
	}
	
   else if (ModWorld.superHardmode)
   {
			
		 if (Main.netMode == 0)
		 {
			Main.NewText("The portal from The Abyss remains open..."); 
			Main.NewText("You must seek out the Shaman Elder..."); 
			
		 }
		else if (Main.netMode == 2)
		 {
			NetMessage.SendData(25, -1, -1, "The portal from The Abyss remains open...", 255, 255f, 60f, 0f, 0);
			NetMessage.SendData(25, -1, -1, "You must seek out the Shaman Elder...", 255, 255f, 60f, 0f, 0);
		 }

		 ModWorld.superHardmode = true;
		 Main.hardMode = true;
		 ModWorld.theEnd = false;

	}
		
}
#endregion 

#region save and read
public static Dictionary<string,int> Slayed = new Dictionary<string,int>();

public void Initialize(int modId)
{
    Slayed = new Dictionary<string,int>();

	gwyn = 0;
	theEnd = false;
	attraidies = 0;
	superHardmode = false;
	
}

public void Save(BinaryWriter writer) 
{
    writer.Write(attraidies);
    writer.Write(superHardmode);
    writer.Write(Slayed.Count);
    
	foreach(KeyValuePair<string, int> pair in Slayed)
    {
        writer.Write(pair.Key);
    } 

	writer.Write(gwyn);
	writer.Write(theEnd);
}

public void Load(BinaryReader reader, int version) 
{
	
	
	attraidies = reader.ReadInt32();
    superHardmode = reader.ReadBoolean();
    
    int amt = reader.ReadInt32();
    while(amt > 0)
    {
        string s = reader.ReadString();
        Slayed.Add(s,0);
        amt--;
    }

	gwyn = reader.ReadInt32(); 
	theEnd = reader.ReadBoolean();

//try
//	{ 
//		gwyn = reader.ReadInt32(); 
//		theEnd = reader.ReadBoolean();

//	}
//	catch(Exception)
//	{ 
//		gwyn = 0;
//		theEnd = false;
//	}
	
	
}
#endregion

#region Omnir Jumping Code


//Omnir code
public Vector2 TileCollision(Vector2 Result,Vector2 Position,Vector2 Velocity,int Width,int Height,bool fallThrough,bool fall2) 
{
    if(CheckingMyCollision) Result = Velocity;
    CheckingMyCollision = false;
    return Result;
}
#endregion

#region Dragon Wings 
//Code from Zoodletech's Necro Mod
public static int AddWingByTextureName(string tex)
{
    Texture2D TEX = Main.goreTexture[Config.goreID[tex]];
    for (int i = 0; i < Main.wingsTexture.Length; i++)
        if (Main.wingsTexture[i] == TEX) return i;
    Array.Resize(ref Main.wingsTexture, Main.wingsTexture.Length + 1);
    Main.wingsTexture[Main.wingsTexture.Length - 1] = TEX;
    return Main.wingsTexture.Length - 1;
}
#endregion 

#region Covenant of Artorias
// Item that causes a perpetual blood moon when worn
public void UpdateWorld() {
  bool charm = false;
  foreach(Player p in Main.player) {
    foreach(Item i in p.armor) {
      if(i.type == Config.itemDefs.byName["Covenant of Artorias"].type) {
        charm = true;
        
      }
    }
  }
  if(charm) {

    //Main.NewText("You have entered The Abyss..."); 
    Main.bloodMoon = true;
    Main.moonPhase = 0;
    Main.dayTime = false;
    Main.time = 16240.0;

  } else {
    if(Main.bloodMoon) {
      Main.bloodMoon = false;
      Main.dayTime = true;
    }
  }
}
#endregion 

//can put souls in chests

//can dig normally