public static int catarystDefeated;
public static int jungleEx;
//public static int DungEnt;
public static int armageddon;
public static bool isOblivionSpawned = false;
public static int modIndex=0;
public static bool superHardmode;
private static bool scanned = false;
public static int everIce;
public static int hallowAltarCount;
public static bool droppedStuff = false;
public static bool droppedStuff2 = false;
public static bool WraithInvasion;
public static int WraithInvasionCount;
public static bool Added = false;
public static int WingIndex = 0;
public static int grassSpreading = 0;
public static int grassCounter = 0;
public static int TropicGrassTimer = 0;
public static bool deadUb = false;
public static bool deadUbReal = false;
public static bool[] tookDamageAv = new bool[Main.player.Length];
public static bool needsToLoadRecipes = FakeLoad();
//public struct avalonMsgs
//{
public static string[] misc = { "Your world has been glorified with Hallowed Ore!", "Your world has been desecrated with Corrupted Ore!", "Your world has been frozen with Ever Ice!", "Your world has been melted with Magmatic Ore!", "Your world has been elementalized with Primordial Ore!", "Your world has been infected with Dark Matter!", "Something is hiding on the top of your world...", "The ancient souls have been disturbed!", "Dark and light have been obliterated...", "Dark and light have been eliminated..." };

public static string[] gen = { "Adding Clouds...", "Adding Titanium Ore...", "Adding Coal...", "Adding Jungle Ore...", "Adding Ice Shrines..", "Adding Caesium Ore...", "Generating Hellcastle:", "Placing hallowed altars:", "Generating Heartstone biomes...", "Adding Ice Caves:", "Placing Avalon's statues:" };
//}


#INCLUDE "GuiAccessorySlots.cs"

public const int
	MSG_ITEM = 1,
	MSG_REQUEST = 2,
	MSG_BLESS = 3,
	MSG_ARMA = 4,
	MSG_FREEZE = 5;

public static InterfaceObj slots = new InterfaceObj(new GuiAccessorySlots(),ModGeneric.extraSlots+1,0);
public static int modId;

public static Item[][] accessories;

static ModWorld() {
	int x = Main.screenWidth-139, y = 364;
	for (int i = 0; i < ModGeneric.extraSlots; i++) slots.AddItemSlot(x-i/3*48,y+(i%3)*48);
	slots.AddItemSlot(-100,-100);
	
	accessories = new Item[Main.player.Length][];
	for (int i = 0; i < accessories.Length; i++) {
		accessories[i] = new Item[ModGeneric.extraSlots];
		for (int j = 0; j < accessories[i].Length; j++) accessories[i][j] = new Item();
	}
}
public static void DrawTexture(SpriteBatch sb, Texture2D texture, Vector2 position, int width, int height, float scale, float rotation, int direction, int framecount, Rectangle frame, object overrideColor)
{
	Vector2 origin = new Vector2((float)(texture.Width / 2), (float)(texture.Height / framecount / 2));
	Color lightColor = overrideColor != null ? (Color)overrideColor : Lighting.GetColor((int)(position.X + width * 0.5f) / 16, (int)(position.Y + height * 0.5f) / 16);
	sb.Draw(texture, GetDrawPosition(position, origin, width, height, texture.Width, texture.Height, framecount, scale), !frame.IsEmpty ? frame : new Rectangle(0, 0, texture.Width, texture.Height), lightColor, rotation, origin, scale, direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
}
public static Vector2 GetDrawPosition(Vector2 position, Vector2 origin, int width, int height, int texWidth, int texHeight, int framecount, float scale)
{
	return position - Main.screenPosition + new Vector2(width * 0.5f, height) - new Vector2(texWidth * scale / 2f, texHeight * scale / (float)framecount) + (origin * scale) + new Vector2(0f, 5f);
}
public static void GetJungle()
{
  int
    fX = 0,
    lX = 0;
  bool doneFirst = false;
  for (int x = Main.maxTilesX - Main.dungeonX - 100; x < Main.maxTilesX - Main.dungeonX + 100; x++)
    for (int y = 0; y < Main.maxTilesY; y++)
    {
      Tile T = Main.tile[x, y] != null ? Main.tile[x, y] : new Tile();
      if (T.active && T.type == Config.tileDefs.ID["Jungle Grass"])
      {
        if (!doneFirst)
          fX = x;
        doneFirst = true;
        lX = x;
      }
    }
  jungleEx = (int)((fX + lX) / 2); // i once found out that a code of mine was calculating this as a FLOAT.......
}


public void PlayerConnected(int playerID) {
	for (int i = 0; i < accessories[playerID].Length; i++) accessories[playerID][i] = new Item();
	
	for (int i = 0; i < Main.player.Length; i++) {
		if (playerID == i) continue;
		Player player = Main.player[i];
		if (player == null) continue;
		
		SendItemData(i,accessories[i],playerID,-1);
	}
	
	NetMessage.SendModData(modId,MSG_REQUEST,-1,Main.myPlayer);
}

public bool JungleRunner(int x,int y) { ModWorld.jungleEx = x; return true; }

public void NetReceive(int messageType, BinaryReader br) {
	switch (messageType)
	{
		case MSG_ITEM:
		{
			int playerID = (int)br.ReadByte();
			for (int i = 0; i < ModGeneric.extraSlots; i++) accessories[playerID][i] = ModPlayer.ItemLoad(br);
			if (Main.netMode == 2) SendItemData(playerID,accessories[playerID],-1,playerID);
		}
		break;
		case MSG_REQUEST:
		{
			SendItemData(Main.myPlayer,ExternalGetAccessorySlots(),-1,-1);
		}
		break;
		#region MSG_ARMA
		case MSG_ARMA:
		{
			Armageddon();
			if (Main.netMode == 2)
				NetMessage.SendModData(modId, MSG_ARMA, -1, -1, -1);
		}
		break;
		#endregion
		#region MSG_BLESS
		case MSG_BLESS:
		{
			Bless();
			if (Main.netMode == 2)
				NetMessage.SendModData(modId, MSG_BLESS, -1, -1, -1);
		}
		break;
		#endregion
		#region MSG_FREEZE
		case MSG_FREEZE:
		{
			Freeze();
			if (Main.netMode == 2)
				NetMessage.SendModData(modId, MSG_FREEZE, -1, -1, -1);
		}
		break;
		#endregion
	}
}

public static void SendItemData(int playerID, Item[] items, int remoteClient, int ignoreClient) {
	MemoryStream ms = new MemoryStream();
	BinaryWriter bw = new BinaryWriter(ms);
	
	for (int i = 0; i < items.Length; i++) ModPlayer.ItemSave(bw,items[i]);
	byte[] data = ms.ToArray();
	object[] toSend = new object[data.Length+1];
	toSend[0] = (byte)playerID;
	for (int i = 0; i < data.Length; i++) toSend[i+1] = data[i];
	NetMessage.SendModData(modId,MSG_ITEM,remoteClient,ignoreClient,toSend);
}

public bool PreDrawPlayerEquipment(SpriteBatch spriteBatch) {
	if (!Main.playerInventory || Config.mainInstance.showNPCs) return true;
	Player player = Main.player[Main.myPlayer];
	slots.SetLocation(new Vector2(player.position.X/16,player.position.Y/16));
	
	UpdateSlotsPositions();
	string sEmpty = string.Empty;
	slots.Draw(ref sEmpty);
	
	return true;
}
public void PostDraw(SpriteBatch spriteBatch)
{
	//if (ModPlayer.runonce)
	//{
		foreach (Player P in Main.player)
		{
			ModPlayer.rot++;
			if (ModPlayer.rot >= Math.PI * 2) ModPlayer.rot -= (float)Math.PI * 2f;
			Texture2D tex = Main.goreTexture[Config.goreID["Force Field"]];
			if (!P.dead && (P.armor[0].name == "Avalon Helmet" &&
			    P.armor[1].name == "Avalon Bodyarmor" && P.armor[2].name == "Avalon Cuisses") || P.HasBuff("Force Field") != -1)
			{
				DrawTexture(spriteBatch, tex, P.position, P.width, P.height, 1f, ModPlayer.rot, P.direction, 1, Rectangle.Empty, Color.White);
			}
		}
		//ModPlayer.runonce = false;
	//}
	if (!Main.playerInventory || Config.mainInstance.showNPCs) return;
	Player player = Main.player[Main.myPlayer];
	
	for (int i = 0; i < ModGeneric.extraSlots; i++)
	{
		float scale = .85f;
		Vector2 pos = slots.slotLocation[i];
		if (Main.mouseX >= pos.X && Main.mouseX <= pos.X+Main.inventoryBackTexture.Width*scale && Main.mouseY >= pos.Y && Main.mouseY <= pos.Y+Main.inventoryBackTexture.Height*scale)
		{
			player.mouseInterface = true;
			ItemMouseText(ModWorld.slots.itemSlots[i]);
		}
	}
}
public void ItemMouseText(Item item)
{
	if (item == null || item.type == 0) return;
	string tip = item.name;
	Main.toolTip = (Item)item.Clone();
	
	if (item.stack > 1) tip += " ("+item.stack+")";
	Config.mainInstance.MouseText(tip,item.rare,0);
}

public static void UpdateSlotsPositions() {
	int x = Main.screenWidth-139;
	for (int i = 0; i < ModGeneric.extraSlots; i++) slots.slotLocation[i].X = x-i/3*48;
}

public static Item[] ExternalGetAccessorySlots() {
	Item[] ret = new Item[ModGeneric.extraSlots];
	for (int i = 0; i < ModGeneric.extraSlots; i++) ret[i] = (Item)slots.itemSlots[i].Clone();
	return ret;
}

public static void DeadUB()
{
	ModWorld.deadUb = true;
	// other stuff later, like ore spawning
}
public static void DeadUBReal()
{
	if (!ModWorld.deadUbReal)
	{
		int xm = WorldGen.genRand.Next(200, (int)(Main.maxTilesX - 200));
		int ym = WorldGen.genRand.Next((int)Main.rockLayer, (int)(Main.maxTilesY - 300));
		AddLibraryK(xm, ym);
		if (Main.netMode == 0)
		{
			Main.NewText("The knowledge of the universe is at your fingertips...", 58, 198, 170);
		}
		else if (Main.netMode == 2)
		{
			NetMessage.SendData(25, -1, -1, "The knowledge of the universe is at your fingertips...", 255, 58f, 198f, 170f, 0);
		}
	}
	ModWorld.deadUbReal = true;
}

#region Armageddon() : void [STATIC]
public static void Armageddon()
{
    if (Codable.RunGlobalMethod("ModWorld", "PreArmageddon") && !(bool)Codable.customMethodReturn)
        return;
    if (Main.netMode == 1) return;
	armageddon++;
	if (!ModWorld.superHardmode)
	{
		ModWorld.InitiateSuperHardmode();
		int amount = 0;
		double num5;
		num5 = Main.rockLayer + 100;
		int xloc = -100 + Main.maxTilesX - 100;
		int yloc = -(int)num5 + Main.maxTilesY - 200;
		int sum = xloc * yloc;
		amount = (int)(sum / 10000) * 10;
		if (ModWorld.armageddon <= 2 && Main.netMode != 1)
		{
			for(int zz = 0; zz < amount; zz++)
			{
				int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
				double num6;
				num6 = Main.rockLayer;
				int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 200);
				WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(1, 5), WorldGen.genRand.Next(1, 3), Config.tileDefs.ID["Dark Matter"]);
			}
			if (Main.netMode == 0)
			{
				Main.NewText(ModWorld.misc[5], 62, 0, 97);
			}
			else if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, ModWorld.misc[5], 255, 62f, 0f, 97f, 0);
			}
		}
	}
	int amount2 = 0;
	double num8;
	num8 = Main.rockLayer + 100;
	int xloc2 = -100 + Main.maxTilesX - 100;
	int yloc2 = -(int)num8 + Main.maxTilesY - 200;
	int sum2 = xloc2 * yloc2;
	amount2 = (int)(sum2 / 10000) * 8;
	if (ModWorld.armageddon <= 4 && Main.netMode != 1)
	{
		for(int zz = 0; zz < amount2; zz++)
		{
			int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
			double num7;
			num7 = Main.rockLayer;
			int j2 = WorldGen.genRand.Next((int)num7, Main.maxTilesY - 50);
			WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(5, 7)), WorldGen.genRand.Next(WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(6, 9)), Config.tileDefs.ID["Primordial Ore"]);
		}
		if (Main.netMode == 0)
		{
			Main.NewText(ModWorld.misc[4], 0, 255, 0);
		}
		else if (Main.netMode == 2)
		{
			NetMessage.SendData(25, -1, -1, ModWorld.misc[4], 255, 0f, 255f, 0f, 0);
		}
	}
    if (Main.netMode == 2)
        NetMessage.SendModData(modId, MSG_ARMA, -1, -1, -1);
    Codable.RunGlobalMethod("ModWorld", "PostArmageddon");
}
#endregion
// --------------------------------------------------------------------
#region Bless() : void [STATIC]
public static void Bless()
{
    if (Codable.RunGlobalMethod("ModWorld", "PreBless") && !(bool)Codable.customMethodReturn)
        return;
    if (Main.netMode == 1) return;
	catarystDefeated++;
	int amount = 0;
	double num5;
	num5 = Main.rockLayer;
	int xloc = -100 + Main.maxTilesX - 100;
	int yloc = -(int)num5 + Main.maxTilesY - 200;
	int sum = xloc * yloc;
	amount = (int)(sum / 10000) * 10;
	if (catarystDefeated == 1 || catarystDefeated == 2)
	{
		if (catarystDefeated == 2)
		{
			for(int zz = 0; zz < amount; zz++)
			{
				int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
				double num6;
				num6 = Main.rockLayer;
				int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 200);
				WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(4, 7)), WorldGen.genRand.Next(WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(4, 8)), Config.tileDefs.ID["Corrupted Ore"]);
			}
			if (Main.netMode == 0)
				Main.NewText(ModWorld.misc[1], 80, 65, 130);
			else if (Main.netMode == 2)
				NetMessage.SendData(25, -1, -1, ModWorld.misc[1], 255, 80f, 65f, 130f, 0);
		}
		else if (catarystDefeated == 1)
		{
			for(int zz = 0; zz < amount; zz++)
			{
				int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
				double num6;
				num6 = Main.rockLayer;
				int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 200);
				WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(4, 7)), WorldGen.genRand.Next(WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(4, 8)), Config.tileDefs.ID["Hallowed Ore"]);
			}
			if (Main.netMode == 0)
				Main.NewText(ModWorld.misc[0], 220, 170, 0);
			else if (Main.netMode == 2)
				NetMessage.SendData(25, -1, -1, ModWorld.misc[0], 255, 220f, 170f, 0f, 0);
		}
	}
    if (Main.netMode == 2)
        NetMessage.SendModData(modId, MSG_BLESS, -1, -1, -1);
    Codable.RunGlobalMethod("ModWorld", "PostBless");
}
#endregion

#region Freeze() : void [STATIC]
public static void Freeze()
{
    if (Codable.RunGlobalMethod("ModWorld", "PreFreeze") && !(bool)Codable.customMethodReturn)
        return;
    if (Main.netMode == 1) return;
    everIce++;
	int amount = 0;
	double num5;
	num5 = Main.rockLayer;
	int xloc = -100 + Main.maxTilesX - 100;
	int yloc = -(int)num5 + Main.maxTilesY - 200;
	int sum = xloc * yloc;
	amount = (int)(sum / 10000) * 10;
	if (everIce == 1)
    {
		for (int zz = 0; zz < amount; zz++)
        {
			int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
			double num6;
			num6 = Main.rockLayer;
			int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 200);
			WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(1, 4), WorldGen.genRand.Next(1, 4), Config.tileDefs.ID["Ever Ice"]);
		}
		if (Main.netMode == 0)
			Main.NewText("Your world has been frozen with Ever Ice!", 0, 201, 190);
		else if (Main.netMode == 2)
			NetMessage.SendData(25, -1, -1, "Your world has been frozen with Ever Ice!", 255, 0f, 201f, 190f, 0);
	}
    if (Main.netMode != 0)
        NetMessage.SendModData(modId, MSG_FREEZE, -1, -1, -1);
    Codable.RunGlobalMethod("ModWorld", "PostFreeze");
}
#endregion

public void UpdateWorld()
{
	droppedStuff = false;
	droppedStuff2 = false;
	for (int thing = 0; thing < 50; thing++)
	{
		if (Main.npc[thing].type == 94 && Main.npc[thing].active)
		{
			for (int thing2 = 0; thing2 < 50; thing2++)
			{
				if (Main.npc[thing2].type == Config.npcDefs.byName["Hallowor"].type && Main.npc[thing2].active)
				{
					if (NPCCollision(Main.npc[thing], Main.npc[thing2]))
					{
						if (!droppedStuff)
						{
							Make3x3Circle((int)(Main.npc[thing].position.X / 16f), (int)(Main.npc[thing].position.Y / 16f), (ushort)Config.tileDefs.ID["Oblivion Ore"]);
							Main.npc[thing].life = 0;
							Main.npc[thing].NPCLoot();
							Main.npc[thing].active = false;
							Main.PlaySound(4, (int)Main.npc[thing].position.X, (int)Main.npc[thing].position.Y, Main.npc[thing].soundKilled);
							Main.npc[thing2].life = 0;
							Main.npc[thing2].NPCLoot();
							Main.npc[thing2].active = false;
							Main.PlaySound(4, (int)Main.npc[thing2].position.X, (int)Main.npc[thing2].position.Y, Main.npc[thing2].soundKilled);
							if (Main.netMode == 0)
							{
								Main.NewText(ModWorld.misc[8], 135, 78, 0);
							}
							else if (Main.netMode == 2)
							{
								NetMessage.SendData(25, -1, -1, ModWorld.misc[8], 255, 135f, 78f, 0f, 0);
							}
							droppedStuff = true;
						}
							//goto stuff;
					}
				}
			}
		}
	}
	for (int thing3 = 0; thing3 < 50; thing3++)
	{
		if (Main.npc[thing3].type == Config.npcDefs.byName["Guardian Corruptor"].type && Main.npc[thing3].active)
		{
			for (int thing4 = 0; thing4 < 50; thing4++)
			{
				if (Main.npc[thing4].type == Config.npcDefs.byName["Aegis Hallowor"].type && Main.npc[thing4].active)
				{
					if (NPCCollision(Main.npc[thing3], Main.npc[thing4]))
					{
						if (!droppedStuff2)
						{
							MakeCircle((int)(Main.npc[thing3].position.X / 16f), (int)(Main.npc[thing3].position.Y / 16f), 3f, (ushort)Config.tileDefs.ID["Oblivion Ore"]);
							Main.npc[thing3].life = 0;
							Main.npc[thing3].NPCLoot();
							Main.npc[thing3].active = false;
							Main.PlaySound(4, (int)Main.npc[thing3].position.X, (int)Main.npc[thing3].position.Y, Main.npc[thing3].soundKilled);
							Main.npc[thing4].life = 0;
							Main.npc[thing4].NPCLoot();
							Main.npc[thing4].active = false;
							Main.PlaySound(4, (int)Main.npc[thing4].position.X, (int)Main.npc[thing4].position.Y, Main.npc[thing4].soundKilled);
							if (Main.netMode == 0)
							{
								Main.NewText(ModWorld.misc[9], 135, 78, 0);
							}
							else if (Main.netMode == 2)
							{
								NetMessage.SendData(25, -1, -1, ModWorld.misc[9], 255, 135f, 78f, 0f, 0);
							}
							droppedStuff2 = true;
						}
					}
				}
			}
		}
	}

    int num3 = 0;
    float num = 3E-05f * (float)Main.worldRate;
    while ((float)num3 < (float)(Main.maxTilesX * Main.maxTilesY) * num)
    {
	num3++;
        int num4 = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
        int num5 = WorldGen.genRand.Next(10, (int)Main.worldSurface - 1);
        int num6 = num4 - 1;
        int num7 = num4 + 2;
        int num8 = num5 - 1;
        int num9 = num5 + 2;
        if (num6 < 10)
        {
            num6 = 10;
        }
        if (num7 > Main.maxTilesX - 10)
        {
            num7 = Main.maxTilesX - 10;
        }
        if (num8 < 10)
        {
            num8 = 10;
        }
        if (num9 > Main.maxTilesY - 10)
        {
            num9 = Main.maxTilesY - 10;
        }
        if (Main.tile[num4, num5] != null && Main.tile[num4, num5].active)
        {
            if (Main.tile[num4, num5].type == Config.tileDefs.ID["Tropical Grass"])
            {
                bool flag2 = false;
                for (int j = num6; j < num7; j++)
                {
                    for (int k = num8; k < num9; k++)
                    {
                        if ((num4 != j || num5 != k) && Main.tile[j, k].active)
                        {
                            if (Main.tile[j, k].type == Config.tileDefs.ID["Tropical Mud"])
                            {
                                WorldGen.SpreadGrass(j, k, Config.tileDefs.ID["Tropical Mud"], Config.tileDefs.ID["Tropical Grass"], false);
                                if ((int)Main.tile[j, k].type == Config.tileDefs.ID["Tropical Grass"])
                                {
                                    WorldGen.SquareTileFrame(j, k, true);
                                    flag2 = true;
                                }
                            }
                        }
                    }
                }
                if (Main.netMode == 2 && flag2)
                {
                    NetMessage.SendTileSquare(-1, num4, num5, 3);
                }
            }
        }
    }

	//ModWorld.TropicGrassTimer++;
	//if (ModWorld.TropicGrassTimer == 1801)
	//{
	//	ModWorld.TropicGrassTimer = 0;
	//}
	if (ModWorld.WraithInvasion)
	{
		ModWorld.WraithInvasionCount++;
		if (ModWorld.WraithInvasionCount >= 14000)
		{
			ModWorld.EndWraithInvasion();
		}
	}
	if (!Main.dayTime && Main.player[Main.myPlayer].HasBuff("Starbright") != -1)
	{
		float num66 = (float)(Main.maxTilesX / 4200);
		if ((float)Main.rand.Next(4000) < 10f * num66)
		{
			int num67 = 12;
			int num68 = Main.rand.Next(Main.maxTilesX - 50) + 100;
			num68 *= 16;
			int num69 = Main.rand.Next((int)((double)Main.maxTilesY * 0.05));
			num69 *= 16;
			Vector2 vector = new Vector2((float)num68, (float)num69);
			float num70 = (float)Main.rand.Next(-100, 101);
			float num71 = (float)(Main.rand.Next(200) + 100);
			float num72 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
			num72 = (float)num67 / num72;
			num70 *= num72;
			num71 *= num72;
			Projectile.NewProjectile(vector.X, vector.Y, num70, num71, 12, 1000, 10f, Main.myPlayer);
		}
	}
	if (!Main.dayTime && Main.bloodMoon)
	{
		float num66 = (float)(Main.maxTilesX / 4200);
		if ((float)Main.rand.Next(9000) < 10f * num66)
		{
			int num67 = 12;
			int num68 = Main.rand.Next(Main.maxTilesX - 50) + 100;
			num68 *= 16;
			int num69 = Main.rand.Next((int)((double)Main.maxTilesY * 0.05));
			num69 *= 16;
			Vector2 vector = new Vector2((float)num68, (float)num69);
			float num70 = (float)Main.rand.Next(-100, 101);
			float num71 = (float)(Main.rand.Next(200) + 100);
			float num72 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
			num72 = (float)num67 / num72;
			num70 *= num72;
			num71 *= num72;
			Projectile.NewProjectile(vector.X, vector.Y, num70, num71, 12, 1000, 10f, Main.myPlayer);
		}
	}
}

