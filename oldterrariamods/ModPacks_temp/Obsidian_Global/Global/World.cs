public static bool DirectAccessed = true;



public void KillTile(int x, int y, Player player){

            if(player.inventory[player.selectedItem].name == "Fossil Pick"){
                if(Main.tile[x,y].type ==  Config.tileDefs.ID["Eternium Ore"]){
               
   Codable.globalRunKnowledge=true;
          
            player.inventory[player.selectedItem].RunMethod("DecreaseCount", 15);

            player.inventory[player.selectedItem].toolTip3 = "Durability : "+(int)Codable.customMethodReturn+"/35";

			Codable.globalRunKnowledge=false;

                }
            }
}

public static void UpdateWorld(){
if(Main.worldName == "Parallel World")
    {

// Meteor Fall Code :
    if(Main.rand.Next(10000)==0)
        {
        Main.NewText("Meteors are falling down !");
            for(int i=0; i<5; i++)
             {
             Projectile.NewProjectile(Main.rand.Next((int)Main.rightWorld), Main.player[Main.myPlayer].position.Y - 2000, 0, 5, Config.projDefs.byName["Meteor"].type, 15, 4, Main.myPlayer)   ; 
             }
        }



    }
    if(Main.rand.Next(100000)==0)
        {
        foreach( Player players in Main.player ){
            Main.player[players.whoAmi].AddBuff(Config.buffID["Rain"], 10800, false);
        }

}
if((ModPlayer.currentWorld == "Parallel") && (DirectAccessed == true)){
WorldGen.SaveAndQuit();
}
}


public static void Initialize(){
    if(Main.worldName == "Parallel World"){
        ModPlayer.currentWorld = "Parallel";
    }else{
        ModPlayer.currentWorld = "Normal";
    }
}

public void  Save(BinaryWriter writer){
DirectAccessed = true;
}




public static void UsePortal(){
	
    if(ModPlayer.currentWorld == "Normal"){
        ModPlayer.parallelVisit = true;
        //DirectAccessed = false;
        //Save the current world state
        WorldGen.saveWorld(true);

        //Generate the new World
        WorldGen.clearWorld();
        WorldGen.generateWorld(-1);

        ModPlayer.NormalWorldName  = Main.worldName;
        ModPlayer.associatedWorld = Main.worldPathName;
        Main.worldName = "Parallel World";

        //Save it to the Worlds folder
        Main.worldPathName = CreateWorldFile();

        WorldGen.EveryTileFrame();

        ModifyWorld();
    

    if (WorldGen.loadFailed || !WorldGen.loadSuccess)
	{
	Main.worldName = ModPlayer.NormalWorldName;
    Main.worldPathName = ModPlayer.associatedWorld;
    WorldGen.playWorld();
    }

Main.player[Main.myPlayer].Spawn();
DirectAccessed = false;
        ModPlayer.currentWorld = "Parallel";


}
  ModPlayer.currentWorld = "Parallel";
ModPlayer.parallelVisit = true;
}



public static string CreateWorldFile(){
			return string.Concat(new object[]
			{
				Main.WorldPath, 
				"\\world", 
				99, 
				".wld"
			});
}


static int realTileHeight = tileHeight/2;
static int BIOMEWIDTH=100 ;//ok, half-width, so sue me
static int BIOMEHEIGHT=100;
static int BIOMETHRESHOLD = 200;
static int jungleDist = tileWidth/20;
static int jungleX = WorldGen.JungleX;
static int islandClearance = 150;
static int tileWidth = Main.tile.GetUpperBound(0) - 1;
static int tileHeight = Main.tile.Length / tileWidth;
static int realTileWidth = tileWidth/2;

