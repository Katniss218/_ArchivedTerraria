public static bool ZombieInvasion;
public static int ZombieInvasionCount;
public static int NdragonDefeated;
public static string newWorld="Normal"; //which world is this?
public static string log = "";
public static int fakeTime=0; //used on asteroid
public const int TREE_TOP_NUM = 5;
public const int liquidNum = 2;
public const int backgroundNum = 29;
public const int tileNum = 149;
public const int miscLangNum = 19;
public static Texture2D[] treeTops = new Texture2D[TREE_TOP_NUM];
public static Texture2D[] treeBranches = new Texture2D[TREE_TOP_NUM];
public static Texture2D[] liquids = new Texture2D[liquidNum];
public static Texture2D[] backgrounds = new Texture2D[backgroundNum];
public static Texture2D[] tiles = new Texture2D[tileNum];
public static string[] langMisc = new string[miscLangNum];
public static int modIndex=0;
public static int modId;
public static bool CheckingMyCollision;

#region Invasion
public void UpdateWorld()
{
	if (ModWorld.ZombieInvasion)
	{
		ModWorld.ZombieInvasionCount++;
		if (ModWorld.ZombieInvasionCount >= 32000)
		{
			ModWorld.EndZombieInvasion();
		}
	}
}

public static void StartZombieInvasion() {
    Main.hardMode = true;
    Main.bloodMoon = true;
    ZombieInvasion = true;
    ZombieInvasionCount = 0;
    if (Main.netMode == 0) Main.NewText("A Zombie outbreak is now inevitable!", 255, 50, 175);
    else if (Main.netMode == 2) NetMessage.SendData(25, -1, -1, "A Zombie outbreak is now inevitable!", 255, 255f, 50f, 175f, 0);
}

public static void EndZombieInvasion() {
    Main.hardMode = true;
    Main.bloodMoon = false;
    ZombieInvasion = false;
    ZombieInvasionCount = 0;
    if (Main.netMode == 0) Main.NewText("The Zombie hoard has been suppressed!", 255, 50, 175);
    else if (Main.netMode == 2) NetMessage.SendData(25, -1, -1, "The Zombie hoard has been suppressed!", 255, 255f, 50f, 175f, 0);
}
#endregion

#region Wings
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

#region Add Ore
public const int
	MSG_BONE = 1;

public void NetReceive(int messageType, BinaryReader br) {
	switch (messageType)
	{
		case MSG_BONE:
		{
			Bone();
			if (Main.netMode == 2)
				NetMessage.SendModData(modId, MSG_BONE, -1, -1, -1);
		}
		break;
    }
}

public static void Bone()
{
    if (Codable.RunGlobalMethod("ModWorld", "PreBone") && !(bool)Codable.customMethodReturn)
    return;
	NdragonDefeated++;
	int amount = 0;
	double num5;
	num5 = Main.rockLayer;
	int xloc = -100 + Main.maxTilesX - 100;
	int yloc = -(int)num5 + Main.maxTilesY - 200;
	int sum = xloc * yloc;
	amount = (int)(sum / 10000) * 10;
	if (NdragonDefeated == 1)
	{
			for(int zz = 0; zz < amount; zz++)
			{
				int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
				double num6;
				num6 = Main.rockLayer;
				int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 200);
				WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(4, 7)), WorldGen.genRand.Next(WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(4, 8)), Config.tileDefs.ID["Dragon Bone"]);
			}
			if (Main.netMode == 0)
			Main.NewText("Your dream has been filled with Dragon Bone", 80, 65, 130);
			else if (Main.netMode == 2)
			NetMessage.SendData(25, -1, -1, "Your dream has been filled with Dragon Bone", 255, 80f, 65f, 130f, 0);
	}
    if (Main.netMode != 0)
    NetMessage.SendModData(modId, MSG_BONE, -1, -1, -1);
    Codable.RunGlobalMethod("ModWorld", "PostBone");
}
#endregion

#region Nightmare World
public static void Save(BinaryWriter W)
{
	W.Write(newWorld);
}