public static void SpawnNPCOnPlayerWithoutMessage(int plr, int Type)
{
	if (Main.netMode == 1)
	{
		return;
	}
	bool flag = false;
	int num = 0;
	int num2 = 0;
	int num3 = (int)(Main.player[plr].position.X / 16f) - NPC.spawnRangeX * 2;
	int num4 = (int)(Main.player[plr].position.X / 16f) + NPC.spawnRangeX * 2;
	int num5 = (int)(Main.player[plr].position.Y / 16f) - NPC.spawnRangeY * 2;
	int num6 = (int)(Main.player[plr].position.Y / 16f) + NPC.spawnRangeY * 2;
	int num7 = (int)(Main.player[plr].position.X / 16f) - NPC.safeRangeX;
	int num8 = (int)(Main.player[plr].position.X / 16f) + NPC.safeRangeX;
	int num9 = (int)(Main.player[plr].position.Y / 16f) - NPC.safeRangeY;
	int num10 = (int)(Main.player[plr].position.Y / 16f) + NPC.safeRangeY;
	if (num3 < 0)
	{
		num3 = 0;
	}
	if (num4 > Main.maxTilesX)
	{
		num4 = Main.maxTilesX;
	}
	if (num5 < 0)
	{
		num5 = 0;
	}
	if (num6 > Main.maxTilesY)
	{
		num6 = Main.maxTilesY;
	}
	for (int i = 0; i < 1000; i++)
	{
		int j = 0;
		while (j < 100)
		{
			int num11 = Main.rand.Next(num3, num4);
			int num12 = Main.rand.Next(num5, num6);
			if (Main.tile[num11, num12].active && Main.tileSolid[(int)Main.tile[num11, num12].type])
			{
				goto IL_304;
			}
			if (!Main.wallHouse[(int)Main.tile[num11, num12].wall] || i >= 999)
			{
				int k = num12;
				while (k < Main.maxTilesY)
				{
					if (Main.tile[num11, k].active && Main.tileSolid[(int)Main.tile[num11, k].type])
					{
						if (num11 < num7 || num11 > num8 || k < num9 || k > num10 || i == 999)
						{
							ushort arg_237_0 = Main.tile[num11, k].type;
							num = num11;
							num2 = k;
							flag = true;
							break;
						}
						break;
					}
					else
					{
						k++;
					}
				}
				if (!flag || i >= 999)
				{
					goto IL_304;
				}
				int num13 = num - 3 / 2;
				int num14 = num + 3 / 2;
				int num15 = num2 - 3;
				int num16 = num2;
				if (num13 < 0)
				{
					flag = false;
				}
				if (num14 > Main.maxTilesX)
				{
					flag = false;
				}
				if (num15 < 0)
				{
					flag = false;
				}
				if (num16 > Main.maxTilesY)
				{
					flag = false;
				}
				if (flag)
				{
					for (int l = num13; l < num14; l++)
					{
						for (int m = num15; m < num16; m++)
						{
							if (Main.tile[l, m].active && Main.tileSolid[(int)Main.tile[l, m].type])
							{
								flag = false;
								break;
							}
						}
					}
					goto IL_304;
				}
				goto IL_304;
			}
			IL_30A:
			j++;
			continue;
			IL_304:
			if (!flag && !flag)
			{
				goto IL_30A;
			}
			break;
		}
		if (flag && i < 999)
		{
			Rectangle rectangle = new Rectangle(num * 16, num2 * 16, 16, 16);
			for (int n = 0; n < 255; n++)
			{
				if (Main.player[n].active)
				{
					Rectangle rectangle2 = new Rectangle((int)(Main.player[n].position.X + (float)(Main.player[n].width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(Main.player[n].position.Y + (float)(Main.player[n].height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
					if (rectangle.Intersects(rectangle2))
					{
						flag = false;
					}
				}
			}
		}
		if (flag)
		{
			break;
		}
	}
	if (flag)
	{
		int num17 = NPC.NewNPC(num * 16 + 8, num2 * 16, Type, 1);
		if (num17 == 200)
		{
			return;
		}
		Main.npc[num17].target = plr;
		Main.npc[num17].timeLeft *= 20;
		//string str = Main.npc[num17].name;
		//if (Main.npc[num17].displayName != "")
		//{
		//	str = Main.npc[num17].displayName;
		//}
		if (Main.netMode == 2 && num17 < 200)
		{
			NetMessage.SendData(23, -1, -1, "", num17, 0f, 0f, 0f, 0);
		}
	}
}

public static bool NPCCollision(NPC n1,NPC n2)
{
	Rectangle rect1 = new Rectangle((int)n1.position.X, (int)n1.position.Y,n1.width,n1.height);
	Rectangle rect2 = new Rectangle((int)n2.position.X, (int)n2.position.Y,n2.width,n2.height);
	if (rect1.Intersects(rect2))
	{
		return true;
	}
	else return false;
}

public static bool FakeLoad()
{
	Recipe R;

	R = new Recipe();
	R.createItem.SetDefaults(74, false); //, false);
	R.createItem.stack = 100; // with stack size going here of course
	R.requiredItem[0].SetDefaults(Config.itemDefs.byName["Demonite Coin"].type, false);
	R.requiredItem[0].stack = 1;
	Config.recipeByName.Add("Platinum Coin 3", R);


	R = new Recipe();
	R.createItem.SetDefaults(Config.itemDefs.byName["Demonite Coin"].type, false);
	R.createItem.stack = 100; // with stack size going here of course
	R.requiredItem[0].SetDefaults(Config.itemDefs.byName["Hellstone Coin"].type, false);
	R.requiredItem[0].stack = 1;
	Config.recipeByName.Add("Demonite Coin 2", R);


	R = new Recipe();
	R.createItem.SetDefaults("Mega Spelunker Potion");
	R.createItem.stack = 1;
	R.requiredItem[0].SetDefaults("Spelunker Potion");
	R.requiredItem[0].stack = 1;
	R.requiredItem[1].SetDefaults("Gold Ore");
	R.requiredItem[1].stack = 1;
	R.requiredItem[2].SetDefaults("Daybloom");
	R.requiredItem[2].stack = 1;
	R.requiredTile[0] = 13;
	Config.recipeByName.Add("Mega Spelunk Pot 2", R);

	R = new Recipe();
	R.createItem.SetDefaults("Gold Chest");
	R.createItem.stack = 1;
	R.requiredItem[0].SetDefaults("Gold Bar");
	R.requiredItem[0].stack = 5;
	R.requiredItem[1].SetDefaults("Wood");
	R.requiredItem[1].stack = 20;
	R.requiredItem[2].SetDefaults("Iron Bar");
	R.requiredItem[2].stack = 2;
	R.requiredTile[0] = 16;
	Config.recipeByName.Add("Gold Chest 2", R);

	R = new Recipe();
	R.createItem.SetDefaults("Torch");
	R.createItem.stack = 4;
	R.requiredItem[0].SetDefaults("Coal");
	R.requiredItem[0].stack = 1;
	R.requiredItem[1].SetDefaults("Wood");
	R.requiredItem[1].stack = 1;
	Config.recipeByName.Add("Torch 2", R);

	R = new Recipe();
	R.createItem.SetDefaults("Overlord Emblem");
	R.createItem.stack = 1;
	R.requiredItem[0].SetDefaults("Damage Emblem");
	R.requiredItem[0].stack = 3;
	R.requiredItem[1].SetDefaults("Soul of Might");
	R.requiredItem[1].stack = 100;
	R.requiredItem[2].SetDefaults("Soul of Fright");
	R.requiredItem[2].stack = 100;
	R.requiredItem[3].SetDefaults("Soul of Sight");
	R.requiredItem[3].stack = 100;
	R.requiredTile[0] = 114;
	Config.recipeByName.Add("Overlord Emblem 2", R);

	R = new Recipe();
	R.createItem.SetDefaults("Dark Matter Bullet");
	R.createItem.stack = 2000;
	R.requiredItem[0].SetDefaults("Bullet Emblem");
	R.requiredItem[0].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Adamantite Anvil"];
	Config.recipeByName.Add("Dark Matter Bullet 2000", R);

	R = new Recipe();
	R.createItem.SetDefaults("Frozen Bullet");
	R.createItem.stack = 2000;
	R.requiredItem[0].SetDefaults("Bullet Emblem");
	R.requiredItem[0].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Adamantite Anvil"];
	Config.recipeByName.Add("Frozen Bullet 2000", R);

	R = new Recipe();
	R.createItem.SetDefaults(97, false);
	R.createItem.stack = 2000;
	R.requiredItem[0].SetDefaults("Bullet Emblem");
	R.requiredItem[0].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Adamantite Anvil"];
	Config.recipeByName.Add("Musket Ball 2000", R);

	R = new Recipe();
	R.createItem.SetDefaults(234, false);
	R.createItem.stack = 2000;
	R.requiredItem[0].SetDefaults("Bullet Emblem");
	R.requiredItem[0].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Adamantite Anvil"];
	Config.recipeByName.Add("Meteor Shot 2000", R);

	R = new Recipe();
	R.createItem.SetDefaults(278, false);
	R.createItem.stack = 2000;
	R.requiredItem[0].SetDefaults("Bullet Emblem");
	R.requiredItem[0].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Adamantite Anvil"];
	Config.recipeByName.Add("Silver Bullet 2000", R);

	R = new Recipe();
	R.createItem.SetDefaults(515, false);
	R.createItem.stack = 2000;
	R.requiredItem[0].SetDefaults("Bullet Emblem");
	R.requiredItem[0].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Adamantite Anvil"];
	Config.recipeByName.Add("Crystal Bullet 2000", R);

	R = new Recipe();
	R.createItem.SetDefaults(546, false);
	R.createItem.stack = 2000;
	R.requiredItem[0].SetDefaults("Bullet Emblem");
	R.requiredItem[0].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Adamantite Anvil"];
	Config.recipeByName.Add("Cursed Bullet 2000", R);

	R = new Recipe();
	R.createItem.SetDefaults("Berserker Bullet");
	R.createItem.stack = 2000;
	R.requiredItem[0].SetDefaults("Bullet Emblem");
	R.requiredItem[0].stack = 1;
	R.requiredTile[0] = Config.tileDefs.ID["Adamantite Anvil"];
	Config.recipeByName.Add("Berserker Bullet 2000", R);

	#region what tConfig uses to load recipes from mods , copy paste it to yours


	Recipe.maxRecipes = Config.recipeByName.Values.Count+2;

	Main.recipe = new Recipe[Recipe.maxRecipes];

	Main.availableRecipe = new int[Recipe.maxRecipes];
	Main.availableRecipeY = new float[Recipe.maxRecipes];

	Recipe.numRecipes = 0;
	for (int num11 = 0; num11 < Recipe.maxRecipes; num11++)

	{

		Main.recipe[num11] = new Recipe();
		Main.availableRecipeY[num11] = (float)(65 * num11);
	}

	foreach (Recipe r in Config.recipeByName.Values)
	{
		if (r.createItem.type == 0) continue;
		Recipe.newRecipe = r;
		Recipe.addRecipe();
	}


	#endregion
	return false;
}
public void Initialize(int modId) 
{
	Texture2D mytex = Main.goreTexture[Config.goreID["Golden Wings"]];
	foreach(Texture2D T in Main.wingsTexture)
	{
		if(mytex == T)
		{
			Added = true;
			break;
		}
	}
	if(!Added)
	{
		Added = true;
		Texture2D[] wingsTextureNew = new Texture2D[Main.wingsTexture.Length+1];
		for (int i = 0; i < Main.wingsTexture.Length; i++)
		{
			wingsTextureNew[i]=Main.wingsTexture[i];
		}
		wingsTextureNew[Main.wingsTexture.Length] = mytex;
		Main.wingsTexture = wingsTextureNew;
		WingIndex = Main.wingsTexture.Length-1;
	}
	ModWorld.modId = modId;
	modIndex = Config.mods.IndexOf("Avalon");
	catarystDefeated = 0;
	armageddon = 0;
	superHardmode = false;
	everIce = 0;
	hallowAltarCount = 0;
	WraithInvasion = false;
	WraithInvasionCount = 0;
	deadUb = false;
	deadUbReal = false;
	//if (!scanned)
	//	GetJungle();
	scanned = true;

} 
public void Save(BinaryWriter W)
{
	W.Write(catarystDefeated);
	W.Write(armageddon);
	W.Write(superHardmode);
	W.Write(everIce);
	W.Write(hallowAltarCount);
	W.Write(WraithInvasion);
	W.Write(WraithInvasionCount);
	W.Write(deadUb);
	W.Write(jungleEx);
	W.Write(scanned);
	W.Write(deadUbReal);
}
public void Load(BinaryReader R , int V)
{
	catarystDefeated = R.ReadInt32();
	armageddon = R.ReadInt32();
	superHardmode = R.ReadBoolean();
	everIce = R.ReadInt32();
	hallowAltarCount = R.ReadInt32();
	WraithInvasion = R.ReadBoolean();
	WraithInvasionCount = R.ReadInt32();
	deadUb = R.ReadBoolean();
	jungleEx = R.ReadInt32();
	scanned = R.ReadBoolean();
	deadUbReal = R.ReadBoolean();
	//GetJungle();
}


public static void SwapXtoYinBoxRecursive(int xStart, int yStart, int xRad, int yRad, ushort target, int cuberadius)
{
	for (int x = xStart - xRad; x < xStart + xRad + 1; x++)
	{
		for (int y = yStart - yRad; y < yStart + yRad + 1; y++)
		{
			if(Main.tile[x, y].active && Main.tile[x, y].type != target)
			{
				Main.tile[x, y].type = target;
				WorldGen.SquareTileFrame(x, y);
				SwapXtoYinBoxRecursive(x, y, xStart + cuberadius, yStart + cuberadius, target, 0);
			}
		}
	}
}

public static void dropComet()
{
	bool flag = true;
	int num = 0;
	ushort ice = (ushort)Config.tileDefs.ID["Ever Ice"];
	if (Main.netMode == 1)
	{
		return;
	}
	for (int i = 0; i < 255; i++)
	{
		if (Main.player[i].active)
		{
			flag = false;
			break;
		}
	}
	int num2 = 0;
	float num3 = (float)(Main.maxTilesX / 4200);
	int num4 = (int)(400f * num3);
	for (int j = 5; j < Main.maxTilesX - 5; j++)
	{
		int num5 = 5;
		while ((double)num5 < Main.worldSurface)
		{
			if (Main.tile[j, num5].active && Main.tile[j, num5].type == ice)
			{
				num2++;
				if (num2 > num4)
				{
					return;
				}
			}
			num5++;
		}
	}
	while (!flag)
	{
		float num6 = (float)Main.maxTilesX * 0.08f;
		int num7 = Main.rand.Next(50, Main.maxTilesX - 50);
		while ((float)num7 > (float)Main.spawnTileX - num6 && (float)num7 < (float)Main.spawnTileX + num6)
		{
			num7 = Main.rand.Next(50, Main.maxTilesX - 50);
		}
		for (int k = Main.rand.Next(100); k < Main.maxTilesY; k++)
		{
			if (Main.tile[num7, k].active && Main.tileSolid[(int)Main.tile[num7, k].type])
			{
				flag = comet(num7, k);
				break;
			}
		}
		num++;
		if (num >= 100)
		{
			return;
		}
	}
}

public static bool comet(int x, int y)
{
	ushort ice = (ushort)Config.tileDefs.ID["Ever Ice"];
	for (int xoff = x - 10; xoff <= x + 10; xoff++)
	{
		for (int yoff = y - 10; yoff <= y + 10; yoff++)
		{
			if ((xoff >= x - 5 && xoff <= x + 5) && (yoff >= y - 5 && yoff <= y + 5))
			{
				Main.tile[xoff, yoff].active = true;
				Main.tile[xoff, yoff].type = ice;
				WorldGen.SquareTileFrame(xoff, yoff);
			}
			if ((xoff >= x - 3 && xoff <= x + 3) && (yoff == y + 6 || yoff == y - 6))
			{
				Main.tile[xoff, yoff].active = true;
				Main.tile[xoff, yoff].type = ice;
				WorldGen.SquareTileFrame(xoff, yoff);
			}
			if ((xoff == x - 6 || xoff == x + 6) && (yoff >= y - 3 && yoff <= y + 3))
			{
				Main.tile[xoff, yoff].active = true;
				Main.tile[xoff, yoff].type = ice;
				WorldGen.SquareTileFrame(xoff, yoff);
			}
			if (((xoff == x - 7 || xoff == x + 7) && (yoff >= y - 1 && yoff <= y + 1)) || ((xoff >= x - 1 && xoff <= x + 1) && (yoff == y - 7 || yoff == y + 7)))
			{
				Main.tile[xoff, yoff].active = true;
				Main.tile[xoff, yoff].type = ice;
				WorldGen.SquareTileFrame(xoff, yoff);
			}
			if (WorldGen.genRand.Next(25) == 0)
			{
				if (yoff == y)
				{
					int randTileOn = WorldGen.genRand.Next(2, 4);
					int randTileOn2 = WorldGen.genRand.Next(2, 4);
					//SwapXtoYinBoxRecursive(x + 8, yoff + randTileOn, 10, 10, ice, 5);
					//SwapXtoYinBoxRecursive(x - 8, yoff - randTileOn2, 10, 10, ice, 5);
					Main.tile[x + 8, yoff + randTileOn].active = true;
					Main.tile[x + 8, yoff + randTileOn].type = ice;
					WorldGen.SquareTileFrame(x + 8, yoff + randTileOn);
					Main.tile[x - 8, yoff + randTileOn2].active = true;
					Main.tile[x - 8, yoff + randTileOn2].type = ice;
					WorldGen.SquareTileFrame(x - 8, yoff + randTileOn2);
				}
				if (yoff == y + 1)
				{
					int randTileOn = WorldGen.genRand.Next(2, 4);
					int randTileOn2 = WorldGen.genRand.Next(2, 4);
					//SwapXtoYinBoxRecursive(x + 7, yoff + randTileOn, 10, 10, ice, 5);
					//SwapXtoYinBoxRecursive(x - 7, yoff - randTileOn2, 10, 10, ice, 5);
					Main.tile[x + 7, yoff + randTileOn].active = true;
					Main.tile[x + 7, yoff + randTileOn].type = ice;
					WorldGen.SquareTileFrame(x + 7, yoff + randTileOn);
					Main.tile[x - 7, yoff + randTileOn2].active = true;
					Main.tile[x - 7, yoff + randTileOn2].type = ice;
					WorldGen.SquareTileFrame(x - 7, yoff + randTileOn2);
				}
				if (yoff == y + 3)
				{
					int randTileOn = WorldGen.genRand.Next(2, 4);
					int randTileOn2 = WorldGen.genRand.Next(2, 4);
					//SwapXtoYinBoxRecursive(x + 6, yoff + randTileOn, 10, 10, ice, 5);
					//SwapXtoYinBoxRecursive(x - 6, yoff - randTileOn2, 10, 10, ice, 5);
					Main.tile[x + 6, yoff + randTileOn].active = true;
					Main.tile[x + 6, yoff + randTileOn].type = ice;
					WorldGen.SquareTileFrame(x + 6, yoff + randTileOn);
					Main.tile[x - 6, yoff + randTileOn2].active = true;
					Main.tile[x - 6, yoff + randTileOn2].type = ice;
					WorldGen.SquareTileFrame(x - 6, yoff + randTileOn2);
				}
				if (yoff == y + 5)
				{
					int randTileOn = WorldGen.genRand.Next(2, 4);
					int randTileOn2 = WorldGen.genRand.Next(2, 4);
					//SwapXtoYinBoxRecursive(x + 4, yoff + randTileOn, 10, 10, ice, 5);
					//SwapXtoYinBoxRecursive(x - 4, yoff - randTileOn2, 10, 10, ice, 5);
					Main.tile[x + 4, yoff + randTileOn].active = true;
					Main.tile[x + 4, yoff + randTileOn].type = ice;
					WorldGen.SquareTileFrame(x + 4, yoff + randTileOn);
					Main.tile[x - 4, yoff + randTileOn2].active = true;
					Main.tile[x - 4, yoff + randTileOn2].type = ice;
					WorldGen.SquareTileFrame(x - 4, yoff + randTileOn2);
				}
				if (yoff == y + 6)
				{
					int randTileOn = WorldGen.genRand.Next(2, 4);
					int randTileOn2 = WorldGen.genRand.Next(2, 4);
					//SwapXtoYinBoxRecursive(x + 2, yoff + randTileOn, 10, 10, ice, 5);
					//SwapXtoYinBoxRecursive(x - 2, yoff - randTileOn2, 10, 10, ice, 5);
					Main.tile[x + 2, yoff + randTileOn].active = true;
					Main.tile[x + 2, yoff + randTileOn].type = ice;
					WorldGen.SquareTileFrame(x + 2, yoff + randTileOn);
					Main.tile[x - 2, yoff + randTileOn2].active = true;
					Main.tile[x - 2, yoff + randTileOn2].type = ice;
					WorldGen.SquareTileFrame(x - 2, yoff + randTileOn2);
				}
				if (yoff == y + 7)
				{
					int randTileOn = WorldGen.genRand.Next(2, 4);
					Main.tile[x, yoff + randTileOn].active = true;
					Main.tile[x, yoff + randTileOn].type = ice;
					WorldGen.SquareTileFrame(x, yoff + randTileOn);
				}
			}
		}
	}
	if (Main.netMode == 0)
	{
		Main.NewText("A comet has struck ground!", 0, 201, 190);
	}
	else if (Main.netMode == 2)
	{
		NetMessage.SendData(25, -1, -1, "A comet has struck ground!", 255, 0f, 201f, 190f, 0);
	}
	return true;
}
/*public static void InitiateSuperHardmode()
{
	if (Main.netMode == 1)
	{
		return;
	}
	try
	{
		System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(InitiateSuperHardmodeCallBack), 1);
	}
	catch (Exception E)
	{
		Main.NewText("exc. caught!: " + E.GetType().ToString());
	}
	//System.Threading.Thread.Sleep(1000);
}*/
public static void InitiateSuperHardmode() //object threadContext)
{
	if (!ModWorld.superHardmode)
	{
		//WorldGen.hardLock = true;
		if (Main.netMode == 0)
		{
			Main.NewText(ModWorld.misc[7], 255, 60, 0);
			Main.NewText(ModWorld.misc[6], 244, 140, 140);
		}
		else if (Main.netMode == 2)
		{
			NetMessage.SendData(25, -1, -1, ModWorld.misc[7], 255, 255f, 60f, 0f, 0);
			NetMessage.SendData(25, -1, -1, ModWorld.misc[6], 255, 244f, 140f, 140f, 0);
		}
		ModWorld.superHardmode = true;
		generateSkyFortress();
		TropicsRunner();
		/*int amount = 0;
		double num5;
		num5 = Main.rockLayer + 100;
		int xloc = -100 + Main.maxTilesX - 100;
		int yloc = -(int)num5 + Main.maxTilesY - 200;
		int sum = xloc * yloc;
		amount = (int)(sum / 10000) * 10;
		if (ModWorld.armageddon <= 2 && Main.netMode != 1)
		{
			for(int zz = 0; zz < amount; zz++)
			{
				int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
				double num6;
				num6 = Main.rockLayer;
				int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 200);
				WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(1, 5), WorldGen.genRand.Next(1, 3), Config.tileDefs.ID["Dark Matter"]);
			}
			if (Main.netMode == 0)
			{
				Main.NewText("Your world has been infected with Dark Matter!", 62, 0, 97);
			}
			else if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, "Your world has been infected with Dark Matter!", 255, 62f, 0f, 97f, 0);
			}
		}*/
		//WorldGen.hardLock = false;
	}
	else ModWorld.superHardmode = true;
}

public static void generateSkyFortress()
{
	ushort hallowStone = (ushort)Config.tileDefs.ID["Hallowstone Block"];
	ushort reinGlass = (ushort)Config.tileDefs.ID["Reinforced Glass"];
	ushort resWood = (ushort)Config.tileDefs.ID["Resistant Wood"];
	int xoff = WorldGen.genRand.Next(150, (int)(Main.maxTilesX / 3));
	//if (WorldGen.genRand.Next(2) == 0)
	//{
	//	xoff = Main.maxTilesX - xoff;
	//}
	int yoff = (int)(Main.topWorld + 100f);

	for (int x = xoff - 37; x <= xoff + 37; x++)
	{
		for (int y = yoff - 53; y <= yoff; y++)
		{
			Main.tile[x, y].active = true;
			if ((x >= xoff - 32 && x <= xoff + 32) && (y >= yoff - 49 && y <= yoff - 4))
			{
				Main.tile[x, y].active = false;
				Main.tile[x, y].wall = (byte)Config.wallDefs.ID["Hallowstone Wall"];
			}
			Main.tile[x, y].liquid = 0;
			Main.tile[x, y].lava = false;
			Main.tile[x, y].wall = 0;
			Main.tile[x, y].type = reinGlass;
			WorldGen.SquareTileFrame(x, y);
    		}
	}	

	for (int tower1x = xoff - 50; tower1x <= xoff - 37; tower1x++)
	{
		for (int tower1y = yoff - 60; tower1y <= yoff; tower1y++)
		{
			if ((tower1x == xoff - 50 && tower1y == yoff - 60) || (tower1x == xoff - 49 && tower1y == yoff - 60) || (tower1x == xoff - 50 && tower1y == yoff - 59) || (tower1x == xoff - 49 && tower1y == yoff - 59) || (tower1x == xoff - 46 && tower1y == yoff - 60) || (tower1x == xoff - 46 && tower1y == yoff - 59) || (tower1x == xoff - 45 && tower1y == yoff - 60) || (tower1x == xoff - 45 && tower1y == yoff - 59) || (tower1x == xoff - 42 && tower1y == yoff - 60) || (tower1x == xoff - 42 && tower1y == yoff - 59) || (tower1x == xoff - 41 && tower1y == yoff - 60) || (tower1x == xoff - 41 && tower1y == yoff - 59) || (tower1x == xoff - 38 && tower1y == yoff - 60) || (tower1x == xoff - 37 && tower1y == yoff - 60) || (tower1x == xoff - 38 && tower1y == yoff - 59) || (tower1x == xoff - 37 && tower1y == yoff - 59) || ((tower1x >= xoff - 49 && tower1x <= xoff - 38) && (tower1y == yoff - 58 || tower1y == yoff - 57)) || ((tower1x >= xoff - 49 && tower1x <= xoff - 47) && (tower1y >= yoff - 56 || tower1y <= yoff)) || ((tower1x >= xoff - 40 && tower1x <= xoff - 38) && (tower1y >= yoff - 56 || tower1y <= yoff)) || ((tower1x >= xoff - 46 && tower1x <= xoff - 41) && (tower1y <= yoff && tower1y >= yoff - 2)))
			{
				Main.tile[tower1x, tower1y].active = true;
				Main.tile[tower1x, tower1y].type = reinGlass;
				WorldGen.SquareTileFrame(tower1x, tower1y);
			}
		}
	}
	for (int tower2x = xoff + 37; tower2x <= xoff + 50; tower2x++)
	{
		for (int tower2y = yoff - 60; tower2y <= yoff; tower2y++)
		{
			if ((tower2x == xoff + 50 && tower2y == yoff - 60) || (tower2x == xoff + 49 && tower2y == yoff - 60) || (tower2x == xoff + 50 && tower2y == yoff - 59) || (tower2x == xoff + 49 && tower2y == yoff - 59) || (tower2x == xoff + 46 && tower2y == yoff - 60) || (tower2x == xoff + 46 && tower2y == yoff - 59) || (tower2x == xoff + 45 && tower2y == yoff - 60) || (tower2x == xoff + 45 && tower2y == yoff - 59) || (tower2x == xoff + 42 && tower2y == yoff - 60) || (tower2x == xoff + 42 && tower2y == yoff - 59) || (tower2x == xoff + 41 && tower2y == yoff - 60) || (tower2x == xoff + 41 && tower2y == yoff - 59) || (tower2x == xoff + 38 && tower2y == yoff - 60) || (tower2x == xoff + 37 && tower2y == yoff - 60) || (tower2x == xoff + 38 && tower2y == yoff - 59) || (tower2x == xoff + 37 && tower2y == yoff - 59) || ((tower2x <= xoff + 49 && tower2x >= xoff + 38) && (tower2y == yoff - 58 || tower2y == yoff - 57)) || ((tower2x <= xoff + 49 && tower2x >= xoff + 47) && (tower2y >= yoff - 56 || tower2y <= yoff)) || ((tower2x <= xoff + 40 && tower2x >= xoff + 38) && (tower2y >= yoff - 56 || tower2y <= yoff)) || ((tower2x <= xoff + 46 && tower2x >= xoff + 41) && (tower2y <= yoff && tower2y >= yoff - 2)))
			{
				Main.tile[tower2x, tower2y].active = true;
				Main.tile[tower2x, tower2y].type = reinGlass;
				WorldGen.SquareTileFrame(tower2x, tower2y);
			}
		}
	}
	for (int floor1x = xoff - 29; floor1x <= xoff + 29; floor1x++)
	{
		for (int floor1y = yoff - 15; floor1y < yoff - 10; floor1y++)
		{
			Main.tile[floor1x, floor1y].active = true;
			Main.tile[floor1x, floor1y].type = hallowStone;
			Main.tile[floor1x, floor1y].wall = 0;
			WorldGen.SquareTileFrame(floor1x, floor1y);
		}
	}
	for (int floor2x = xoff - 29; floor2x <= xoff + 29; floor2x++)
	{
		for (int floor2y = yoff - 40; floor2y < yoff - 35; floor2y++)
		{
			Main.tile[floor2x, floor2y].active = true;
			Main.tile[floor2x, floor2y].type = hallowStone;
			Main.tile[floor2x, floor2y].wall = 0;
			WorldGen.SquareTileFrame(floor2x, floor2y);
		}
	}
	Main.tile[xoff, yoff + 10].active = false;
	Main.tile[xoff, yoff + 11].active = false;
	Main.tile[xoff + 1, yoff + 10].active = false;
	Main.tile[xoff + 1, yoff + 11].active = false;
	Main.tile[xoff - 1, yoff + 10].active = false;
	Main.tile[xoff - 1, yoff + 11].active = false;
	for (int boxX = xoff - 10; boxX < xoff + 10; boxX++)
	{
		for (int boxY = yoff - 4; boxY <= yoff + 15; boxY++)
		{
			if ((boxX >= xoff - 5 && boxX <= xoff + 5) && ((boxY >= yoff + 1 && boxY <= yoff + 4) || (boxY >= yoff + 12 && boxY <= yoff + 15)))
			{
				Main.tile[boxX, boxY].active = true;
				Main.tile[boxX, boxY].type = reinGlass;
				WorldGen.SquareTileFrame(boxX, boxY);
			}
			if (((boxX >= xoff - 9 && boxX <= xoff - 6) || (boxX >= xoff + 6 && boxX <= xoff + 9)) && (boxY <= yoff + 15 && boxY >= yoff + 1))
			{
				Main.tile[boxX, boxY].active = true;
				Main.tile[boxX, boxY].type = reinGlass;
				WorldGen.SquareTileFrame(boxX, boxY);
			}
			if ((boxX >= xoff - 3 && boxX <= xoff + 3) && (boxY >= yoff - 4 && boxY <= yoff + 4))
			{
				if (boxY == yoff - 3 || boxY == yoff + 4)
				{
					Main.tile[boxX, boxY].type = 19;
					WorldGen.SquareTileFrame(boxX, boxY);
				}
				else
				{
					Main.tile[boxX, boxY].active = false;
				}
			}
			if (AddPlatinumChest(xoff, yoff + 10, Config.itemDefs.byName["Dragon Lord Bait"].type, false, 1))
			{
			}
		}
	}
	Main.tile[xoff - 49, yoff - 28].type = resWood;
	Main.tile[xoff - 49, yoff - 29].type = resWood;
	Main.tile[xoff - 49, yoff - 30].type = resWood;
	Main.tile[xoff + 49, yoff - 28].type = resWood;
	Main.tile[xoff + 49, yoff - 29].type = resWood;
	Main.tile[xoff + 49, yoff - 30].type = resWood;
	Main.tile[xoff - 49, yoff - 28].active = true;
	Main.tile[xoff - 49, yoff - 29].active = true;
	Main.tile[xoff - 49, yoff - 30].active = true;
	Main.tile[xoff + 49, yoff - 28].active = true;
	Main.tile[xoff + 49, yoff - 29].active = true;
	Main.tile[xoff + 49, yoff - 30].active = true;
	WorldGen.SquareTileFrame(xoff + 49, yoff - 29);
	WorldGen.SquareTileFrame(xoff - 49, yoff - 29);
	Main.tile[xoff - 48, yoff - 28].active = false;
	Main.tile[xoff - 47, yoff - 28].active = false;
	Main.tile[xoff + 48, yoff - 28].active = false;
	Main.tile[xoff + 47, yoff - 28].active = false;
	Main.tile[xoff - 48, yoff - 29].active = false;
	Main.tile[xoff - 47, yoff - 29].active = false;
	Main.tile[xoff + 48, yoff - 29].active = false;
	Main.tile[xoff + 47, yoff - 29].active = false;
	Main.tile[xoff - 48, yoff - 30].active = false;
	Main.tile[xoff - 47, yoff - 30].active = false;
	Main.tile[xoff + 48, yoff - 30].active = false;
	Main.tile[xoff + 47, yoff - 30].active = false;
	Main.tile[xoff - 40, yoff - 28].active = false;
	Main.tile[xoff - 39, yoff - 28].active = false;
	Main.tile[xoff - 38, yoff - 28].active = false;
	Main.tile[xoff + 40, yoff - 28].active = false;
	Main.tile[xoff + 39, yoff - 28].active = false;
	Main.tile[xoff + 38, yoff - 28].active = false;
	Main.tile[xoff - 40, yoff - 29].active = false;
	Main.tile[xoff - 39, yoff - 29].active = false;
	Main.tile[xoff - 38, yoff - 29].active = false;
	Main.tile[xoff + 40, yoff - 29].active = false;
	Main.tile[xoff + 39, yoff - 29].active = false;
	Main.tile[xoff + 38, yoff - 29].active = false;
	Main.tile[xoff - 40, yoff - 30].active = false;
	Main.tile[xoff - 39, yoff - 30].active = false;
	Main.tile[xoff - 38, yoff - 30].active = false;
	Main.tile[xoff + 40, yoff - 30].active = false;
	Main.tile[xoff + 39, yoff - 30].active = false;
	Main.tile[xoff + 38, yoff - 30].active = false;

	Main.tile[xoff - 37, yoff - 30].active = false;
	Main.tile[xoff - 36, yoff - 30].active = false;
	Main.tile[xoff - 35, yoff - 30].active = false;
	Main.tile[xoff - 34, yoff - 30].active = false;
	Main.tile[xoff - 33, yoff - 30].active = false;
	Main.tile[xoff + 37, yoff - 30].active = false;
	Main.tile[xoff + 36, yoff - 30].active = false;
	Main.tile[xoff + 35, yoff - 30].active = false;
	Main.tile[xoff + 34, yoff - 30].active = false;
	Main.tile[xoff + 33, yoff - 30].active = false;
	Main.tile[xoff - 37, yoff - 29].active = false;
	Main.tile[xoff - 36, yoff - 29].active = false;
	Main.tile[xoff - 35, yoff - 29].active = false;
	Main.tile[xoff - 34, yoff - 29].active = false;
	Main.tile[xoff - 33, yoff - 29].active = false;
	Main.tile[xoff + 37, yoff - 29].active = false;
	Main.tile[xoff + 36, yoff - 29].active = false;
	Main.tile[xoff + 35, yoff - 29].active = false;
	Main.tile[xoff + 34, yoff - 29].active = false;
	Main.tile[xoff + 33, yoff - 29].active = false;
	Main.tile[xoff - 37, yoff - 28].active = false;
	Main.tile[xoff - 36, yoff - 28].active = false;
	Main.tile[xoff - 35, yoff - 28].active = false;
	Main.tile[xoff - 34, yoff - 28].active = false;
	Main.tile[xoff - 33, yoff - 28].active = false;
	Main.tile[xoff + 37, yoff - 28].active = false;
	Main.tile[xoff + 36, yoff - 28].active = false;
	Main.tile[xoff + 35, yoff - 28].active = false;
	Main.tile[xoff + 34, yoff - 28].active = false;
	Main.tile[xoff + 33, yoff - 28].active = false;

	WorldGen.SquareTileFrame(xoff - 36, yoff - 27);
	WorldGen.SquareTileFrame(xoff - 36, yoff - 31);
	WorldGen.SquareTileFrame(xoff - 33, yoff - 27);
	WorldGen.SquareTileFrame(xoff - 33, yoff - 31);
	WorldGen.SquareTileFrame(xoff - 38, yoff - 27);
	WorldGen.SquareTileFrame(xoff - 38, yoff - 31);
	WorldGen.SquareTileFrame(xoff + 36, yoff - 27);
	WorldGen.SquareTileFrame(xoff + 36, yoff - 31);
	WorldGen.SquareTileFrame(xoff + 33, yoff - 27);
	WorldGen.SquareTileFrame(xoff + 33, yoff - 31);
	WorldGen.SquareTileFrame(xoff + 38, yoff - 27);
	WorldGen.SquareTileFrame(xoff + 38, yoff - 31);

	WorldGen.SquareTileFrame(xoff - 4, yoff - 4);
	WorldGen.SquareTileFrame(xoff - 4, yoff - 2);
	WorldGen.SquareTileFrame(xoff - 4, yoff);
	WorldGen.SquareTileFrame(xoff - 4, yoff + 2);
	WorldGen.SquareTileFrame(xoff - 4, yoff + 4);
	WorldGen.SquareTileFrame(xoff + 4, yoff - 4);
	WorldGen.SquareTileFrame(xoff + 4, yoff - 2);
	WorldGen.SquareTileFrame(xoff + 4, yoff);
	WorldGen.SquareTileFrame(xoff + 4, yoff + 2);
	WorldGen.SquareTileFrame(xoff + 4, yoff + 4);
	
}

public static void AddOpals()
{
	int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
	double num6;
	num6 = Main.rockLayer;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 150);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 5), Config.tileDefs.ID["Opal"]);
}

public static void TropicsRunner()
{
	int xmin = 0;
	int xmax = 350;
	int ymin = (int)Main.topWorld;
	int ymax = Main.maxTilesY - 50;
	if (Main.rand.Next(2) == 0)
	{
		xmin = Main.maxTilesX - 350;
		xmax = Main.maxTilesX;
	}
	for (int x = xmin; x < xmax; x++)
	{
		for (int y = ymin; y < ymax; y++)
		{
			if (Main.tile[x, y].active)
			{
				if (Main.tile[x, y].type == 53 || Main.tile[x, y].type == 112 || Main.tile[x, y].type == 116)
				{
					Main.tile[x, y].type = (ushort)Config.tileDefs.ID["Black Sand"];
					WorldGen.SquareTileFrame(x, y);
				}
				if (Main.tile[x, y].type == 1)
				{
					Main.tile[x, y].type = (ushort)Config.tileDefs.ID["Tropic Stone"];
					WorldGen.SquareTileFrame(x, y);
				}
				if (Main.tile[x, y].type == 2)
				{
					Main.tile[x, y].type = (ushort)Config.tileDefs.ID["Tropical Grass"];
					WorldGen.SquareTileFrame(x, y);
				}
				if (Main.tile[x, y].type == 0 || Main.tile[x, y].type == 59)
				{
					Main.tile[x, y].type = (ushort)Config.tileDefs.ID["Tropical Mud"];
					WorldGen.SquareTileFrame(x, y);
				}
				//ModWorld.SpreadCustomGrassOverSurface(x, y, (int)Config.tileDefs.ID["Tropical Mud"], (int)Config.tileDefs.ID["Tropical Grass"]);
				//if (Main.rand.Next(100000) == 0 || (Main.rand.Next(500) == 0 && y < Main.rockLayer - 70))
				//{
				//	WorldGen.SpreadGrass(x, y, (int)Config.tileDefs.ID["Tropical Mud"], (int)Config.tileDefs.ID["Tropical Grass"], true);
				//}
			}
		}
	}
	int Amount_Of_Spawns = 100+(int)(Main.maxTilesY/5);
	for(int i=0;i<Amount_Of_Spawns;i++) AddOpals();
}

public static void SmashHallowAltar(int i, int j)
{
	if (Main.netMode == 1)
	{
		return;
	}
	if (!superHardmode)
	{
		return;
	}
	if (WorldGen.noTileActions)
	{
		return;
	}
	if (WorldGen.gen)
	{
		return;
	}
	int oreNumber = hallowAltarCount % 3;
	int num2 = hallowAltarCount / 3 + 1;
	float numOfHMOres = (float)(Main.maxTilesX / 4200);
	int add = 1 - oreNumber;
	numOfHMOres = numOfHMOres * 260f - (float)(85 * oreNumber);
	numOfHMOres *= 0.75f;
	numOfHMOres /= (float)num2;
	if (oreNumber == 0)
	{
		//if (Main.netMode == 0)
		//{
		//	Main.NewText("Your world has been desecrated with Corrupted Ore!", 80, 65, 130);
		//}
		//else
		//{
		//	if (Main.netMode == 2)
		//	{
		//		NetMessage.SendData(25, -1, -1, "Your world has been desecrated with Corrupted Ore!", 255, 80f, 65f, 130f, 0);
		//	}
		//}
		//oreNumber = Config.tileDefs.ID["Corrupted Ore"];
		//numOfHMOres *= 1.05f;
	}
	else
	{
		if (oreNumber == 1)
		{
		//	if (Main.netMode == 0)
		//	{
		//		Main.NewText("Your world has been glorified with Hallowed Ore!", 220, 170, 0);
		//	}
		//	else
		//	{
		//		if (Main.netMode == 2)
		//		{
		//			NetMessage.SendData(25, -1, -1, "Your world has been glorified with Hallowed Ore!", 255, 220f, 170f, 0f, 0);
		//		}
		//	}
		//	oreNumber = Config.tileDefs.ID["Hallowed Ore"];
		}
		else if (oreNumber == 2)
		{
			if (Main.netMode == 0)
			{
				Main.NewText("Your world has been melted with Magmatic Ore!", 255, 60, 0);
			}
			else
			{
				if (Main.netMode == 2)
				{
					NetMessage.SendData(25, -1, -1, "Your world has been melted with Magmatic Ore!", 255, 255f, 60f, 0f, 0);
				}
			}
			oreNumber = Config.tileDefs.ID["Magmatic Ore"];
		}
	}
	int hardmodeOreLoopCounter = 0;
	while ((float)hardmodeOreLoopCounter < numOfHMOres)
	{
		int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
		double worldLayer = Main.worldSurface;
		if (oreNumber == Config.tileDefs.ID["Hallowed Ore"])
		{
			worldLayer = Main.rockLayer;
		}
		if (oreNumber == Config.tileDefs.ID["Magmatic Ore"])
		{
			worldLayer = (Main.rockLayer + Main.rockLayer + (double)Main.maxTilesY) / 3.0;
		}
		int j2 = WorldGen.genRand.Next((int)worldLayer, Main.maxTilesY - 150);
		WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(4, 6 + add), WorldGen.genRand.Next(5, 7 + add), Config.tileDefs.ID["Magmatic Ore"]);
		hardmodeOreLoopCounter++;
	}
	if (Main.netMode != 1)
	{
		int altarCounter = Main.rand.Next(2) + 1;
		for (int k = 0; k < altarCounter; k++)
		{
			SpawnNPCOnPlayerWithoutMessage((int)Player.FindClosest(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16), Config.npcDefs.byName["Armored Wraith"].type);
		}
	}
	hallowAltarCount++;
}

public static void AddHellCastle()
{
	ushort brimStone = (ushort)Config.tileDefs.ID["Brimstone Block"];
	ushort brickI = (ushort)Config.tileDefs.ID["Impervious Brick"];
	ushort caesiumOre = (ushort)Config.tileDefs.ID["Caesium Ore"];
	ushort resWood = (ushort)Config.tileDefs.ID["Resistant Wood"];
	ushort pSpike = (ushort)Config.tileDefs.ID["Poison Spikes"];
	int xoff = WorldGen.genRand.Next(150, (int)(Main.maxTilesX / 3));
	int yoff = Main.maxTilesY - 150;
	for (int loop = 0; loop < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0015); loop++)
	{
		float num58 = (float)((double)loop / ((double)(Main.maxTilesX * Main.maxTilesY) * 0.0015));
		Main.statusText = string.Concat(new object[]
		{
			"Generating Hellcastle:",
			" ",
			(int)(num58 * 100f + 1f),
			"%"
		});
	//Main.statusText = "Generating Hellcastle: 5%";
	for (int x = xoff - 50; x <= xoff + 50; x++)
	{
		for (int y = yoff - 37; y <= yoff + 37; y++)
		{
			Main.tile[x, y].active = false;
			if (x <= xoff - 45 || x >= xoff + 45 || y <= yoff - 32 || y >= yoff + 32) Main.tile[x, y].active = true;
			Main.tile[x, y].liquid = 0;
			Main.tile[x, y].lava = false;
			Main.tile[x, y].wall = 0;
			Main.tile[x, y].type = brickI;
			if (((x <= xoff - 45 && x >= xoff - 50) || (x <= xoff + 50 && x >= xoff + 45)) && (y <= yoff - 26 && y >= yoff - 31))
			{
				Main.tile[x, y].type = resWood;
			}
    		}
	}
	bool hasMadeOpening = false;
	bool hasMadeOpeningLeftSide = false;
	for(int y = 0; y < 73; y++)
	{
		if (!(Main.tile[xoff + 51, yoff - y].active) && !hasMadeOpening)
		{
			Main.tile[xoff + 50, yoff - y].type = resWood;
			Main.tile[xoff + 50, yoff - y - 1].type = resWood;
			Main.tile[xoff + 50, yoff - y + 1].type = resWood;
			for (int opening = 49; opening >= 45; opening--)
			{
				Main.tile[xoff + opening, yoff - y].active = false;
				Main.tile[xoff + opening, yoff - y - 1].active = false;
				Main.tile[xoff + opening, yoff - y + 1].active = false;
				hasMadeOpening = true;
			}
		}
		if (!(Main.tile[xoff + 51, yoff + y].active) && !hasMadeOpening)
		{
			Main.tile[xoff + 50, yoff - y].type = resWood;
			Main.tile[xoff + 50, yoff - y - 1].type = resWood;
			Main.tile[xoff + 50, yoff - y + 1].type = resWood;
			for (int opening = 49; opening >= 45; opening--)
			{
				Main.tile[xoff + opening, yoff - y].active = false;
				Main.tile[xoff + opening, yoff - y - 1].active = false;
				Main.tile[xoff + opening, yoff - y + 1].active = false;
				hasMadeOpening = true;
			}
		}
		if (!(Main.tile[xoff - 51, yoff - y].active) && !hasMadeOpeningLeftSide)
		{
			Main.tile[xoff - 50, yoff - y].type = resWood;
			Main.tile[xoff - 50, yoff - y - 1].type = resWood;
			Main.tile[xoff - 50, yoff - y + 1].type = resWood;
			for (int opening = 49; opening >= 45; opening--)
			{
				Main.tile[xoff - opening, yoff - y].active = false;
				Main.tile[xoff - opening, yoff - y - 1].active = false;
				Main.tile[xoff - opening, yoff - y + 1].active = false;
				hasMadeOpeningLeftSide = true;
			}
		}
		if (!(Main.tile[xoff - 51, yoff + y].active) && !hasMadeOpeningLeftSide)
		{
			Main.tile[xoff - 50, yoff - y].type = resWood;
			Main.tile[xoff - 50, yoff - y - 1].type = resWood;
			Main.tile[xoff - 50, yoff - y + 1].type = resWood;
			for (int opening = 49; opening >= 45; opening--)
			{
				Main.tile[xoff - opening, yoff - y].active = false;
				Main.tile[xoff - opening, yoff - y - 1].active = false;
				Main.tile[xoff - opening, yoff - y + 1].active = false;
				hasMadeOpeningLeftSide = true;
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 15%";
	if (!hasMadeOpening)
	{
		Main.tile[xoff + 50, yoff].type = resWood;
		Main.tile[xoff + 50, yoff - 1].type = resWood;
		Main.tile[xoff + 50, yoff + 1].type = resWood;
		for (int opening = 49; opening >= 45; opening--)
		{
			Main.tile[xoff + opening, yoff].active = false;
			Main.tile[xoff + opening, yoff - 1].active = false;
			Main.tile[xoff + opening, yoff + 1].active = false;
		}
	}
	if (!hasMadeOpeningLeftSide)
	{
		Main.tile[xoff - 50, yoff].type = resWood;
		Main.tile[xoff - 50, yoff - 1].type = resWood;
		Main.tile[xoff - 50, yoff + 1].type = resWood;
		for (int opening = 49; opening >= 45; opening--)
		{
			Main.tile[xoff - opening, yoff].active = false;
			Main.tile[xoff - opening, yoff - 1].active = false;
			Main.tile[xoff - opening, yoff + 1].active = false;
		}
	}
	//Main.statusText = "Generating Hellcastle: 20%";
	for (int x2 = xoff - 45; x2 <= xoff + 45; x2++)
	{
		for (int y2 = yoff - 25; y2 <= yoff - 20; y2++)
		{
			Main.tile[x2, y2].active = true;
			Main.tile[x2, y2].wall = 0;
			Main.tile[x2, y2].liquid = 0;
			Main.tile[x2, y2].type = brickI;
			if ((x2 <= xoff - 25 && x2 >= xoff - 30) || (x2 <= xoff + 30 && x2 >= xoff + 25))
			{
				if (y2 == yoff - 25 || y2 == yoff - 20)
				{
					Main.tile[x2, y2].type = 19;
				}
				else Main.tile[x2, y2].active = false;
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 25%";
	for (int x4 = xoff - 45; x4 <= xoff + 45; x4++)
	{
		for (int y4 = yoff + 2; y4 <= yoff + 7; y4++)
		{
			Main.tile[x4, y4].active = true;
			Main.tile[x4, y4].wall = 0;
			Main.tile[x4, y4].liquid = 0;
			Main.tile[x4, y4].type = brickI;
			if ((x4 <= xoff - 25 && x4 >= xoff - 30) || (x4 <= xoff + 30 && x4 >= xoff + 25))
			{
				if (y4 == yoff + 2 || y4 == yoff + 7)
				{
					Main.tile[x4, y4].type = 19;
				}
				else Main.tile[x4, y4].active = false;
			}
			if (x4 >= xoff - 10 && x4 <= xoff + 10 && y4 == yoff + 2)
			{
				Main.tile[x4, y4].active = true;
				Main.tile[x4, y4].type = pSpike;
			}
		}
	}
	for (int x6 = xoff - 10; x6 <= xoff + 10; x6++)
	{
		for (int y6 = yoff + 1; y6 <= yoff + 2; y6++)
		{
			if ((x6 == xoff - 9 || x6 == xoff - 7 || x6 == xoff - 5 || x6 == xoff - 3 || x6 == xoff - 1 || x6 == xoff + 1 || x6 == xoff + 3 || x6 == xoff + 5 || x6 == xoff + 7 || x6 == xoff + 9) && y6 == yoff + 1)
			{
				Main.tile[x6, y6].active = true;
				Main.tile[x6, y6].type = pSpike;
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 30%";
	for (int x5 = xoff - 45; x5 <= xoff + 45; x5++)
	{
		for (int y5 = yoff + 15; y5 <= yoff + 20; y5++)
		{
			Main.tile[x5, y5].active = true;
			Main.tile[x5, y5].wall = 0;
			Main.tile[x5, y5].liquid = 0;
			Main.tile[x5, y5].type = brickI;
			if ((x5 <= xoff - 25 && x5 >= xoff - 30) || (x5 <= xoff + 30 && x5 >= xoff + 25))
			{
				if (y5 == yoff + 15 || y5 == yoff + 20)
				{
					Main.tile[x5, y5].type = 19;
				}
				else if (y5 >= yoff + 16 && y5 <= yoff + 19) 
				{
					Main.tile[x5, y5].active = false;
				}
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 35%";
	for (int brimstoneX = xoff - 45; brimstoneX <= xoff + 45; brimstoneX++)
	{
		for (int brimstoneY = yoff + 21; brimstoneY <= yoff + 31; brimstoneY++)
		{
			Main.tile[brimstoneX, brimstoneY].liquid = 0;
			Main.tile[brimstoneX, brimstoneY].wall = 0;
			Main.tile[brimstoneX, brimstoneY].active = true;
			Main.tile[brimstoneX, brimstoneY].type = brimStone;
			if (WorldGen.genRand.Next(5) == 0)
			{
				Main.tile[brimstoneX, brimstoneY].type = caesiumOre;
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 40%";
	for (int lanternX = xoff - 45; lanternX <= xoff + 45; lanternX++)
	{
		for (int lanternY = yoff - 32; lanternY <= yoff + 14; lanternY++)
		{
			if (((lanternX == xoff - 40 || lanternX == xoff - 28 || lanternX == xoff - 15 || lanternX == xoff || lanternX == xoff + 15 || lanternX == xoff + 28 || lanternX == xoff + 40) && lanternY == yoff - 31))
			{
				WorldGen.Place1x2Top(lanternX, lanternY, 42);
			}
			if (((lanternX == xoff - 40 || lanternX == xoff - 15 || lanternX == xoff || lanternX == xoff + 15 || lanternX == xoff + 40) && lanternY == yoff - 19))
			{
				WorldGen.Place1x2Top(lanternX, lanternY, 42);
			}
			if (((lanternX == xoff - 40 || lanternX == xoff - 15 || lanternX == xoff || lanternX == xoff + 15 || lanternX == xoff + 40) && lanternY == yoff + 8))
			{
				WorldGen.Place1x2Top(lanternX, lanternY, 42);
			}
			if (((lanternX == xoff - 40 || lanternX == xoff - 15 || lanternX == xoff || lanternX == xoff + 15 || lanternX == xoff + 40) && lanternY == yoff + 1))
			{
				WorldGen.PlaceTile(lanternX, lanternY, 4, true, true, -1, 8);
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 45%";
	for (int torchX = xoff - 45; torchX <= xoff + 45; torchX++)
	{
		for (int torchY = yoff - 32; torchY <= yoff + 20; torchY++)
		{
			if ((torchX == xoff - 30 || torchX == xoff - 25 || torchX == xoff + 25 || torchX == xoff + 30) && torchY == yoff - 23)
			{
				WorldGen.PlaceTile(torchX, torchY, 4, true, true, -1, 8);
			}
			if ((torchX == xoff - 30 || torchX == xoff - 25 || torchX == xoff + 25 || torchX == xoff + 30) && torchY == yoff + 4)
			{
				WorldGen.PlaceTile(torchX, torchY, 4, true, true, -1, 8);
			}
			if ((torchX == xoff - 30 || torchX == xoff - 25 || torchX == xoff + 25 || torchX == xoff + 30) && torchY == yoff + 17)
			{
				WorldGen.PlaceTile(torchX, torchY, 4, true, true, -1, 8);
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 50%";
	//Main.statusText = "Generating Hellcastle: 60%";
	for (int platx = xoff - 2; platx <= xoff + 2; platx++)
	{
		for (int platy = yoff + 32; platy <= yoff + 37; platy++)
		{
			Main.tile[platx, platy].active = false;
			if (platy == yoff + 32)
			{
				Main.tile[platx, platy].active = true;
				Main.tile[platx, platy].type = 19;
			}
			if (platy == yoff + 37)
			{
				Main.tile[platx, platy].active = true;
				Main.tile[platx, platy].type = resWood;
			}
			if ((platx == xoff + 2 || platx == xoff - 2) && platy == yoff + 34)
			{
				WorldGen.PlaceTile(platx, platy, 4, true, true, -1, 8);
			}
		}
	}
	}
	//Main.statusText = "Generating Hellcastle: 65%";
	for (int chestBoxX = xoff - 17; chestBoxX <= xoff + 16; chestBoxX++)
	{
		for (int chestBoxY = yoff + 38; chestBoxY <= yoff + 55; chestBoxY++)
		{
			if (((chestBoxX <= xoff - 12 && chestBoxX >= xoff - 17) || (chestBoxX <= xoff + 16 && chestBoxX >= xoff + 11)) && (chestBoxY <= yoff + 55 && chestBoxY >= yoff + 38))
			{
				Main.tile[chestBoxX, chestBoxY].active = true;
				Main.tile[chestBoxX, chestBoxY].wall = 0;
				Main.tile[chestBoxX, chestBoxY].liquid = 0;
				Main.tile[chestBoxX, chestBoxY].lava = false;
				Main.tile[chestBoxX, chestBoxY].type = brickI;
			}
			if ((chestBoxX >= xoff - 11 && chestBoxX <= xoff + 10) && (chestBoxY >= yoff + 38 && chestBoxY <= yoff + 50))
			{
				Main.tile[chestBoxX, chestBoxY].active = false;
				Main.tile[chestBoxX, chestBoxY].wall = 0;
				Main.tile[chestBoxX, chestBoxY].liquid = 0;
				Main.tile[chestBoxX, chestBoxY].lava = false;
			}
			if ((chestBoxX <= xoff + 10 && chestBoxX >= xoff - 11) && (chestBoxY >= yoff + 51 && chestBoxY <= yoff + 55))
			{
				Main.tile[chestBoxX, chestBoxY].active = true;
				Main.tile[chestBoxX, chestBoxY].liquid = 0;
				Main.tile[chestBoxX, chestBoxY].lava = false;
				Main.tile[chestBoxX, chestBoxY].wall = 0;
				Main.tile[chestBoxX, chestBoxY].type = brickI;
			}
			//if ((chestBoxX == xoff - 7 || chestBoxX == xoff + 6) && chestBoxY == yoff + 38)
			//{
				//Main.tile[chestBoxX, chestBoxY].type = 42;
				//Main.tile[chestBoxX, chestBoxY].active = true;
				//Main.tile[chestBoxX, chestBoxY].frameX = (short)1;
				//Main.tile[chestBoxX, chestBoxY].frameY = (short)1;
				//Main.tile[chestBoxX, chestBoxY + 1].frameX = (short)1;
				//Main.tile[chestBoxX, chestBoxY + 1].frameY = (short)19;
				//WorldGen.Place1x2Top(chestBoxX, chestBoxY, 42);
			//}
			if ((chestBoxX >= xoff - 2 && chestBoxX <= xoff + 1) && (chestBoxY >= yoff + 47 && chestBoxY <= yoff + 50))
			{
				Main.tile[chestBoxX, chestBoxY].active = true;
				Main.tile[chestBoxX, chestBoxY].type = resWood;
				if ((chestBoxX == xoff - 1 || chestBoxX == xoff) && (chestBoxY == yoff + 48 || chestBoxY == yoff + 49))
				{
					Main.tile[chestBoxX, chestBoxY].active = false;
				}
			}
			if ((chestBoxX == xoff - 3 || chestBoxX == xoff + 2) && (chestBoxY >= yoff + 47 && chestBoxY <= yoff + 50))
			{
				Main.tile[chestBoxX, chestBoxY].active = true;
				Main.tile[chestBoxX, chestBoxY].type = pSpike;
			}
			if (AddHellfireChest(xoff, yoff + 49, Config.itemDefs.byName["Autonomic Drill"].type, false, 1))
			{
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 70%";
	for (int leftSideX = xoff - 65; leftSideX <= xoff - 51; leftSideX++)
	{
		for (int leftSideY = yoff - 37; leftSideY <= yoff + 37; leftSideY++)
		{
			if ((leftSideX <= xoff - 51 && leftSideX >= xoff - 65) && (leftSideY <= yoff + 37 && leftSideY >= yoff - 37))
			{
				Main.tile[leftSideX, leftSideY].active = true;
				Main.tile[leftSideX, leftSideY].liquid = 0;
				Main.tile[leftSideX, leftSideY].wall = 0;
				Main.tile[leftSideX, leftSideY].lava = false;
				Main.tile[leftSideX, leftSideY].type = brickI;
			}
			if ((leftSideX >= xoff - 60 && leftSideX <= xoff - 51) && ((leftSideY <= yoff - 26 && leftSideY >= yoff - 31) || (leftSideY <= yoff + 31 && leftSideY >= yoff + 26)))
			{
				Main.tile[leftSideX, leftSideY].active = false;
			}
			if (leftSideX == xoff - 65 && (leftSideY == yoff - 1 || leftSideY == yoff || leftSideY == yoff + 1))
			{
				Main.tile[leftSideX, leftSideY].type = resWood;
			}
			if ((leftSideX >= xoff - 64 && leftSideX <= xoff - 51) && (leftSideY == yoff - 1 || leftSideY == yoff || leftSideY == yoff + 1))
			{
				Main.tile[leftSideX, leftSideY].active = false;
			}
			if ((leftSideX >= xoff - 60 && leftSideX <= xoff - 55) && ((leftSideY <= yoff + 26 && leftSideY >= yoff + 5) || (leftSideY <= yoff - 5 && leftSideY >= yoff - 26)))
			{
				Main.tile[leftSideX, leftSideY].active = false;
				if (leftSideX == xoff - 60 && (leftSideY == yoff + 18 || leftSideY == yoff - 18))
				{
					//WorldGen.KillTile(leftSideX, leftSideY, false, false, false);
					//Main.tile[leftSideX, leftSideY].active = true;
					WorldGen.PlaceTile(leftSideX, leftSideY, 4, true, true, -1, 8);
				}
			}
			if ((leftSideX <= xoff - 54 && leftSideX >= xoff - 59) && (leftSideY == yoff + 5 || leftSideY == yoff - 5))
			{
				Main.tile[leftSideX, leftSideY].active = false;
			}
			if ((leftSideX <= xoff - 53 && leftSideX >= xoff - 58) && (leftSideY == yoff + 4 || leftSideY == yoff - 4))
			{
				Main.tile[leftSideX, leftSideY].active = false;
			}
			if ((leftSideX <= xoff - 52 && leftSideX >= xoff - 57) && (leftSideY == yoff + 3 || leftSideY == yoff - 3))
			{
				Main.tile[leftSideX, leftSideY].active = false;
			}
			if ((leftSideX <= xoff - 51 && leftSideX >= xoff - 56) && (leftSideY == yoff + 2 || leftSideY == yoff - 2))
			{
				Main.tile[leftSideX, leftSideY].active = true;
				Main.tile[leftSideX, leftSideY].type = 19;
			}
			if (leftSideX == xoff - 60 && (leftSideY == yoff - 5 || leftSideY == yoff + 5))
			{
				Main.tile[leftSideX, leftSideY].active = true;
			}
			if (leftSideX == xoff - 55 && leftSideY == yoff + 31)
			{
				Main.tile[leftSideX, leftSideY].active = true;
				Main.tile[leftSideX, leftSideY].type = 4;
				Main.tile[leftSideX, leftSideY].frameX = (short)0;
				Main.tile[leftSideX, leftSideY].frameY = (short)176;
				//WorldGen.PlaceTile(leftSideX, leftSideY, 4, true, true, -1, 8);
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 85%";
	for (int rightSideX = xoff + 51; rightSideX <= xoff + 65; rightSideX++)
	{
		for (int rightSideY = yoff - 37; rightSideY <= yoff + 37; rightSideY++)
		{
			if ((rightSideX >= xoff + 51 && rightSideX <= xoff + 65) && (rightSideY <= yoff + 37 && rightSideY >= yoff - 37))
			{
				Main.tile[rightSideX, rightSideY].active = true;
				Main.tile[rightSideX, rightSideY].liquid = 0;
				Main.tile[rightSideX, rightSideY].wall = 0;
				Main.tile[rightSideX, rightSideY].lava = false;
				Main.tile[rightSideX, rightSideY].type = brickI;
			}
			if ((rightSideX <= xoff + 60 && rightSideX >= xoff + 51) && ((rightSideY <= yoff - 26 && rightSideY >= yoff - 31) || (rightSideY <= yoff + 31 && rightSideY >= yoff + 26)))
			{
				Main.tile[rightSideX, rightSideY].active = false;
			}
			if (rightSideX == xoff + 65 && (rightSideY == yoff - 1 || rightSideY == yoff || rightSideY == yoff + 1))
			{
				Main.tile[rightSideX, rightSideY].type = resWood;
			}
			if ((rightSideX <= xoff + 64 && rightSideX >= xoff + 51) && (rightSideY == yoff - 1 || rightSideY == yoff || rightSideY == yoff + 1))
			{
				Main.tile[rightSideX, rightSideY].active = false;
			}
			if ((rightSideX <= xoff + 60 && rightSideX >= xoff + 55) && ((rightSideY <= yoff + 26 && rightSideY >= yoff + 5) || (rightSideY <= yoff - 5 && rightSideY >= yoff - 26)))
			{
				Main.tile[rightSideX, rightSideY].active = false;
				if (rightSideX == xoff + 60 && (rightSideY == yoff + 18 || rightSideY == yoff - 18))
				{
					Main.tile[rightSideX, rightSideY].active = true;
					Main.tile[rightSideX, rightSideY].type = 4;
					Main.tile[rightSideX, rightSideY].frameX = (short)44;
					Main.tile[rightSideX, rightSideY].frameY = (short)176;
				}
			}
			if ((rightSideX >= xoff + 54 && rightSideX <= xoff + 59) && (rightSideY == yoff + 5 || rightSideY == yoff - 5))
			{
				Main.tile[rightSideX, rightSideY].active = false;
			}
			if ((rightSideX >= xoff + 53 && rightSideX <= xoff + 58) && (rightSideY == yoff + 4 || rightSideY == yoff - 4))
			{
				Main.tile[rightSideX, rightSideY].active = false;
			}
			if ((rightSideX >= xoff + 52 && rightSideX <= xoff + 57) && (rightSideY == yoff + 3 || rightSideY == yoff - 3))
			{
				Main.tile[rightSideX, rightSideY].active = false;
			}
			if ((rightSideX >= xoff + 51 && rightSideX <= xoff + 56) && (rightSideY == yoff + 2 || rightSideY == yoff - 2))
			{
				Main.tile[rightSideX, rightSideY].active = true;
				Main.tile[rightSideX, rightSideY].type = 19;
			}
			if (rightSideX == xoff + 60 && (rightSideY == yoff - 5 || rightSideY == yoff + 5))
			{
				Main.tile[rightSideX, rightSideY].active = true;
			}
			if (rightSideX == xoff + 55 && rightSideY == yoff + 31)
			{
				Main.tile[rightSideX, rightSideY].active = true;
				Main.tile[rightSideX, rightSideY].type = 4;
				Main.tile[rightSideX, rightSideY].frameX = (short)0;
				Main.tile[rightSideX, rightSideY].frameY = (short)176;
				//WorldGen.PlaceTile(rightSideX, rightSideY, 4, true, true, -1, 8);
			}
		}
	}
	for (int spikeX = xoff - 65; spikeX <= xoff + 65; spikeX++)
	{
		for (int spikeY = yoff - 33; spikeY <= yoff + 32; spikeY++)
		{
			if (((spikeX >= xoff - 61 && spikeX <= xoff - 57) || (spikeX >= xoff + 57 && spikeX <= xoff + 61)) && (spikeY == yoff + 32 || spikeY == yoff - 32))
			{
				Main.tile[spikeX, spikeY].active = true;
				Main.tile[spikeX, spikeY].type = pSpike;
			}
			if ((spikeX == xoff - 61 || spikeX == xoff + 61) && ((spikeY >= yoff - 31 && spikeY <= yoff - 28) || (spikeY >= yoff + 28 && spikeY <= yoff + 31)))
			{
				Main.tile[spikeX, spikeY].active = true;
				Main.tile[spikeX, spikeY].type = pSpike;
			}
		}
	}
	Main.tile[xoff - 60, yoff - 28].active = true;
	Main.tile[xoff - 60, yoff - 30].active = true;
	Main.tile[xoff - 60, yoff + 28].active = true;
	Main.tile[xoff - 60, yoff + 30].active = true;
	Main.tile[xoff + 60, yoff - 28].active = true;
	Main.tile[xoff + 60, yoff - 30].active = true;
	Main.tile[xoff + 60, yoff + 28].active = true;
	Main.tile[xoff + 60, yoff + 30].active = true;
	Main.tile[xoff - 60, yoff - 28].type = pSpike;
	Main.tile[xoff - 60, yoff - 30].type = pSpike;
	Main.tile[xoff - 60, yoff + 28].type = pSpike;
	Main.tile[xoff - 60, yoff + 30].type = pSpike;
	Main.tile[xoff + 60, yoff - 28].type = pSpike;
	Main.tile[xoff + 60, yoff - 30].type = pSpike;
	Main.tile[xoff + 60, yoff + 28].type = pSpike;
	Main.tile[xoff + 60, yoff + 30].type = pSpike;
	//Main.statusText = "Generating Hellcastle: 90%";
	for (int shelfX = xoff - 65; shelfX <= xoff + 65; shelfX++)
	{
		for (int shelfY = yoff - 37; shelfY <= yoff + 55; shelfY++)
		{
			if (((shelfX == xoff - 59 || shelfX == xoff - 60) || (shelfX == xoff + 60 || shelfX == xoff + 59)) && (shelfY == yoff - 10 || shelfY == yoff + 10))
			{
				Main.tile[shelfX, shelfY].active = true;
				Main.tile[shelfX, shelfY].type = 19;
				Main.tile[shelfX, shelfY - 1].active = true;
				Main.tile[shelfX, shelfY - 1].type = 50;
				int randomBook = WorldGen.genRand.Next(5);
				if (randomBook == 0)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)0;
				}
				else if (randomBook == 1)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)18;
				}
				else if (randomBook == 2)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)36;
				}
				else if (randomBook == 3)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)54;
				}
				else if (randomBook == 4)
				{
					int randomNum = Main.rand.Next(25);
					if (randomNum == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else if (randomNum == 24)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["DVS"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)72;
				}
			}
			if (((shelfX == xoff - 55 || shelfX == xoff - 56) || (shelfX == xoff + 56 || shelfX == xoff + 55)) && (shelfY == yoff - 20 || shelfY == yoff + 20))
			{
				Main.tile[shelfX, shelfY].active = true;
				Main.tile[shelfX, shelfY].type = 19;
				Main.tile[shelfX, shelfY - 1].active = true;
				Main.tile[shelfX, shelfY - 1].type = 50;
				int randomBook2 = WorldGen.genRand.Next(5);
				if (randomBook2 == 0)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)0;
				}
				else if (randomBook2 == 1)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)18;
				}
				else if (randomBook2 == 2)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)36;
				}
				else if (randomBook2 == 3)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)54;
				}
				else if (randomBook2 == 4)
				{
					int randomNum = Main.rand.Next(25);
					if (randomNum == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else if (randomNum == 24)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["DVS"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)72;
				}
			}
			Main.tile[xoff - 44, yoff + 11].active = true;
			Main.tile[xoff - 44, yoff + 11].type = 19;
			Main.tile[xoff + 44, yoff + 11].active = true;
			Main.tile[xoff + 44, yoff + 11].type = 19;
			if (((shelfX >= xoff - 43 && shelfX <= xoff - 41) || (shelfX >= xoff + 41 && shelfX <= xoff + 43)) && shelfY == yoff + 11)
			{
				Main.tile[shelfX, shelfY].active = true;
				Main.tile[shelfX, shelfY].type = 19;
				Main.tile[shelfX, shelfY - 1].active = true;
				Main.tile[shelfX, shelfY - 1].type = 50;
				int randomBook3 = WorldGen.genRand.Next(5);
				if (randomBook3 == 0)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)0;
				}
				else if (randomBook3 == 1)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)18;
				}
				else if (randomBook3 == 2)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)36;
				}
				else if (randomBook3 == 3)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)54;
				}
				else if (randomBook3 == 4)
				{
					int randomNum = Main.rand.Next(25);
					if (randomNum == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else if (randomNum == 24)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["DVS"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)72;
				}
			}
			if (((shelfX >= xoff - 11 && shelfX <= xoff - 10) || (shelfX >= xoff + 9 && shelfX <= xoff + 10)) && shelfY == yoff + 43)
			{
				Main.tile[shelfX, shelfY].active = true;
				Main.tile[shelfX, shelfY].type = 19;
				Main.tile[shelfX, shelfY - 1].active = true;
				Main.tile[shelfX, shelfY - 1].type = 50;
				int randomBook4 = WorldGen.genRand.Next(5);
				if (randomBook4 == 0)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)0;
				}
				else if (randomBook4 == 1)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)18;
				}
				else if (randomBook4 == 2)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)36;
				}
				else if (randomBook4 == 3)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)54;
				}
				else if (randomBook4 == 4)
				{
					int randomNum = Main.rand.Next(25);
					if (randomNum == 0)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else if (randomNum == 24)
					{
						Main.tile[shelfX, shelfY - 1].type = (ushort)Config.tileDefs.ID["DVS"];
						Main.tile[shelfX, shelfY - 1].frameX = (short)0;
						Main.tile[shelfX, shelfY - 1].frameY = (short)0;
					}
					else Main.tile[shelfX, shelfY - 1].frameX = (short)72;
				}
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 95%";
	for (int trapX = xoff - 50; trapX <= xoff + 50; trapX++)
	{
		for (int trapY = yoff - 37; trapY <= yoff + 37; trapY++)
		{
			if ((trapX == xoff - 12 || trapX == xoff - 11 || trapX == xoff + 11 || trapX == xoff + 12) && (trapY >= yoff - 19 && trapY <= yoff - 12))
			{
				Main.tile[trapX, trapY].active = true;
				Main.tile[trapX, trapY].type = brickI;
			}
			if ((trapX == xoff - 10 || trapX == xoff + 10) && trapY == yoff - 15)
			{
				Main.tile[trapX, trapY].active = true;
				Main.tile[trapX, trapY].type = 4;
				Main.tile[trapX, trapY].frameX = (short)0;
				Main.tile[trapX, trapY].frameY = (short)176;
			}
			if (((trapX >= xoff - 10 && trapX <= xoff - 8) || (trapX <= xoff + 10 && trapX >= xoff + 8)) && (trapY == yoff - 13 && trapY == yoff - 17))
			{
				Main.tile[trapX, trapY].active = true;
				Main.tile[trapX, trapY].type = 19;
				Main.tile[trapX, trapY - 1].active = true;
				Main.tile[trapX, trapY - 1].type = 50;
				int randomBook5 = WorldGen.genRand.Next(5);
				if (randomBook5 == 0)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[trapX, trapY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[trapX, trapY - 1].frameX = (short)0;
						Main.tile[trapX, trapY - 1].frameY = (short)0;
					}
					else Main.tile[trapX, trapY - 1].frameX = (short)0;
				}
				else if (randomBook5 == 1)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[trapX, trapY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[trapX, trapY - 1].frameX = (short)0;
						Main.tile[trapX, trapY - 1].frameY = (short)0;
					}
					else Main.tile[trapX, trapY - 1].frameX = (short)18;
				}
				else if (randomBook5 == 2)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[trapX, trapY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[trapX, trapY - 1].frameX = (short)0;
						Main.tile[trapX, trapY - 1].frameY = (short)0;
					}
					else Main.tile[trapX, trapY - 1].frameX = (short)36;
				}
				else if (randomBook5 == 3)
				{
					int randomNum = Main.rand.Next(25);
					if (randomNum == 0)
					{
						Main.tile[trapX, trapY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[trapX, trapY - 1].frameX = (short)0;
						Main.tile[trapX, trapY - 1].frameY = (short)0;
					}
					else if (randomNum == 24)
					{
						Main.tile[trapX, trapY - 1].type = (ushort)Config.tileDefs.ID["DVS"];
						Main.tile[trapX, trapY - 1].frameX = (short)0;
						Main.tile[trapX, trapY - 1].frameY = (short)0;
					}
					else Main.tile[trapX, trapY - 1].frameX = (short)54;
				}
				else if (randomBook5 == 4)
				{
					int randomNum = Main.rand.Next(25);
					if (randomNum == 0)
					{
						Main.tile[trapX, trapY - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[trapX, trapY - 1].frameX = (short)0;
						Main.tile[trapX, trapY - 1].frameY = (short)0;
					}
					else if (randomNum == 24)
					{
						Main.tile[trapX, trapY - 1].type = (ushort)Config.tileDefs.ID["DVS"];
						Main.tile[trapX, trapY - 1].frameX = (short)0;
						Main.tile[trapX, trapY - 1].frameY = (short)0;
					}
					else Main.tile[trapX, trapY - 1].frameX = (short)72;
				}
			}
			if ((trapX == xoff - 45 || trapX == xoff + 45) && trapY == yoff - 8)
			{
				Main.tile[trapX, trapY].active = true;
				if (trapX == xoff - 45)
				{
					WorldGen.PlaceTile(trapX, trapY, 137, true, true, -1, 1);
				}
				else WorldGen.PlaceTile(trapX, trapY, 137, true, true, -1, -1);
			}
			if (((trapX >= xoff - 44 && trapX <= xoff - 30) || (trapX <= xoff + 44 && trapX >= xoff + 30) || (trapX >= xoff - 12 && trapX <= xoff + 12)) && (trapY == yoff - 7 || trapY == yoff - 6))
			{
				Main.tile[trapX, trapY].active = true;
				Main.tile[trapX, trapY].type = brickI;
				if ((trapX == xoff - 8 || trapX == xoff + 8) && trapY == yoff - 7)
				{
					WorldGen.PlaceTile(trapX, trapY, 4, true, true, -1, 8);
				}
			}
			if (trapX == xoff && trapY == yoff - 8)
			{
				Main.tile[trapX, trapY].active = true;
				Main.tile[trapX, trapY].type = 135;
				Main.tile[trapX, trapY].frameX = (short)0;
				Main.tile[trapX, trapY].frameY = (short)36;
				//Main.tile[trapX, trapY + 1].type = 56;
			}
			if ((trapX >= xoff - 45 && trapX <= xoff + 45) && trapY == yoff - 8)
			{
				Main.tile[trapX, trapY].wire = true;
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 96%";
	for (int lanternX2 = xoff - 65; lanternX2 <= xoff + 65; lanternX2++)
	{
		for (int lanternY2 = yoff - 32; lanternY2 <= yoff + 55; lanternY2++)
		{
			if ((lanternX2 == xoff - 55 || lanternX2 == xoff + 55) && lanternY2 == yoff - 31)
			{
				WorldGen.Place1x2Top(lanternX2, lanternY2, 42);
			}
			if ((lanternX2 == xoff - 7 || lanternX2 == xoff + 7) && lanternY2 == yoff + 38)
			{
				WorldGen.Place1x2Top(lanternX2, lanternY2, 42);
			}
			if ((lanternX2 == xoff - 7 || lanternX2 == xoff + 7) && lanternY2 == yoff + 50)
			{
				Main.tile[lanternX2, lanternY2].active = true;
				Main.tile[lanternX2, lanternY2].type = 4;
				Main.tile[lanternX2, lanternY2].frameX = (short)0;
				Main.tile[lanternX2, lanternY2].frameY = (short)176;
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 97%";
	for (int trap2X = xoff - 17; trap2X <= xoff + 16; trap2X++)
	{
		for (int trap2Y = yoff + 38; trap2Y <= yoff + 55; trap2Y++)
		{
			if ((trap2X == xoff || trap2X == xoff - 1) && trap2Y == yoff + 46)
			{
				Main.tile[trap2X, trap2Y].active = true;
				Main.tile[trap2X, trap2Y].type = 135;
				Main.tile[trap2X, trap2Y].frameX = (short)0;
				Main.tile[trap2X, trap2Y].frameY = (short)36;
				//Main.tile[trap2X, trap2Y + 1].type = 56;
			}
			if ((trap2X == xoff - 12 || trap2X == xoff + 11) && trap2Y == yoff + 46)
			{
				if (trap2X == xoff - 12)
				{
					WorldGen.PlaceTile(trap2X, trap2Y, 137, true, true, -1, 1);
				}
				else WorldGen.PlaceTile(trap2X, trap2Y, 137, true, true, -1, -1);
			}
			if ((trap2X >= xoff - 12 && trap2X <= xoff + 11) && trap2Y == yoff + 46)
			{
				Main.tile[trap2X, trap2Y].wire = true;
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 98%";
	for (int statueX = xoff - 65; statueX <= xoff + 65; statueX++)
	{
		for (int statueY = yoff - 37; statueY <= yoff + 55; statueY++)
		{
			if ((statueX == xoff - 9 || statueX == xoff + 8) && statueY == yoff + 50)
			{
				WorldGen.PlaceTile(statueX, statueY, 105, true, true, -1, 13);
			}
			if ((statueX == xoff - 52 || statueX == xoff + 51) && statueY == yoff - 26)
			{
				WorldGen.PlaceTile(statueX, statueY, 105, true, true, -1, 14);
			}
			if ((statueX == xoff - 52 || statueX == xoff + 51) && statueY == yoff + 31)
			{
				WorldGen.PlaceTile(statueX, statueY, 105, true, true, -1, 36);
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 99%";
	for (int trap3X = xoff - 65; trap3X <= xoff + 65; trap3X++)
	{
		for (int trap3Y = yoff - 37; trap3Y <= yoff - 10; trap3Y++)
		{
			if ((trap3X == xoff - 54 || trap3X == xoff + 54) && trap3Y == yoff - 26)
			{
				Main.tile[trap3X, trap3Y].active = true;
				Main.tile[trap3X, trap3Y].type = 135;
				Main.tile[trap3X, trap3Y].frameX = (short)0;
				Main.tile[trap3X, trap3Y].frameY = (short)36;
				//Main.tile[trap3X, trap3Y + 1].type = 56;
			}
			if ((trap3X == xoff - 61 || trap3X == xoff + 61) && trap3Y == yoff - 26)
			{
				if (trap3X == xoff - 61)
				{
					WorldGen.PlaceTile(trap3X, trap3Y, 137, true, true, -1, 1);
				}
				else WorldGen.PlaceTile(trap3X, trap3Y, 137, true, true, -1, -1);
			}
			if (((trap3X >= xoff - 61 && trap3X <= xoff - 54) || (trap3X >= xoff + 54 && trap3X <= xoff + 61)) && trap3Y == yoff - 26)
			{
				Main.tile[trap3X, trap3Y].wire = true;
			}
		}
	}
	//Main.statusText = "Generating Hellcastle: 100%";
	Main.tile[xoff - 44, yoff - 12].active = true;
	Main.tile[xoff - 44, yoff - 12].type = 4;
	Main.tile[xoff - 44, yoff - 12].frameX = (short)24;
	Main.tile[xoff - 44, yoff - 12].frameY = (short)176;
	Main.tile[xoff + 44, yoff - 12].active = true;
	Main.tile[xoff + 44, yoff - 12].type = 4;
	Main.tile[xoff + 44, yoff - 12].frameX = (short)44;
	Main.tile[xoff + 44, yoff - 12].frameY = (short)176;
	Main.tile[xoff - 62, yoff + 1].active = true;
	Main.tile[xoff - 62, yoff + 1].type = 4;
	Main.tile[xoff - 62, yoff + 1].frameX = (short)0;
	Main.tile[xoff - 62, yoff + 1].frameY = (short)176;
	Main.tile[xoff + 62, yoff + 1].active = true;
	Main.tile[xoff + 62, yoff + 1].type = 4;
	Main.tile[xoff + 62, yoff + 1].frameX = (short)0;
	Main.tile[xoff + 62, yoff + 1].frameY = (short)176;
}

public static bool AddPlatinumChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
{
	if (WorldGen.genRand == null)
	{
		WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
	}
	int k = j;
	while (k < Main.maxTilesY)
	{
		if (Main.tile[i, k].active && Main.tileSolid[(int)Main.tile[i, k].type])
		{
			int num = k;
			int num2 = ModWorld.PlaceCustomChest(i - 1, num - 1, (ushort)Config.tileDefs.ID["Platinum Chest"], notNearOtherChests, 1);
			if (num2 >= 0)
			{
				int num3 = 0;
				while (num3 == 0)
				{
					if (contain > 0)
					{
						Main.chest[num2].item[num3].SetDefaults(contain, false);
						Main.chest[num2].item[num3].stack = WorldGen.genRand.Next(7, 15);
						num3++;
					}
					int randomNum = WorldGen.genRand.Next(3);
					if (randomNum == 0)
					{
						Main.chest[num2].item[num3].SetDefaults(Config.itemDefs.byName["Dragon Stone"].type, false);
						Main.chest[num2].item[num3].Prefix(-1);
						num3++;
					}
					else if (randomNum == 1)
					{
						Main.chest[num2].item[num3].SetDefaults(Config.itemDefs.byName["Hallowed Bar"].type, false);
						Main.chest[num2].item[num3].stack = WorldGen.genRand.Next(13) + 1;
						num3++;
					}
					else
					{
						Main.chest[num2].item[num3].SetDefaults(Config.itemDefs.byName["Greater Restoration Potion"].type, false);
						int numOfGRPotions = WorldGen.genRand.Next(12, 23);
						Main.chest[num2].item[num3].stack = numOfGRPotions;
						num3++;
					}
					Main.chest[num2].item[num3].SetDefaults(Config.itemDefs.byName["Dark Matter Ore"].type, false);
					int numOfOres = WorldGen.genRand.Next(22, 37);
					Main.chest[num2].item[num3].stack = numOfOres;
					Main.chest[num2].item[3].SetDefaults(Config.itemDefs.byName["Reinforced Glass"].type, false);
					int numOfBricks = WorldGen.genRand.Next(11, 55);
					Main.chest[num2].item[3].stack = numOfBricks;
					Main.chest[num2].item[4].SetDefaults(74, false);
					int numOfCoins = WorldGen.genRand.Next(1, 3);
					Main.chest[num2].item[4].stack = numOfCoins;
					int randomNum3 = WorldGen.genRand.Next(3);
					if (randomNum3 == 0)
					{
						Main.chest[num2].item[5].SetDefaults(Config.itemDefs.byName["Attraction Potion"].type, false);
						int numOfAPotions = WorldGen.genRand.Next(2, 4);
						Main.chest[num2].item[5].stack = numOfAPotions;
					}
					else if (randomNum3 == 1)
					{
						Main.chest[num2].item[5].SetDefaults(Config.itemDefs.byName["Invincibility Potion"].type, false);
						int numOfIPotions = WorldGen.genRand.Next(1, 4);
						Main.chest[num2].item[5].stack = numOfIPotions;
					}
					else
					{
						Main.chest[num2].item[5].SetDefaults(Config.itemDefs.byName["Strength Potion"].type, false);
						int numOfSPotions = WorldGen.genRand.Next(3, 5);
						Main.chest[num2].item[5].stack = numOfSPotions;
					}
					Main.chest[num2].item[6].SetDefaults(Config.itemDefs.byName["Blackened Flame"].type, false);
					Main.chest[num2].item[6].stack = (WorldGen.genRand.Next(2) + 1);
					//Main.chest[num2].item[7].SetDefaults(Config.itemDefs.byName["Instantanium Drill"].type, false);
					//Main.chest[num2].item[7].Prefix(-1);
					if (Main.rand.Next(40) == 0)
					{
						Main.chest[num2].item[7].SetDefaults(Config.itemDefs.byName["Soul Essence"].type, false);
						Main.chest[num2].item[7].stack = Main.rand.Next(2, 6);
					}
				}
				return true;
			}
			return false;
		}
		else
		{
			k++;
		}
	}
	return false;
}

public static bool AddHellfireChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
{
	if (WorldGen.genRand == null)
	{
		WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
	}
	int k = j;
	while (k < Main.maxTilesY)
	{
		if (Main.tile[i, k].active && Main.tileSolid[(int)Main.tile[i, k].type])
		{
			int num = k;
			int num2 = ModWorld.PlaceCustomChest(i - 1, num - 1, (ushort)Config.tileDefs.ID["Hellfire Chest"], notNearOtherChests, 1);
			if (num2 >= 0)
			{
				int num3 = 0;
				while (num3 == 0)
				{
					if (contain > 0)
					{
						Main.chest[num2].item[num3].SetDefaults(contain, false);
						Main.chest[num2].item[num3].Prefix(-1);
						num3++;
					}
					int randomNum = WorldGen.genRand.Next(7);
					if (randomNum == 0)
					{
						Main.chest[num2].item[num3].SetDefaults(Config.itemDefs.byName["Damage Emblem"].type, false);
						Main.chest[num2].item[num3].Prefix(-1);
						num3++;
					}
					else if (randomNum == 1)
					{
						Main.chest[num2].item[num3].SetDefaults(Config.itemDefs.byName["Spectrum Scimitar"].type, false);
						Main.chest[num2].item[num3].Prefix(-1);
						num3++;
					}
					else if (randomNum == 2)
					{
						Main.chest[num2].item[num3].SetDefaults(489, false);
						Main.chest[num2].item[num3].Prefix(-1);
						num3++;
					}
					else if (randomNum == 3)
					{
						Main.chest[num2].item[num3].SetDefaults(490, false);
						Main.chest[num2].item[num3].Prefix(-1);
						num3++;
					}
					else if (randomNum == 4)
					{
						Main.chest[num2].item[num3].SetDefaults(353, false);
						int numOfAles = WorldGen.genRand.Next(3) + 1;
						Main.chest[num2].item[num3].stack = numOfAles;
						num3++;
					}
					else if (randomNum == 5)
					{
						Main.chest[num2].item[num3].SetDefaults(Config.itemDefs.byName["Greater Restoration Potion"].type, false);
						int numOfGRPotions = WorldGen.genRand.Next(12, 23);
						Main.chest[num2].item[num3].stack = numOfGRPotions;
						num3++;
					}
					else
					{
						Main.chest[num2].item[num3].SetDefaults(491, false);
						Main.chest[num2].item[num3].Prefix(-1);
						num3++;
					}
					Main.chest[num2].item[num3].SetDefaults(Config.itemDefs.byName["Caesium Bar"].type, false);
					int numOfBars = WorldGen.genRand.Next(22, 37);
					Main.chest[num2].item[num3].stack = numOfBars;
					Main.chest[num2].item[3].SetDefaults(Config.itemDefs.byName["Impervious Brick"].type, false);
					int numOfBricks = WorldGen.genRand.Next(11, 55);
					Main.chest[num2].item[3].stack = numOfBricks;
					Main.chest[num2].item[4].SetDefaults(73, false);
					int numOfCoins = WorldGen.genRand.Next(45, 110);
					Main.chest[num2].item[4].stack = numOfCoins;
					int randomNum2 = WorldGen.genRand.Next(11);
					if (randomNum2 == 0)
					{
						Main.chest[num2].item[5].SetDefaults(391, false);
						int numOfBars2 = WorldGen.genRand.Next(10, 30);
						Main.chest[num2].item[5].stack = numOfBars2;
					}
					else if (randomNum2 == 1)
					{
						Main.chest[num2].item[5].SetDefaults(522, false);
						int numOfCF = WorldGen.genRand.Next(10, 30);
						Main.chest[num2].item[5].stack = numOfCF;
					}
					else if (randomNum2 == 2)
					{
						Main.chest[num2].item[5].SetDefaults(Config.itemDefs.byName["Soul of Delight"].type, false);
						int numOfSD = WorldGen.genRand.Next(3, 8);
						Main.chest[num2].item[5].stack = numOfSD;
					}
					else if (randomNum2 == 3)
					{
						Main.chest[num2].item[5].SetDefaults(Config.itemDefs.byName["Soul of Plight"].type, false);
						int numOfSP = WorldGen.genRand.Next(3, 8);
						Main.chest[num2].item[5].stack = numOfSP;
					}
					else if (randomNum2 == 4)
					{
						Main.chest[num2].item[5].SetDefaults(575, false);
						int numOfSoFl = WorldGen.genRand.Next(5, 7);
						Main.chest[num2].item[5].stack = numOfSoFl;
					}
					else if (randomNum2 == 5)
					{
						Main.chest[num2].item[5].SetDefaults(547, false);
						int numOfSoFr = WorldGen.genRand.Next(5, 7);
						Main.chest[num2].item[5].stack = numOfSoFr;
					}
					else if (randomNum2 == 6)
					{
						Main.chest[num2].item[5].SetDefaults(548, false);
						int numOfSoM = WorldGen.genRand.Next(5, 7);
						Main.chest[num2].item[5].stack = numOfSoM;
					}
					else if (randomNum2 == 7)
					{
						Main.chest[num2].item[5].SetDefaults(549, false);
						int numOfSoS = WorldGen.genRand.Next(5, 7);
						Main.chest[num2].item[5].stack = numOfSoS;
					}
					else if (randomNum2 == 8)
					{
						Main.chest[num2].item[5].SetDefaults(520, false);
						int numOfSoL = WorldGen.genRand.Next(5, 7);
						Main.chest[num2].item[5].stack = numOfSoL;
					}
					else if (randomNum2 == 9)
					{
						Main.chest[num2].item[5].SetDefaults(521, false);
						int numOfSoN = WorldGen.genRand.Next(5, 7);
						Main.chest[num2].item[5].stack = numOfSoN;
					}
					else
					{
						Main.chest[num2].item[5].SetDefaults(Config.itemDefs.byName["Soul of Height"].type, false);
						int numOfSH = WorldGen.genRand.Next(3, 8);
						Main.chest[num2].item[5].stack = numOfSH;
					}
					int randomNum3 = WorldGen.genRand.Next(4);
					if (randomNum3 == 0)
					{
						Main.chest[num2].item[6].SetDefaults(Config.itemDefs.byName["Attraction Potion"].type, false);
						int numOfAPotions = WorldGen.genRand.Next(2, 4);
						Main.chest[num2].item[6].stack = numOfAPotions;
					}
					else if (randomNum3 == 1)
					{
						Main.chest[num2].item[6].SetDefaults(Config.itemDefs.byName["Invincibility Potion"].type, false);
						int numOfIPotions = WorldGen.genRand.Next(1, 4);
						Main.chest[num2].item[6].stack = numOfIPotions;
					}
					else if (randomNum == 2)
					{
						Main.chest[num2].item[6].SetDefaults(Config.itemDefs.byName["Strength Potion"].type, false);
						int numOfSPotions = WorldGen.genRand.Next(3, 5);
						Main.chest[num2].item[6].stack = numOfSPotions;
					}
					else
					{
						Main.chest[num2].item[6].SetDefaults(437, false);
					}
					Main.chest[num2].item[7].SetDefaults(Config.itemDefs.byName["Golden Flame"].type, false);
					Main.chest[num2].item[7].stack = (WorldGen.genRand.Next(2) + 1);
				}
				return true;
			}
			return false;
		}
		else
		{
			k++;
		}
	}
	return false;
}

public static bool AddIceCaveChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
{
	if (WorldGen.genRand == null)
	{
		WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
	}
	int k = j;
	while (k < Main.maxTilesY)
	{
		if (Main.tile[i, k].active && Main.tileSolid[(int)Main.tile[i, k].type])
		{
			int num = k;
			int num2 = WorldGen.PlaceChest(i - 1, num - 1, 21, notNearOtherChests, 1);
			if (num2 >= 0)
			{
				int num3 = 0;
				while (num3 == 0)
				{
					if (contain > 0)
					{
						Main.chest[num2].item[num3].SetDefaults(contain, false);
						if (contain == Config.itemDefs.byName["White Gel"].type)
						{
							Main.chest[num2].item[num3].stack = WorldGen.genRand.Next(5, 11);
						}
						else if (contain == Config.itemDefs.byName["Water Shard"].type)
						{
							Main.chest[num2].item[num3].stack = WorldGen.genRand.Next(2, 3);
						}
						else if (contain == 73)
						{
							Main.chest[num2].item[num3].stack = WorldGen.genRand.Next(1, 2);
						}
						else if (contain == Config.itemDefs.byName["Icy Greatsword"].type)
						{
							Main.chest[num2].item[num3].Prefix(-1);
						}
						num3++;
					}
					int randomNum = WorldGen.genRand.Next(3);
					if (randomNum == 0)
					{
						Main.chest[num2].item[num3].SetDefaults(50, false);
						num3++;
					}
					else if (randomNum == 1)
					{
						Main.chest[num2].item[num3].SetDefaults(287, false);
						Main.chest[num2].item[num3].stack = WorldGen.genRand.Next(31, 53);
						num3++;
					}
					else if (randomNum == 2)
					{
						Main.chest[num2].item[num3].SetDefaults(126, false);
						Main.chest[num2].item[num3].stack = WorldGen.genRand.Next(7, 14);
						num3++;
					}
					Main.chest[num2].item[num3].SetDefaults(57, false);
					int numOfBars = WorldGen.genRand.Next(6, 19);
					Main.chest[num2].item[3].stack = numOfBars;
					int randomNum2 = WorldGen.genRand.Next(3);
					if (randomNum2 == 0)
					{
						Main.chest[num2].item[3].SetDefaults(118, false);
					}
					else if (randomNum2 == 1)
					{
						Main.chest[num2].item[3].SetDefaults(28, false);
						Main.chest[num2].item[3].stack = WorldGen.genRand.Next(1, 6);
					}
					else if (randomNum2 == 2)
					{
						Main.chest[num2].item[3].SetDefaults(166, false);
						Main.chest[num2].item[3].stack = WorldGen.genRand.Next(7, 14);
					}
					Main.chest[num2].item[4].SetDefaults(73, false);
					int numOfCoins = WorldGen.genRand.Next(1, 3);
					Main.chest[num2].item[4].stack = numOfCoins;
				}
				return true;
			}
			return false;
		}
		else
		{
			k++;
		}
	}
	return false;
}

public static void HeartStonePatch(int i, int j)
{
	double num = (double)WorldGen.genRand.Next(10, 30);
	double num2 = num;
	float num3 = (float)WorldGen.genRand.Next(10, 15);
	if (WorldGen.genRand.Next(5) == 0)
	{
		num *= 1.5;
		num2 *= 1.5;
		num3 *= 1.2f;
	}
	Vector2 value;
	value.X = (float)i;
	value.Y = (float)j - num3 * 0.3f;
	Vector2 value2;
	value2.X = (float)WorldGen.genRand.Next(-5, 6) * 0.1f;
	value2.Y = (float)WorldGen.genRand.Next(-10, -5) * 0.1f;
	while (num > 0.0 && num3 > 0f)
	{
		num -= (double)WorldGen.genRand.Next(3);
		num3 -= 1f;
		int num4 = (int)((double)value.X - num * 0.5);
		int num5 = (int)((double)value.X + num * 0.5);
		int num6 = (int)((double)value.Y - num * 0.5);
		int num7 = (int)((double)value.Y + num * 0.5);
		if (num4 < 0)
		{
			num4 = 0;
		}
		if (num5 > Main.maxTilesX)
		{
			num5 = Main.maxTilesX;
		}
		if (num6 < 0)
		{
			num6 = 0;
		}
		if (num7 > Main.maxTilesY)
		{
			num7 = Main.maxTilesY;
		}
		num2 = num * (double)WorldGen.genRand.Next(80, 120) * 0.01;
		for (int k = num4; k < num5; k++)
		{
			for (int l = num6; l < num7; l++)
			{
				float num8 = Math.Abs((float)k - value.X);
				float num9 = Math.Abs(((float)l - value.Y) * 2.3f);
				double num10 = Math.Sqrt((double)(num8 * num8 + num9 * num9));
				if (num10 < num2 * 0.4)
				{
					if ((double)l < (double)value.Y + num2 * 0.02)
					{
						if (Main.tile[k, l].type != 59)
						{
							Main.tile[k, l].active = false;
						}
					}
					else
					{
						Main.tile[k, l].type = 59;
					}
					Main.tile[k, l].liquid = 0;
					Main.tile[k, l].lava = false;
				}
			}
		}
		value += value2;
		value.X += value2.X;
		value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
		value2.Y -= (float)WorldGen.genRand.Next(11) * 0.05f;
		if ((double)value2.X > -0.5 && (double)value2.X < 0.5)
		{
			if (value2.X < 0f)
			{
				value2.X = -0.5f;
			}
			else
			{
				value2.X = 0.5f;
			}
		}
		if (value2.X > 2f)
		{
			value2.X = 1f;
		}
		if (value2.X < -2f)
		{
			value2.X = -1f;
		}
		if (value2.Y > 1f)
		{
			value2.Y = 1f;
		}
		if (value2.Y < -1f)
		{
			value2.Y = -1f;
		}
		for (int m = 0; m < 2; m++)
		{
			int num11 = (int)value.X + WorldGen.genRand.Next(-20, 20);
			int num12 = (int)value.Y + WorldGen.genRand.Next(0, 20);
			while (!Main.tile[num11, num12].active && Main.tile[num11, num12].type != 59)
			{
				num11 = (int)value.X + WorldGen.genRand.Next(-10, 10);
				num12 = (int)value.Y + WorldGen.genRand.Next(0, 10);
			}
			int num13 = WorldGen.genRand.Next(7, 10);
			int num14 = WorldGen.genRand.Next(7, 10);
			WorldGen.TileRunner(num11, num12, (double)num13, num14, Config.tileDefs.ID["Heartstone"], true, 0f, 2f, true, true);
			if (WorldGen.genRand.Next(3) == 0)
			{
				WorldGen.TileRunner(num11, num12, (double)(num13 - 3), num14 - 3, -1, false, 0f, 2f, true, true);
			}
			if (WorldGen.genRand.Next(5) == 0)
			{
				WorldGen.AddLifeCrystal(num11, num12);
			}
		}
	}
}

/*public static void generateIceCave(int x, int y)
{
	//bool madeChest = false;
	for (int xoff = x - 30; xoff <= x + 30; xoff++)
	{
		for (int yoff = y - 30; yoff <= y + 30; yoff++)
		{
			if (xoff < 0) xoff = 0;
			if (xoff > (int)Main.maxTilesX) xoff = (int)Main.maxTilesX;
			if (yoff < (int)Main.rockLayer) yoff = (int)Main.rockLayer;
			if (yoff > (int)(Main.maxTilesY - 200)) yoff = (int)(Main.maxTilesY - 200);
			if (Main.tile[xoff, yoff].active && (Main.tile[xoff, yoff].type == 0 || Main.tile[xoff, yoff].type == 1 || Main.tile[xoff, yoff].type == 59))
			{
				Main.tile[xoff, yoff].type = (ushort)Config.tileDefs.ID["Ice Block"];
			}
		}
	}
	for (int x2 = x - 35; x2 < x - 31; x2++)
	{
		for (int y2 = y - 30; y2 <= y + 30; y2++)
		{
			if (x2 < 0) x2 = 0;
			if (x2 > (int)Main.maxTilesX) x2 = (int)Main.maxTilesX;
			if (y2 < (int)Main.rockLayer) y2 = (int)Main.rockLayer;
			if (y2 > (int)(Main.maxTilesY - 200)) y2 = (int)(Main.maxTilesY - 200);
			if (Main.tile[x2, y2].active && (Main.tile[x2, y2].type == 0 || Main.tile[x2, y2].type == 1 || Main.tile[x2, y2].type == 59))
			{
				if (WorldGen.genRand.Next(2) == 0)
				{
					Main.tile[x2, y2].type = (ushort)Config.tileDefs.ID["Ice Block"];
				}
			}
		}
	}
	for (int x3 = x + 31; x3 < x + 35; x3++)
	{
		for (int y3 = y - 30; y3 <= y + 30; y3++)
		{
			if (x3 < 0) x3 = 0;
			if (x3 > (int)Main.maxTilesX) x3 = (int)Main.maxTilesX;
			if (y3 < (int)Main.rockLayer) y3 = (int)Main.rockLayer;
			if (y3 > (int)(Main.maxTilesY - 200)) y3 = (int)(Main.maxTilesY - 200);
			if (Main.tile[x3, y3].active && (Main.tile[x3, y3].type == 0 || Main.tile[x3, y3].type == 1 || Main.tile[x3, y3].type == 59))
			{
				if (WorldGen.genRand.Next(2) == 0)
				{
					Main.tile[x3, y3].type = (ushort)Config.tileDefs.ID["Ice Block"];
				}
			}
		}
	}
	for (int x4 = x - 30; x4 <= x + 30; x4++)
	{
		for (int y4 = y - 35; y4 < y - 31; y4++)
		{
			if (x4 < 0) x4 = 0;
			if (x4 > (int)Main.maxTilesX) x4 = (int)Main.maxTilesX;
			if (y4 < (int)Main.rockLayer) y4 = (int)Main.rockLayer;
			if (y4 > (int)(Main.maxTilesY - 200)) y4 = (int)(Main.maxTilesY - 200);
			if (Main.tile[x4, y4].active && (Main.tile[x4, y4].type == 0 || Main.tile[x4, y4].type == 1 || Main.tile[x4, y4].type == 59))
			{
				if (WorldGen.genRand.Next(2) == 0)
				{
					Main.tile[x4, y4].type = (ushort)Config.tileDefs.ID["Ice Block"];
				}
			}
		}
	}
	for (int x5 = x - 30; x5 <= x + 30; x5++)
	{
		for (int y5 = y + 31; y5 < y + 35; y5++)
		{
			if (x5 < 0) x5 = 0;
			if (x5 > (int)Main.maxTilesX) x5 = (int)Main.maxTilesX;
			if (y5 < (int)Main.rockLayer) y5 = (int)Main.rockLayer;
			if (y5 > (int)(Main.maxTilesY - 200)) y5 = (int)(Main.maxTilesY - 200);
			if (Main.tile[x5, y5].active && (Main.tile[x5, y5].type == 0 || Main.tile[x5, y5].type == 1 || Main.tile[x5, y5].type == 59))
			{
				if (WorldGen.genRand.Next(2) == 0)
				{
					Main.tile[x5, y5].type = (ushort)Config.tileDefs.ID["Ice Block"];
				}
			}
		}
	}
}*/

public static void Make3x3Circle(int x, int y, ushort type)
{
	for (int xoff = x - 1; xoff <= x + 1; xoff++)
	{
		for (int yoff = y - 1; yoff <= y + 1; yoff++)
		{
			Main.tile[xoff, yoff].active = true;
			Main.tile[xoff, yoff].type = type;
			WorldGen.SquareTileFrame(xoff, yoff);
		}
	}
	Main.tile[x - 2, y].active = true;
	Main.tile[x + 2, y].active = true;
	Main.tile[x, y - 2].active = true;
	Main.tile[x, y + 2].active = true;
	Main.tile[x - 2, y].type = type;
	Main.tile[x + 2, y].type = type;
	Main.tile[x, y - 2].type = type;
	Main.tile[x, y + 2].type = type;
	WorldGen.SquareTileFrame(x - 2, y);
	WorldGen.SquareTileFrame(x + 2, y);
	WorldGen.SquareTileFrame(x, y - 2);
	WorldGen.SquareTileFrame(x, y + 2);
}
#region ExternalInitAchievementsDelegates
// achievement stuff
// for Shockah's Achievements mod: http://www.terrariaonline.com/threads/shockahs-mods.93134/
public static void ExternalInitAchievementsDelegates(
	Action<string, string, string, string, string, int, Texture2D, bool> AddAchievement,
	Action<string[], int> ConfigNetMode,
	Action<string[], int> ConfigDifficulty,
	Action<string[], int> ConfigHardmode,
	Action<string, object, Func<object, object, string>> ConfigProgress,
	Func<string, bool> GetAchieved,
	Func<string, Texture2D, bool> Achieve,
	Action<int, string> AchievePlayer,
	Action<string> AchieveAllPlayers,
	Func<string, object[]> GetProgress,
	Func<string, object, Texture2D, bool> SetProgress,
	Func<string, object, Texture2D, bool> Progress,
	Action<int, string, object> ProgressPlayer,
	Action<string, object> ProgressAllPlayers,
	Func<string, object[]> GetAchievementInfo)
    {
	    ModPlayer.ExternalInitAchievementsDelegates(AddAchievement, ConfigNetMode, ConfigDifficulty, ConfigHardmode, ConfigProgress, GetAchieved, Achieve, AchievePlayer, AchieveAllPlayers, GetProgress, SetProgress, Progress, ProgressPlayer, ProgressAllPlayers, GetAchievementInfo);
    }
#endregion
#region StartWraithInvasion
public static void StartWraithInvasion() {
    Main.bloodMoon = true;
    WraithInvasion = true;
    WraithInvasionCount = 0;
    if (Main.netMode == 0) Main.NewText("The Wraith Legion is approaching from the north!", 255, 50, 175);
    else if (Main.netMode == 2) NetMessage.SendData(25, -1, -1, "The Wraith Legion is approaching from the north!", 255, 255f, 50f, 175f, 0);
}
#endregion
#region EndWraithInvasion
public static void EndWraithInvasion() {
    Main.bloodMoon = false;
    WraithInvasion = false;
    WraithInvasionCount = 0;
    if (Main.netMode == 0) Main.NewText("The Wraith Legion has been defeated!", 255, 50, 175);
    else if (Main.netMode == 2) NetMessage.SendData(25, -1, -1, "The Wraith Legion has been defeated!", 255, 255f, 50f, 175f, 0);
    if (Main.netMode == 0) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_EVENT_WRAITH", null});
    else if (Main.netMode == 2) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_SHM_EVENT_WRAITH"});
}
#endregion
#region KillTile
public void KillTile(int x, int y, Player P) {
    if (P == null) return;
	if (P.whoAmi != Main.myPlayer) return;
    Tile T = Main.tile[x, y];
    if (Main.netMode == 0) {
        if (T.type == (ushort)Config.tileDefs.ID["Titanium Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_MINE_TITANIUM", null});
        if (T.type == (ushort)Config.tileDefs.ID["Jungle Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_MINE_JUNGLE", null});
        if (T.type == (ushort)Config.tileDefs.ID["Caesium Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_MINE_CAESIUM", null});
        if (T.type == (ushort)Config.tileDefs.ID["Hallowed Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_MINE_HALLOW", null});
        if (T.type == (ushort)Config.tileDefs.ID["Corrupted Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_MINE_CORRUPT", null});
        if (T.type == (ushort)Config.tileDefs.ID["Magmatic Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_MINE_MAGMATIC", null});
        if (T.type == (ushort)Config.tileDefs.ID["Oblivion Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_MINE_OBLIVION", null});
	if (T.type == (ushort)Config.tileDefs.ID["Ever Ice"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_MINE_EVERICE", null});
	if (T.type == (ushort)Config.tileDefs.ID["Dark Matter"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_MINE_DARK_MATTER", null});
	if (T.type == (ushort)Config.tileDefs.ID["Opal"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_MINE_OPAL", null});
    }
    else {
        if (T.type == (ushort)Config.tileDefs.ID["Titanium Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_MINE_TITANIUM"});
        if (T.type == (ushort)Config.tileDefs.ID["Jungle Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_MINE_JUNGLE"});
        if (T.type == (ushort)Config.tileDefs.ID["Caesium Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_MINE_CAESIUM"});
        if (T.type == (ushort)Config.tileDefs.ID["Hallowed Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_MINE_HALLOW"});
        if (T.type == (ushort)Config.tileDefs.ID["Corrupted Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_MINE_CORRUPT"});
        if (T.type == (ushort)Config.tileDefs.ID["Magmatic Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_SHM_MINE_MAGMATIC"});
        if (T.type == (ushort)Config.tileDefs.ID["Oblivion Ore"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_SHM_MINE_OBLIVION"});
	if (T.type == (ushort)Config.tileDefs.ID["Ever Ice"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_SHM_MINE_EVERICE"});
	if (T.type == (ushort)Config.tileDefs.ID["Dark Matter"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_SHM_MINE_DARK_MATTER"});
	if (T.type == (ushort)Config.tileDefs.ID["Opal"]) Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {P.whoAmi, "AVALON_SHM_MINE_OPAL"});
    }
	if (T.type == (ushort)Config.tileDefs.ID["Primordial Ore"])
	{
		int result = Main.rand.Next(18);
		int a = 0;
		if (result == 0)
		{
			for (int i = 0; i < 5; i++)
			{
				a = Item.NewItem(x*16, y*16, 16, 16, 12, 1, false);
				NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
			}
		}
		else if (result == 1)
		{
			for (int i = 0; i < 4; i++)
			{
				a = Item.NewItem(x*16, y*16, 16, 16, 11, 1, false);
				NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
			}
		}
		else if (result == 2)
		{
			for (int i = 0; i < 3; i++)
			{
				a = Item.NewItem(x*16, y*16, 16, 16, 14, 1, false);
				NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
			}
		}
		else if (result == 3)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, 13, 2, false);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 4)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, 56, 2, false);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 5)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, 116, 2, false);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 6)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, 174, 2, false);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 7)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, 173, 2, false);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 8)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, 364, 1, false);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 9)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, 365, 1, false);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 10)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, 366, 1, false);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 11)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, Config.itemDefs.byName["Caesium Ore"].type, 1);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 12)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, Config.itemDefs.byName["Hallowed Ore"].type, 1);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 13)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, Config.itemDefs.byName["Corrupted Ore"].type, 1);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 14)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, Config.itemDefs.byName["Ever Ice"].type, 1);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 15)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, Config.itemDefs.byName["Magmatic Ore"].type, 1);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 16)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, Config.itemDefs.byName["Oblivion Ore"].type, 1);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
		else if (result == 17)
		{
			a = Item.NewItem(x*16, y*16, 16, 16, Config.itemDefs.byName["Primordial Ore"].type, 1);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
	}
	if (T.type == 3 && T.frameX != 144)
	{
		bool flag2 = false;
		foreach (Item I in Main.player[Main.myPlayer].inventory)
		{
			if (I == null || I.type == 0) continue;
			if (I.name.Contains("Blowpipe"))
			{
				flag2 = true;
				break;
			}
		}
		if (flag2)
		{
			int a = Item.NewItem(x*16, y*16, 16, 16, 283, 1, false, 0);
			NetMessage.SendData(21, -1, -1, "", a, 0f, 0f, 0f, 0);
		}
	}
}
#endregion

