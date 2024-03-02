public static bool isImmuneToSlimes = false;
public static bool LavaMerman = false;
public static int hook = 0;
public static bool gobTB = false;
public static bool runonce = true;
public const int Num_Of_Accs = 3;
public static float rot = 0f;
public static int tropicsTiles = 0;
public static int hellCastleTiles = 0;
public static int skyTiles = 0;
public static int iceTiles = 0;
public static int everTiles = 0;
public static int tropicsCounter = 1;
public static int hellCounter = 1;
public static int skyCounter = 1;
public static int iceCounter = 1;
public static int cometCounter = 1;
public static int idTileChestJungle;
public static int idTileChestHell;
public static bool mainSlots = false;
public static bool extraSlots = false;
public static ushort bs = (ushort)Config.tileDefs.ID["Black Sand"];
public static ushort ib = (ushort)Config.tileDefs.ID["Impervious Brick"];
public static ushort rg = (ushort)Config.tileDefs.ID["Reinforced Glass"];
public static ushort ice = (ushort)Config.tileDefs.ID["Ice Block"];
public static ushort ei = (ushort)Config.tileDefs.ID["Ever Ice"];
public static ushort tlm = (ushort)Config.tileDefs.ID["Tropical Mud"];
public static ushort ts = (ushort)Config.tileDefs.ID["Tropic Stone"];
public static bool zoneTropics = false;
public static bool zoneHellcastle = false;
public static bool zoneSky = false;
public static bool zoneIceCave = false;
public static bool zoneComet = false;
public static bool oldJump = false;
public static int[] MUSIC_BOXES = new int[]{-1,0,1,2,4,5,-1,6,7,9,8,11,10,12};

public static Func<string, Texture2D, bool> AcAchieve;

public static bool HasBuff(string buffName)
{
	int num = Config.buffDefs.ID[buffName];
	for (int i = 0; i < Main.player[Main.myPlayer].buffType.Length; i++)
	{
		if (Main.player[Main.myPlayer].buffType[i] == num && Main.player[Main.myPlayer].buffTime[i] > 0)
		{
			return true;
		}
	}
	return false;
}

public static bool HasBuff(int buffType)
{
	for (int i = 0; i < Main.player[Main.myPlayer].buffType.Length; i++)
	{
		if (Main.player[Main.myPlayer].buffType[i] == buffType && Main.player[Main.myPlayer].buffTime[i] > 0)
		{
			return true;
		}
	}
	return false;
}

/*public static void UpdateMyPlayer(Player player)
{
	if (player.chest >= 0)
	{
		Chest c = Main.chest[player.chest];
		
		if (Main.tile[c.x,c.y].type == 21) { //vanilla chests
			switch (Main.tile[c.x,c.y].frameX) {
				case 2*18: Main.chestText = "Gold Chest"; break;
				case 6*18: Main.chestText = "Shadow Chest"; break;
			}
		} else if (Main.tile[c.x,c.y].type == idTileChestJungle) {
			Main.chestText = "Jungle Chest";
		} else if (Main.tile[c.x,c.y].type == idTileChestHell) {
			Main.chestText = "Hellfire Chest";
		}
	}
}*/

public void DealtPlayer(Player player, double damage, NPC npc)
{
	ModWorld.tookDamageAv[player.whoAmi] = true;
	
	if (player.whoAmi != Main.myPlayer) return;
	if (player.statLife > 0) return;
	
	if (npc.name == "Gargoyle") Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_DEATHGARGOYLE", null});
	/* if (npc.name == "Corrupt Goldfish") ExternalAchieve("TERRARIA_DEATHCORRUPTGOLDFISH");
	if (npc.name == "Mimic") ExternalAchieve("TERRARIA_DEATHMIMIC"); */
	for (int i = 0; i < ModGeneric.extraSlots; i++)
	{
		Item acc = player.whoAmi == Main.myPlayer ? ModWorld.slots.itemSlots[i] : ModWorld.accessories[player.whoAmi][i];
		acc.RunMethod("DealtPlayer", player, damage, npc);
		player.immuneAlpha = 0;
	}
}
public void DamageNPC(Player P, NPC N, ref int DMG, ref float KB)
{
	for (int i = 0; i < ModGeneric.extraSlots; i++)
	{
		Item acc = P.whoAmi == Main.myPlayer ? ModWorld.slots.itemSlots[i] : ModWorld.accessories[P.whoAmi][i];
		acc.RunMethod("DamageNPC", P, N, DMG, KB);
	}
}
public void DamagePVP(Player P, ref int DMG, Player eP) {
	for (int i = 0; i < ModGeneric.extraSlots; i++) {
		Item acc = P.whoAmi == Main.myPlayer ? ModWorld.slots.itemSlots[i] : ModWorld.accessories[P.whoAmi][i];
        acc.RunMethod("DamagePVP", P, DMG, eP);
    }
}
public void DealtPVP(Player P, int DMG, Player eP)
{
	for (int i = 0; i < ModGeneric.extraSlots; i++)
	{
		Item acc = P.whoAmi == Main.myPlayer ? ModWorld.slots.itemSlots[i] : ModWorld.accessories[P.whoAmi][i];
        	acc.RunMethod("DealtPVP", P, DMG, eP);
	}
}
public void DamagePlayer(Player P,ref int DMG,NPC N)
{
	for (int i = 0; i < ModGeneric.extraSlots; i++)
	{
		Item acc = P.whoAmi == Main.myPlayer ? ModWorld.slots.itemSlots[i] : ModWorld.accessories[P.whoAmi][i];
        	acc.RunMethod("DamagePlayer", P, DMG, N);
		P.immuneAlpha = 0;
	}
}

public static int HasItemFind(int type)
{
	for (int j = 0; j < 48; j++)
	{
		if (type == Main.player[Main.myPlayer].inventory[j].type)
		{
			return j;
		}
	}
	return 0;
}

public static bool HasItemInArmor(int type)
{
	for (int j = 0; j < 11; j++)
	{
		if (type == Main.player[Main.myPlayer].armor[j].type)
		{
			return true;
		}
	}
	return false;
}

#region HasItemInExtraSlots
public static bool HasItemInExtraSlots(int type)
{
	for (int j = 0; j < ModGeneric.extraSlots; j++)
	{
		if (type == ModWorld.slots.itemSlots[j].type)
		{
			return true;
		}
	}
	return false;
}
#endregion


