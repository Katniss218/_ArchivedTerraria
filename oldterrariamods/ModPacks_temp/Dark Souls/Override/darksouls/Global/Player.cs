#region Dark Souls Drop on Death
//BEGIN DARK SOULS MOD
bool hasblankedsouls = false;

public void PreDraw(Player player,SpriteBatch SP,ref bool LetDraw) 
{
if (player.statLife <= 0 && !hasblankedsouls) {

for (int num24 = 0; num24 < Main.item.Length; num24++) {

if (Main.item[num24].type == Config.itemDefs.byName["Dark Soul"].type && Main.item[num24].damage == player.whoAmi) {
Main.item[num24].active = false;
NetMessage.SendData(21, -1, -1, "", num24, 0f, 0f, 0f, 0);
}

}

for (int num24 = 0; num24 < 44; num24++)
                                {
                                    if (player.inventory[num24].type == Config.itemDefs.byName["Dark Soul"].type && player.inventory[num24].stack > 0)
                                    {
                                        int num54 = Item.NewItem((int)player.position.X,(int)player.position.Y,20,20,Config.itemDefs.byName["Dark Soul"].type,player.inventory[num24].stack);
					Main.item[num54].SetDefaults("Dark Soul");
					Main.item[num54].stack = player.inventory[num24].stack;
					Main.item[num54].damage = player.whoAmi;
					player.inventory[num24].stack = 0;
                                    }

				
				}
		hasblankedsouls = true;
		}
if (player.statLife > 0) 
	hasblankedsouls=false;
return; 



}

#endregion

#region Diamond Pickaxe Does No Damage
public bool CanHitboxDamageNPC(Player P,Rectangle Hitbox,NPC N) // called on npcs that are in the player's weapon hitbox , return true to hit the npc , false otherwise
{
	if(P.inventory[P.selectedItem].type == Config.itemDefs.byName["Diamond Pickaxe"].type) return false;
	else return true;
}

#endregion

#region CreatePlayer
public static void CreatePlayer(Player P)
{
    int v1 = -1, v2 = -1, v3 = -1, v4 = -1;
    for(int u = 0; u < P.inventory.Length ;u++)
    {
        if(v1 != -1 && v2 != -1 && v3 != -1 && v4 != -1) break;
        if(v1 == -1 && P.inventory[u].type == 0) { v1 = u; continue;}
        if(v2 == -1 && P.inventory[u].type == 0) { v2 = u; continue;}
		if(v3 == -1 && P.inventory[u].type == 0) { v3 = u; continue;}
		if(v4 == -1 && P.inventory[u].type == 0) { v4 = u; continue;}
    }
    if(v1 != -1) P.inventory[v1].SetDefaults("Diamond Pickaxe");
    if(v2 != -1) P.inventory[v2].SetDefaults("Magic Mirror"); //&& Config.itemDefs.byName.ContainsKey("Magic Mirror"))
	if(v3 != -1) P.inventory[v3].SetDefaults("Mana Crystal");
	if(v4 != -1) P.inventory[v4].SetDefaults("Orb of Light");
}
#endregion

#region Has Item In Armor
public static bool HasItemInArmor(int type)
{
	for (int f = 0; f < 11; f++)
	{
		if (type == Main.player[Main.myPlayer].armor[f].type)
		{
			return true;
		}
	}
	return false;
}
#endregion

#region Has Buff
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
#endregion

#region Custom Textures
public static Texture2D[] defaultTexture = new Texture2D[0];

public void SetTextures(bool custom)
{
    if(custom)
    {
		Main.sunTexture = Main.tileTexture[Config.tileDefs.ID["Nightmare Sun"]];
		Main.sun2Texture = Main.tileTexture[Config.tileDefs.ID["Nightmare Sun2"]];
		Main.moonTexture = Main.tileTexture[Config.tileDefs.ID["Nightmare Moon"]];

    }
	else
    {
		Main.sunTexture = defaultTexture[0];
		Main.moonTexture = defaultTexture[1];
    }
}

#endregion

// Omnir stuff
public static int[] Defense_Bonus = new int[Main.player.Length];
public static bool dragoonBoots = false;
public static bool dragoonJump = false;

public bool IsShield(Item I)
{
    if(I.shoot == 0) return false;
    if(I.RunMethod("This_Is_A_Shield")) return true;
    return false;
}

// Update Player
public void UpdatePlayer(Player P)