//tiles
const int 	 DIRT = 0;
const int 	 STONE = 1;
const int 	 GRASS = 2;
const int 	 SMALL_PLANTS = 3;
const int 	 TORCH = 4;
const int 	 TREE_TRUNK = 5;
const int 	 IRON = 6;
const int 	 COPPER = 7;
const int 	 GOLD = 8;
const int 	 SILVER = 9;
const int 	 OPEN_DOOR = 10;
const int 	 CLOSED_DOOR = 11;
const int 	 HEART_PIECE = 12;
const int 	 BOTTLES_AND_JUGS = 13;
const int 	 TABLE = 14;
const int 	 CHAIRS = 15;
const int 	 ANVIL = 16;
const int 	 FURNACE = 17;
const int 	 WORKBENCH = 18;
const int 	 WOOD_PLATFORM = 19;
const int 	 SAPLING = 20;
const int 	 CHESTS = 21;
const int 	 DEMONITE = 22;
const int 	 CORRUPTION_GRASS = 23;
const int 	 SMALL_CORRUPTION_PLANTS = 24;
const int 	 EBONSTONE = 25;
const int 	 DEMON_ALTAR = 26;
const int 	 SUNFLOWER = 27;
const int 	 POT = 28;
const int 	 PIGGY_BANK = 29;
const int 	 WOOD = 30;
const int 	 SHADOW_ORB = 31;
const int 	 CORRUPTION_BARBS = 32;
const int 	 CANDLE = 33;
const int 	 BRONZE_CHANDELLIER = 34;
const int 	 SILVER_CHANDELLIER = 35;
const int 	 GOLD_CHANDELLIER = 36;
const int 	 METEORITE = 37;
const int 	 GREY_BRICK = 38;
const int 	 RED_BRICK = 39;
const int 	 CLAY = 40;
const int 	 BLUE_BRICK = 41;
const int 	 CHAIN_LANTERN = 42;
const int 	 GREEN_BRICK = 43;
const int 	 PINK_BRICK = 44;
const int 	 GOLD_BRICK = 45;
const int 	 SILVER_BRICK = 46;
const int 	 COPPER_BRICK = 47;
const int 	 SPIKE = 48;
const int 	 WATER_CANDLE = 49;
const int 	 BOOKS = 50;
const int 	 COBWEB = 51;
const int 	 VINES = 52;
const int 	 SAND = 53;
const int 	 GLASS = 54;
const int 	 SIGN = 55;
const int 	 OBSIDIAN = 56;
const int 	 ASH = 57;
const int 	 HELLSTONE = 58;
const int 	 MUD = 59;
const int 	 JUNGLE_GRASS = 60;
const int 	 SMALL_JUNGLE_PLANTS = 61;
const int 	 JUNGLE_VINES = 62;
const int 	 SAPPHIRE = 63;
const int 	 RUBY = 64;
const int 	 EMERALD = 65;
const int 	 TOPAZ = 66;
const int 	 AMETHYST = 67;
const int 	 DIAMOND = 68;
const int 	 THORNS = 69;
const int 	 GLOWING_MUSHROOM_GRASS = 70;
const int 	 SMALL_GLOWING_MUSHROOMS = 71;
const int 	 MUSHROOM_STALKS = 72;
const int 	 SMALL_PLANTS_2 = 73;
const int 	 SMALL_PLANTS_3 = 74;
const int 	 OBSIDIAN_BRICK = 75;
const int 	 HELLSTONE_BRICK = 76;
const int 	 HELLFORGE = 77;
const int 	 CLAY_POT = 78;
const int 	 BED = 79;
const int 	 CACTUS = 80;
const int 	 CORAL = 81;
const int 	 NEW_HERBS = 82;
const int 	 GROWN_HERBS = 83;
const int 	 BLOOMED_HERBS = 84;
const int 	 TOMBSTONE = 85;
const int 	 LOOM = 86;
const int 	 PIANO = 87;
const int 	 DRAWER = 88;
const int 	 BENCH = 89;
const int 	 BATHTUB = 90;
const int 	 BANNER = 91;
const int 	 LAMP_POST = 92;
const int 	 TIKI_TORCH = 93;
const int 	 KEG = 94;
const int 	 CHINESE_LANTERN = 95;
const int 	 COOKING_POT = 96;
const int 	 SAFE = 97;
const int 	 SKULL_CANDLE = 98;
const int 	 TRASH_CAN = 99;
const int 	 CANDLABRA = 100;
const int 	 BOOKCASE = 101;
const int 	 THRONE = 102;
const int 	 BOWL = 103;
const int 	 GRANDFATHER_CLOCK = 104;
const int 	 STATUE = 105;
const int 	 SAWMILL = 106;
const int 	 COBALT = 107;
const int 	 MYTHRIL = 108;
const int 	 HALLOWED_GRASS = 109;
const int 	 HALLOWED_PLANTS = 110;
const int 	 ADAMANTITE = 111;
const int 	 EBONSAND = 112;
const int 	 HALLOWED_FLOWERS = 113;
const int 	 TINKERERS_WORKBENCH = 114;
const int 	 HALLOWED_VINES = 115;
const int 	 PEARLSAND = 116;
const int 	 PEARLSTONE = 117;
const int 	 PEARLSTONE_BRICK = 118;
const int 	 IRIDESCENT_BRICK = 119;
const int 	 MUDSTONE_BRICK = 120;
const int 	 COBALT_BRICK = 121;
const int 	 MYTHRIL_BRICK = 122;
const int 	 SILT = 123;
const int 	 WOODEN_BEAM = 124;
const int 	 CRYSTAL_BALL = 125;
const int 	 DISCOBALL = 126;
const int 	 GLASS2 = 127;
const int 	 MANNEQUIN = 128;
const int 	 CRYSTAL_SHARD = 129;
const int 	 ACTIVE_STONE = 130;
const int 	 INACTIVE_STONE = 131;
const int 	 LEVER = 132;
const int 	 ADAMANTITE_FORGE = 133;
const int 	 MYTHRIL_ANVIL = 134;
const int 	 PRESSURE_PLATES = 135;
const int 	 SWITCH = 136;
const int 	 DART_TRAP = 137;
const int 	 BOULDER = 138;
const int 	 MUSIC_BOXES = 139;
const int 	 OBSIDIAN_BRICK_2 = 140;
const int 	 EXPLOSIVES = 141;
const int 	 INLET_PUMP = 142;
const int 	 OUTLET_PUMP = 143;
const int 	 TIMERS = 144;
const int 	 RED_CANDYCANE_BLOCK = 145;
const int 	 GREEN_CANDYCANE_BLOCK = 146;
const int 	 SNOW = 147;
const int 	 SNOW_BRICK = 148;
const int 	 FESTIVE_LIGHTS = 149;

