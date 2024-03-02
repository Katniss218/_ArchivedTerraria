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

#region Red Cloud No Digging or Placing Blocks Code by Surfpup
public List<int> allowed = new List<int>() { //These can always be destroyed
    
    
    19, //Wood Platform 
    67, //Amethyst 
            //25, ebonstone
    12, //Heart crystal
    2, //grass
	3, //small plants
    4, // torch
    5, //tree trunk
    6, //iron
    7, //copper
    9, //silver
    10, //closed door
    11, //open door
    12, //bottles
    13, //bottles and jugs
    14, //table
    15, //chairs
    16, //anvil
    17, //furnance
    18, //workbench
    20, //sapling
		//21, //chests
    23, //corruption grass
    27, //sunflower
    28, //pot
    29, //piggy bank
    31, //shadow orb
    32, //corruption barbs
    33, //candle
    34, //bronze chandellier
    35, //silver c
    36, //gold c
    37, //meteorite
    42, //chain lantern
    49, //water candle
    50, //books
    51, //cobweb
    52, //vines
    53, //sand
    55, //Sign 
    56, //obsidian
    60, //jungle grass
    62, //jungle vines
    66, //Topaz 
    69, //thorns
    72, //mushroom stalks
    71, //small mushrooms
    73, //plants
    74, //plants
    78, //clay pot
    79, //bed
    80, //cactus
    81, //corals
    82, //new herbs
    83, //grown herbs
    84, //bloomed herbs
    85, //tombstone
    86, //loom
    87, //piano
    88, //drawer
    89, //bench
    90, //bathtub
    91, //banner
    92, //lamp post
    93, //tiki torch
    94, //keg
    95, //chinese lantern
    96, //cooking pot
    97, //safe
    98, //skull candle
    99, //trash can
    100, //candlabra
    101, //bookcase
    102, //throne
    103, //bowl
    104, //grandfather clock
    105, //statue
    106, //sawmill
    107, //cobalt
    108, //mythril
    109, //Hallowed Grass
    110, //Hallowed Plants	 
    111, //adamantite
    112, //ebonsand
    114, //tinkerer's workbench
    115, //Hallowed Vines 
    116, //pearlsand
    125, //crystal ball
    126, //discoball
    128, //mannequin
    129, //crystal shard
    133, //adamantite forge
    134, //mythril anvil
    138, //boulder
    141 //explosives
};
public List<int> unbreakable = new List<int>() 
{
    132, //lever
    130, //active stone block
    135, //pressure plates
    136, //switch
    137 //dart trap
};
public bool CanDestroyTile(int x, int y) 
{
    if(x < 10 || x > Main.maxTilesX-10) return true;
    if(y < 10 || y > Main.maxTilesY-10) return true;
    if(Main.tile[x,y] == null) return true;
    int type = Main.tile[x,y].type;
    if(allowed.Contains(type)) return true;
    if(unbreakable.Contains(type)) return false;
    bool right = (Main.tile[x+1, y] == null || !Main.tile[x+1, y].active);
    bool left = (Main.tile[x-1, y] == null || !Main.tile[x-1, y].active);
    bool below = (Main.tile[x, y-1] == null || !Main.tile[x, y-1].active);
    bool above = (Main.tile[x, y+1] == null || !Main.tile[x, y+1].active);
    if(right && left) return true;
    if(below && above) return true;
    return false;
}



public bool CanExplode(int x,int y,int projType,bool current)
{
    bool CanDestroy = true;
    if (Main.tileDungeon[(int)Main.tile[x,y].type] 
        || Main.tile[x,y].type == 9 
        || Main.tile[x,y].type == 107 
        || Main.tile[x,y].type == 108 
        || Main.tile[x,y].type == 111
	
    )
    {
        CanDestroy = false;
    }
    if (!Main.hardMode && Main.tile[x,y].type == 58)
    {
        CanDestroy = false;
    }
    if(!CanDestroy) return false;
    return (projType == 108) || CanDestroyTile(x,y);
}
#endregion 