#region new ice caves
public static void GrowIceCave(int x, int y, ushort type, int rounds)
{
	int growth = Main.rand.Next(256);
	
	for (int i = 0; i < 9; i++)
	{
		int j = i % 3;
		int tgro = 1 << i;
		if ((tgro & growth) == tgro){
			int tx = (x + j - 1);
			int ty = (int)(y + (i / 3) - 1);
			
			if (Main.tile[tx,ty].active)
			{
				Main.tile[tx,ty].active = true;
				Main.tile[tx,ty].type = type;
				WorldGen.SquareTileFrame(tx,ty);
				if (rounds > 0)
				{
					ModWorld.GrowFragile(tx,ty,type, rounds-1);
				}
			}
		}
	}
	WorldGen.SquareTileFrame(x,y);
}

public static void MakeIceCave(int x, int y)
{
	int xsave = x;
	int ysave = y;
	if (x < 30) x = 30;
	if (x > Main.maxTilesX - 30) x = Main.maxTilesX - 30;
	if (y < (int)Main.rockLayer) y = (int)Main.rockLayer;
	if (y > Main.maxTilesY - 200) y = Main.maxTilesY - 200;
	/*for (int stuff = 100; stuff < y; stuff++)
	{
		Main.tile[x, stuff].type = (ushort)Config.tileDefs.ID["Ice Block"];
		WorldGen.SquareTileFrame(x, stuff);
	}*/
	int thing = 0;
	while (thing < 9)
	{
		ModWorld.GrowIceCave(x,y, (ushort)Config.tileDefs.ID["Ice Block"], 3);
		ModWorld.GrowIceCave(x,y-2, (ushort)Config.tileDefs.ID["Ice Block"], 7);
		ModWorld.GrowIceCave(x+1,y, (ushort)Config.tileDefs.ID["Ice Block"], 3);
		ModWorld.GrowIceCave(x,y, (ushort)Config.tileDefs.ID["Ice Block"], 4);
		ModWorld.GrowIceCave(x-1,y, (ushort)Config.tileDefs.ID["Ice Block"], 3);
		ModWorld.GrowIceCave(x,y, (ushort)Config.tileDefs.ID["Ice Block"], 4);
		ModWorld.GrowIceCave(x+3,y, (ushort)Config.tileDefs.ID["Ice Block"], 2);
		ModWorld.GrowIceCave(x-3,y, (ushort)Config.tileDefs.ID["Ice Block"], 2);

		ModWorld.GrowIceCave(x+2,y-1, (ushort)Config.tileDefs.ID["Ice Block"], 8);
		ModWorld.GrowIceCave(x-1,y+2, (ushort)Config.tileDefs.ID["Ice Block"], 9);
		ModWorld.GrowIceCave(x+1,y, (ushort)Config.tileDefs.ID["Ice Block"], 8);
		ModWorld.GrowIceCave(x+3,y-3, (ushort)Config.tileDefs.ID["Ice Block"], 6);
		ModWorld.GrowIceCave(x-2,y, (ushort)Config.tileDefs.ID["Ice Block"], 9);
		ModWorld.GrowIceCave(x-4,y+2, (ushort)Config.tileDefs.ID["Ice Block"], 8);
		ModWorld.GrowIceCave(x-3,y+1, (ushort)Config.tileDefs.ID["Ice Block"], 5);
		ModWorld.GrowIceCave(x-3,y-1, (ushort)Config.tileDefs.ID["Ice Block"], 5);

		ModWorld.GrowIceCave(x+5,y-2, (ushort)Config.tileDefs.ID["Ice Block"], 9);
		ModWorld.GrowIceCave(x-4,y+1, (ushort)Config.tileDefs.ID["Ice Block"], 10);
		ModWorld.GrowIceCave(x+2,y-1, (ushort)Config.tileDefs.ID["Ice Block"], 7);
		ModWorld.GrowIceCave(x+3,y-2, (ushort)Config.tileDefs.ID["Ice Block"], 8);
		ModWorld.GrowIceCave(x,y+3, (ushort)Config.tileDefs.ID["Ice Block"], 9);
		ModWorld.GrowIceCave(x-3,y+2, (ushort)Config.tileDefs.ID["Ice Block"], 8);
		ModWorld.GrowIceCave(x-3,y+2, (ushort)Config.tileDefs.ID["Ice Block"], 6);
		ModWorld.GrowIceCave(x-3,y-2, (ushort)Config.tileDefs.ID["Ice Block"], 6);

		switch (thing)
		{
			case 0:
				x+=6;
				y-=6;
				break;
			case 1:
				x+=6;
				y+=6;
				break;
			case 2:
				x-=6;
				y+=6;
				break;
			case 3:
				x-=6;
				y-=6;
				break;
			case 4:
				x = xsave + 18;
				y = ysave - 12;
				break;
			case 5:
				x+=6;
				y+=6;
				break;
			case 6:
				x-=6;
				y+=6;
				break;
			case 7:
				x-=6;
				y-=6;
				break;
			default:
				break;
		}
		thing++;
	}
}
#endregion