//walls
const int 	 STONE_WALL = 1;
const int 	 DIRT_WALL = 2;
const int 	 EBONSTONE_WALL = 3;
const int 	 WOOD_WALL = 4;
const int 	 STONE_BRICK_WALL = 5;
const int 	 RED_BRICK_WALL = 6;
const int 	 BLUE_BRICK_WALL = 7;
const int 	 GREEN_BRICK_WALL = 8;
const int 	 PINK_BRICK_WALL = 9;
const int 	 GOLD_BRICK_WALL = 10;
const int 	 SILVER_BRICK_WALL = 11;
const int 	 COPPER_BRICK_WALL = 12;
const int 	 HELLSTONE_BRICK_WALL = 13;
const int 	 OBSIDIAN_BRICK_WALL = 14;
const int 	 MUD_WALL = 15;
const int 	 PLAYER_DIRT_WALL = 16;
const int 	 PLAYER_BLUE_BRICK_WALL = 17;
const int 	 PLAYER_GREEN_BRICK_WALL = 18;
const int 	 PLAYER_PINK_BRICK_WALL = 19;
const int 	 PLAYER_OBSIDIAN_WALL = 20;
const int 	 GLASS_WALL = 21;
const int 	 PEARLSTONE_BRICK_WALL = 22;
const int 	 IRIDESCENT_BRICK_WALL = 23;
const int 	 MUDSTONE_BRICK_WALL = 24;
const int 	 COBALT_BRICK_WALL = 25;
const int 	 MITHRIL_BRICK_WALL = 26;
const int 	 WOOD_PANELLING_WALL = 27;
const int 	 FRAGILE_STONE_WALL = 28;
const int 	 RED_CANDYCANE_WALL = 29;
const int 	 GREEN_CANDYCANE_WALL = 30;
const int 	 SNOW_BRICK_WALL = 31;