public void Load(BinaryReader R, int V)
{
	newWorld = R.ReadString();
	for(int i=0;i<TREE_TOP_NUM;i++)
	{
		treeTops[i]=Main.treeTopTexture[i];
		treeBranches[i] = Main.treeBranchTexture[i];
	}
	for(int i=0;i<liquidNum;i++)
	{
		 liquids[i] = Main.liquidTexture[i];
	}
	for(int i=0;i<backgroundNum;i++)
	{
		 backgrounds[i] = Main.backgroundTexture[i];
	}
	for(int i=0;i<tileNum;i++)
	{
		 tiles[i] = Main.tileTexture[i];
	}
	
	if(ModWorld.newWorld=="Nightmare")
	{
		Main.treeTopTexture[0] = Main.tileTexture[Config.tileDefs.ID["Tree_Tops_Black"]];
		Main.treeBranchTexture[0] = Main.tileTexture[Config.tileDefs.ID["Tree_Branches_Black"]];
		Main.liquidTexture[0] = Main.tileTexture[Config.tileDefs.ID["Blood Water"]];
		Main.backgroundTexture[0] = Main.tileTexture[Config.tileDefs.ID["Lavender Sky"]];
	    Main.backgroundTexture[5] = Main.tileTexture[Config.tileDefs.ID["Background_5"]];
	    Main.backgroundTexture[6] = Main.tileTexture[Config.tileDefs.ID["Background_6"]];
		Main.backgroundTexture[7] = Main.tileTexture[Config.tileDefs.ID["Background_7"]];
		Main.backgroundTexture[8] = Main.tileTexture[Config.tileDefs.ID["Background_8"]];
	    Main.backgroundTexture[28] = Main.tileTexture[Config.tileDefs.ID["Background_28"]];
		Main.backgroundTexture[9] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
		Main.backgroundTexture[10] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
		Main.backgroundTexture[11] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
		Main.backgroundTexture[12] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
		Main.backgroundTexture[13] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
		Main.backgroundTexture[14] = Main.tileTexture[Config.tileDefs.ID["Blank"]];
		Main.tileTexture[0] = Main.tileTexture[Config.tileDefs.ID["Purple Dirt"]];
		Main.tileTexture[25] = Main.tileTexture[Config.tileDefs.ID["Obscure Ore"]];
	    Main.tileTexture[6] = Main.tileTexture[Config.tileDefs.ID["Demon Blood Ore"]];
	    Main.tileTexture[7] = Main.tileTexture[Config.tileDefs.ID["Angelite"]];
	    Main.tileTexture[8] = Main.tileTexture[Config.tileDefs.ID["Uranium Ore"]];
	    Main.tileTexture[9] = Main.tileTexture[Config.tileDefs.ID["Nightmare Ore"]];
		Main.tileTexture[57] = Main.tileTexture[Config.tileDefs.ID["Flesh Block"]];
		Main.tileTexture[59] = Main.tileTexture[Config.tileDefs.ID["Blue Dirt"]];
		Main.tileTexture[2] = Main.tileTexture[Config.tileDefs.ID["Black Grass"]];
		Main.tileTexture[60] = Main.tileTexture[Config.tileDefs.ID["Blue Grass"]];
		Main.tileTexture[3] = Main.tileTexture[Config.tileDefs.ID["Grave Stones"]];
		Main.tileTexture[61] = Main.tileTexture[Config.tileDefs.ID["Tall Grave Stones"]];
		Main.tileTexture[52] = Main.tileTexture[Config.tileDefs.ID["Red Vines"]];
		Main.tileTexture[62] = Main.tileTexture[Config.tileDefs.ID["Purple Vines"]];
		Main.sunTexture = Main.tileTexture[Config.tileDefs.ID["Nightmare Sun"]];
		Main.sun2Texture = Main.tileTexture[Config.tileDefs.ID["Nightmare Sun2"]];
		Main.moonTexture = Main.tileTexture[Config.tileDefs.ID["Nightmare Moon"]];
	}
}

public static void Initialize(int ModId)
{
	if(Main.worldName == "Nightmare")
	{
		if(ModPlayer.diamondUse == true)
		{
		}
		else
		{
			WorldGen.SaveAndQuit();
		}
	}
	newWorld="Normal";
	if(treeTops[0] != null)
	{
		for(int i=0;i<TREE_TOP_NUM;i++)
		{
			Main.treeTopTexture[i] = treeTops[i];
			Main.treeBranchTexture[i] = treeBranches[i];
		}
		for(int i=0;i<liquidNum;i++)
		{
			Main.liquidTexture[i] = liquids[i];
		}
		for(int i=0;i<backgroundNum;i++)
		{
			Main.backgroundTexture[i] = backgrounds[i];
		}
		for(int i=0;i<tileNum;i++)
		{
			Main.tileTexture[i] = tiles[i];
		}
		//Main.sunTexture=sun;
	}
	ModWorld.modId = modId;
	modIndex = Config.mods.IndexOf("Necro SP");
}
#endregion

#region Collision Check
public Vector2 TileCollision(Vector2 Result,Vector2 Position,Vector2 Velocity,int Width,int Height,bool fallThrough,bool fall2) 
{
    if(CheckingMyCollision) Result = Velocity;
    CheckingMyCollision = false;
    return Result;
}
#endregion

#region DrawChain
public static void DrawChain(Vector2 start, Vector2 end, string name, SpriteBatch spriteBatch){
start -= Main.screenPosition;
end -= Main.screenPosition;

int linklength=Main.goreTexture[Config.goreID[name]].Height;
Vector2 chain = end - start;

float length = (float)chain.Length();
int numlinks = (int)Math.Ceiling(length/linklength);
Vector2[] links = new Vector2[numlinks];
float rotation = (float)Math.Atan2(chain.Y, chain.X);

for (int i = 0; i < numlinks; i++){
    links[i] =start + chain/numlinks * i;
}
 
for (int i = 0; i < numlinks; i++){
Color color = Lighting.GetColor((int)((links[i].X+Main.screenPosition.X)/16), (int)((links[i].Y+Main.screenPosition.Y)/16));
spriteBatch.Draw(Main.goreTexture[Config.goreID[name]],
new Rectangle((int)links[i].X, (int)links[i].Y, Main.goreTexture[Config.goreID[name]].Width, linklength), null,
color, rotation+1.57f, new Vector2(Main.goreTexture[Config.goreID[name]].Width/2f, linklength), SpriteEffects.None, 1f);
}
}
#endregion