#region clouds
public static void MakeCloud(int x, int y)
{

	ModWorld.GrowWall(x,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x,y-3,(ushort)Config.wallDefs.ID["CloudWall"], 8);
	ModWorld.GrowFragile(x,y-2, (ushort)Config.tileDefs.ID["Cloud"], 7);
	ModWorld.GrowWall(x+2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x+1,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x+1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 4);
	ModWorld.GrowWall(x-2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x-1,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x-1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 4);
	ModWorld.GrowWall(x+4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3);
	ModWorld.GrowFragile(x+3,y, (ushort)Config.tileDefs.ID["Cloud"], 2);
	ModWorld.GrowWall(x-4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3);
	ModWorld.GrowFragile(x-3,y, (ushort)Config.tileDefs.ID["Cloud"], 2);

	/* ModWorld.GrowWall(x,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowWall(x,y-3,(ushort)Config.wallDefs.ID["CloudWall"], 8);
	ModWorld.GrowWall(x+2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowWall(x+1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowWall(x-2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowWall(x-1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowWall(x+4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3);
	ModWorld.GrowWall(x-4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3); */

	
	x+=6;
	y-=6;

	ModWorld.GrowWall(x,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x,y-3,(ushort)Config.wallDefs.ID["CloudWall"], 8);
	ModWorld.GrowFragile(x,y-2, (ushort)Config.tileDefs.ID["Cloud"], 7);
	ModWorld.GrowWall(x+2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x+1,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x+1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 4);
	ModWorld.GrowWall(x-2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x-1,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x-1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 4);
	ModWorld.GrowWall(x+4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3);
	ModWorld.GrowFragile(x+3,y, (ushort)Config.tileDefs.ID["Cloud"], 2);
	ModWorld.GrowWall(x-4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3);
	ModWorld.GrowFragile(x-3,y, (ushort)Config.tileDefs.ID["Cloud"], 2);	

	/* ModWorld.GrowWall(x,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowWall(x,y-3,(ushort)Config.wallDefs.ID["CloudWall"], 8);
	ModWorld.GrowWall(x+2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowWall(x+1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowWall(x-2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowWall(x-1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowWall(x+4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3);
	ModWorld.GrowWall(x-4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3); */

	y+=6;
	x+=6;

	ModWorld.GrowWall(x,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x,y-3,(ushort)Config.wallDefs.ID["CloudWall"], 8);
	ModWorld.GrowFragile(x,y-2, (ushort)Config.tileDefs.ID["Cloud"], 7);
	ModWorld.GrowWall(x+2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x+1,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x+1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 4);
	ModWorld.GrowWall(x-2,y,(ushort)Config.wallDefs.ID["CloudWall"], 4);
	ModWorld.GrowFragile(x-1,y, (ushort)Config.tileDefs.ID["Cloud"], 3);
	ModWorld.GrowWall(x-1,y,(ushort)Config.wallDefs.ID["CloudWall"], 5);
	ModWorld.GrowFragile(x,y, (ushort)Config.tileDefs.ID["Cloud"], 4);
	ModWorld.GrowWall(x+4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3);
	ModWorld.GrowFragile(x+3,y, (ushort)Config.tileDefs.ID["Cloud"], 2);
	ModWorld.GrowWall(x-4,y,(ushort)Config.wallDefs.ID["CloudWall"], 3);
	ModWorld.GrowFragile(x-3,y, (ushort)Config.tileDefs.ID["Cloud"], 2);
}