const int PLANT_FRAMES = 9;
const int JUNGLE_PLANT_FRAMES = 10;





//turns all tiles of types in "targets" inti tiles of type "replacement"
public static void sub(int[] targets, int replacement){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget)
			{
				Main.tile[x, y].type = (byte)replacement;
			}
		}
	}
}
//specifies the chance
public static void subOnChance(int[] targets, int replacement,int chance){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget && Main.rand.Next(chance)==0)
			{
				Main.tile[x, y].type = (byte)replacement;
			}
		}
	}
}

public static void subOnChance(int[] targets, int replacement,int chance, int xMin, int xMax, int yMin, int yMax){
	for (int x = xMin; x < xMax; x++)
	{
		for (int y = yMin; y < yMax; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget && Main.rand.Next(chance)==0)
			{
				Main.tile[x, y].type = (byte)replacement;
			}
		}
	}
}
//optionally specify number of frames of tile, will set to random one
public static void sub(int[] targets, int replacement,int numFrames=1){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget)
			{
				Main.tile[x, y].type = (byte)replacement;
				if(numFrames > 1){
					Main.tile[x,y].frameNumber = (byte) (numFrames-1);
				}
			}
		}
	}
}

public static void sub(int[] targets, int replacement,int xMin, int xMax, int yMin, int yMax){
	for (int x = xMin; x < xMax; x++)
	{
		for (int y = yMin; y < yMax; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget)
			{
				Main.tile[x, y].type = (byte)replacement;
			}
		}
	}
}

public static void subTileToLiquid(int[] targets, int amount=255,bool lava=false){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget)
			{
				Main.tile[x, y].active = false;
				Main.tile[x, y].liquid = (byte)amount;
				Main.tile[x, y].lava = lava;
			}
		}
	}
}

public static void subWall(int[] targets, int replacement){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].wall == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget)
			{
				Main.tile[x, y].wall = (byte)replacement;
			}
		}
	}
}

public static void subWall(int[] targets, int replacement,int xMin, int xMax, int yMin, int yMax){
	for (int x = xMin; x < xMax; x++)
	{
		for (int y = yMin; y < yMax; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].wall == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget)
			{
				Main.tile[x, y].wall = (byte)replacement;
			}
		}
	}
}

public static void subWallOnChance(int[] targets, int replacement,int xMin, int xMax, int yMin, int yMax, int chance){
	for (int x = xMin; x < xMax; x++)
	{
		for (int y = yMin; y < yMax; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].wall == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget && Main.rand.Next(chance)==0)
			{
				Main.tile[x, y].wall = (byte)replacement;
			}
		}
	}
}

public static void subLiquid(){
	for (int x = 0; x < tileWidth; x++)
	{
		//Main.statusText = "x = "+x;
		for (int y = 0; y < tileHeight; y++)
		{
			//Main.statusText = "y = "+y;
			
			if ((Main.tile[x, y] != null) && (Main.tile[x,y].liquid != null))
			{
				//Main.statusText = ""+Main.tile[x,y].liquid;
				Main.tile[x, y].lava = true;
			}
		}
	}
}

public static void remove(int[] targets){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget)
			{
				Main.tile[x, y].active = false;
			}
		}
	}
}

public static void killLiquid(int[] targets){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight-1; y++)
		{
			//Main.statusText = "y = "+y;
			bool containsTarget = false;
			for (int k = 0; k < targets.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == targets[k]){
					containsTarget = true;
				}
			}
			
			if (containsTarget)
			{
				//Main.statusText = "contains";
				int thisY = y-1;
				while((thisY >= 0 && Main.tile[x,thisY] != null && Main.tile[x,thisY].liquid != null && Main.tile[x,thisY].liquid > 0)){
					//Main.statusText = "thisY = "+thisY;
					Main.tile[x, thisY].liquid=0;
					thisY--;
				}
			}
		}
	}
}