{

//texture changing for SHM
if(defaultTexture.Length == 0)
		{
			defaultTexture = new Texture2D[2];
			defaultTexture[0] = Main.sunTexture;
			defaultTexture[1] = Main.moonTexture;
		}
		SetTextures(!ModWorld.theEnd && ModWorld.superHardmode);
//end texture	

 int ME = P.whoAmi;
    P.statDefense+=Defense_Bonus[ME];
    Defense_Bonus[ME] = 0;
    bool SearchForShields = (Main.GetKeyState((int)Microsoft.Xna.Framework.Input.Keys.C) < 0);
    if (SearchForShields && P.itemAnimation == 0)
    {
        for (int l = 0; l < 40; l++)
        {
            if (IsShield(P.inventory[l]))
            {
                if (P.nonTorch == -1)
                {
                    P.nonTorch = P.selectedItem;
                }
                P.selectedItem = l;
                break;
            }   
        }
    }
    if(SearchForShields && P.selectedItem != P.nonTorch && IsShield(P.inventory[P.selectedItem])) P.controlUseItem = true;
    if(SearchForShields && P.heldProj >= 0 && Main.projectile[P.heldProj].name.Contains("Shield")) P.controlUseItem = true;
    bool toggleDragoonBoots = (Main.GetKeyState((int)Microsoft.Xna.Framework.Input.Keys.Z) == 1);
    if (dragoonBoots == true)
    {
        if (toggleDragoonBoots)
        {
            dragoonJump = true;
            //Main.NewText("Dragoon Jump is now active.", 175, 75, 255);
        }
        else
        {
            dragoonJump = false;
           //Main.NewText("Dragoon Jump is now deactivated.", 175, 75, 255);
        }
    }
    else
    {
        dragoonBoots = false;
        dragoonJump = false;
        //Main.NewText("Dragoon Jump is now deactivated3.", 175, 75, 255);
    }
    dragoonBoots = false;
    if (dragoonJump)
    {
	    Player.jumpSpeed += 10f;
    }





	bool sky = ((double)P.position.Y < Main.worldSurface * 2.85);

    bool surface = !sky && (P.position.Y <= Main.worldSurface);

    bool undergroundHoly =  (P.position.Y >= Main.rockLayer * 13) && P.zoneHoly;

    bool underground = (P.position.Y >= 795);

		int PTilePosX = (int)P.position.X/16;
    bool Ocean = (PTilePosX < 750 || PTilePosX > Main.maxTilesX - 750); 

    bool holyDungeon = (P.position.Y >= Main.rockLayer * 13) && P.zoneDungeon;

    
	if((undergroundHoly && !Ocean && !holyDungeon) || P.zoneMeteor)
	
    {

            P.gravControl=true;
		

    }

    else

    {

    }


	float REDUCE = CheckReduceDefense(P.position, P.velocity, P.width, P.height,P.fireWalk); // <--- added firewalk parameter
	if(REDUCE != 0)
	{
		REDUCE = 1f-REDUCE;
		P.statDefense = (int)((float)P.statDefense*REDUCE);
	}




}



#region Consistent Spike and Hellstone Damge
//Yoraizor code that makes your defense reduce a certain amount when touching spikes and hellstone so they always do the same damage
//Big thanks to Yoraizor for all his help with this
public static Dictionary<int,float> DamageDir = MakeDamDir();
public static Dictionary<int,float> MakeDamDir()
{
	Dictionary<int,float> DamDir = new Dictionary<int,float>();
	//tile id , then the percents to reduce 0.75f = 75% to reduce
	DamDir.Add(48,4); //spike, 4 made defense always 0 (this works fine)
	DamDir.Add(76,4); //hellstone
	return DamDir;
}
public static float CheckReduceDefense(Vector2 Position, Vector2 Velocity, int Width, int Height,bool fireWalk) // <---- added firewalk param
{
	Vector2 Me = Position;

	int LowX = (int)(Position.X / 16f) - 1;
	int HighX = (int)((Position.X + (float)Width) / 16f) + 2;
	int LowY = (int)(Position.Y / 16f) - 1;
	int HighY = (int)((Position.Y + (float)Height) / 16f) + 2;

	#region constraints
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
	#endregion

	for (int i = LowX; i < HighX; i++)
	{
		for (int j = LowY; j < HighY; j++)
		{
			if (Main.tile[i, j] != null && Main.tile[i, j].active)
			{
				Vector2 TilePos;
				TilePos.X = (float)(i * 16);
				TilePos.Y = (float)(j * 16);

				int type = (int)Main.tile[i, j].type;

				if(DamageDir.ContainsKey(type) && !(fireWalk && type == 76)) // <---- hacked a code into here saying that skip things if you havefirewalk and its hellstone (big thanks to Yoraizor for all his help)
				{
					float a = DamageDir[type];
					float z = 0.5f;
					if (Me.X + (float)Width > TilePos.X -z && 
						Me.X < TilePos.X + 16f +z && 
						Me.Y + (float)Height > TilePos.Y -z && 
						Me.Y < TilePos.Y + 16f +z)
					{
						return a;
					}
				}
			}
		}
	}
	return 0;
}
#endregion