public static void CloudPlatform()
{	
	int i = Main.rand.Next(30, Main.maxTilesX-30);
	int j = Main.rand.Next(100,150);
	
	if (Main.tile[i,j].wall == (byte)Config.wallDefs.ID["CloudWall"])
	{
		ModWorld.GrowFragile(i,j,(ushort)Config.tileDefs.ID["Cloud"], 5);
		ModWorld.GrowFragile(i+2,j,(ushort)Config.tileDefs.ID["Cloud"], 5);
	}
}
public static void GrowFragile(int x, int y, ushort type, int rounds)
{
	int growth = Main.rand.Next(256);
	
	for (int i = 0; i < 9; i++)
	{
		int j = i % 3;
		//bool doit = true;
		int tgro = 1 << i;
		if ((tgro & growth) == tgro){
			int tx = (x + j - 1);
			int ty = (int)(y + (i / 3) - 1);
			
			if (!Main.tile[tx,ty].active)
			{
				Main.tile[tx,ty].active = true;
				Main.tile[tx,ty].type = type;
				WorldGen.SquareTileFrame(tx,ty);
				if (rounds > 0)
				{
					ModWorld.GrowFragile(tx,ty,type, rounds-1);
				}
			}
		}
	}
	WorldGen.SquareTileFrame(x,y);
}
public static void GrowWall(int x, int y, ushort type, int rounds){
	int growth = Main.rand.Next(256);
	
	for (int i = 0; i < 9; i++)
	{
		int j = i % 3;
		bool doit = true;
		int tgro = 1 << i;
		if ((tgro & growth) == tgro)
		{
			int tx = (x + j - 1);
			int ty = (int)(y + (i / 3) - 1);
				
			if (Main.tile[tx,ty].wall == 0)
			{
					
				Main.tile[tx,ty].wall = (byte)type;
				if (rounds > 0)
				{
					ModWorld.GrowWall(tx,ty,type, rounds-1);
				}
			}
		}
	}
	WorldGen.SquareWallFrame(x,y);
}
#endregion

