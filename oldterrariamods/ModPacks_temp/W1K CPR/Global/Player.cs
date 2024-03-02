public static bool OPress = false;
public static bool DragonMorph = false;
public static int DragonId = -1;

int medusaHeadsTimer = 0;

public static int WINDEX = ModWorld.AddWingByTextureName("Jump Pack"); //its static because there's no point to initialize this for every single item's instance

public void PreDraw(Player player,SpriteBatch SP,ref bool LetDraw)
{
	if (DragonMorph == true) LetDraw = false;
	
	bool equipd = false;
	for (int num36 = 2; num36 <= 7; num36++)
	{
	if (player.armor[num36].type == Config.itemDefs.byName["Jump Pack"].type) equipd = true;
	}
	for (int num36 = 2; num36 <= 7; num36++)
	{
	if (player.armor[num36].type == 492 || player.armor[num36].type == 493) equipd = false;
	}
	if (equipd)
	{
	player.wings = WINDEX;
	}
}

public bool PostDraw(Player player,SpriteBatch SP) 
{
	bool incomp = false;
	for (int num36 = 2; num36 <= 7; num36++)
	{
	if (player.armor[num36].type != 492 || player.armor[num36].type != 493) incomp = true;
	}
	for (int num36 = 2; num36 <= 7; num36++)
	{
	//if (!incomp && player.armor[num36].type == Config.itemDefs.byName["Jump Pack"].type) player.wings = 0;
	}
	
	return true;
}

public void PreUpdatePlayer(Player player)
{
	if (DragonMorph)
	{
		player.controlHook = false;
		player.controlJump = false;
		player.controlUseItem = false;
		player.controlTorch = false;
	}
	
	//Nightmare Gravity Control
	foreach(NPC npc in Main.npc)
	{
		if (npc.type == Config.npcDefs.byName["Nightmare"].type && npc.active)
		{
			if (player.Distance(npc.Center) <= 1500)
			{
				player.controlUp = false;
				player.controlDown = false;
			}
		}
	}
}

public bool HeldItemEffects(Player P)
{
	if (DragonMorph) return false;
	return true;
}