//remove a percentage of liquid from world
public static void dryWorld(double dryFactor, bool lavaToo){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight-1; y++)
		{		
			if (Main.tile[x,y] != null && Main.tile[x,y].liquid != null && Main.tile[x,y].liquid > 0 && (lavaToo || !Main.tile[x,y].lava))
			{
				Main.tile[x,y].liquid= (byte)(Main.tile[x,y].liquid * dryFactor);
			}
		}
	}
}

public static void killTrees(int[] targets){
	for (int x = 0; x < tileWidth; x++)
	{
		for (int y = 0; y < tileHeight-1; y++)
		{
			if(Main.tile[x, y] != null && Main.tile[x, y].type == TREE_TRUNK){
				bool containsTarget = false;
				for (int k = 0; k < targets.Length; k++){
					if(Main.tile[x, y+1] != null && Main.tile[x, y+1].type == targets[k]){
						containsTarget = true;
					}
				}
				if (containsTarget)
				{
					int thisY = y;
					while((Main.tile[x,thisY].type==TREE_TRUNK) || thisY <= 0){
						//Main.statusText = "y = "+thisY;
						Main.tile[x, thisY].active=false;
						if(Main.tile[x+1,thisY].type==TREE_TRUNK){Main.tile[x+1,thisY].active=false;}
						if(Main.tile[x-1,thisY].type==TREE_TRUNK){Main.tile[x-1,thisY].active=false;}						
						thisY--;
					}
				}
			}
		}
	}
}

public static void addPyramid(int newTile, int height=55)
{
	int dX = WorldGen.dungeonX; //dungeonX, not slope, lol
	int dY = WorldGen.dungeonY;
	byte tile = (byte) newTile;
	int pyramidHeight = height;
	int hallHeight = 13;
	int stairsHeight = 25;
	bool dungeonIsRight = false;
	if(dX > (tileWidth / 4)){
		dungeonIsRight = true;
	}
	int thisX = dX;
	int sideHeight;
	sideHeight = dY-hallHeight-1;
	
	sub(new [] {BLUE_BRICK,PINK_BRICK,GREEN_BRICK},tile);
	if(dungeonIsRight){//right side is long when it's the farther away side
		sideHeight = dY+stairsHeight;
	}
	for(int thisY = dY-pyramidHeight;thisY < sideHeight;thisY++){
		Main.tile[thisX,thisY].active = true;
		Main.tile[thisX,thisY].type = tile;
		for(int subThisY = thisY+1; (subThisY < sideHeight) && Main.tile[thisX,subThisY].type != tile; subThisY++)
		{
			Main.tile[thisX,subThisY].active = true;
			Main.tile[thisX,subThisY].type = tile;
		}
		thisX++;
	}
	thisX = dX;
	sideHeight = dY-hallHeight-1;
	if(!dungeonIsRight){
		sideHeight = dY+stairsHeight;
	}
	for(int thisY = dY-pyramidHeight;thisY < sideHeight;thisY++){
		Main.tile[thisX,thisY].active = true;
		Main.tile[thisX,thisY].type = tile;
		for(int subThisY = thisY+1; (subThisY < sideHeight) && Main.tile[thisX,subThisY].type != tile;subThisY++)
		{
			Main.tile[thisX,subThisY].active = true;
			Main.tile[thisX,subThisY].type = tile;
		}
		thisX--;
	}
}

public static void wallBodyTiles(int [] tiles, int wall,int xMin, int xMax, int yMin, int yMax)
{
	for (int x = xMin; x < xMax; x++)
	{
		for (int y = yMin; y < yMax; y++)
		{
			bool containsTarget = false;
			for (int k = 0; k < tiles.Length; k++){
				if(Main.tile[x, y] != null && Main.tile[x, y].type == tiles[k]){
					containsTarget = true;
				}
			}
			
			//if (containsTarget && Main.tile[x+1, y] != null && Main.tile[x+1, y].active && Main.tile[x-1, y] != null && Main.tile[x-1, y].active && Main.tile[x, y+1] != null && Main.tile[x, y+1].active)
			if (containsTarget && Main.tile[x, y-3] != null && Main.tile[x, y-3].active)
			{
				Main.tile[x, y].wall = (byte)wall;
			}
		}
	}
}

