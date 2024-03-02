public static int[] stationPosX = new int[4];
public static int[] stationPosY = new int[4];
public static int[] stationScore = new int[4];
public static bool[] stationExists = new bool[4];
public const int TimeFree = 60*10; // 60 = 1 second , multiply by the amount of seconds you want it to be at.
public const int PointBlockRange= 160;
public const int RangeToScore = 32;
public static bool[] DownedPhoenixes = { false , false , false} ; // phoenix , jungix , aquatix

public static void Save(BinaryWriter writer) 
{
    for (int i = 0; i < 4; i++)
			{
	writer.Write(stationPosX[i]);
	writer.Write(stationPosY[i]);
	writer.Write(stationScore[i]);
	writer.Write(stationExists[i]);
			}
    for (int i = 0; i < 3; i++)
    {
	    writer.Write(DownedPhoenixes[i]);
    }
    //writer.Write(TimeFree);
    //writer.Write(PointBlockRange);
    //writer.Write(RangeToScore);
}
public static void Load(BinaryReader reader, int version) 
{
    for (int i = 0; i < 4; i++)
			{
	            stationPosX[i]=reader.ReadInt32();
	            stationPosY[i]=reader.ReadInt32();
	            stationScore[i]=reader.ReadInt32();
	            stationExists[i]=reader.ReadBoolean();
			}
    for (int i = 0; i < 3; i++)
			{
			    DownedPhoenixes[i] = reader.ReadBoolean();
			}
    //TimeFree=reader.ReadInt32();
    //PointBlockRange= reader.ReadInt32();
    //RangeToScore = reader.ReadInt32();
}


public static void PostDraw(SpriteBatch spriteBatch) 
{
    if(Main.netMode != 1)
        return;
    if(false){ // doesnt work on tconfig , for now...
    if (Main.GetKeyState((int)Microsoft.Xna.Framework.Input.Keys.O) < 0)
    {
        if(!ModPlayer.trap)
        {
            bool executeChange = false;
            if(executeChange)
            {
                ModPlayer.CTFshow = !ModPlayer.CTFshow;
            }
            ModPlayer.trap = true;           
        }
    }
    else
    {
        ModPlayer.trap = false;
    }
    }
    bool bugfixer = !ModPlayer.trap;
    if(!Main.playerInventory && !Main.chatMode && bugfixer)
    {          
        string s1 = ""+stationScore[0];
        string s2 = ""+stationScore[1];
        string s3 = ""+stationScore[2];
        string s4 = ""+stationScore[3]; 
        Vector2 v1 = Main.fontMouseText.MeasureString(s1);
        Vector2 v2 = Main.fontMouseText.MeasureString(s2);
        Vector2 v3 = Main.fontMouseText.MeasureString(s3);
        Vector2 v4 = Main.fontMouseText.MeasureString(s4);
        Color c1 = new Color(255,0,0,255);
        Color c2 = new Color(0,255,0,255);
        Color c3 = new Color(0,0,255,255);
        Color c4 = new Color(255,255,0,255);
        float f1 = 0.95f;
        float f2 = 0.95f;
        float f3 = 0.95f;
        float f4 = 0.95f;
        spriteBatch.DrawString(Main.fontMouseText, s1, new Vector2(32f, Main.screenHeight-32f-30*4*f1), c1, 0f, default(Vector2), f1 , SpriteEffects.None, 0f);
        spriteBatch.DrawString(Main.fontMouseText, s2, new Vector2(32f, Main.screenHeight-32f-30*3*f2), c2, 0f, default(Vector2), f2 , SpriteEffects.None, 0f);
        spriteBatch.DrawString(Main.fontMouseText, s3, new Vector2(32f, Main.screenHeight-32f-30*2*f3), c3, 0f, default(Vector2), f3 , SpriteEffects.None, 0f);
        spriteBatch.DrawString(Main.fontMouseText, s4, new Vector2(32f, Main.screenHeight-32f-30*1*f4), c4, 0f, default(Vector2), f4 , SpriteEffects.None, 0f);
    
        spriteBatch.Draw(Main.teamTexture, new Vector2(12f, Main.screenHeight-32f-30*4*f1), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[1], 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        spriteBatch.Draw(Main.teamTexture, new Vector2(12f, Main.screenHeight-32f-30*3*f2), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[2], 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        spriteBatch.Draw(Main.teamTexture, new Vector2(12f, Main.screenHeight-32f-30*2*f3), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[3], 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        spriteBatch.Draw(Main.teamTexture, new Vector2(12f, Main.screenHeight-32f-30*1*f4), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[4], 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				

    }
}

public void Initialize()
{
    for (int i = 0; i < 4; i++)
			{
	            stationPosX[i]= 0;
	            stationPosY[i]= 0;
	            stationScore[i]= 0;
	            stationExists[i]= false;
			}
    for (int i = 0; i < 3 ; i++)
    {
        DownedPhoenixes[i] = false;
    }
            //TimeFree = 60*10; // 60 = 1 second , multiply by the amount of seconds you want it to be at.
           // PointBlockRange= 160;
          //  RangeToScore = 32;
}

public static void DownPhoenix(int i)
{
    DownedPhoenixes[i] = true;
    if(Main.netMode == 1)
        return;
    bool MakeHallowedz = true;
    for (int zz = 0; zz < 3; zz++)
    {
        if(!DownedPhoenixes[zz]) 
            MakeHallowedz = false;
    }
    if(MakeHallowedz)
    {
        Main.NewText("Your world has been blessed with Hallowed Ore!");
	    int amount=0;
	double num6;
	num6 = Main.rockLayer;
	int i2 = -100+Main.maxTilesX-100;
	int j2 = -(int)num6+Main.maxTilesY-150;
    int sum = i2*j2;
    amount = (int)(sum/10000)*3*6;
	    for(int zz=0;zz<amount;zz++) PhoenixOre(); 
    for (int zz = 0; zz < 3; zz++)
			{
			 
    DownedPhoenixes[zz] = false;
			}
    }
}
public static void PhoenixOre() {
	int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
	double num6;
	num6 = Main.rockLayer;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 150);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 5), Config.tileDefs.ID["Hallowed Ore"]);	
}