public static void SpreadCustomGrassOverSurface(int i, int j, int dirt = 0, int grass = 2)
{
	if ((int)Main.tile[i, j].type == dirt && Main.tile[i, j].active)
	{
		int j2 = 0;
		int i2 = 0;
		int j3 = 0;
		int i3 = 0;
		if (j - 1 < 0) j2 = 0;
		else j2 = j - 1;
		if (j + 1 > Main.maxTilesY - 200) j2 = Main.maxTilesY - 200;
		else j3 = j + 1;
		if (i - 1 < 0) i2 = 0;
		else i2 = i - 1;
		if (i + 1 > Main.maxTilesX) i3 = Main.maxTilesX;
		else i3 = i + 1;
		if (!Main.tile[i, j2].active && j < Main.worldSurface)
		{
			Main.tile[i, j].type = (ushort)grass;
			WorldGen.SquareTileFrame(i, j);
		}
		if (!Main.tile[i, j3].active && j < Main.worldSurface)
		{
			Main.tile[i, j].type = (ushort)grass;
			WorldGen.SquareTileFrame(i, j);
		}
		if (!Main.tile[i2, j].active && j < Main.worldSurface)
		{
			Main.tile[i, j].type = (ushort)grass;
			WorldGen.SquareTileFrame(i, j);
		}
		if (!Main.tile[i3, j].active && j < Main.worldSurface)
		{
			Main.tile[i, j].type = (ushort)grass;
			WorldGen.SquareTileFrame(i, j);
		}
	}
}