//attempts to find surface y coord at specified x
//returns -1 on fail
public static int findSurface(int xPos, int [] surfaceTiles)
{
	for(int traceY = islandClearance;traceY < tileHeight/2; traceY++)
	{
		//Main.statusText = "traceY = "+traceY;
		bool containsTarget = false;
		for (int k = 0; k < surfaceTiles.Length; k++){
			if(Main.tile[xPos, traceY] != null && Main.tile[xPos, traceY].active && Main.tile[xPos, traceY].type == surfaceTiles[k]){
				containsTarget = true;
			}
		}
		if (containsTarget)
		{
			return traceY;
			
		}
	} 
	return -1;
}

 public static int findSurface(int xPos)
{
	for(int traceY = islandClearance;traceY < tileHeight/2; traceY++)
	{
		//Main.statusText = "traceY = "+traceY;
		if(Main.tile[xPos, traceY] != null && Main.tile[xPos, traceY].active)
		{
			return traceY;
		}
	} 
	return -1;
} 

 public static void addVillage(int xPos, int direction = 1, int tile=MUDSTONE_BRICK, int wall=MUDSTONE_BRICK_WALL, int spacing=25, int number=7, int spacingVariance=0)
{
	for(int i=0; i < number; i++)
	{
		int houseX = xPos + (i * spacing * direction);
		int houseY = findSurface(houseX);
		WorldGen.HellHouse(houseX,houseY);
	}
	killTrees(new [] {HELLSTONE_BRICK,WOOD_PLATFORM});
	sub(new [] {HELLSTONE_BRICK}, tile);
	subWall(new [] {HELLSTONE_BRICK_WALL}, wall);
} 

public static void AddOres(int type,int depthReduce=0) {
    int add = 0;
    //float num3 = (float)(Main.maxTilesX / 4200);
    int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
    double num6 = Main.worldSurface;
    int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - (150+depthReduce));
    WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(5, 9 + add), WorldGen.genRand.Next(5, 9 + add), (byte)type); //change yet again.
}



public static void ModifyWorld(){
	//ModWorld.otherWorld="SNOWY";
//subLiquid();

for(int i=0; i<30; i++){
        Projectile.NewProjectile(Main.rand.Next((int)Main.rightWorld), Main.player[Main.myPlayer].position.Y - 2000, 0, 5, Config.projDefs.byName["Meteor"].type, 15, 4, Main.myPlayer)   ; 
        }
	sub(new [] {GRASS,SNOW,GLOWING_MUSHROOM_GRASS,CORRUPTION_GRASS,EBONSTONE,SAND,ASH},(byte)JUNGLE_GRASS);
	sub(new [] {PINK_BRICK,BLUE_BRICK,GREEN_BRICK,GOLD_BRICK,HELLSTONE_BRICK},(byte)OBSIDIAN_BRICK);
    sub(new [] {IRON, GOLD, SILVER, DEMONITE, COPPER, COBALT, MYTHRIL, ADAMANTITE}, (byte)Config.tileDefs.ID["Eternium Ore"]);
	remove(new [] {SPIKE,CORRUPTION_BARBS,THORNS,CACTUS,SMALL_CORRUPTION_PLANTS, SUNFLOWER, DEMON_ALTAR});
	subWall(new [] {EBONSTONE_WALL},DIRT_WALL); 
	subWall(new [] {BLUE_BRICK_WALL,GREEN_BRICK_WALL,PINK_BRICK_WALL},DIRT_WALL); 
  //  addVillage(Main.rand.Next(6500), 1, MUDSTONE_BRICK, MUDSTONE_BRICK_WALL, 35, 5, 10);
// addVillage(Main.rand.Next(6500), 1, MUDSTONE_BRICK, MUDSTONE_BRICK_WALL, 35, 5, 10);


		WorldGen.EveryTileFrame();
}