public void AdjTiles(Player P)
{
	int num = 4;
	int num2 = 3;
	int num3 = (int)((P.position.X + (float)(P.width / 2)) / 16f);
	int num4 = (int)((P.position.Y + (float)P.height) / 16f);
	for (int j = num3 - num; j <= num3 + num; j++)
	{
		for (int k = num4 - num2; k < num4 + num2; k++)
		{
			if (Main.tile[j, k].active)
			{
				P.adjTile[(int)Main.tile[j, k].type] = true;
				if (Main.tile[j, k].type == (ushort)Config.tileDefs.ID["Caesium Forge"])
				{
					P.adjTile[17] = true;
					P.adjTile[77] = true;
					P.adjTile[133] = true;
				}
				if (Main.tile[j, k].type == (ushort)Config.tileDefs.ID["Adamantite Anvil"])
				{
					P.adjTile[16] = true;
					P.adjTile[134] = true;
				}
				if (Main.tile[j, k].type == (ushort)Config.tileDefs.ID["Resistant Workbench"])
				{
					P.adjTile[18] = true;
				}
				if (Main.tile[j, k].type == (ushort)Config.tileDefs.ID["Ice Workbench"])
				{
					P.adjTile[18] = true;
				}
				if (Main.tile[j, k].type == (ushort)Config.tileDefs.ID["Berserker Anvil"])
				{
					P.adjTile[16] = true;
					P.adjTile[134] = true;
					P.adjTile[Config.tileDefs.ID["Adamantite Anvil"]] = true;
				}
				if (Main.tile[j, k].type == (ushort)Config.tileDefs.ID["Anvenalforge"])
				{
					P.adjTile[13] = true;
					P.adjTile[16] = true;
					P.adjTile[17] = true;
					P.adjTile[18] = true;
					P.adjTile[26] = true;
					P.adjTile[77] = true;
					P.adjTile[133] = true;
					P.adjTile[134] = true;
					P.adjTile[Config.tileDefs.ID["Berserker Anvil"]] = true;
					P.adjTile[Config.tileDefs.ID["Resistant Workbench"]] = true;
					P.adjTile[Config.tileDefs.ID["Ice Workbench"]] = true;
					P.adjTile[Config.tileDefs.ID["Caesium Forge"]] = true;
					P.adjTile[Config.tileDefs.ID["Hallowed Altar"]] = true;
					P.adjTile[Config.tileDefs.ID["Adamantite Anvil"]] = true;
				}
			}
			if (Main.tile[j, k].lava && Main.tile[j, k].liquid > 0)
			{
				P.adjTile[Config.tileDefs.ID["Invisotile"]] = true;
			}
			if (ModWorld.superHardmode)
			{
				P.adjTile[Config.tileDefs.ID["SHM"]] = true;
			}
		}
	}
	int PID = P.whoAmi;
	if(!P.adjTile[114] && PID == Main.myPlayer)
	{
		if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Goblin Toolbelt"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Goblin Toolbelt"].type)) P.adjTile[114] = true;
		else P.adjTile[114] = false;
	}
	if(!P.adjTile[18] && PID == Main.myPlayer)
	{
		if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Goblin Toolbelt"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Goblin Toolbelt"].type)) P.adjTile[18] = true;
		else P.adjTile[18] = false;
	}
}
public bool PreQuickGrapple(Player P)
{
    int quadWhip = Config.itemDefs.byName["Quad Whip"].type;
    if (P.HasItem(quadWhip) && ((ModPlayer.HasItemFind(quadWhip) < ModPlayer.HasItemFind(437)) || (ModPlayer.HasItemFind(quadWhip) < ModPlayer.HasItemFind(185)) || (ModPlayer.HasItemFind(quadWhip) < ModPlayer.HasItemFind(84))) || (P.HasItem(quadWhip) && !(P.HasItem(437)) && !(P.HasItem(185)) && !(P.HasItem(84))))
    {
        Main.player[Main.myPlayer].grappling[0] = -1;
        Main.player[Main.myPlayer].grapCount = 0;
        if (P.controlHook)
        {
            float num48 = 16f;
            Vector2 vector = new Vector2(P.position.X + (float)P.width * 0.5f, P.position.Y + (float)P.height * 0.5f);
            float speedX = (float)Main.mouseX + Main.screenPosition.X - vector.X;
            float speedY = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
            float num51 = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
            num51 = num48 / num51;
            speedX *= num51;
            speedY *= num51;
            hook = Projectile.NewProjectile(vector.X, vector.Y, (float)speedX, (float)speedY, Config.projDefs.byName["Quad Hook"].type, 0, 0f, P.whoAmi);
            //if (Main.projectile[hook].type == Config.projDefs.byName["Quad Hook"].type)
            //{
            //    Main.chainTexture = Main.goreTexture[Config.goreID["Quad Whip Chain"]];
            //}
            //if (Main.projectile[hook].active) Main.chainTexture = Main.goreTexture[Config.goreID["Quad Whip Chain"]];
            //else Main.chainTexture = Main.goreTexture[Config.goreID["Grapple Chain"]];
        }
	//if (Main.projectile[hook].active) Main.chainTexture = Main.goreTexture[Config.goreID["Quad Whip Chain"]];
        //else Main.chainTexture = Main.goreTexture[Config.goreID["Grapple Chain"]];
        return false;
    }
    return true;
}
public static void DrawTexture(SpriteBatch sb, Texture2D texture, Vector2 position, int width, int height, float scale, float rotation, int direction, int framecount, Rectangle frame, object overrideColor)
{
	Vector2 origin = new Vector2((float)(texture.Width / 2), (float)(texture.Height / framecount / 2));
	Color lightColor = overrideColor != null ? (Color)overrideColor : Lighting.GetColor((int)(position.X + width * 0.5f) / 16, (int)(position.Y + height * 0.5f) / 16);
	sb.Draw(texture, GetDrawPosition(position, origin, width, height, texture.Width, texture.Height, framecount, scale), !frame.IsEmpty ? frame : new Rectangle(0, 0, texture.Width, texture.Height), lightColor, rotation, origin, scale, direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
}
/*public void PostDraw(Player P, SpriteBatch SB)
{
	if (runonce)
	{
		rot++;
		Texture2D tex = Main.goreTexture[Config.goreID["Force Field"]];
		//if (P.head == Config.itemDefs.byName["Avalon Helmet"].headSlot &&
		//    P.body == Config.itemDefs.byName["Avalon Bodyarmor"].bodySlot &&
		//    P.legs == Config.itemDefs.byName["Avalon Cuisses"].legSlot)
		//{
			DrawTexture(SB, tex, P.position, P.width, P.height, 1f, rot, P.direction, 1, Rectangle.Empty, Color.White);
		//}
		runonce = false;
	}		
}*/
public static Vector2 GetDrawPosition(Vector2 position, Vector2 origin, int width, int height, int texWidth, int texHeight, int framecount, float scale)
{
	return position - Main.screenPosition + new Vector2(width * 0.5f, height) - new Vector2(texWidth * scale / 2f, texHeight * scale / (float)framecount) + (origin * scale) + new Vector2(0f, 5f);
}
public void UpdatePlayer(Player P)
{
    runonce = true;
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Quad Whip"].type)
    {
        Main.chainTexture = Main.goreTexture[Config.goreID["Quad Whip Chain"]];
    }
    if (P.inventory[P.selectedItem].type != Config.itemDefs.byName["Quad Whip"].type)
    {
        Main.chainTexture = Main.goreTexture[Config.goreID["Grapple Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Sporalash"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Sporalash Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Moonfury"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Moonfury Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Silver Flail"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Silver Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Cobalt Flail"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Cobalt Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Mythril Flail"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Mythril Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Adamantite Flail"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Adamantite Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Heaven's Tear"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Heaven Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Cursed Flail"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Cursed Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Meteor Masher"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Meteor Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Eclipse's Waning"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Eclipse Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Berserker Nightmare"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Berserker Chain"]];
    }
    if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Quad Sunfury"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Quad Chain"]];
    }
    if (P.inventory[P.selectedItem].type != Config.itemDefs.byName["Sporalash"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Moonfury"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Silver Flail"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Cobalt Flail"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Mythril Flail"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Adamantite Flail"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Heaven's Tear"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Cursed Flail"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Meteor Masher"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Eclipse's Waning"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Berserker Nightmare"].type && P.inventory[P.selectedItem].type != Config.itemDefs.byName["Quad Sunfury"].type)
    {
        Main.chain3Texture = Main.goreTexture[Config.goreID["Blue Moon Chain"]];
    }
    if (!Collision.LavaCollision(P.position, P.width, P.height))
    {
        Main.armorArmTexture[22] = Main.goreTexture[Config.goreID["MermanArm"]];
        Main.armorBodyTexture[22] = Main.goreTexture[Config.goreID["MermanBody"]];
        Main.armorHeadTexture[39] = Main.goreTexture[Config.goreID["MermanHead"]];
        Main.armorLegTexture[21] = Main.goreTexture[Config.goreID["MermanLegs"]];
    }
    if (ModPlayer.zoneTropics)
        SoundHandler.SetMusicVanilla(7);
    if (ModPlayer.zoneComet)
        SoundHandler.SetMusicVanilla(2);

    /*if (P.head == Config.itemDefs.byName["Avalon Helmet"].headSlot &&
	P.body == Config.itemDefs.byName["Avalon Bodyarmor"].bodySlot &&
	P.legs == Config.itemDefs.byName["Avalon Cuisses"].legSlot)
    {
	int a = -1;
	if (runonce)
	{
		a = Projectile.NewProjectile(P.position.X, P.position.Y, P.velocity.X, P.velocity.Y, Config.projectileID["Force Field"], 0, 0.5f, P.whoAmi);
		if (Main.projectile[a].timeLeft == 0)
		{
			runonce = true;
		}
		else runonce = false;
	}
	if (a != -1)
	{
		Rectangle proj = ModGeneric.NewRect(Main.projectile[a]);
		foreach (Projectile Pr in Main.projectile)
		{
			if (Pr.type != Config.projectileID["Force Field"])
			{
				Rectangle proj2 = ModGeneric.NewRect(Pr);
				if (proj2.Intersects(proj))
				{
					Pr.hostile = false;
					Pr.friendly = true;
					Pr.velocity.X *= -1f;
					Pr.velocity.Y *= -1f;
				}
			}
		}
	}
    }*/

    #region comet check
    /*int sw = (int)(Main.screenWidth / 16f);
    int sh = (int)(Main.screenHeight / 16f);
    int sx = (int)(Main.screenPosition.X / 16f);
    int sy = (int)(Main.screenPosition.Y / 16f);
    for (int xpos5 = sx; xpos5 < (sx + sw); xpos5++)
    {
	for (int ypos5 = sy; ypos5 < (sy + sh); ypos5++)
	{
		if (xpos5 > Main.maxTilesX - 25) xpos5 = Main.maxTilesX - 25;
		if (xpos5 < 25) xpos5 = 25;
		if (ypos5 > Main.maxTilesY - 40) ypos5 = Main.maxTilesY - 40;
		if (ypos5 < 40) ypos5 = 40;
		if (Main.tile[xpos5, ypos5].active && Main.tile[xpos5, ypos5].type == ei)
		{
			ModPlayer.everTiles++;
		}
	}
    }
    ModPlayer.cometCounter++;
    if (ModPlayer.cometCounter % 12 == 0)
    {
	if (ModPlayer.everTiles >= 50 && P.position.Y < Main.worldSurface + 10f) ModPlayer.zoneComet = true;
	else
	{
		ModPlayer.zoneComet = false;
	}
	ModPlayer.everTiles = 0;
	ModPlayer.cometCounter = 1;
    }
    #endregion

    #region ice cave check
    for (int xpos4 = sx; xpos4 < (sx + sw); xpos4++)
    {
	for (int ypos4 = sy; ypos4 < (sy + sh); ypos4++)
	{
		if (xpos4 > Main.maxTilesX - 25) xpos4 = Main.maxTilesX - 25;
		if (xpos4 < 25) xpos4 = 25;
		if (ypos4 > Main.maxTilesY - 40) ypos4 = Main.maxTilesY - 40;
		if (ypos4 < 40) ypos4 = 40;
		if (Main.tile[xpos4, ypos4].active && Main.tile[xpos4, ypos4].type == ice)
		{
			ModPlayer.iceTiles++;
		}
	}
    }
    ModPlayer.iceCounter++;
    if (ModPlayer.iceCounter % 12 == 0)
    {
	if (ModPlayer.iceTiles >= 75) ModPlayer.zoneIceCave = true;
	else
	{
		ModPlayer.zoneIceCave = false;
	}
	ModPlayer.iceTiles = 0;
	ModPlayer.iceCounter = 1;
    }
    #endregion

    #region sky check
    for (int xpos3 = sx; xpos3 < (sx + sw); xpos3++)
    {
	for (int ypos3 = sy; ypos3 < (sy + sh); ypos3++)
	{
		if (xpos3 > Main.maxTilesX - 25) xpos3 = Main.maxTilesX - 25;
		if (xpos3 < 25) xpos3 = 25;
		if (ypos3 > Main.maxTilesY - 40) ypos3 = Main.maxTilesY - 40;
		if (ypos3 < 40) ypos3 = 40;
		if (Main.tile[xpos3, ypos3].active && Main.tile[xpos3, ypos3].type == rg)
		{
			ModPlayer.skyTiles++;
		}
	}
    }
    ModPlayer.skyCounter++;
    if (ModPlayer.skyCounter % 12 == 0)
    {
	if (ModPlayer.skyTiles >= 75) ModPlayer.zoneSky = true;
	else
	{
		ModPlayer.zoneSky = false;
	}
	ModPlayer.skyTiles = 0;
	ModPlayer.skyCounter = 1;
    }
    #endregion

    #region hellcastle check
    for (int xpos = sx; xpos < (sx + sw); xpos++)
    {
	for (int ypos = sy; ypos < (sy + sh); ypos++)
	{
		if (xpos > Main.maxTilesX - 25) xpos = Main.maxTilesX - 25;
		if (xpos < 25) xpos = 25;
		if (ypos > Main.maxTilesY - 40) ypos = Main.maxTilesY - 40;
		if (ypos < 40) ypos = 40;
		if (Main.tile[xpos, ypos].active && Main.tile[xpos, ypos].type == ib)
		{
			ModPlayer.hellCastleTiles++;
		}
	}
    }
    ModPlayer.hellCounter++;
    if (ModPlayer.hellCounter % 12 == 0)
    {
	if (ModPlayer.hellCastleTiles >= 75) ModPlayer.zoneHellcastle = true;
	else
	{
		ModPlayer.zoneHellcastle = false;
	}
	ModPlayer.hellCastleTiles = 0;
	ModPlayer.hellCounter = 1;
    }
    #endregion

    #region tropics check
    for (int xpos2 = sx; xpos2 < (sx + sw); xpos2++)
    {
	for (int ypos2 = sy; ypos2 < (sy + sh); ypos2++)
	{
		if (xpos2 > Main.maxTilesX - 25) xpos2 = Main.maxTilesX - 25;
		if (xpos2 < 25) xpos2 = 25;
		if (ypos2 > Main.maxTilesY - 40) ypos2 = Main.maxTilesY - 40;
		if (ypos2 < 40) ypos2 = 40;
		if (Main.tile[xpos2, ypos2].active && (Main.tile[xpos2, ypos2].type == bs || Main.tile[xpos2, ypos2].type == tlm || Main.tile[xpos2, ypos2].type == ts))
		{
			ModPlayer.tropicsTiles++;
			//Main.sandTiles++;
		}
	}
    }
    ModPlayer.tropicsCounter++;
    if (ModPlayer.tropicsCounter % 12 == 0)
    {
	if (ModPlayer.tropicsTiles >= 100)
	{
		ModPlayer.zoneTropics = true;
		SoundHandler.SetMusicVanilla(7);
	}
	else
	{
		ModPlayer.zoneTropics = false;
	}
	ModPlayer.tropicsTiles = 0;
	ModPlayer.tropicsCounter = 1;
    }*/
    #endregion

    if (P.zone["Hellcastle"] && Codable.RunGlobalMethod("ModPlayer", "ExternalGetAchieved" , "AVALON_HELLCASTLE") && !(bool)Codable.customMethodReturn)
	Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_HELLCASTLE", null});
    if (P.zone["Tropics"] && Codable.RunGlobalMethod("ModPlayer", "ExternalGetAchieved" , "AVALON_SHM_TROPICS") && !(bool)Codable.customMethodReturn)
	Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_TROPICS", null});
    if (P.zone["Sky Fortress"] && Codable.RunGlobalMethod("ModPlayer", "ExternalGetAchieved" , "AVALON_SHM_SKYFORTRESS") && !(bool)Codable.customMethodReturn)
	Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_SKYFORTRESS", null});

    for (int i = 0; i <= 39; i++)
    {
	if (P.inventory[i] == null || P.inventory[i].name == null || P.inventory[i].name == "" || P.inventory[i].stack <= 0) continue;
	if (P.inventory[i].type == Config.itemDefs.byName["Kinetic Boots"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_KINETIC_BOOTS", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Kinetic Boots D"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_KINETIC_BOOTS", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Kinetic Boots DS"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_KINETIC_BOOTS", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Kinetic Boots S"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_KINETIC_BOOTS", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Kinetic Boots Gold"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_KINETIC_BOOTS_G", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Heaven's Tear"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_HEAVENSTEAR", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Cisgemhibyashoo Bar"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_CIS_BAR", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Starfall"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_STARFALL", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Demonite Coin"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_DEMONCOIN", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Hellstone Coin"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_HELLCOIN", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Vertex of Excalibur"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_VOE", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Elemental Excalibur"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_EE", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Ancient"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_ANCIENT", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Draxmer"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_DRAXMER", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Axe of Emancipation"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_AOE", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Ultrashark"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_ULTRASHARK", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Hallowed Greatsword"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_HALLOW_G", null});
	if (P.inventory[i].type == Config.itemDefs.byName["Destroyer Drill"].type) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_GET_DEST_DRILL", null});
    }
    if (Main.dayTime && !NPC.AnyNPCs(Config.npcDefs.byName["Oblivion Head 1"].type) && ModWorld.superHardmode && P.townNPCs < 1 && Main.sandTiles >= 100 && !ModWorld.WraithInvasion && Main.rand.Next(30000) == 0)
    {
        NPC.SpawnOnPlayer(P.whoAmi, Config.npcDefs.byName["Desert Beak"].type);
        Main.PlaySound(15, -1, -1, 0);
    }
    if (Main.dayTime && !NPC.AnyNPCs(Config.npcDefs.byName["Oblivion Head 1"].type) && ModWorld.superHardmode && P.townNPCs < 1 && Main.jungleTiles >= 150 && !ModWorld.WraithInvasion && Main.rand.Next(40000) == 0)
    {
        NPC.SpawnOnPlayer(P.whoAmi, Config.npcDefs.byName["King Sting"].type);
        Main.PlaySound(15, -1, -1, 0);
    }
    if (Main.dayTime && !NPC.AnyNPCs(Config.npcDefs.byName["Oblivion Head 1"].type) && ModWorld.superHardmode && P.townNPCs < 1 && Main.holyTiles >= 150 && !ModWorld.WraithInvasion && Main.rand.Next(50000) == 0)
    {
        NPC.SpawnOnPlayer(P.whoAmi, Config.npcDefs.byName["Cataryst"].type);
        Main.PlaySound(15, -1, -1, 0);
    }
    if (!Main.dayTime && !NPC.AnyNPCs(Config.npcDefs.byName["Oblivion Head 1"].type) && ModWorld.superHardmode && P.townNPCs < 1 && !P.zone["Hellcastle"] && !ModWorld.WraithInvasion && Main.rand.Next(40000) == 0)
    {
        NPC.SpawnOnPlayer(P.whoAmi, 4);
        Main.PlaySound(15, -1, -1, 0);
    }
    if (!Main.dayTime && !NPC.AnyNPCs(Config.npcDefs.byName["Oblivion Head 1"].type) && !NPC.AnyNPCs(Config.npcDefs.byName["Ultrablivion Head"].type) && ModWorld.superHardmode && P.townNPCs < 1 && !P.zone["Hellcastle"] && !ModWorld.WraithInvasion && Main.rand.Next(40000) == 0)
    {
        NPC.SpawnOnPlayer(P.whoAmi, 134);
        Main.PlaySound(15, -1, -1, 0);
    }
    //int xPos = (int)(P.position.X / 16);
    //int yPos = (int)(P.position.Y / 16);
    //if (Main.dungeonTiles >= 250 && !Main.wallHouse[(int)Main.tile[xPos, yPos].wall] && P.position.Y > Main.worldSurface * 16)
    //{
    //    P.zoneDungeon = true;
    //}
	for (int i = 0; i < ModGeneric.extraSlots; i++) {
		Item acc = P.whoAmi == Main.myPlayer ? ModWorld.slots.itemSlots[i] : ModWorld.accessories[P.whoAmi][i];
		if (acc.type == 15) {if (P.accWatch < 1) P.accWatch = 1;}
		else if (acc.type == 16) {if (P.accWatch < 2) P.accWatch = 2;}
		else if (acc.type == 17) {if (P.accWatch < 3) P.accWatch = 3;}
		else if (acc.type == 18) {if (P.accDepthMeter < 1) P.accDepthMeter = 1;}
		else if (acc.type == 53) P.doubleJump = true;
		else if (acc.type == 54) P.baseMaxSpeed = 6f;
		else if (acc.type == 128) P.rocketBoots = 1;
		else if (acc.type == 156) P.noKnockback = true;
		else if (acc.type == 158) P.noFallDmg = true;
		else if (acc.type == 159) P.jumpBoost = true;
		else if (acc.type == 187) P.accFlipper = true;
		else if (acc.type == 211) P.meleeSpeed += 0.12f;
		else if (acc.type == 223) P.manaCost -= 0.06f;
		else if (acc.type == 285) P.moveSpeed += 0.05f;
		else if (acc.type == 212) P.moveSpeed += 0.1f;
		else if (acc.type == 267) P.killGuide = true;
		else if (acc.type == 193) P.fireWalk = true;
		else if (acc.type == 485) P.wolfAcc = true;
		else if (acc.type == 486) P.rulerAcc = true;
		else if (acc.type == 393) P.accCompass = 1;
		else if (acc.type == 394) {
			P.accFlipper = true;
			P.accDivingHelm = true;
		} else if (acc.type == 395) {
			P.accWatch = 3;
			P.accDepthMeter = 1;
			P.accCompass = 1;
		} else if (acc.type == 396) {
			P.noFallDmg = true;
			P.fireWalk = true;
		} else if (acc.type == 397) {
			P.noKnockback = true;
			P.fireWalk = true;
		} else if (acc.type == 399) {
			P.jumpBoost = true;
			P.doubleJump = true;
		} else if (acc.type == 405) {
			P.baseMaxSpeed = 6f;
			P.rocketBoots = 2;
		} else if (acc.type == 407) P.blockRange = 1;
		else if (acc.type == 489) P.magicDamage += 0.15f;
		else if (acc.type == 490) P.meleeDamage += 0.15f;
		else if (acc.type == 491) P.rangedDamage += 0.15f;
		else if (acc.type == 492) P.wings = 1;
		else if (acc.type == 493) P.wings = 2;
		else if (acc.type == 497) P.accMerman = true;
		else if (acc.type == 535) P.pStone = true;
		else if (acc.type == 536) P.kbGlove = true;
		else if (acc.type == 532) P.starCloak = true;
		else if (acc.type == 554) P.longInvince = true;
		else if (acc.type == 555) {
			P.manaFlower = true;
			P.manaCost -= 0.08f;
		} else if (Main.myPlayer == P.whoAmi) {
			if (acc.type == 576 && Main.rand.Next(18000) == 0 && !(Main.curMusic is SoundHandler.MusicVanilla) || (Main.curMusic is SoundHandler.MusicVanilla && ((SoundHandler.MusicVanilla)Main.curMusic).ID == 0))
			{
				int musId = 0;
				switch (((SoundHandler.MusicVanilla)Main.curMusic).ID)
				{
					case 1:
						musId = 0;
						break;
					case 2:
						musId = 1;
						break;
					case 3:
						musId = 2;
						break;
					case 4:
						musId = 4;
						break;
					case 5:
						musId = 5;
						break;
					case 7:
						musId = 6;
						break;
					case 8:
						musId = 7;
						break;
					case 9:
						musId = 9;
						break;
					case 10:
						musId = 8;
						break;
					case 11:
						musId = 11;
						break;
					case 12:
						musId = 10;
						break;
					case 13:
						musId = 12;
						break;
					default:
						break;
				}
				if (acc.type>=562 && acc.type <=574)
                    acc.SetDefaults(musId+562,false,true);
                Main.musicBox2=acc.type-562;
            }
		}
		
		P.statDefense += acc.defense;
		P.lifeRegen += acc.lifeRegen;
		if (acc.prefix == 62) P.statDefense++;
		else if (acc.prefix == 63) P.statDefense += 2;
		else if (acc.prefix == 64) P.statDefense += 3;
		else if (acc.prefix == 65) P.statDefense += 4;
		else if (acc.prefix == 66) P.statManaMax2 += 20;
		else if (acc.prefix == 67) {
			P.meleeCrit++;
			P.rangedCrit++;
			P.magicCrit++;
		} else if (acc.prefix == 68) {
			P.meleeCrit += 2;
			P.rangedCrit += 2;
			P.magicCrit += 2;
		} else if (acc.prefix == 69) {
			P.meleeDamage += 0.01f;
			P.rangedDamage += 0.01f;
			P.magicDamage += 0.01f;
		} else if (acc.prefix == 70) {
			P.meleeDamage += 0.02f;
			P.rangedDamage += 0.02f;
			P.magicDamage += 0.02f;
		} else if (acc.prefix == 71) {
			P.meleeDamage += 0.03f;
			P.rangedDamage += 0.03f;
			P.magicDamage += 0.03f;
		} else if (acc.prefix == 72) {
			P.meleeDamage += 0.04f;
			P.rangedDamage += 0.04f;
			P.magicDamage += 0.04f;
		} else if (acc.prefix == 73) P.moveSpeed += 0.01f;
		else if (acc.prefix == 74) P.moveSpeed += 0.02f;
		else if (acc.prefix == 75) P.moveSpeed += 0.03f;
		else if (acc.prefix == 76) P.moveSpeed += 0.04f;
		else if (acc.prefix == 77) P.meleeSpeed += 0.01f;
		else if (acc.prefix == 78) P.meleeSpeed += 0.02f;
		else if (acc.prefix == 79) P.meleeSpeed += 0.03f;
		else if (acc.prefix == 80) P.meleeSpeed += 0.04f;
		else if (acc.prefix == Prefix.ID["Avalon:Boosted"]) P.moveSpeed += 0.05f;
		else if (acc.prefix == Prefix.ID["Avalon:Languid"]) P.moveSpeed -= 0.02f;
		else if (acc.prefix == Prefix.ID["Avalon:Timid2"]) P.meleeSpeed -= 0.02f;
		else if (acc.prefix == Prefix.ID["Avalon:Protective"]) P.statDefense += 5;
		else if (acc.prefix == Prefix.ID["Avalon:Dangerous"])
		{
			P.meleeDamage += 0.05f;
			P.rangedDamage += 0.05f;
			P.magicDamage += 0.05f;
		}
		else if (acc.prefix == Prefix.ID["Avalon:Busted"])
		{
			P.meleeDamage -= 0.02f;
			P.rangedDamage -= 0.02f;
			P.magicDamage -= 0.02f;
		}
		else if (acc.prefix == Prefix.ID["Avalon:Magical"]) P.statManaMax2 += 40;
		else if (acc.prefix == Prefix.ID["Avalon:Mythic"]) P.statManaMax2 += 60;
		else if (acc.prefix == Prefix.ID["Avalon:Limited"])
		{
			P.meleeCrit -= 2;
			P.rangedCrit -= 2;
			P.magicCrit -= 2;
		}
		else if (acc.prefix == Prefix.ID["Avalon:Bogus"])
		{
			P.meleeCrit += 3;
			P.rangedCrit += 3;
			P.magicCrit += 3;
		}
		else if (acc.prefix == Prefix.ID["Avalon:Vigorous"])
		{
			P.meleeSpeed += 0.03f;
			P.meleeDamage += 0.03f;
			P.rangedDamage += 0.03f;
			P.magicDamage += 0.03f;
		}
		else if (acc.prefix == Prefix.ID["Avalon:Robust"])
		{
			P.statDefense += 3;
			P.meleeDamage += 0.03f;
			P.rangedDamage += 0.03f;
			P.magicDamage += 0.03f;
		}
		else if (acc.prefix == Prefix.ID["Avalon:Lurid"])
		{
			P.meleeCrit += 2;
			P.rangedCrit += 2;
			P.magicCrit += 2;
			P.statDefense += 2;
		}
		else if (acc.prefix == Prefix.ID["Avalon:Enchanted"])
		{
			P.moveSpeed += 0.03f;
			P.statManaMax2 += 20;
			P.statDefense += 1;
		}
		else if (acc.prefix == Prefix.ID["Avalon:Insane"]) P.meleeSpeed += 0.05f;
		if (!acc.RunMethod("Effects",new object[]{P})) {
			if (acc.type == 238) P.magicDamage += 0.15f;
			else if (acc.type == 123 || acc.type == 124 || acc.type == 125) P.magicDamage += 0.05f;
			else if (acc.type == 151 || acc.type == 152 || acc.type == 153) P.rangedDamage += 0.05f;
			else if (acc.type == 111 || acc.type == 228 || acc.type == 229 || acc.type == 230) P.statManaMax2 += 20;
			else if (acc.type == 228 || acc.type == 229 || acc.type == 230) P.magicCrit += 3;
			else if (acc.type == 100 || acc.type == 101 || acc.type == 102) P.meleeSpeed += 0.07f;
			else if (acc.type == 371) {
				P.magicCrit += 9;
				P.statManaMax2 += 40;
			} else if (acc.type == 372) {
				P.moveSpeed += 0.07f;
				P.meleeSpeed += 0.12f;
			} else if (acc.type == 373) {
				P.rangedDamage += 0.1f;
				P.rangedCrit += 6;
			} else if (acc.type == 374) {
				P.magicCrit += 3;
				P.meleeCrit += 3;
				P.rangedCrit += 3;
			} else if (acc.type == 375) P.moveSpeed += 0.1f;
			else if (acc.type == 376) {
				P.magicDamage += 0.15f;
				P.statManaMax2 += 60;
			} else if (acc.type == 377) {
				P.meleeCrit += 5;
				P.meleeDamage += 0.1f;
			} else if (acc.type == 378) {
				P.rangedDamage += 0.12f;
				P.rangedCrit += 7;
			} else if (acc.type == 379) {
				P.rangedDamage += 0.05f;
				P.meleeDamage += 0.05f;
				P.magicDamage += 0.05f;
			} else if (acc.type == 380) {
				P.magicCrit += 3;
				P.meleeCrit += 3;
				P.rangedCrit += 3;
			} else if (acc.type == 268) P.accDivingHelm = true;
			else if (acc.type == 400) {
				P.magicDamage += 0.11f;
				P.magicCrit += 11;
				P.statManaMax2 += 80;
			} else if (acc.type == 401) {
				P.meleeCrit += 7;
				P.meleeDamage += 0.14f;
			} else if (acc.type == 402) {
				P.rangedDamage += 0.14f;
				P.rangedCrit += 8;
			} else if (acc.type == 403) {
				P.rangedDamage += 0.06f;
				P.meleeDamage += 0.06f;
				P.magicDamage += 0.06f;
			} else if (acc.type == 404) {
				P.magicCrit += 4;
				P.meleeCrit += 4;
				P.rangedCrit += 4;
				P.moveSpeed += 0.05f;
			} else if (acc.type == 558) {
				P.magicDamage += 0.12f;
				P.magicCrit += 12;
				P.statManaMax2 += 100;
			} else if (acc.type == 559) {
				P.meleeCrit += 10;
				P.meleeDamage += 0.1f;
				P.meleeSpeed += 0.1f;
			} else if (acc.type == 553) {
				P.rangedDamage += 0.15f;
				P.rangedCrit += 8;
			} else if (acc.type == 551) {
				P.magicCrit += 7;
				P.meleeCrit += 7;
				P.rangedCrit += 7;
			} else if (acc.type == 552) {
				P.rangedDamage += 0.07f;
				P.meleeDamage += 0.07f;
				P.magicDamage += 0.07f;
				P.moveSpeed += 0.08f;
			}
		}
	}
	Item acces = new Item();
	for (int i = 3; i < 8; i++)
	{
		acces = P.armor[i];
		if (acces == null || acces.name == "" || acces.stack <= 0)
		{
			ModPlayer.mainSlots = false;
			return;
		}
		else ModPlayer.mainSlots = true;
	}
	for (int i = 0; i < ModGeneric.extraSlots; i++)
	{
		acces = ModWorld.slots.itemSlots[i];
		if (acces == null || acces.name == "" || acces.stack <= 0)
		{
			ModPlayer.extraSlots = false;
			return;
		}
		else ModPlayer.extraSlots = true;
	}
        if (mainSlots && extraSlots && Codable.RunGlobalMethod("ModPlayer", "ExternalGetAchieved" , "AVALON_AS+_OVERKILL") && !(bool)Codable.customMethodReturn) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_AS+_OVERKILL", null});
    if (P.position.Y/16f-P.fallStart >= 800)
    {
        Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_HELLEVATOR", null});
    }
    HurtPlayerMagma(P);
    HurtPlayerPSpikes(P);
    Slip(P);
    if (P.HasItem(Config.itemDefs.byName["Whoopie Cushion"].type))
    {
        if (P.controlJump && !oldJump)
        {
            //Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, 14);
            Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, 16);
        }
        oldJump = P.controlJump;
    }
    //if (P.whoAmi == Main.myPlayer) UpdateMyPlayer(P);
}

public void HurtPlayerPSpikes(Player P)
{
	int[] A = { Config.tileDefs.ID["Poison Spikes"] };
	if (!DetectTileCollision(P.position, P.width, P.height, 1, A)) return;
	else
	{
		P.AddBuff(20, 600, false);
		P.Hurt(30 + P.statDefense / 2, P.direction, false, false, " was poison-infused...");
	}
}

public void HurtPlayerMagma(Player P)
{
	int[] A = { Config.tileDefs.ID["Magmatic Ore"] };
	if(!DetectTileCollision(P.position,P.width,P.height,1,A)) return;
	else
	{
		if (!ModPlayer.HasItemInArmor(Config.itemDefs.byName["Tome of Luck"].type) && !ModPlayer.HasItemInArmor(Config.itemDefs.byName["Kinetic Boots Gold"].type) && !ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Tome of Luck"].type) && !ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Kinetic Boots Gold"].type))
		{
			P.Hurt(13 + P.statDefense / 2, P.direction, false, false, " got singed...");
			/* if (P.statDefense >= 0 && P.statDefense <= 60) P.Hurt(40 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 60 && P.statDefense <= 70) P.Hurt(45 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 70 && P.statDefense <= 80) P.Hurt(50 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 80 && P.statDefense <= 90) P.Hurt(55 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 90 && P.statDefense <= 100) P.Hurt(60 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 110 && P.statDefense <= 120) P.Hurt(65 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 120 && P.statDefense <= 130) P.Hurt(70 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 130 && P.statDefense <= 140) P.Hurt(75 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 140 && P.statDefense <= 150) P.Hurt(80 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else if (P.statDefense > 150 && P.statDefense <= 160) P.Hurt(85 - P.statDefense / 2, P.direction, false, false, " got singed...");
			else P.Hurt(90 - P.statDefense / 2, P.direction, false, false, " got singed..."); */
		}
	}
}

#region slip(player)
public void Slip(Player P)
{
	int[] I = new int[]{Config.tileDefs.ID["Ice Block"]};
	if (DetectTileCollision(P.position, P.width, P.height, 1, I))
	{
		#region X affection
		float startSpd = 2.5f; //highspeed start
		if (((double)P.velocity.X > startSpd || (double)P.velocity.X < -startSpd) && (P.controlLeft || P.controlRight))
		{
			float multiplier = 1.02f;
			if (P.controlLeft && P.velocity.X > 0)
				multiplier -= 0.5f;
			if (P.controlRight && P.velocity.X < 0)
				multiplier += 0.5f;
			P.velocity.X *= multiplier;
		}
		else
		{
			if (P.controlLeft || P.controlRight)
				P.velocity.X = P.velocity.X * 1.01f;
			else
				P.velocity.X = P.velocity.X * 0.99f;
		}
		float maxSpd = 12f; //max speed
		if (P.velocity.X > maxSpd)
			P.velocity.X = maxSpd;
		if (P.velocity.X < -maxSpd)
			P.velocity.X = -maxSpd;
		#endregion
	}
}
#endregion

public static bool DetectTileCollision(Vector2 Position, int Width, int Height,int Radius,int[] DetectTargets)
{
	int LowX = (int)((Position.X - 2f) / 16f); // - Radius;
	int HighX = (int)((Position.X + (float)Width) / 16f); // + Radius;
	int LowY = (int)((Position.Y - 2f) / 16f); // - Radius;
	int HighY = (int)((Position.Y + (float)Height) / 16f); // + Radius;
	if (LowX < 0)
	{
		LowX = 0;
	}
	if (HighX > Main.maxTilesX)
	{
		HighX = Main.maxTilesX;
	}
	if (LowY < 0)
	{
		LowY = 0;
	}
	if (HighY > Main.maxTilesY)
	{
		HighY = Main.maxTilesY;
	}
	for (int i = LowX; i <= HighX; i++)
	{
		for (int j = LowY; j <= HighY; j++)
		{
			if (Main.tile[i, j] != null && Main.tile[i, j].active && IsATargetTile(Main.tile[i,j].type,DetectTargets))
			{
				return true;
			}
		}
	}
	return false;
}
public static bool IsATargetTile(int x, int[] t)
{
	foreach (int y in t) if (x == y) return true;
	return false;
}

public void Initialize(int modID) {
	for (int i = 0; i < ModGeneric.extraSlots; i++) ModWorld.slots.itemSlots[i] = new Item();
	idTileChestJungle = Config.tileDefs.ID["Jungle Chest"];
	idTileChestHell = Config.tileDefs.ID["Hellfire Chest"];
}
public void CreatePlayer(Player p) {
	Initialize(ModWorld.modId);
}
public void Save(BinaryWriter bw) {
	for (int i = 0; i < ModGeneric.extraSlots; i++) ItemSave(bw,ModWorld.slots.itemSlots[i]);
}
public void Load(BinaryReader br, int version) {
	for (int i = 0; i < ModGeneric.extraSlots; i++) ModWorld.slots.itemSlots[i] = ItemLoad(br);
}

public static void ItemSave(BinaryWriter bw, Item item) {
	if (item == null) item = new Item();
	bw.Write(item.type != 0);
	if (item.type != 0) {
		bw.Write(item.name);
		bw.Write((byte)item.stack);
		bw.Write((byte)item.prefix);
		Codable.SaveCustomData(item,bw);
	}
}
public static Item ItemLoad(BinaryReader br) {
	Item item = new Item();
	try {
		if (!br.ReadBoolean()) return item;
		item.SetDefaults(br.ReadString());
		item.stack = (int)br.ReadByte();
		item.Prefix((int)br.ReadByte());
		Codable.LoadCustomData(item,br,5,true);
		return item;
	} catch (Exception) {
		return new Item();
	}
}
#region ExternalInitAchievementsDelegates
public static void ExternalInitAchievementsDelegates(
    // bleh?!
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
	    AcAchieve = Achieve;
	    string s, cat;
        bool hmHid = false;
        if (Main.hardMode) hmHid = false;
        if (!Main.hardMode) hmHid = true;

        cat = "Avalon";
        s = "AVALON_HELLCASTLE"; AddAchievement(s, cat, "WoF's house?", "Arrive at the Hellcastle.", null, 10, Main.itemTexture[Config.itemDefs.byName["Resistant Wood"].type], hmHid);
	s = "AVALON_HELLEVATOR"; AddAchievement(s, cat, "Look out below!", "Fall all the way down a Hellevator.", null, 30, Main.itemTexture[Config.itemDefs.byName["Lucky Horseshoe"].type], false);

	cat = "Avalon->Accessory Slots+";
	s = "AVALON_AS+_OVERKILL"; AddAchievement(s, cat, "Overkill!", "Have an accessory equipped in each accessory slot.", null, 20, Main.itemTexture[Config.itemDefs.byName["Anklet of the Wind"].type],false);

        cat = "Avalon->Bosses";
        s = "AVALON_BOSS_BEAK"; AddAchievement(s, cat, "Watch the claws!","Defeat Desert Beak.", null, 10, Main.itemTexture[Config.itemDefs.byName["The Beak"].type], false);
        s = "AVALON_BOSS_STING"; AddAchievement(s, cat, "I heard you like bees?","Defeat King Sting.", null, 10, Main.itemTexture[Config.itemDefs.byName["Hornet Food"].type], false);
        s = "AVALON_BOSS_SLIME"; AddAchievement(s, cat, "You must like disturbing souls.", "Defeat the Armageddon Slime.", null, 20, Main.itemTexture[Config.itemDefs.byName["Dark Matter Gel"].type], hmHid);
        s = "AVALON_BOSS_STEELFANG"; AddAchievement(s, cat, "No need for Retinazer", "Defeat Steelfang.", null, 20, Main.itemTexture[Config.itemDefs.byName["Mechanical Beak"].type], hmHid);
        s = "AVALON_BOSS_MECHASTING"; AddAchievement(s,cat,"ALSO with lazers?!", "Defeat Mechasting.", "AVALON_BOSS_STING", 20, Main.itemTexture[Config.itemDefs.byName["Mechanical Stinger"].type], hmHid);
        s = "AVALON_BOSS_CATARYST"; AddAchievement(s, cat, "It's God!", "Defeat Cataryst.", null, 20, Main.itemTexture[Config.itemDefs.byName["All-Seeing Eye"].type], hmHid);

	cat = "Avalon->Crafting";
	s = "AVALON_GET_KINETIC_BOOTS"; AddAchievement(s, cat, "Must be a speed demon.", "Obtain a version of Kinetic Boots.", null, 20, Main.itemTexture[Config.itemDefs.byName["Kinetic Boots"].type], false);
	s = "AVALON_GET_KINETIC_BOOTS_G"; AddAchievement(s, cat, "That fast enough for you?", "Obtain Kinetic Boots Gold.", "AVALON_GET_KINETIC_BOOTS", 30, Main.itemTexture[Config.itemDefs.byName["Kinetic Boots Gold"].type], true);
	s = "AVALON_GET_HEAVENSTEAR"; AddAchievement(s, cat, "Why would you do that?", "Get Heaven's Tear.", null, 20, Main.itemTexture[Config.itemDefs.byName["Heaven's Tear"].type], false);
	s = "AVALON_GET_CIS_BAR"; AddAchievement(s, cat, "Say that 3 times fast.", "Get a Cisgemhibyashoo Bar.", null, 20, Main.itemTexture[Config.itemDefs.byName["Cisgemhibyashoo Bar"].type], true);
	s = "AVALON_GET_STARFALL"; AddAchievement(s, cat, "Too much damage.", "Get Starfall.", null, 30, Main.itemTexture[Config.itemDefs.byName["Starfall"].type], true);
	s = "AVALON_GET_DEMONCOIN"; AddAchievement(s, cat, "Got enough money?", "Get a Demonite Coin.", null, 10, Main.itemTexture[Config.itemDefs.byName["Demonite Coin"].type], false);
	s = "AVALON_GET_HELLCOIN"; AddAchievement(s, cat, "I think you have too much money.", "Get a Hellstone Coin.", null, 30, Main.itemTexture[Config.itemDefs.byName["Hellstone Coin"].type], true);
	s = "AVALON_GET_VOE"; AddAchievement(s, cat, "Night and light... It's a nightlight!", "Get Vertex of Excalibur.", null, 20, Main.itemTexture[Config.itemDefs.byName["Vertex of Excalibur"].type], hmHid);
	s = "AVALON_GET_EE"; AddAchievement(s, cat, "Elemental fury!", "Get Elemental Excalibur.", "AVALON_GET_VOE", 30, Main.itemTexture[Config.itemDefs.byName["Elemental Excalibur"].type], true);
	s = "AVALON_GET_DRAXMER"; AddAchievement(s, cat, "Isn't that a bit much?", "Get a Draxmer.", null, 20, Main.itemTexture[Config.itemDefs.byName["Draxmer"].type], true);
	s = "AVALON_GET_ULTRASHARK"; AddAchievement(s, cat, "Careful with that.", "Get an Ultrashark.", null, 30, Main.itemTexture[Config.itemDefs.byName["Ultrashark"].type], hmHid);
	s = "AVALON_GET_AOE"; AddAchievement(s, cat, "Hellcastle, here I come.", "Get an Axe of Emancipation.", null, 10, Main.itemTexture[Config.itemDefs.byName["Axe of Emancipation"].type], hmHid);
	s = "AVALON_GET_HALLOW_G"; AddAchievement(s, cat, "Good Lord, that's long.", "Get a Hallowed Greatsword.", null, 10, Main.itemTexture[Config.itemDefs.byName["Hallowed Greatsword"].type], hmHid);
	s = "AVALON_GET_ANCIENT"; AddAchievement(s, cat, "Old... and powerful!", "Get Ancient.", null, 20, Main.itemTexture[Config.itemDefs.byName["Ancient"].type], true);
	s = "AVALON_GET_DEST_DRILL"; AddAchievement(s, cat, "I can mine THAT!", "Get the Destroyer Drill.", "AVALON_GET_DRAXMER", 40, Main.itemTexture[Config.itemDefs.byName["Destroyer Drill"].type], true);

	cat = "Avalon->Death";
	s = "AVALON_DEATHGARGOYLE"; AddAchievement(s, cat, "Revenge of the statue", "Get killed by a Gargoyle.", null, 20, Main.goreTexture[Config.goreID["Gargoyle"]], true);

        cat = "Avalon->Mining";
        s = "AVALON_MINE_TITANIUM"; AddAchievement(s, cat, "Better than iron!", "Mine Titanium Ore.", null, 10, Main.itemTexture[Config.itemDefs.byName["Titanium Ore"].type], false);
        s = "AVALON_MINE_JUNGLE";  AddAchievement(s, cat, "Greener than Mythril!", "Mine Jungle Ore.", null, 10, Main.itemTexture[Config.itemDefs.byName["Jungle Ore"].type], false);
        s = "AVALON_MINE_CAESIUM"; AddAchievement(s, cat, "Right from hell!", "Mine Caesium Ore.", null, 20, Main.itemTexture[Config.itemDefs.byName["Caesium Ore"].type], hmHid);
        s = "AVALON_MINE_HALLOW"; AddAchievement(s, cat, "Holy--!", "Mine Hallowed Ore.", null, 20, Main.itemTexture[Config.itemDefs.byName["Hallowed Ore"].type], hmHid);
        s = "AVALON_MINE_CORRUPT"; AddAchievement(s, cat, "Evil at its finest.", "Mine Corrupted Ore.", null, 20, Main.itemTexture[Config.itemDefs.byName["Corrupted Ore"].type], hmHid);

        cat = "Avalon->Superhardmode";
        s = "AVALON_SHM_SKYFORTRESS"; AddAchievement(s, cat, "No Aether reference!", "Arrive at the Sky Fortress.", null, 30, Main.itemTexture[Config.itemDefs.byName["Reinforced Glass"].type], true);
        s = "AVALON_SHM_TROPICS"; AddAchievement(s, cat, "Jungle!... not?", "Arrive at the Tropics.", null, 10, Main.goreTexture[Config.goreID["MoW"]], true);
        s = "AVALON_SHM_JUGGERNAUT"; AddAchievement(s, cat, "Who said anything about Skeletron?", "Defeat a Juggernaut.", null, 20, Main.goreTexture[Config.goreID["Juggernaut Helmet"]], false);

        cat = "Avalon->Superhardmode->Bosses";
        s = "AVALON_SHM_BOSS_OBLIVION"; AddAchievement(s, cat, "Died enough times?", "Defeat Oblivion.", null, 30, Main.itemTexture[Config.itemDefs.byName["Eye of Oblivion"].type], true);
        s = "AVALON_SHM_BOSS_DRAGON"; AddAchievement(s, cat, "Dragon essence", "Defeat the Dragon Lord.", null, 30, Main.itemTexture[Config.itemDefs.byName["Dragon Lord Helmet"].type], true);
	s = "AVALON_SHM_BOSS_UO"; AddAchievement(s, cat, "Lord of Terraria", "Defeat Ultrablivion.", "AVALON_SHM_BOSS_OBLIVION", 50, Main.itemTexture[Config.itemDefs.byName["Soul of Wight"].type], true);

        cat = "Avalon->Superhardmode->Mining";
        s = "AVALON_SHM_MINE_MAGMATIC"; AddAchievement(s, cat, "Hotter than hot", "Mine Magmatic Ore.", null, 30, Main.itemTexture[Config.itemDefs.byName["Magmatic Ore"].type], false);
        s = "AVALON_SHM_MINE_OBLIVION"; AddAchievement(s, cat, "Like a baws!", "Mine Oblivion Ore.", null, 30, Main.itemTexture[Config.itemDefs.byName["Oblivion Ore"].type], true);
        s = "AVALON_SHM_MINE_OPAL"; AddAchievement(s, cat, "Pearly!", "Mine Opal", null, 30, Main.itemTexture[Config.itemDefs.byName["Opal"].type], false);
	s = "AVALON_SHM_MINE_EVERICE"; AddAchievement(s, cat, "That's c-c-c-cold!", "Mine Ever Ice", null, 10, Main.itemTexture[Config.itemDefs.byName["Ever Ice"].type], true);
	s = "AVALON_SHM_MINE_DARK_MATTER"; AddAchievement(s, cat, "As a Matter of fact, I am Dark.", "Mine Dark Matter", null, 20, Main.itemTexture[Config.itemDefs.byName["Dark Matter Ore"].type], true);

        cat = "Avalon->Superhardmode->Events";
        s = "AVALON_SHM_EVENT_WRAITH"; AddAchievement(s, cat, "Spooky...", "Defeat the Wraith Legion.", null, 20, Main.itemTexture[Config.itemDefs.byName["Ghost Bait"].type], true);
    }
#endregion
#region CheckAc(Player)
public void CheckAc(Player P)
{
	if (P == null) return;
	Item acc = new Item();
	bool mainSlots = false;
	bool extraSlots = false;
	for (int i = 3; i < 8; i++)
	{
		acc = P.armor[i];
		if (acc == null || acc.name == "" || acc.stack <= 0) return;
		else mainSlots = true;
	}
	for (int i = 0; i < ModGeneric.extraSlots; i++)
	{
		acc = ModWorld.slots.itemSlots[i];
		if (acc == null || acc.name == "" || acc.stack <= 0) return;
		else extraSlots = true;
	}
        if (mainSlots && extraSlots) Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_AS+_OVERKILL", null});
}
#endregion

#region watercollision
public static bool WaterCollision(Vector2 Position, int Width, int Height)
{
	int num = (int)(Position.X / 16f) - 1;
	int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
	int num3 = (int)(Position.Y / 16f) - 1;
	int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
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
	for (int i = num; i < num2; i++)
	{
		for (int j = num3; j < num4; j++)
		{
			if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && !Main.tile[i, j].lava)
			{
				Vector2 vector;
				vector.X = (float)(i * 16);
				vector.Y = (float)(j * 16);
				int num5 = 16;
				float num6 = (float)(256 - (int)Main.tile[i, j].liquid);
				num6 /= 32f;
				vector.Y += num6 * 2f;
				num5 -= (int)(num6 * 2f);
				if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num5)
				{
					return true;
				}
			}
		}
	}
	return false;
}
#endregion