#region SpreadCustomGrass
public static void SpreadCustomGrass(int i, int j, int dirt = 0, int grass = 2, bool repeat = true)
{
	try
	{
		//if (((int)Main.tile[i - 1, j].type == dirt && Main.tile[i - 1, j].active) || ((int)Main.tile[i + 1, j].type == dirt && Main.tile[i + 1, j].active))
		if ((int)Main.tile[i, j].type == dirt && Main.tile[i, j].active && ((double)j < Main.worldSurface || dirt != 0))
		{
			int num = i - 1;
			int num2 = i + 2;
			int num3 = j - 1;
			int num4 = j + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			bool flag = true;
			for (int k = num; k < num2; k++)
			{
				for (int l = num3; l < num4; l++)
				{
					if (!Main.tile[k, l].active || !Main.tileSolid[(int)Main.tile[k, l].type])
					{
						flag = false;
					}
					//if (Main.tile[k, l].active || Main.tileSolid[(int)Main.tile[k, l].type])
					//{
					//	flag = false;
					//}
					if (Main.tile[k, l].lava && Main.tile[k, l].liquid > 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				if (grass != 23 || Main.tile[i, j - 1].type != 27)
				{
					Main.tile[i, j].type = (ushort)grass;
					WorldGen.SquareTileFrame(i, j);
					for (int m = num; m < num2; m++)
					{
						for (int n = num3; n < num4; n++)
						{
							if (Main.tile[m, n].active && (int)Main.tile[m, n].type == dirt)
							{
								try
								{
									if (repeat && WorldGen.grassSpread < 1000)
									{
										WorldGen.grassSpread++;
										ModWorld.SpreadCustomGrass(m, n, dirt, grass, true);
										WorldGen.grassSpread--;
									}
								}
								catch
								{
								}
							}
						}
					}
				}
			}
		}
	}
	catch
	{
	}
}
#endregion


#region PlaceCustomChest
public static int PlaceCustomChest(int x, int y, int type = 21, bool notNearOtherChests = false, int style = 0)
{
	bool flag = true;
	int num = -1;
	for (int i = x; i < x + 2; i++)
	{
		for (int j = y - 1; j < y + 1; j++)
		{
			if (Main.tile[i, j] == null)
			{
				Main.tile[i, j] = new Tile();
			}
			if (Main.tile[i, j].active)
			{
				flag = false;
			}
			if (Main.tile[i, j].lava)
			{
				flag = false;
			}
		}
		if (Main.tile[i, y + 1] == null)
		{
			Main.tile[i, y + 1] = new Tile();
		}
		if (!Main.tile[i, y + 1].active || !Main.tileSolid[(int)Main.tile[i, y + 1].type])
		{
			flag = false;
		}
	}
	if (flag)
	{
		num = Chest.CreateChest(x, y - 1);
		if (num == -1)
		{
			flag = false;
		}
	}
	if (flag)
	{
		WorldGen.PlaceTile(x, y, (ushort)type);
	}
	return num;
}
#endregion

public static void MakeCircle(int x,int y,float r,ushort type)
{
   int fx = (int)(x-r); //first x
   int fy = (int)(y-r); //first y
   int lx = (int)(x+r); //last x
   int ly = (int)(y+r); //last y
   for(int i = fx; i < lx+1; i++)
   {
       for(int j = fy; j < ly+1; j++)
       {
           if(Vector2.Distance(new Vector2(i,j),new Vector2(x,y)) <= r)
           {
		Main.tile[i,j].active = true;
		Main.tile[i,j].type = type;
		WorldGen.SquareTileFrame(i, j);
              //should still be a damn killtile method instead
           }
       }
   }
}

public static void ExplodeCircle(int x,int y,float r)
{
	List<int> dontDrop = new List<int>() { 0, 1, 2, 3, 5, 19, 23, 24, 25, 27, 30, 38, 39, 40, 41, 43, 44, 45, 46, 47, 49, 50, 51, 53, 54, 55, 57, 59, 60, 70, 71, 72, 75, 76, 78, 85, 109, 110, 112, 116, 117, 118, 119, 120, 121, 122, 123, 124, 140, 145, 146, 147, 148 };
	int fx = (int)(x-r); //first x
	int fy = (int)(y-r); //first y
	int lx = (int)(x+r); //last x
	int ly = (int)(y+r); //last y
	for(int i = fx; i < lx+1; i++)
	{
		for(int j = fy; j < ly+1; j++)
		{
			if(Vector2.Distance(new Vector2(i,j),new Vector2(x,y)) <= r)
			{
				if (Main.tile[i, j].type == (ushort)Config.tileDefs.ID["Impervious Brick"] || Main.tile[i, j].type == (ushort)Config.tileDefs.ID["Impervious Brick 2"] || Main.tile[i, j].type == (ushort)Config.tileDefs.ID["Oblivion Brick"] || Main.tile[i, j].type == (ushort)Config.tileDefs.ID["Oblivion Ore"] || Main.tile[i, j].type == (ushort)Config.tileDefs.ID["Berserker Ore"]) continue;
				else
				{
					if (!dontDrop.Contains(Main.tile[i, j].type))
					{
						WorldGen.KillTile(i, j);
					}
					else
					{
						Main.tile[i, j].active = false;
						WorldGen.SquareTileFrame(i, j);
					}
				}
				WorldGen.KillWall(i, j);
              //Main.tile[i,j].active = false;
			}
		}
	}
	foreach (Player P in Main.player)
	{
		Rectangle player = new Rectangle((int)P.position.X, (int)P.position.Y, P.width, P.height);
		Rectangle explosion = new Rectangle(fx * 16, fy * 16, lx * 16, ly * 16);
		if (player.Intersects(explosion))
		{
			P.Hurt(700, P.direction, false, false, " was vaporized...");
		}
	}
	foreach (NPC N in Main.npc)
	{
		Rectangle npc = new Rectangle((int)N.position.X, (int)N.position.Y, N.width, N.height);
		Rectangle explosion = new Rectangle(fx * 16, fy * 16, lx * 16, ly * 16);
		if (npc.Intersects(explosion))
		{
			N.StrikeNPC(700, 0f, 1);
		}
	}
}

#region DrawOutlinedString(SpriteBatch, SpriteFont, string, Vector2, Color, Color, float, Vector2, float, SpriteEffects, float)
private void DrawOutlinedString(SpriteBatch SB, SpriteFont SF, string txt, Vector2 P, Color C, Color shadeC, float strength = 1f, Vector2 V = default(Vector2), float scale = 1f, SpriteEffects SE = SpriteEffects.None, float LL = 0f)
{
	if (string.IsNullOrEmpty(txt) || string.IsNullOrWhiteSpace(txt)) return;
	Vector2[] OS = new Vector2[4] { new Vector2(strength, strength), new Vector2(strength, -strength), new Vector2(-strength, strength), new Vector2(-strength, -strength) };
	foreach (Vector2 VO in OS)
		SB.DrawString(SF, txt, new Vector2(P.X + VO.X, P.Y + VO.Y), shadeC, 0f, V, scale, SE, LL);
	SB.DrawString(SF, txt, P, C, 0f, V, scale, SE, LL);
}
#endregion

#region FindUO() : int
private int FindUO()
{
        foreach (NPC N in Main.npc)
        {
            if (N.type == Config.npcDefs.byName["Ultrablivion Head"].type && N.active && N.life > 0)
                return N.whoAmI;
        }
        return -1;
}
#endregion

#region PreDrawInterface(SpriteBatch) : void
public void PreDrawInterface(SpriteBatch SB)
{
        Player P = Main.player[Main.myPlayer];
        int NID = FindUO();
        if (Config.npcInterface != null)
            return;
        if (NID < 0 || NID > Main.npc.Length)
            return;
        if (P == null)
            return;
        if (P.ghost)
            return;
        if (Main.hideUI)
            return;
        NPC N = Main.npc[NID];
        int
            x = 510,
            y = 132;
        Texture2D
            LB = Main.goreTexture[Config.goreID["UOLbar"]],
            LBB = Main.goreTexture[Config.goreID["UOLbarBorder"]];
        float percent = N.lifeMax == 0 ? 0f : 1f * (N.life / N.lifeMax);
        Color[] CC = new Color[3] { Color.Green, Color.Orange, Color.Red };
        Color C = percent <= 0.2f ? CC[2] : (percent <= 0.5f ? CC[1] : CC[0]);
        int w = (int)(Math.Floor(LB.Width / 2f * percent) * 2);
        int times = (int)Math.Ceiling(LB.Height / 2f);

        percent = N.lifeMax == 0 ? 0f : 1f * N.life / N.lifeMax;
        w = (int)(Math.Floor(LB.Width / 2f * percent) * 2);
        C = percent <= 0.2f ? CC[2] : (percent <= 0.5f ? CC[1] : CC[0]);
        for (int j = 0; j < times; j++)
        {
            int ww = w - (j / 2) * 2;
            if (ww > 0)
	    {
		//if (!Config.mainInstance.graphics.IsFullScreen)
                //{
		//	SB.Draw(LB, new Vector2(x, y + j * 2), new Rectangle(0, j * 2, (int)(ww / 2), 1), C);
		//}
		SB.Draw(LB, new Vector2(x, y + j * 2), new Rectangle(0, j * 2, ww, 2), C);
	    }
        }
	//if (!Config.mainInstance.graphics.IsFullScreen)
	//{
	//	SB.Draw(LBB, new Vector2(x, y), new Rectangle(0, 0, (int)(LBB.Width / 2), (int)(LBB.Height / 2)), Color.White);
	//}
	SB.Draw(LBB, new Vector2(x, y), new Rectangle(0, 0, LBB.Width, LBB.Height), Color.White);
        C = percent <= 0.2f ? CC[2] : (percent <= 0.5f ? CC[1] : CC[0]);
        DrawOutlinedString(SB, Main.fontMouseText, N.displayName + ": " + N.life + "/" + N.lifeMax, new Vector2(x, y), Color.White, Color.Black);
        times = (int)Math.Ceiling(LB.Height / 2f);
}
#endregion

#region ice shrine

public static void IceShrine(int x, int y)
{
	ushort IcBr = (ushort)Config.tileDefs.ID["Ice Brick"];
	ushort IB = (ushort)Config.tileDefs.ID["Ice Block"];
	ushort EI = (ushort)Config.tileDefs.ID["Ever Ice"];
	ushort IS = (ushort)Config.tileDefs.ID["Ice Sculpture"];
	ushort IS2 = (ushort)Config.tileDefs.ID["DNA Sculpture"];
	Main.tile[x, y].active = true;
	Main.tile[x + 2, y].active = true;
	Main.tile[x + 4, y].active = true;
	Main.tile[x + 18, y].active = true;
	Main.tile[x + 20, y].active = true;
	Main.tile[x + 22, y].active = true;

	Main.tile[x, y].type = IcBr;
	Main.tile[x + 2, y].type = IcBr;
	Main.tile[x + 4, y].type = IcBr;
	Main.tile[x + 18, y].type = IcBr;
	Main.tile[x + 20, y].type = IcBr;
	Main.tile[x + 22, y].type = IcBr;

	for (int i = x; i <= x + 22; i++)
	{
		if ((i > x + 4 && i < x + 10) || (i > x + 12 && i < x + 18))
		{
		}
		else
		{
			Main.tile[i, y + 1].active = true;
			Main.tile[i, y + 1].type = IcBr;
		}
	}
	for (int i = x; i <= x + 22; i++)
	{
		if (i == x + 2 || i == x + 20)
		{
			Main.tile[i, y + 2].active = true;
			Main.tile[i, y + 2].type = EI;
		}
		if (i >= x && i <= x + 4 && i != x + 2)
		{
			Main.tile[i, y + 2].active = true;
			Main.tile[i, y + 2].type = IcBr;
		}
		if (i >= x + 9 && i <= x + 13)
		{
			Main.tile[i, y + 2].active = true;
			Main.tile[i, y + 2].type = IcBr;
		}
		if (i >= x + 18 && i <= x + 22 && i != x + 20)
		{
			Main.tile[i, y + 2].active = true;
			Main.tile[i, y + 2].type = IcBr;
		}
	}
	for (int i = x + 1; i <= x + 21; i++)
	{
		if ((i >= x + 1 && i <= x + 3) || (i >= x + 19 && i <= x + 21))
		{
			Main.tile[i, y + 3].active = true;
			Main.tile[i, y + 3].type = IcBr;
		}
		if (i >= x + 10 && i <= x + 12)
		{
			Main.tile[i, y + 3].active = true;
			Main.tile[i, y + 3].type = EI;
		}
	}
	Main.tile[x + 8, y + 3].active = true;
	Main.tile[x + 9, y + 3].active = true;
	Main.tile[x + 13, y + 3].active = true;
	Main.tile[x + 14, y + 3].active = true;
	Main.tile[x + 8, y + 3].type = IcBr;
	Main.tile[x + 9, y + 3].type = IcBr;
	Main.tile[x + 13, y + 3].type = IcBr;
	Main.tile[x + 14, y + 3].type = IcBr;

	Main.tile[x + 2, y + 4].active = true;
	Main.tile[x + 3, y + 4].active = true;
	Main.tile[x + 19, y + 4].active = true;
	Main.tile[x + 20, y + 4].active = true;
	Main.tile[x + 2, y + 4].type = IcBr;
	Main.tile[x + 3, y + 4].type = IcBr;
	Main.tile[x + 19, y + 4].type = IcBr;
	Main.tile[x + 20, y + 4].type = IcBr;

	for (int i = x + 7; i <= x + 15; i++)
	{
		if (i >= x + 10 && i <= x + 12)
		{
			Main.tile[i, y + 4].active = true;
			Main.tile[i, y + 4].type = EI;
		}
		if ((i >= x + 7 && i <= x + 9) || (i >= x + 13 && i <= x + 15))
		{
			Main.tile[i, y + 4].active = true;
			Main.tile[i, y + 4].type = IcBr;
		}
	}
	for (int i = x + 2; i <= x + 20; i++)
	{
		Main.tile[i, y + 5].active = true;
		Main.tile[i, y + 5].type = IcBr;
	}
	for (int i = x + 2; i <= x + 20; i++)
	{
		for (int j = y + 6; j <= y + 14; j++)
		{
			Main.tile[i, j].active = false;
			Main.tile[i, j].liquid = 0;
		}
	}
	Main.tile[x + 2, y + 6].active = true;
	Main.tile[x + 20, y + 6].active = true;
	Main.tile[x + 2, y + 6].type = IcBr;
	Main.tile[x + 20, y + 6].type = IcBr;
	
	Main.tile[x + 2, y + 10].active = true;
	Main.tile[x + 3, y + 10].active = true;
	Main.tile[x + 4, y + 10].active = true;
	Main.tile[x + 18, y + 10].active = true;
	Main.tile[x + 19, y + 10].active = true;
	Main.tile[x + 20, y + 10].active = true;
	Main.tile[x + 2, y + 10].type = IcBr;
	Main.tile[x + 3, y + 10].type = IcBr;
	Main.tile[x + 4, y + 10].type = 19;
	Main.tile[x + 18, y + 10].type = 19;
	Main.tile[x + 4, y + 10].wall = 14;
	Main.tile[x + 18, y + 10].wall = 14;
	Main.tile[x + 19, y + 10].type = IcBr;
	Main.tile[x + 20, y + 10].type = IcBr;

	// doors
	WorldGen.PlaceTile(x + 2, y + 7, 10);
	WorldGen.PlaceTile(x + 20, y + 7, 10);

	for (int i = x + 3; i <= x + 19; i++)
	{
		if (i >= x + 3 && i <= x + 5)
		{
			Main.tile[i, y + 11].active = true;
			Main.tile[i, y + 11].type = IcBr;
		}
		if (i >= x + 17 && i <= x + 19)
		{
			Main.tile[i, y + 11].active = true;
			Main.tile[i, y + 11].type = IcBr;
		}
		if (i == x + 6 && i == x + 16)
		{
			Main.tile[i, y + 11].active = true;
			Main.tile[i, y + 11].type = 19;
			Main.tile[i, y + 11].wall = 14;
		}
	}
	for (int i = x + 5; i <= x + 17; i++)
	{
		if (i == x + 5 || i == x + 6 || i == x + 16 || i == x + 17)
		{
			Main.tile[i, y + 12].active = true;
			Main.tile[i, y + 12].type = IcBr;
		}
		else Main.tile[i, y + 12].wall = 14;
		if (i == x + 7 || i == x + 15)
		{
			Main.tile[i, y + 12].active = true;
			Main.tile[i, y + 12].type = 19;
			Main.tile[i, y + 12].wall = 14;
		}
	}
	for (int i = x + 6; i <= x + 16; i++)
	{
		if ((i >= x + 6 && i <= x + 8) || (i >= x + 14 && i <= x + 16))
		{
			Main.tile[i, y + 13].active = true;
			Main.tile[i, y + 13].type = IcBr;
		}
		else Main.tile[i, y + 13].wall = 14;
	}
	for (int i = x + 8; i <= x + 14; i++)
	{
		Main.tile[i, y + 14].active = true;
		Main.tile[i, y + 14].type = IcBr;
		Main.tile[i, y + 9].active = true;
		Main.tile[i, y + 9].type = 19;
	}
	Main.tile[x + 7, y + 9].active = true;
	Main.tile[x + 7, y + 9].type = IB;
	Main.tile[x + 15, y + 9].active = true;
	Main.tile[x + 15, y + 9].type = IB;

	// statue 1
	Main.tile[x + 9, y + 6].active = true;
	Main.tile[x + 9, y + 6].frameY = 0;
	Main.tile[x + 9, y + 6].frameX = 0;
	Main.tile[x + 9, y + 6].type = IS;
	Main.tile[x + 10, y + 6].active = true;
	Main.tile[x + 10, y + 6].frameY = 0;
	Main.tile[x + 10, y + 6].frameX = 18;
	Main.tile[x + 10, y + 6].type = IS;
	Main.tile[x + 9, y + 7].active = true;
	Main.tile[x + 9, y + 7].frameY = 18;
	Main.tile[x + 9, y + 7].frameX = 0;
	Main.tile[x + 9, y + 7].type = IS;
	Main.tile[x + 10, y + 7].active = true;
	Main.tile[x + 10, y + 7].frameY = 18;
	Main.tile[x + 10, y + 7].frameX = 18;
	Main.tile[x + 10, y + 7].type = IS;
	Main.tile[x + 9, y + 8].active = true;
	Main.tile[x + 9, y + 8].frameY = 36;
	Main.tile[x + 9, y + 8].frameX = 0;
	Main.tile[x + 9, y + 8].type = IS;
	Main.tile[x + 10, y + 8].active = true;
	Main.tile[x + 10, y + 8].frameY = 36;
	Main.tile[x + 10, y + 8].frameX = 18;
	Main.tile[x + 10, y + 8].type = IS;

	// statue 2
	Main.tile[x + 12, y + 6].active = true;
	Main.tile[x + 12, y + 6].frameY = 0;
	Main.tile[x + 12, y + 6].frameX = 0;
	Main.tile[x + 12, y + 6].type = IS2;
	Main.tile[x + 13, y + 6].active = true;
	Main.tile[x + 13, y + 6].frameY = 0;
	Main.tile[x + 13, y + 6].frameX = 18;
	Main.tile[x + 13, y + 6].type = IS2;
	Main.tile[x + 12, y + 7].active = true;
	Main.tile[x + 12, y + 7].frameY = 18;
	Main.tile[x + 12, y + 7].frameX = 0;
	Main.tile[x + 12, y + 7].type = IS2;
	Main.tile[x + 13, y + 7].active = true;
	Main.tile[x + 13, y + 7].frameY = 18;
	Main.tile[x + 13, y + 7].frameX = 18;
	Main.tile[x + 13, y + 7].type = IS2;
	Main.tile[x + 12, y + 8].active = true;
	Main.tile[x + 12, y + 8].frameY = 36;
	Main.tile[x + 12, y + 8].frameX = 0;
	Main.tile[x + 12, y + 8].type = IS2;
	Main.tile[x + 13, y + 8].active = true;
	Main.tile[x + 13, y + 8].frameY = 36;
	Main.tile[x + 13, y + 8].frameX = 18;
	Main.tile[x + 13, y + 8].type = IS2;

	for (int i = x + 3; i <= x + 19; i++)
	{
		for (int j = y + 6; j <= y + 9; j++)
		{
			Main.tile[i, j].wall = 14;
		}
	}
	for (int i = x + 6; i <= x + 16; i++)
	{
		for (int j = y + 10; j <= y + 12; j++)
		{
			Main.tile[i, j].wall = 14;
		}
	}
	Main.tile[x + 5, y + 10].wall = 14;
	Main.tile[x + 17, y + 10].wall = 14;
	if (AddIceShrineChest1(x + 13, y + 13, 0, false, 1)) {}
	if (AddIceShrineChest2(x + 10, y + 13, 0, false, 1)) {}
	Main.tile[x + 6, y + 12].wall = 0;
	Main.tile[x + 16, y + 12].wall = 0;

	for (int i = x + 2; i <= x + 4; i++)
	{
		for (int j = y + 12; j <= y + 14; j++)
		{
			if (Main.tile[i, j].type > 0)
			{
				Main.tile[i, j].active = true;
			}
		}
	}
	for (int i = x + 18; i <= x + 20; i++)
	{
		for (int j = y + 12; j <= y + 14; j++)
		{
			if (Main.tile[i, j].type > 0)
			{
				Main.tile[i, j].active = true;
			}
		}
	}
	for (int i = x + 5; i <= x + 7; i++)
	{
		for (int j = y + 13; j <= y + 14; j++)
		{
			if (Main.tile[i, j].type > 0)
			{
				Main.tile[i, j].active = true;
			}
		}
	}
	for (int i = x + 15; i <= x + 17; i++)
	{
		for (int j = y + 13; j <= y + 14; j++)
		{
			if (Main.tile[i, j].type > 0)
			{
				Main.tile[i, j].active = true;
			}
		}
	}
	if (Main.tile[x + 2, y + 10].type > 0) Main.tile[x + 2, y + 10].active = true;
	if (Main.tile[x + 20, y + 10].type > 0) Main.tile[x + 20, y + 10].active = true;
}

public static bool AddIceShrineChest1(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
{
	if (WorldGen.genRand == null)
	{
		WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
	}
	int k = j;
	while (k < Main.maxTilesY)
	{
		if (Main.tile[i, k].active && Main.tileSolid[(int)Main.tile[i, k].type])
		{
			int num = k;
			int num2 = WorldGen.PlaceChest(i - 1, num - 1, 21, notNearOtherChests, 1);
			if (num2 >= 0)
			{
				int num3 = 0;
				while (num3 == 0)
				{
					for (int m = 0; m < Main.chest[num2].item.Length; m++)
					{
						Item I = Main.chest[num2].item[m];
						I.SetDefaults(Config.itemDefs.byName["Ice Block"].type);
						I.stack = 250;
					}
					num3++;
				}
				return true;
			}
			return false;
		}
		else
		{
			k++;
		}
	}
	return false;
}

public static bool AddIceShrineChest2(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
{
	if (WorldGen.genRand == null)
	{
		WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
	}
	int k = j;
	while (k < Main.maxTilesY)
	{
		if (Main.tile[i, k].active && Main.tileSolid[(int)Main.tile[i, k].type])
		{
			int num = k;
			int num2 = WorldGen.PlaceChest(i - 1, num - 1, 21, notNearOtherChests, 1);
			if (num2 >= 0)
			{
				int num3 = 0;
				while (num3 == 0)
				{
					int rN = WorldGen.genRand.Next(19);
					if (rN >= 0 && rN <= 6)
					{
						Main.chest[num2].item[0].SetDefaults("White Gel");
						Main.chest[num2].item[0].stack = WorldGen.genRand.Next(100, 150);
					}
					else if (rN >= 7 && rN <= 13)
					{
						Main.chest[num2].item[0].SetDefaults("Poisoned Knife");
						Main.chest[num2].item[0].stack = WorldGen.genRand.Next(34, 79);
					}
					else if (rN >= 14 && rN <= 16)
					{
						Main.chest[num2].item[0].SetDefaults("Soul of Ice");
						Main.chest[num2].item[0].stack = WorldGen.genRand.Next(3) + 1;
					}
					else if (rN == 17)
					{
						Main.chest[num2].item[0].SetDefaults("Icy Greatsword");
						Main.chest[num2].item[0].Prefix(-1);
					}
					else if (rN == 18)
					{
						Main.chest[num2].item[0].SetDefaults("Ice Step Boots");
						Main.chest[num2].item[0].Prefix(-1);
					}
					Main.chest[num2].item[1].SetDefaults(73, false);
					Main.chest[num2].item[1].stack = WorldGen.genRand.Next(60, 82);
					int rand = WorldGen.genRand.Next(4);
					if (rand == 0)
					{
						Main.chest[num2].item[2].SetDefaults("Ice Shard");
						Main.chest[num2].item[2].stack = WorldGen.genRand.Next(3, 7);
					}
					if (rand == 1)
					{
						Main.chest[num2].item[2].SetDefaults("Ice Sculpture");
						Main.chest[num2].item[2].stack = 1;
					}
					if (rand == 2)
					{
						Main.chest[num2].item[2].SetDefaults("DNA Sculpture");
						Main.chest[num2].item[2].stack = 1;
					}
					if (rand == 3)
					{
						Main.chest[num2].item[2].SetDefaults("Ice Brick");
						Main.chest[num2].item[2].stack = WorldGen.genRand.Next(30, 73);
					}
					num3++;
				}
				return true;
			}
			return false;
		}
		else
		{
			k++;
		}
	}
	return false;
}

#endregion


public static void SquareTileFrameArea(int x, int y, int r)
{
	for (int i = x - r; i < x + r; i++)
	{
		for (int j = y - r; j < y + r; j++)
		{
			WorldGen.SquareTileFrame(i, j);
		}
	}
}


public static void AddLibraryK(int xm, int ym)
{
	//int xm = WorldGen.genRand.Next(50, (int)(Main.maxTilesX - 50));
	//int ym = WorldGen.genRand.Next((int)Main.rockLayer, (int)(Main.maxTilesY - 300));

	ushort resWood = (ushort)Config.tileDefs.ID["Goblin Brick"];

	// hollow out the house's area
	for (int x = xm - 15; x <= xm + 15; x++)
	{
		for (int y = ym - 15; y <= ym + 15; y++)
		{
			Main.tile[x, y].liquid = 0;
			Main.tile[x, y].lava = false;
			if ((x == xm - 15 && (y <= ym + 15 && y >= ym - 15)) || (x == xm + 15 && (y <= ym + 15 && y >= ym - 15)) || (y == ym - 15 && (x <= xm + 15 && x >= xm - 15)) || (y == ym + 15 && (x <= xm + 15 && x >= xm - 15)))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
			else Main.tile[x, y].active = false;
			if (x > xm - 15 && x < xm + 15 && y > ym - 15 && y < ym + 15)
			{
				Main.tile[x, y].wall = 4;
			}
		}
	}
	// chest room 1
	for (int x = xm - 15; x <= xm - 9; x++)
	{
		for (int y = ym + 15; y >= ym + 11; y--)
		{
			if (x == xm - 9 && (y <= ym + 14 && y >= ym + 11))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
			if (y == ym + 11 && (x <= xm - 9 && x >= xm - 15))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
		}
	}
	// chest room 2
	for (int x = xm - 9; x <= xm - 3; x++)
	{
		for (int y = ym + 15; y >= ym + 11; y--)
		{
			if (x == xm - 3 && (y <= ym + 14 && y >= ym + 11))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
			if (y == ym + 11 && (x <= xm - 3 && x >= xm - 9))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
		}
	}
	// chest room 3
	for (int x = xm + 3; x <= xm + 9; x++)
	{
		for (int y = ym + 15; y >= ym + 11; y--)
		{
			if (x == xm + 3 && (y <= ym + 14 && y >= ym + 11))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
			if (y == ym + 11 && (x <= xm + 9 && x >= xm + 3))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
		}
	}
	// chest room 4
	for (int x = xm + 9; x <= xm + 15; x++)
	{
		for (int y = ym + 15; y >= ym + 11; y--)
		{
			if (x == xm + 9 && (y <= ym + 14 && y >= ym + 11))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
			if (y == ym + 11 && (x <= xm + 15 && x >= xm + 9))
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
		}
	}
	// doors on chest rooms
	for (int ypos = ym + 12; ypos <= ym + 14; ypos++)
	{
		Main.tile[xm - 9, ypos].active = false;
		Main.tile[xm - 3, ypos].active = false;
		Main.tile[xm + 3, ypos].active = false;
		Main.tile[xm + 9, ypos].active = false;
	}
	WorldGen.PlaceDoor(xm - 9, ym + 13, 10);
	WorldGen.PlaceDoor(xm - 3, ym + 13, 10);
	WorldGen.PlaceDoor(xm + 3, ym + 13, 10);
	WorldGen.PlaceDoor(xm + 9, ym + 13, 10);
	// end doors on chest rooms
	for (int x = xm - 14; x < xm - 11; x++)
	{
		for (int y = ym - 9; y <= ym + 6; y++)
		{
			if (y == ym - 9 || y == ym + 6 || y == ym - 1)
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = 19;
				Main.tile[x, y - 1].active = true;
				Main.tile[x, y - 1].type = 50;
				int rN = WorldGen.genRand.Next(5);
				if (rN == 0)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)0;
				}
				else if (rN == 1)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)18;
				}
				else if (rN == 2)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)36;
				}
				else if (rN == 3)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)54;
				}
				else if (rN == 4)
				{
					int rn2 = WorldGen.genRand.Next(25);
					if (rn2 == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else if (rn2 == 24)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["MTB"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)72;
				}
			}
		}
	}
	for (int x = xm + 11; x <= xm + 14; x++)
	{
		for (int y = ym - 9; y <= ym + 6; y++)
		{
			if (y == ym - 9 || y == ym + 6 || y == ym - 1)
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = 19;
				Main.tile[x, y - 1].active = true;
				Main.tile[x, y - 1].type = 50;
				int rN = WorldGen.genRand.Next(5);
				if (rN == 0)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)0;
				}
				else if (rN == 1)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)18;
				}
				else if (rN == 2)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)36;
				}
				else if (rN == 3)
				{
					if (WorldGen.genRand.Next(25) == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)54;
				}
				else if (rN == 4)
				{
					int rn2 = WorldGen.genRand.Next(25);
					if (rn2 == 0)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["IWI"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else if (rn2 == 24)
					{
						Main.tile[x, y - 1].type = (ushort)Config.tileDefs.ID["MTB"];
						Main.tile[x, y - 1].frameX = (short)0;
						Main.tile[x, y - 1].frameY = (short)0;
					}
					else Main.tile[x, y - 1].frameX = (short)72;
				}
			}
		}
	}
	for (int x = xm - 1; x < xm + 1; x++)
	{
		for (int y = ym - 15; y < ym + 12; y++)
		{
			if (x == xm)
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = resWood;
			}
		}
	}
	for (int x = xm + 1; x <= xm + 4; x++)
	{
		for (int y = ym - 13; y <= ym - 9; y++)
		{
			if (y == ym - 13 || y == ym - 11 || y == ym - 9)
			{
				Main.tile[x, y].active = true;
				Main.tile[x, y].type = 19;
			}
		}
	}
	Main.tile[xm + 5, ym - 11].active = true;
	Main.tile[xm + 5, ym - 11].type = 19;

	// lower right shelf
	for (int x = xm + 5; x < xm + 15; x++)
	{
		for (int y = ym + 2; y <= ym + 3; y++)
		{
			Main.tile[x, y].active = true;
			Main.tile[x, y].type = resWood;
		}
	}
	// upper right shelf
	for (int x = xm + 5; x < xm + 15; x++)
	{
		for (int y = ym - 6; y <= ym - 5; y++)
		{
			Main.tile[x, y].active = true;
			Main.tile[x, y].type = resWood;
		}
	}
	// lower left shelf
	for (int x = xm - 15; x <= xm - 5; x++)
	{
		for (int y = ym + 2; y <= ym + 3; y++)
		{
			Main.tile[x, y].active = true;
			Main.tile[x, y].type = resWood;
		}
	}
	// upper left shelf
	for (int x = xm - 15; x <= xm - 5; x++)
	{
		for (int y = ym - 6; y <= ym - 5; y++)
		{
			Main.tile[x, y].active = true;
			Main.tile[x, y].type = resWood;
		}
	}
	WorldGen.Place3x4(xm + 5, ym + 10, 101);
	WorldGen.Place3x4(xm - 7, ym + 10, 101);
	WorldGen.Place3x4(xm + 9, ym + 10, 101);
	WorldGen.Place3x4(xm - 11, ym + 10, 101);
	WorldGen.Place3x4(xm + 6, ym + 1, 101);
	WorldGen.Place3x4(xm - 8, ym + 1, 101);
	WorldGen.Place3x4(xm + 6, ym - 7, 101);
	WorldGen.Place3x4(xm - 8, ym - 7, 101);

	#region spiral staircase
	// stair 8
	Main.tile[xm - 1, ym - 7].active = true;
	Main.tile[xm - 1, ym - 7].type = 19;
	Main.tile[xm + 1, ym - 7].active = true;
	Main.tile[xm + 1, ym - 7].type = 19;
	Main.tile[xm + 2, ym - 7].active = true;
	Main.tile[xm + 2, ym - 7].type = 19;
	Main.tile[xm + 3, ym - 7].active = true;
	Main.tile[xm + 3, ym - 7].type = 19;
	// stair 7
	Main.tile[xm - 2, ym - 5].active = true;
	Main.tile[xm - 2, ym - 5].type = 19;
	Main.tile[xm - 1, ym - 5].active = true;
	Main.tile[xm - 1, ym - 5].type = 19;
	Main.tile[xm + 1, ym - 5].active = true;
	Main.tile[xm + 1, ym - 5].type = 19;
	Main.tile[xm + 2, ym - 5].active = true;
	Main.tile[xm + 2, ym - 5].type = 19;
	// stair 6
	Main.tile[xm - 3, ym - 3].active = true;
	Main.tile[xm - 3, ym - 3].type = 19;
	Main.tile[xm - 2, ym - 3].active = true;
	Main.tile[xm - 2, ym - 3].type = 19;
	Main.tile[xm - 1, ym - 3].active = true;
	Main.tile[xm - 1, ym - 3].type = 19;
	Main.tile[xm + 1, ym - 3].active = true;
	Main.tile[xm + 1, ym - 3].type = 19;
	// stair 5
	Main.tile[xm - 4, ym - 1].active = true;
	Main.tile[xm - 4, ym - 1].type = 19;
	Main.tile[xm - 3, ym - 1].active = true;
	Main.tile[xm - 3, ym - 1].type = 19;
	Main.tile[xm - 2, ym - 1].active = true;
	Main.tile[xm - 2, ym - 1].type = 19;
	Main.tile[xm - 1, ym - 1].active = true;
	Main.tile[xm - 1, ym - 1].type = 19;
	// stair 4
	Main.tile[xm - 5, ym + 1].active = true;
	Main.tile[xm - 5, ym + 1].type = 19;
	Main.tile[xm - 4, ym + 1].active = true;
	Main.tile[xm - 4, ym + 1].type = 19;
	Main.tile[xm - 3, ym + 1].active = true;
	Main.tile[xm - 3, ym + 1].type = 19;
	Main.tile[xm - 2, ym + 1].active = true;
	Main.tile[xm - 2, ym + 1].type = 19;
	Main.tile[xm - 1, ym + 1].active = true;
	Main.tile[xm - 1, ym + 1].type = 19;
	// stair 3
	Main.tile[xm - 4, ym + 3].active = true;
	Main.tile[xm - 4, ym + 3].type = 19;
	Main.tile[xm - 3, ym + 3].active = true;
	Main.tile[xm - 3, ym + 3].type = 19;
	Main.tile[xm - 2, ym + 3].active = true;
	Main.tile[xm - 2, ym + 3].type = 19;
	Main.tile[xm - 1, ym + 3].active = true;
	Main.tile[xm - 1, ym + 3].type = 19;
	// stair 2
	Main.tile[xm - 3, ym + 5].active = true;
	Main.tile[xm - 3, ym + 5].type = 19;
	Main.tile[xm - 2, ym + 5].active = true;
	Main.tile[xm - 2, ym + 5].type = 19;
	Main.tile[xm - 1, ym + 5].active = true;
	Main.tile[xm - 1, ym + 5].type = 19;
	Main.tile[xm + 1, ym + 5].active = true;
	Main.tile[xm + 1, ym + 5].type = 19;
	// stair 1
	Main.tile[xm - 2, ym + 7].active = true;
	Main.tile[xm - 2, ym + 7].type = 19;
	Main.tile[xm - 1, ym + 7].active = true;
	Main.tile[xm - 1, ym + 7].type = 19;
	Main.tile[xm + 1, ym + 7].active = true;
	Main.tile[xm + 1, ym + 7].type = 19;
	Main.tile[xm + 2, ym + 7].active = true;
	Main.tile[xm + 2, ym + 7].type = 19;
	#endregion

	WorldGen.Place1x2Top(xm + 5, ym + 4, 42);
	WorldGen.Place1x2Top(xm - 5, ym + 4, 42);

	WorldGen.PlaceTile(xm - 14, ym + 4, 4, false, true, -1, 0);
	WorldGen.PlaceTile(xm + 14, ym + 4, 4, false, true, -1, 0);
	WorldGen.PlaceTile(xm - 14, ym - 3, 4, false, true, -1, 0);
	WorldGen.PlaceTile(xm + 14, ym - 3, 4, false, true, -1, 0);
	WorldGen.PlaceTile(xm - 14, ym - 11, 4, false, true, -1, 0);
	WorldGen.PlaceTile(xm + 14, ym - 11, 4, false, true, -1, 0);

	WorldGen.Place3x3(xm - 8, ym - 14, 36);
	WorldGen.Place3x3(xm + 6, ym - 14, 36);
	ModWorld.SquareTileFrameArea(xm, ym, 30);
}

public static void Kill3x2TileForGood(int x, int y)
{
	if (Main.tile[x, y].frameX == 0 && Main.tile[x, y].frameY == 0)
	{
		Main.tile[x, y].active = false;
		Main.tile[x + 1, y].active = false;
		Main.tile[x + 2, y].active = false;
		Main.tile[x, y + 1].active = false;
		Main.tile[x + 1, y + 1].active = false;
		Main.tile[x + 2, y + 1].active = false;
		Main.tile[x, y].type = 0;
		Main.tile[x + 1, y].type = 0;
		Main.tile[x + 2, y].type = 0;
		Main.tile[x, y + 1].type = 0;
		Main.tile[x + 1, y + 1].type = 0;
		Main.tile[x + 2, y + 1].type = 0;
	}
	if (Main.tile[x, y].frameX == 18 && Main.tile[x, y].frameY == 0)
	{
		Main.tile[x, y].active = false;
		Main.tile[x + 1, y].active = false;
		Main.tile[x - 1, y].active = false;
		Main.tile[x, y + 1].active = false;
		Main.tile[x + 1, y + 1].active = false;
		Main.tile[x - 1, y + 1].active = false;
		Main.tile[x, y].type = 0;
		Main.tile[x + 1, y].type = 0;
		Main.tile[x - 1, y].type = 0;
		Main.tile[x, y + 1].type = 0;
		Main.tile[x + 1, y + 1].type = 0;
		Main.tile[x - 1, y + 1].type = 0;
	}
	if (Main.tile[x, y].frameX == 36 && Main.tile[x, y].frameY == 0)
	{
		Main.tile[x, y].active = false;
		Main.tile[x - 1, y].active = false;
		Main.tile[x - 2, y].active = false;
		Main.tile[x, y + 1].active = false;
		Main.tile[x - 1, y + 1].active = false;
		Main.tile[x - 2, y + 1].active = false;
		Main.tile[x, y].type = 0;
		Main.tile[x - 1, y].type = 0;
		Main.tile[x - 2, y].type = 0;
		Main.tile[x, y + 1].type = 0;
		Main.tile[x - 1, y + 1].type = 0;
		Main.tile[x - 2, y + 1].type = 0;
	}
	if (Main.tile[x, y].frameX == 0 && Main.tile[x, y].frameY == 18)
	{
		Main.tile[x, y].active = false;
		Main.tile[x + 1, y].active = false;
		Main.tile[x + 2, y].active = false;
		Main.tile[x, y - 1].active = false;
		Main.tile[x + 1, y - 1].active = false;
		Main.tile[x + 2, y - 1].active = false;
		Main.tile[x, y].type = 0;
		Main.tile[x + 1, y].type = 0;
		Main.tile[x + 2, y].type = 0;
		Main.tile[x, y - 1].type = 0;
		Main.tile[x + 1, y - 1].type = 0;
		Main.tile[x + 2, y - 1].type = 0;
	}
	if (Main.tile[x, y].frameX == 18 && Main.tile[x, y].frameY == 18)
	{
		Main.tile[x, y].active = false;
		Main.tile[x + 1, y].active = false;
		Main.tile[x - 1, y].active = false;
		Main.tile[x, y - 1].active = false;
		Main.tile[x + 1, y - 1].active = false;
		Main.tile[x - 1, y - 1].active = false;
		Main.tile[x, y].type = 0;
		Main.tile[x + 1, y].type = 0;
		Main.tile[x - 1, y].type = 0;
		Main.tile[x, y - 1].type = 0;
		Main.tile[x + 1, y - 1].type = 0;
		Main.tile[x - 1, y - 1].type = 0;
	}
	if (Main.tile[x, y].frameX == 36 && Main.tile[x, y].frameY == 18)
	{
		Main.tile[x, y].active = false;
		Main.tile[x - 1, y].active = false;
		Main.tile[x - 2, y].active = false;
		Main.tile[x, y - 1].active = false;
		Main.tile[x - 1, y - 1].active = false;
		Main.tile[x - 2, y - 1].active = false;
		Main.tile[x, y].type = 0;
		Main.tile[x - 1, y].type = 0;
		Main.tile[x - 2, y].type = 0;
		Main.tile[x, y - 1].type = 0;
		Main.tile[x - 1, y - 1].type = 0;
		Main.tile[x - 2, y - 1].type = 0;
	}
}
public static int FindClosestNPC(Vector2 pos, float dist)
{
	int closest = -1;
	float last = dist;
	for (int i = 0; i < Main.npc.Length; i++)
	{
		NPC N = Main.npc[i];
		if (!N.active || N.townNPC) continue;
		if (Vector2.Distance(pos, N.Center) < last)
		{
			last = Vector2.Distance(pos, N.Center);
			closest = i;
		}
		else continue;
	}
	return closest;
}
public static int FindNXClosestNPC(Vector2 pos, int npcIndex)
{
	int xclosest = npcIndex;
	for (int i = 0; i < Main.npc.Length; i++)
	{
		NPC N = Main.npc[i];
		NPC N2 = Main.npc[npcIndex];
		if (!N.active || N.townNPC) continue;
		if (Vector2.Distance(pos, N2.Center) < Vector2.Distance(pos, N.Center))
		{
			xclosest = i;
		}
		else continue;
	}
	return xclosest;
}