public void UpdatePlayer(Player player)
{
	// Shadow Dragon Pet
	bool doll = false;
	for (int num36 = 2; num36 <= 7; num36++)
	{
	if (player.armor[num36].type == Config.itemDefs.byName["Okiku Doll"].type) doll = true;
	}
	
	if (doll)
	{
	if (player.whoAmi == Main.myPlayer && OPress && !Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.O)) OPress = false;
	if (player.whoAmi == Main.myPlayer && Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.O) && !OPress && !Main.chatMode)
	{
		if (DragonMorph)
		{
			Main.npc[DragonId].active = false;
			DragonId = -1;
			DragonMorph = false;
		}
		else
		{
			DragonId = NPC.NewNPC((int) player.Center.X-(30/2), (int) player.Center.Y-(30/2), "Pet Shadow Dragon Head", 0);
			Main.npc[DragonId].Center = player.Center;
			Main.npc[DragonId].velocity = player.velocity;
			Main.npc[DragonId].ai[3] = player.whoAmi;
			Main.npc[DragonId].ai[0] = 0;
			if (Main.netMode == 2 && DragonId < 200)
			{
				NetMessage.SendData(23, -1, -1, "", DragonId, 0f, 0f, 0f, 0);
			}
			DragonMorph = true;
		}
		OPress = true;
    }
	}
	else if (DragonMorph)
	{
		Main.npc[DragonId].active = false;
		DragonId = -1;
		DragonMorph = false;
	}

	//Medusa Head
	if (Main.hardMode && player.zoneDungeon)
	{
		if (medusaHeadsTimer >= 60)
		{
			bool canSpawn = true;
			int closeTownNPCs = 0;
			int MedusaHeads = 0;
			if (!Main.bloodMoon)
			{
				for (int num36 = 0; num36 < 200; num36++)
				{
					if (Main.npc[num36].active)
					{
						if (Main.npc[num36].townNPC && Vector2.Distance(player.position,Main.npc[num36].position) < 1500) closeTownNPCs++;;
						if (Main.npc[num36].type == Config.npcDefs.byName["Medusa Head"].type) MedusaHeads++;
					}
				}
			}
			if (closeTownNPCs == 1 && Config.syncedRand.Next(3) == 0) canSpawn = false;
			if (closeTownNPCs == 2 && Config.syncedRand.Next(2) == 0) canSpawn = false;
			if (closeTownNPCs == 3 && Config.syncedRand.Next(3) <= 1) canSpawn = false;
			if (closeTownNPCs >= 4) canSpawn = false;
			if (canSpawn && MedusaHeads < 15)
			{
				if (Config.syncedRand.Next(2) == 0 && Main.netMode != 1) 
				{
					int Medusa = NPC.NewNPC((int) player.position.X-1000, (int) player.position.Y-1000, "Medusa Head", 0);
					if (Main.netMode == 2 && Medusa < 200)
					{
						NetMessage.SendData(23, -1, -1, "", Medusa, 0f, 0f, 0f, 0);
					}
				}
			}
			medusaHeadsTimer = 0;
		}
		else medusaHeadsTimer++;
	}
	
	//Nightmare Gravity Control
	foreach(NPC npc in Main.npc)
	{
		if (npc.type == Config.npcDefs.byName["Nightmare"].type && npc.active)
		{
			if (player.Distance(npc.Center) <= 1500)
			{
				player.baseGravity /= 1.5f;
				player.maxGravity /= 1.5f;
				player.gravControl = true;
				player.gravDir = npc.ai[3];
			}
		}
	}
	
	//Movement Speed Overhaul
	if (Config.mods.IndexOf("Terrariastuck") == -1 && Settings.GetBool("speedoverhaul"))
	{
		player.baseSpeed*=player.moveSpeed;
		player.maximumMaxSpeed*=player.moveSpeed;
		player.baseMaxSpeed*=player.moveSpeed;
		player.baseSpeedAcceleration*=player.moveSpeed;
		if ((player.velocity.X > 8.7f || player.velocity.X < -8.7f) && !player.wet && player.grappling[0] == -1)
		{
			player.waterWalk = true;
			int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 16, -(player.velocity.X/2)+Main.rand.Next(-5,5), -(player.velocity.Y/2)+Main.rand.Next(-5,5), 100, Color.White, Math.Abs(player.velocity.X/5f));
			Main.dust[dust].noGravity = true;
			Main.dust[dust].noLight = true;
		}
		int defensespeed = player.statDefense-(int)((player.moveSpeed-1f)*25f);
		float speedReduction;
		if (defensespeed <= 0) { defensespeed = 0; speedReduction = 0;}
		else speedReduction = (defensespeed/200f) / player.moveSpeed;
		//Main.NewText(""+player.moveSpeed+" "+speedReduction);
		if (speedReduction < 0) speedReduction = 0;
		player.baseSpeed*=1f-speedReduction;
		player.maximumMaxSpeed*=1f-speedReduction;
		player.baseMaxSpeed*=1f-speedReduction;
		player.baseSpeedAcceleration*=1f-speedReduction;
	}
	
	// Ammo Fix
	if (Settings.GetBool("ammofix") && player.inventory[player.selectedItem].useAmmo == 1)
	{
		for (int i = 0; i < 49; i++)
		{
			if (player.inventory[i].type == 40) // Wooden Arrow
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 8%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.08f);
			}
			if (player.inventory[i].type == 41) // Flaming Arrows
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 12%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.12f);
			}
			if (player.inventory[i].type == 47) // Unholy Arrow
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 16%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.16f);
			}
			if (player.inventory[i].type == 51) // Jester Arrow
			{
				player.inventory[i].toolTip2 = "Increases gun projectiles damage by 18%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.18f);
			}
			if (player.inventory[i].type == 265) // Hellfire Arrow
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 20%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.2f);
			}
			if (player.inventory[i].type == 516) // Holy Arrow
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 12%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.12f);
			}
			if (player.inventory[i].type == 545) // Hellfire Arrow
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 30%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.30f);
			}
		}
	}
	if (player.inventory[player.selectedItem].useAmmo == 14)
	{
		for (int i = 0; i < 49; i++)
		{
			if (player.inventory[i].type == 97) // Musket Ball
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 10%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.10f);
			}
			if (player.inventory[i].type == 278) // Silver Bullet
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 15%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.15f);
			}
			if (player.inventory[i].type == 234) // Meteor Bullet
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 15%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.15f);
			}
			if (player.inventory[i].type == 515) // Crystal Bullet
			{
				// player.inventory[i].toolTip2 = "Increases gun projectiles damage by 10%";
				player.inventory[i].damage = 0;//(int) Math.Round(player.inventory[player.selectedItem].damage*0.10f);
			}
			if (player.inventory[i].type == 546) // Cursed Bullet
			{
				player.inventory[i].toolTip = "Increases gun projectiles damage by 20%";
				player.inventory[i].damage = (int) Math.Round(player.inventory[player.selectedItem].damage*0.20f);
			}
		}
	}
}