public static void AddLavaShrine(int x, int y)
{
	ushort LA = (ushort)Config.tileDefs.ID["Lava Alloy"];
	ushort LB = (ushort)Config.tileDefs.ID["Lava Alloy Brick"];
	ushort MO = (ushort)Config.tileDefs.ID["Magmatic Ore"];
	Main.tile[x + 2, y].active = true;
	Main.tile[x + 5, y].active = true;
	Main.tile[x + 6, y].active = true;
	Main.tile[x + 9, y].active = true;
	Main.tile[x + 2, y].type = LB;
	Main.tile[x + 5, y].type = LB;
	Main.tile[x + 6, y].type = LB;
	Main.tile[x + 9, y].type = LB;
	for (int xoff = x + 2; xoff <= x + 9; xoff++)
	{
		Main.tile[xoff, y + 1].active = true;
		Main.tile[xoff, y + 1].type = LB;
	}
	Main.tile[x + 3, y + 2].active = true;
	Main.tile[x + 3, y + 3].active = true;
	Main.tile[x + 8, y + 2].active = true;
	Main.tile[x + 8, y + 3].active = true;

	Main.tile[x + 3, y + 2].type = LB;
	Main.tile[x + 3, y + 3].type = LB;
	Main.tile[x + 8, y + 2].type = LB;
	Main.tile[x + 8, y + 3].type = LB;
	for (int xoff = x + 4; xoff <= x + 7; xoff++)
	{
		for (int yoff = y + 2; yoff <= y + 3; yoff++)
		{
			Main.tile[xoff, yoff].active = true;
			Main.tile[xoff, yoff].type = LA;
		}
	}
	Main.tile[x + 4, y + 4].active = true;
	Main.tile[x + 5, y + 4].active = true;
	Main.tile[x + 6, y + 4].active = true;
	Main.tile[x + 7, y + 4].active = true;
	Main.tile[x + 5, y + 5].active = true;
	Main.tile[x + 6, y + 5].active = true;
	Main.tile[x + 7, y + 5].active = true;
	Main.tile[x + 5, y + 6].active = true;
	Main.tile[x + 5, y + 7].active = true;
	Main.tile[x + 5, y + 8].active = true;
	Main.tile[x + 4, y + 8].active = true;
	Main.tile[x + 3, y + 8].active = true;
	Main.tile[x + 3, y + 9].active = true;
	Main.tile[x + 3, y + 10].active = true;
	Main.tile[x + 2, y + 10].active = true;
	Main.tile[x + 1, y + 10].active = true;
	Main.tile[x + 1, y + 11].active = true;
	Main.tile[x, y + 11].active = true;
	Main.tile[x, y + 12].active = true;
	Main.tile[x, y + 13].active = true;
	Main.tile[x, y + 14].active = true;
	Main.tile[x + 1, y + 14].active = true;
	Main.tile[x + 1, y + 15].active = true;
	Main.tile[x + 2, y + 15].active = true;
	Main.tile[x + 2, y + 16].active = true;
	Main.tile[x + 3, y + 16].active = true;
	Main.tile[x + 3, y + 17].active = true;
	Main.tile[x + 4, y + 17].active = true;
	Main.tile[x + 5, y + 17].active = true;
	Main.tile[x + 6, y + 17].active = true;
	Main.tile[x + 6, y + 16].active = true;
	Main.tile[x + 7, y + 16].active = true;
	Main.tile[x + 8, y + 16].active = true;
	Main.tile[x + 8, y + 15].active = true;
	Main.tile[x + 9, y + 15].active = true;
	Main.tile[x + 9, y + 14].active = true;
	Main.tile[x + 10, y + 14].active = true;
	Main.tile[x + 10, y + 13].active = true;
	Main.tile[x + 11, y + 13].active = true;
	Main.tile[x + 12, y + 13].active = true;
	Main.tile[x + 13, y + 13].active = true;
	Main.tile[x + 13, y + 14].active = true;
	Main.tile[x + 14, y + 14].active = true;
	Main.tile[x + 14, y + 15].active = true;
	Main.tile[x + 15, y + 15].active = true;
	Main.tile[x + 16, y + 15].active = true;
	Main.tile[x + 16, y + 16].active = true;
	Main.tile[x + 17, y + 16].active = true;
	Main.tile[x + 18, y + 16].active = true;
	Main.tile[x + 19, y + 16].active = true;
	Main.tile[x + 19, y + 17].active = true;
	Main.tile[x + 20, y + 17].active = true;
	Main.tile[x + 20, y + 18].active = true;

	Main.tile[x + 4, y + 4].type = LB;
	Main.tile[x + 5, y + 4].type = LB;
	Main.tile[x + 6, y + 4].type = LB;
	Main.tile[x + 7, y + 4].type = LB;
	Main.tile[x + 5, y + 5].type = LB;
	Main.tile[x + 6, y + 5].type = LB;
	Main.tile[x + 7, y + 5].type = LB;
	Main.tile[x + 5, y + 6].type = LB;
	Main.tile[x + 5, y + 7].type = LB;
	Main.tile[x + 5, y + 8].type = LB;
	Main.tile[x + 4, y + 8].type = LB;
	Main.tile[x + 3, y + 8].type = LB;
	Main.tile[x + 3, y + 9].type = LB;
	Main.tile[x + 3, y + 10].type = LB;
	Main.tile[x + 2, y + 10].type = LB;
	Main.tile[x + 1, y + 10].type = LB;
	Main.tile[x + 1, y + 11].type = LB;
	Main.tile[x, y + 11].type = LB;
	Main.tile[x, y + 12].type = LB;
	Main.tile[x, y + 13].type = LB;
	Main.tile[x, y + 14].type = LB;
	Main.tile[x + 1, y + 14].type = LB;
	Main.tile[x + 1, y + 15].type = LB;
	Main.tile[x + 2, y + 15].type = LB;
	Main.tile[x + 2, y + 16].type = LB;
	Main.tile[x + 3, y + 16].type = LB;
	Main.tile[x + 3, y + 17].type = LB;
	Main.tile[x + 4, y + 17].type = LB;
	Main.tile[x + 5, y + 17].type = LB;
	Main.tile[x + 6, y + 17].type = LB;
	Main.tile[x + 6, y + 16].type = LB;
	Main.tile[x + 7, y + 16].type = LB;
	Main.tile[x + 8, y + 16].type = LB;
	Main.tile[x + 8, y + 15].type = LB;
	Main.tile[x + 9, y + 15].type = LB;
	Main.tile[x + 9, y + 14].type = LB;
	Main.tile[x + 10, y + 14].type = LB;
	Main.tile[x + 10, y + 13].type = LB;
	Main.tile[x + 11, y + 13].type = LB;
	Main.tile[x + 12, y + 13].type = LB;
	Main.tile[x + 13, y + 13].type = LB;
	Main.tile[x + 13, y + 14].type = LB;
	Main.tile[x + 14, y + 14].type = LB;
	Main.tile[x + 14, y + 15].type = LB;
	Main.tile[x + 15, y + 15].type = LB;
	Main.tile[x + 16, y + 15].type = LB;
	Main.tile[x + 16, y + 16].type = LB;
	Main.tile[x + 17, y + 16].type = LB;
	Main.tile[x + 18, y + 16].type = LB;
	Main.tile[x + 19, y + 16].type = LB;
	Main.tile[x + 19, y + 17].type = LB;
	Main.tile[x + 20, y + 17].type = LB;
	Main.tile[x + 20, y + 18].type = LB;

	//------------------------------------------------------------
	for (int xoff = x + 8; xoff <= x + 36; xoff++)
	{
		Main.tile[xoff, y + 5].active = true;
		Main.tile[xoff, y + 5].type = LB;
	}


	Main.tile[x + 11, y + 4].active = true;
	Main.tile[x + 12, y + 4].active = true;
	Main.tile[x + 13, y + 4].active = true;

	Main.tile[x + 14, y + 4].active = true; // LA

	Main.tile[x + 15, y + 4].active = true;
	Main.tile[x + 16, y + 4].active = true;

	Main.tile[x + 17, y + 4].active = true; // LA
	Main.tile[x + 18, y + 4].active = true; // LA

	Main.tile[x + 13, y + 3].active = true;
	Main.tile[x + 14, y + 3].active = true;
	Main.tile[x + 15, y + 3].active = true;

	Main.tile[x + 16, y + 3].active = true; // LA

	Main.tile[x + 17, y + 3].active = true;

	Main.tile[x + 18, y + 3].active = true; // LA

	Main.tile[x + 14, y + 2].active = true;
	Main.tile[x + 15, y + 2].active = true;
	Main.tile[x + 16, y + 2].active = true;
	Main.tile[x + 17, y + 2].active = true;
	Main.tile[x + 18, y + 2].active = true;

	for (int xoff = x + 19; xoff <= x + 25; xoff++)
	{
		for (int yoff = y + 2; yoff <= y + 4; yoff++)
		{
			Main.tile[xoff, yoff].active = true;
			Main.tile[xoff, yoff].type = LA;
		}
	}
	for (int xoff = x + 16; xoff <= x + 28; xoff++)
	{
		Main.tile[xoff, y + 1].active = true;
		Main.tile[xoff, y + 1].type = LB;
	}

	Main.tile[x + 26, y + 2].active = true;
	Main.tile[x + 27, y + 2].active = true;
	Main.tile[x + 28, y + 2].active = true;
	Main.tile[x + 29, y + 2].active = true;
	Main.tile[x + 30, y + 2].active = true;

	Main.tile[x + 26, y + 3].active = true; // LA

	Main.tile[x + 27, y + 3].active = true;

	Main.tile[x + 28, y + 3].active = true; // LA

	Main.tile[x + 29, y + 3].active = true;
	Main.tile[x + 30, y + 3].active = true;
	Main.tile[x + 31, y + 3].active = true;

	Main.tile[x + 26, y + 4].active = true; // LA
	Main.tile[x + 27, y + 4].active = true; // LA

	Main.tile[x + 28, y + 4].active = true;
	Main.tile[x + 29, y + 4].active = true;

	Main.tile[x + 30, y + 4].active = true; // LA



	Main.tile[x + 11, y + 4].type = LB;
	Main.tile[x + 12, y + 4].type = LB;
	Main.tile[x + 13, y + 4].type = LB;

	Main.tile[x + 14, y + 4].type = LA; // LA

	Main.tile[x + 15, y + 4].type = LB;
	Main.tile[x + 16, y + 4].type = LB;

	Main.tile[x + 17, y + 4].type = LA; // LA
	Main.tile[x + 18, y + 4].type = LA; // LA

	Main.tile[x + 13, y + 3].type = LB;
	Main.tile[x + 14, y + 3].type = LB;
	Main.tile[x + 15, y + 3].type = LB;

	Main.tile[x + 16, y + 3].type = LA; // LA

	Main.tile[x + 17, y + 3].type = LB;

	Main.tile[x + 18, y + 3].type = LA; // LA

	Main.tile[x + 14, y + 2].type = LB;
	Main.tile[x + 15, y + 2].type = LB;
	Main.tile[x + 16, y + 2].type = LB;
	Main.tile[x + 17, y + 2].type = LB;
	Main.tile[x + 18, y + 2].type = LB;

	Main.tile[x + 26, y + 2].type = LB;
	Main.tile[x + 27, y + 2].type = LB;
	Main.tile[x + 28, y + 2].type = LB;
	Main.tile[x + 29, y + 2].type = LB;
	Main.tile[x + 30, y + 2].type = LB;

	Main.tile[x + 26, y + 3].type = LA; // LA

	Main.tile[x + 27, y + 3].type = LB;

	Main.tile[x + 28, y + 3].type = LA; // LA

	Main.tile[x + 29, y + 3].type = LB;
	Main.tile[x + 30, y + 3].type = LB;
	Main.tile[x + 31, y + 3].type = LB;

	Main.tile[x + 26, y + 4].type = LA; // LA
	Main.tile[x + 27, y + 4].type = LA; // LA

	Main.tile[x + 28, y + 4].type = LB;
	Main.tile[x + 29, y + 4].type = LB;

	Main.tile[x + 30, y + 4].type = LA; // LA



	Main.tile[x + 24, y + 18].active = true;
	Main.tile[x + 24, y + 17].active = true;
	Main.tile[x + 25, y + 17].active = true;
	Main.tile[x + 25, y + 16].active = true;
	Main.tile[x + 26, y + 16].active = true;
	Main.tile[x + 27, y + 16].active = true;
	Main.tile[x + 28, y + 16].active = true;
	Main.tile[x + 28, y + 15].active = true;
	Main.tile[x + 29, y + 15].active = true;
	Main.tile[x + 30, y + 15].active = true;
	Main.tile[x + 30, y + 14].active = true;
	Main.tile[x + 31, y + 14].active = true;
	Main.tile[x + 31, y + 13].active = true;
	Main.tile[x + 32, y + 13].active = true;
	Main.tile[x + 33, y + 13].active = true;
	Main.tile[x + 34, y + 13].active = true;
	Main.tile[x + 34, y + 14].active = true;
	Main.tile[x + 35, y + 14].active = true;
	Main.tile[x + 35, y + 15].active = true;
	Main.tile[x + 36, y + 15].active = true;
	Main.tile[x + 36, y + 16].active = true;
	Main.tile[x + 37, y + 16].active = true;
	Main.tile[x + 38, y + 16].active = true;
	Main.tile[x + 38, y + 17].active = true;
	Main.tile[x + 39, y + 17].active = true;
	Main.tile[x + 40, y + 17].active = true;
	Main.tile[x + 41, y + 17].active = true;
	Main.tile[x + 41, y + 16].active = true;
	Main.tile[x + 42, y + 16].active = true;
	Main.tile[x + 42, y + 15].active = true;
	Main.tile[x + 43, y + 15].active = true;
	Main.tile[x + 43, y + 14].active = true;
	Main.tile[x + 44, y + 14].active = true;
	Main.tile[x + 44, y + 13].active = true;
	Main.tile[x + 44, y + 12].active = true;
	Main.tile[x + 44, y + 11].active = true;
	Main.tile[x + 43, y + 11].active = true;
	Main.tile[x + 43, y + 10].active = true;
	Main.tile[x + 42, y + 10].active = true;
	Main.tile[x + 41, y + 10].active = true;
	Main.tile[x + 41, y + 9].active = true;
	Main.tile[x + 41, y + 8].active = true;
	Main.tile[x + 40, y + 8].active = true;
	Main.tile[x + 39, y + 8].active = true;
	Main.tile[x + 39, y + 7].active = true;
	Main.tile[x + 39, y + 6].active = true;
	Main.tile[x + 39, y + 5].active = true;
	Main.tile[x + 38, y + 5].active = true;
	Main.tile[x + 37, y + 5].active = true;
	Main.tile[x + 37, y + 4].active = true;
	Main.tile[x + 38, y + 4].active = true;
	Main.tile[x + 39, y + 4].active = true;
	Main.tile[x + 40, y + 4].active = true;
	Main.tile[x + 36, y + 3].active = true;
	Main.tile[x + 36, y + 2].active = true;
	Main.tile[x + 41, y + 3].active = true;
	Main.tile[x + 41, y + 2].active = true;
	Main.tile[x + 35, y + 1].active = true;
	Main.tile[x + 36, y + 1].active = true;
	Main.tile[x + 37, y + 1].active = true;
	Main.tile[x + 38, y + 1].active = true;
	Main.tile[x + 39, y + 1].active = true;
	Main.tile[x + 40, y + 1].active = true;
	Main.tile[x + 41, y + 1].active = true;
	Main.tile[x + 42, y + 1].active = true;
	Main.tile[x + 35, y].active = true;
	Main.tile[x + 38, y].active = true;
	Main.tile[x + 39, y].active = true;
	Main.tile[x + 42, y].active = true;
	for (int xoff = x + 37; xoff <= x + 40; xoff++)
	{
		for (int yoff = y + 2; yoff <= y + 3; yoff++)
		{
			Main.tile[xoff, yoff].active = true;
			Main.tile[xoff, yoff].type = LA;
		}
	}
	Main.tile[x + 24, y + 18].type = LB;
	Main.tile[x + 24, y + 17].type = LB;
	Main.tile[x + 25, y + 17].type = LB;
	Main.tile[x + 25, y + 16].type = LB;
	Main.tile[x + 26, y + 16].type = LB;
	Main.tile[x + 27, y + 16].type = LB;
	Main.tile[x + 28, y + 16].type = LB;
	Main.tile[x + 28, y + 15].type = LB;
	Main.tile[x + 29, y + 15].type = LB;
	Main.tile[x + 30, y + 15].type = LB;
	Main.tile[x + 30, y + 14].type = LB;
	Main.tile[x + 31, y + 14].type = LB;
	Main.tile[x + 31, y + 13].type = LB;
	Main.tile[x + 32, y + 13].type = LB;
	Main.tile[x + 33, y + 13].type = LB;
	Main.tile[x + 34, y + 13].type = LB;
	Main.tile[x + 34, y + 14].type = LB;
	Main.tile[x + 35, y + 14].type = LB;
	Main.tile[x + 35, y + 15].type = LB;
	Main.tile[x + 36, y + 15].type = LB;
	Main.tile[x + 36, y + 16].type = LB;
	Main.tile[x + 37, y + 16].type = LB;
	Main.tile[x + 38, y + 16].type = LB;
	Main.tile[x + 38, y + 17].type = LB;
	Main.tile[x + 39, y + 17].type = LB;
	Main.tile[x + 40, y + 17].type = LB;
	Main.tile[x + 41, y + 17].type = LB;
	Main.tile[x + 41, y + 16].type = LB;
	Main.tile[x + 42, y + 16].type = LB;
	Main.tile[x + 42, y + 15].type = LB;
	Main.tile[x + 43, y + 15].type = LB;
	Main.tile[x + 43, y + 14].type = LB;
	Main.tile[x + 44, y + 14].type = LB;
	Main.tile[x + 44, y + 13].type = LB;
	Main.tile[x + 44, y + 12].type = LB;
	Main.tile[x + 44, y + 11].type = LB;
	Main.tile[x + 43, y + 11].type = LB;
	Main.tile[x + 43, y + 10].type = LB;
	Main.tile[x + 42, y + 10].type = LB;
	Main.tile[x + 41, y + 10].type = LB;
	Main.tile[x + 41, y + 9].type = LB;
	Main.tile[x + 41, y + 8].type = LB;
	Main.tile[x + 40, y + 8].type = LB;
	Main.tile[x + 39, y + 8].type = LB;
	Main.tile[x + 39, y + 7].type = LB;
	Main.tile[x + 39, y + 6].type = LB;
	Main.tile[x + 39, y + 5].type = LB;
	Main.tile[x + 38, y + 5].type = LB;
	Main.tile[x + 37, y + 5].type = LB;
	Main.tile[x + 37, y + 4].type = LB;
	Main.tile[x + 38, y + 4].type = LB;
	Main.tile[x + 39, y + 4].type = LB;
	Main.tile[x + 40, y + 4].type = LB;
	Main.tile[x + 36, y + 3].type = LB;
	Main.tile[x + 36, y + 2].type = LB;
	Main.tile[x + 41, y + 3].type = LB;
	Main.tile[x + 41, y + 2].type = LB;
	Main.tile[x + 35, y + 1].type = LB;
	Main.tile[x + 36, y + 1].type = LB;
	Main.tile[x + 37, y + 1].type = LB;
	Main.tile[x + 38, y + 1].type = LB;
	Main.tile[x + 39, y + 1].type = LB;
	Main.tile[x + 40, y + 1].type = LB;
	Main.tile[x + 41, y + 1].type = LB;
	Main.tile[x + 42, y + 1].type = LB;
	Main.tile[x + 35, y].type = LB;
	Main.tile[x + 38, y].type = LB;
	Main.tile[x + 39, y].type = LB;
	Main.tile[x + 42, y].type = LB;

	for (int xoff = x + 6; xoff <= x + 38; xoff++)
	{
		for (int yoff = y + 6; yoff <= y + 12; yoff++)
		{
			Main.tile[xoff, yoff].active = false;
			Main.tile[xoff, yoff].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
		}
	}
	for (int xoff = x + 17; xoff <= x + 27; xoff++)
	{
		for (int yoff = y + 13; yoff <= y + 15; yoff++)
		{
			Main.tile[xoff, yoff].active = false;
			Main.tile[xoff, yoff].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
		}
	}
	for (int xoff = x + 15; xoff <= x + 29; xoff++)
	{
		for (int yoff = y + 13; yoff <= y + 14; yoff++)
		{
			Main.tile[xoff, yoff].active = false;
			Main.tile[xoff, yoff].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
		}
	}
	for (int xoff = x + 20; xoff <= x + 24; xoff++)
	{
		Main.tile[xoff, y + 16].active = false;
		Main.tile[xoff, y + 16].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	}

	Main.tile[x + 14, y + 13].active = true;
	Main.tile[x + 15, y + 14].active = true;
	Main.tile[x + 16, y + 14].active = true;
	Main.tile[x + 17, y + 15].active = true;
	Main.tile[x + 18, y + 15].active = true;
	Main.tile[x + 26, y + 15].active = true;
	Main.tile[x + 27, y + 15].active = true;
	Main.tile[x + 28, y + 14].active = true;
	Main.tile[x + 29, y + 14].active = true;
	Main.tile[x + 30, y + 13].active = true;

	Main.tile[x + 14, y + 13].type = 19;
	Main.tile[x + 15, y + 14].type = 19;
	Main.tile[x + 16, y + 14].type = 19;
	Main.tile[x + 17, y + 15].type = 19;
	Main.tile[x + 18, y + 15].type = 19;
	Main.tile[x + 26, y + 15].type = 19;
	Main.tile[x + 27, y + 15].type = 19;
	Main.tile[x + 28, y + 14].type = 19;
	Main.tile[x + 29, y + 14].type = 19;
	Main.tile[x + 30, y + 13].type = 19;

	Main.tile[x + 14, y + 13].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 30, y + 13].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];

	WorldGen.PlaceTile(x + 12, y + 12, 4, true, true, -1, 2);
	WorldGen.PlaceTile(x + 32, y + 12, 4, true, true, -1, 2);

	for (int xoff = x + 2; xoff <= x + 8; xoff++)
	{
		for (int yoff = y + 11; yoff <= y + 14; yoff++)
		{
			Main.tile[xoff, yoff].active = false;
			Main.tile[xoff, yoff].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
		}
	}
	for (int xoff = x + 36; xoff <= x + 42; xoff++)
	{
		for (int yoff = y + 11; yoff <= y + 14; yoff++)
		{
			Main.tile[xoff, yoff].active = false;
			Main.tile[xoff, yoff].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
		}
	}
	for (int xoff = x + 3; xoff <= x + 7; xoff++)
	{
		Main.tile[xoff, y + 15].active = false;
		Main.tile[xoff, y + 15].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	}
	for (int xoff = x + 37; xoff <= x + 41; xoff++)
	{
		Main.tile[xoff, y + 15].active = false;
		Main.tile[xoff, y + 15].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	}
	Main.tile[x + 4, y + 16].active = false;
	Main.tile[x + 5, y + 16].active = false;
	Main.tile[x + 39, y + 16].active = false;
	Main.tile[x + 40, y + 16].active = false;
	Main.tile[x + 9, y + 13].active = false;
	Main.tile[x + 35, y + 13].active = false;

	Main.tile[x + 4, y + 16].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 5, y + 16].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 39, y + 16].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 40, y + 16].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 9, y + 13].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 35, y + 13].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];

	for (int xoff = x + 4; xoff <= x + 5; xoff++)
	{
		for (int yoff = y + 9; yoff <= y + 10; yoff++)
		{
			Main.tile[xoff, yoff].active = false;
			Main.tile[xoff, yoff].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
		}
	}
	for (int xoff = x + 39; xoff <= x + 40; xoff++)
	{
		for (int yoff = y + 9; yoff <= y + 10; yoff++)
		{
			Main.tile[xoff, yoff].active = false;
			Main.tile[xoff, yoff].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
		}
	}
	for (int xoff = x + 6; xoff <= x + 10; xoff++)
	{
		Main.tile[xoff, y + 8].active = true;
		Main.tile[xoff, y + 8].type = MO;
	}
	for (int xoff = x + 34; xoff <= x + 38; xoff++)
	{
		Main.tile[xoff, y + 8].active = true;
		Main.tile[xoff, y + 8].type = MO;
	}
	Main.tile[x + 10, y + 9].active = true;
	Main.tile[x + 34, y + 9].active = true;
	Main.tile[x + 10, y + 9].type = MO;
	Main.tile[x + 34, y + 9].type = MO;

	WorldGen.PlaceTile(x + 6, y + 6, 4, true, true, -1, 2);
	WorldGen.PlaceTile(x + 38, y + 6, 4, true, true, -1, 2);

	for (int xoff = x + 21; xoff <= x + 23; xoff++)
	{
		for (int yoff = y + 18; yoff <= y + 21; yoff++)
		{
			Main.tile[xoff, yoff].active = false;
			Main.tile[xoff, yoff].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
		}
	}
	for (int xoff = x + 20; xoff <= x + 24; xoff++)
	{
		Main.tile[xoff, y + 22].active = true;
		Main.tile[xoff, y + 22].type = LB;
	}
	for (int xoff = x + 21; xoff <= x + 23; xoff++)
	{
		Main.tile[xoff, y + 23].active = true;
		Main.tile[xoff, y + 23].type = LB;
	}

	WorldGen.PlaceTile(x + 22, y + 21, 4, true, true, -1, 2);

	WorldGen.PlaceDoor(x + 20, y + 20, 10);
	WorldGen.PlaceDoor(x + 24, y + 20, 10);
	WorldGen.PlaceDoor(x + 10, y + 11, 10);
	WorldGen.PlaceDoor(x + 34, y + 11, 10);
	for (int xoff = x + 21; xoff <= x + 23; xoff++)
	{
		Main.tile[xoff, y + 17].active = true;
		Main.tile[xoff, y + 17].type = 19;
		Main.tile[xoff, y + 17].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	}
	for (int xoff = x + 31; xoff <= x + 33; xoff++)
	{
		Main.tile[xoff, y + 4].active = true;
		Main.tile[xoff, y + 4].type = LB;
	}
	Main.tile[x + 43, y + 12].active = false;
	Main.tile[x + 43, y + 13].active = false;
	Main.tile[x + 1, y + 12].active = false;
	Main.tile[x + 1, y + 13].active = false;
	Main.tile[x + 43, y + 12].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 43, y + 13].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 1, y + 12].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];
	Main.tile[x + 1, y + 13].wall = (ushort)Config.wallDefs.ID["Oblivion Brick Wall"];

	WorldGen.PlaceTile(x + 43, y + 12, 4, true, true, -1, 2);
	WorldGen.PlaceTile(x + 1, y + 12, 4, true, true, -1, 2);
	ModWorld.SquareTileFrameArea(x, y, 44);
	AddLavaChest(x + 5, y + 15, 0, false, 1);
	AddLavaChest(x + 40, y + 17, 0, false, 1);
	//Main.tile[x + 4, y + 15].active = true;
	//Main.tile[x + 4, y + 15].type = LB;
	
}

public static bool AddLavaChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
{
	if (WorldGen.genRand == null)
		WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
	int k = j;
	while (k < Main.maxTilesY)
	{
		if (Main.tile[i, k].active && Main.tileSolid[(int)Main.tile[i, k].type])
		{
			int num = k;
			int num2 = WorldGen.PlaceChest(i - 1, num - 1, 21, notNearOtherChests, 1);
			if (num2 >= 0)
			{
				int num3 = 0;
				while (num3 == 0)
				{
					int rN = WorldGen.genRand.Next(42);
					if (rN >= 0 && rN <= 20)
					{
						Main.chest[num2].item[0].SetDefaults("Lava Alloy");
						Main.chest[num2].item[0].stack = WorldGen.genRand.Next(41, 68);
					}
					else if (rN >= 21 && rN <= 40)
					{
						Main.chest[num2].item[0].SetDefaults("Fire Shard");
						Main.chest[num2].item[0].stack = WorldGen.genRand.Next(2, 7);
					}
					else if (rN == 41)
					{
						Main.chest[num2].item[0].SetDefaults("Boomlash");
						Main.chest[num2].item[0].Prefix(-1);
					}
					//Main.chest[num2].item[1].SetDefaults(73, false);
					//Main.chest[num2].item[1].stack = WorldGen.genRand.Next(60, 82);
					int rand = WorldGen.genRand.Next(51);
					if (rand >= 0 && rand <= 20)
					{
						Main.chest[num2].item[1].SetDefaults("Soul of Torture");
						Main.chest[num2].item[1].stack = WorldGen.genRand.Next(6, 16);
					}
					else if (rand >= 21 && rand <= 30)
					{
						Main.chest[num2].item[1].SetDefaults("Flaming Knife");
						Main.chest[num2].item[1].stack = WorldGen.genRand.Next(77, 125);
					}
					else if (rand >= 31 && rand <= 40)
					{
						Main.chest[num2].item[1].SetDefaults("Crimson Potion");
						Main.chest[num2].item[1].stack = WorldGen.genRand.Next(3) + 1;
					}
					else if (rand >= 41 && rand <= 50)
					{
						Main.chest[num2].item[1].SetDefaults("Starbright Potion");
						Main.chest[num2].item[1].stack = WorldGen.genRand.Next(3) + 1;
					}
					int rand2 = WorldGen.genRand.Next(27);
					if (rand2 >= 0 && rand2 <= 10)
					{
						Main.chest[num2].item[2].SetDefaults(73);
						Main.chest[num2].item[2].stack = WorldGen.genRand.Next(20, 31);
					}
					else if (rand2 >= 11 && rand2 <= 25)
					{
						Main.chest[num2].item[2].SetDefaults("Magma Seed");
						Main.chest[num2].item[2].stack = WorldGen.genRand.Next(400, 556);
					}
					else if (rand2 == 26)
					{
						Main.chest[num2].item[2].SetDefaults(74);
						Main.chest[num2].item[2].stack = WorldGen.genRand.Next(4, 12);
					}
					num3++;
				}
				return true;
			}
			return false;
		}
		else k++;
	}
	return false;
}