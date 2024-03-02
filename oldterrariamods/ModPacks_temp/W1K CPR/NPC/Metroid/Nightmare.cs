//npc.ai[0] = 0; TIMER AI
//npc.ai[2] = 0; Phase
int[] hitBox = new int[4];
bool firstFrame = false;
bool InitPhase = false;
bool Rage = false;

/*public static bool SpawnNPC(int x, int y, int playerID)
{
	int closeTownNPCs = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Rathalos"].type)
	{
	return false;
	}
	if (!Main.bloodMoon && Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(Main.player[playerID].position,Main.npc[num36].position) < 1500)
	{
	closeTownNPCs++;
	}
	}
	if (closeTownNPCs == 1 && Config.syncedRand.Next(3) == 0) return false;
	if (closeTownNPCs == 2 && Config.syncedRand.Next(2) == 0) return false;
	if (closeTownNPCs == 3 && Config.syncedRand.Next(3) <= 1) return false;
	if (closeTownNPCs >= 4) return false;

	if (Main.hardMode)
	{
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);

	if (!Main.dayTime && sky)
	{
	if (Config.syncedRand.Next(50) == 0)
	{
	return true;
	}
	}
	}
	return false;
}*/

public void Initialize()
{
	npc.ai[2] = -1;
	npc.ai[0] = Config.syncedRand.Next(400,800);
	npc.ai[3] = 0f;
	hitBox = new int[4];
}

public void AI()
{
	npc.netUpdate = true;
	
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
	npc.TargetClosest(true);
	}
	
	#region Player is ded
	if (Main.player[npc.target].dead)
	{
	npc.velocity.Y -= 0.04f;
	if (npc.timeLeft > 10)
	{
		npc.timeLeft = 10;
		return;
	}
	}
	#endregion
	
	#region Hitboxes
	if (!firstFrame)
	{
		hitBox[0] = NPC.NewNPC((int)npc.position.X+28, (int)npc.position.Y+148, Config.npcDefs.byName["Nightmare Hitbox1"].type, 0);
		if (Main.netMode == 1 && hitBox[0] < 200)
		{
			NetMessage.SendData(23, -1, -1, "", hitBox[0], 0f, 0f, 0f, 0);
		}
		hitBox[1] = NPC.NewNPC((int)npc.position.X+156, (int)npc.position.Y+24, Config.npcDefs.byName["Nightmare Hitbox2"].type, 0);
		if (Main.netMode == 1 && hitBox[1] < 200)
		{
			NetMessage.SendData(23, -1, -1, "", hitBox[1], 0f, 0f, 0f, 0);
		}
		hitBox[2] = NPC.NewNPC((int)npc.position.X+94, (int)npc.position.Y+144, Config.npcDefs.byName["Nightmare HitboxCore"].type, 0);
		if (Main.netMode == 1 && hitBox[2] < 200)
		{
			NetMessage.SendData(23, -1, -1, "", hitBox[2], 0f, 0f, 0f, 0);
		}
		hitBox[3] = NPC.NewNPC((int)npc.position.X+28, (int)npc.position.Y+32, Config.npcDefs.byName["Nightmare HitboxHead"].type, 0);
		if (Main.netMode == 1 && hitBox[3] < 200)
		{
			NetMessage.SendData(23, -1, -1, "", hitBox[3], 0f, 0f, 0f, 0);
		}
		//int again = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, Config.npcDefs.byName["Nightmare"].type, 0);
		Main.npc[hitBox[0]].realLife = Main.npc[hitBox[2]].whoAmI;
		Main.npc[hitBox[1]].realLife = Main.npc[hitBox[2]].whoAmI;
		npc.realLife = Main.npc[hitBox[2]].whoAmI;
		Main.npc[hitBox[3]].realLife = Main.npc[hitBox[2]].whoAmI;
		//Main.npc[again].ai[3] = 1f;
		//npc.active = false;
		firstFrame = true;
	}
	else
	{
	Main.npc[hitBox[0]].position = new Vector2((int)npc.position.X+32, (int)npc.position.Y+148);
	Main.npc[hitBox[1]].position = new Vector2((int)npc.position.X+160, (int)npc.position.Y+24);
	Main.npc[hitBox[2]].position = new Vector2((int)npc.position.X+94, (int)npc.position.Y+144);
	Main.npc[hitBox[3]].position = new Vector2((int)npc.position.X+28, (int)npc.position.Y+32);
	npc.life = Main.npc[hitBox[2]].life;
	}
	#endregion
	
	#region AI
	npc.ai[0]--;
	if (npc.ai[0] <= 0)
	{
		if (npc.ai[2] == -1) npc.ai[2] = Config.syncedRand.Next(3);
		else npc.ai[2] = -1;
		InitPhase = false;
	}
	
	if (!InitPhase)
	{
		if (npc.ai[2] == -1)
		{
			if (Rage) npc.ai[0] = Config.syncedRand.Next(200,400);
			else npc.ai[0] = Config.syncedRand.Next(400,600);
			npc.ai[3] = 1;
		}
		if (npc.ai[2] == 0)
		{
			if (Rage) npc.ai[0] = 350;
			else npc.ai[0] = 350;
			int prj = Projectile.NewProjectile(npc.Center.X-400, npc.Center.Y, 0, 0, "Black Hole", 0, 0f, Main.myPlayer);
			Main.projectile[prj].timeLeft = (int) npc.ai[0];
			Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
		}
		if (npc.ai[2] == 1)
		{
			if (Rage) npc.ai[0] = 350;
			else npc.ai[0] = 350;
			npc.ai[1] = Config.syncedRand.Next(2);
		}
		if (npc.ai[2] == 2)
		{
			if (Rage) npc.ai[0] = 400;
			else npc.ai[0] = 400;
			npc.ai[1] = Config.syncedRand.Next(2);
			foreach (Player player in Main.player)
			{
				float push = (400f-(Math.Abs(player.Center.X - npc.Center.X)))/50f;
				if (push > 0)
				{
					if (player.Center.X < npc.Center.X) player.velocity.X = -push;
					else player.velocity.X = push;
				}
			}
		}
		InitPhase = true;
	}
	
	if (npc.ai[2] == -1) // NORMAL
	{
		if (!Rage)
		{
			if (Main.player[npc.target].Center.X < npc.Center.X-200)
			{
			if (npc.velocity.X > -3f) npc.velocity.X -= 0.05f;
			}
			if (Main.player[npc.target].Center.X > npc.Center.X-200)
			{
			if (npc.velocity.X < 1.5f) npc.velocity.X += 0.05f;
			}
			
			if (Main.player[npc.target].Center.Y < npc.Center.Y+300)
			{
			if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.3f;
			else npc.velocity.Y -= 0.03f;
			}
			if (Main.player[npc.target].Center.Y > npc.Center.Y+300)
			{
			if (npc.velocity.Y < 0f) npc.velocity.Y += 0.3f;
			else npc.velocity.Y += 0.03f;
			}
		}
		else
		{
			if (Main.player[npc.target].Center.X < npc.Center.X-300)
			{
			if (npc.velocity.X > -2f) npc.velocity.X -= 0.02f;
			}
			if (Main.player[npc.target].Center.X > npc.Center.X-300)
			{
			if (npc.velocity.X < 2f) npc.velocity.X += 0.02f;
			}
			
			if (Main.player[npc.target].Center.Y < npc.Center.Y+300)
			{
			if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.2f;
			else npc.velocity.Y -= 0.01f;
			}
			if (Main.player[npc.target].Center.Y > npc.Center.Y+300)
			{
			if (npc.velocity.Y < 0f) npc.velocity.Y += 0.2f;
			else npc.velocity.Y += 0.01f;
			}
		}
	}
	if (npc.ai[2] == 0) // BLACK HOLE
	{
		if (!Rage)
		{
			if (Main.player[npc.target].Center.X < npc.Center.X-400)
			{
			if (npc.velocity.X > -3f) npc.velocity.X -= 0.05f;
			}
			if (Main.player[npc.target].Center.X > npc.Center.X-400)
			{
			if (npc.velocity.X < 2f) npc.velocity.X += 0.05f;
			}
			
			if (Main.player[npc.target].Center.Y < npc.Center.Y+250)
			{
			if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.3f;
			else npc.velocity.Y -= 0.02f;
			}
			if (Main.player[npc.target].Center.Y > npc.Center.Y+250)
			{
			if (npc.velocity.Y < 0f) npc.velocity.Y += 0.3f;
			else npc.velocity.Y += 0.02f;
			}
		}
		else
		{
			if (Main.player[npc.target].Center.X < npc.Center.X-400)
			{
			if (npc.velocity.X > -4f) npc.velocity.X -= 0.06f;
			}
			if (Main.player[npc.target].Center.X > npc.Center.X-400)
			{
			if (npc.velocity.X < 4f) npc.velocity.X += 0.06f;
			}
			
			if (Main.player[npc.target].Center.Y < npc.Center.Y+250)
			{
			if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.5f;
			else npc.velocity.Y -= 0.04f;
			}
			if (Main.player[npc.target].Center.Y > npc.Center.Y+250)
			{
			if (npc.velocity.Y < 0f) npc.velocity.Y += 0.5f;
			else npc.velocity.Y += 0.04f;
			}

		}
		
		if (Main.netMode != 2)
		{
		if (!Rage)
		{
			if (npc.ai[0] % 45 == 0 && npc.ai[0] < 320)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = NPC.NewNPC((int)vector.X, (int)vector.Y, Config.npcDefs.byName["Gravity Shot"].type, npc.whoAmI);
				Main.npc[proj].velocity.X = Config.syncedRand.Next(-400,-100)/100f;
				Main.npc[proj].velocity.Y = Config.syncedRand.Next(-400,400)/100f;
				NetMessage.SendData(23, -1, -1, "", proj, 0f, 0f, 0f, 0);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
			}
		}
		else
		{
			if (npc.ai[0] % 30 == 0 && npc.ai[0] < 320)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = NPC.NewNPC((int)vector.X, (int)vector.Y, Config.npcDefs.byName["Gravity Shot"].type, npc.whoAmI);
				Main.npc[proj].velocity.X = Config.syncedRand.Next(-400,-100)/100f;
				Main.npc[proj].velocity.Y = Config.syncedRand.Next(-400,400)/100f;
				NetMessage.SendData(23, -1, -1, "", proj, 0f, 0f, 0f, 0);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
			}
		}
		}
	}
	if (npc.ai[2] == 1) // JUST SHOT
	{
		if (!Rage)
		{
			if (Main.player[npc.target].Center.X < npc.Center.X-400)
			{
			if (npc.velocity.X > -3f) npc.velocity.X -= 0.05f;
			}
			if (Main.player[npc.target].Center.X > npc.Center.X-400)
			{
			if (npc.velocity.X < 2f) npc.velocity.X += 0.05f;
			}
			
			if (Main.player[npc.target].Center.Y < npc.Center.Y)
			{
			if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.3f;
			else npc.velocity.Y -= 0.02f;
			}
			if (Main.player[npc.target].Center.Y > npc.Center.Y)
			{
			if (npc.velocity.Y < 0f) npc.velocity.Y += 0.3f;
			else npc.velocity.Y += 0.02f;
			}
		}
		else
		{
			if (Main.player[npc.target].Center.X < npc.Center.X-400)
			{
			if (npc.velocity.X > -4f) npc.velocity.X -= 0.06f;
			}
			if (Main.player[npc.target].Center.X > npc.Center.X-400)
			{
			if (npc.velocity.X < 4f) npc.velocity.X += 0.06f;
			}
			
			if (Main.player[npc.target].Center.Y < npc.Center.Y)
			{
			if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.5f;
			else npc.velocity.Y -= 0.04f;
			}
			if (Main.player[npc.target].Center.Y > npc.Center.Y)
			{
			if (npc.velocity.Y < 0f) npc.velocity.Y += 0.5f;
			else npc.velocity.Y += 0.04f;
			}

		}
		
		if (Main.netMode != 2)
		{
		if (!Rage)
		{
			if (npc.ai[1] == 0 && npc.ai[0] % 45 == 0)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = NPC.NewNPC((int)vector.X, (int)vector.Y, Config.npcDefs.byName["Gravity Shot"].type, npc.whoAmI);
				Main.npc[proj].velocity.X = Config.syncedRand.Next(-400,-100)/100f;
				Main.npc[proj].velocity.Y = Config.syncedRand.Next(-400,400)/100f;
				NetMessage.SendData(23, -1, -1, "", proj, 0f, 0f, 0f, 0);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
			}
			if (npc.ai[1] == 1 && npc.ai[0] % 30 == 0)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = Projectile.NewProjectile(vector.X, vector.Y,(float)-10,0, "Nightmare Laser", 50, 0f, Main.myPlayer);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 12);
			}
		}
		else
		{
			if (npc.ai[1] == 0 && npc.ai[0] % 30 == 0)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = NPC.NewNPC((int)vector.X, (int)vector.Y, Config.npcDefs.byName["Gravity Shot"].type, npc.whoAmI);
				Main.npc[proj].velocity.X = Config.syncedRand.Next(-800,-200)/100f;
				Main.npc[proj].velocity.Y = Config.syncedRand.Next(-800,800)/100f;
				NetMessage.SendData(23, -1, -1, "", proj, 0f, 0f, 0f, 0);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
			}
			if (npc.ai[1] == 1 && npc.ai[0] % 20 == 0)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = Projectile.NewProjectile(vector.X, vector.Y,(float)-10,0, "Nightmare Laser", 50, 0f, Main.myPlayer);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 12);
			}
		}
		}
	}
	if (npc.ai[2] == 2) // GRAVITY SWITCH
	{
		if (!Rage)
		{
			if (Main.player[npc.target].Center.X < npc.Center.X)
			{
			if (npc.velocity.X > -3f) npc.velocity.X -= 0.05f;
			}
			if (Main.player[npc.target].Center.X > npc.Center.X)
			{
			if (npc.velocity.X < 2f) npc.velocity.X += 0.05f;
			}
			
			if (Main.player[npc.target].Center.Y < npc.Center.Y)
			{
			if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.4f;
			else npc.velocity.Y -= 0.03f;
			}
			if (Main.player[npc.target].Center.Y > npc.Center.Y)
			{
			if (npc.velocity.Y < 0f) npc.velocity.Y += 0.4f;
			else npc.velocity.Y += 0.03f;
			}
		}
		else
		{
			if (Main.player[npc.target].Center.X < npc.Center.X-400)
			{
			if (npc.velocity.X > -4f) npc.velocity.X -= 0.06f;
			}
			if (Main.player[npc.target].Center.X > npc.Center.X-400)
			{
			if (npc.velocity.X < 4f) npc.velocity.X += 0.06f;
			}
			
			if (Main.player[npc.target].Center.Y < npc.Center.Y)
			{
			if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.5f;
			else npc.velocity.Y -= 0.04f;
			}
			if (Main.player[npc.target].Center.Y > npc.Center.Y)
			{
			if (npc.velocity.Y < 0f) npc.velocity.Y += 0.5f;
			else npc.velocity.Y += 0.04f;
			}
		}
		
		if (npc.ai[0] % 75 == 0 && npc.ai[0] < 380)
		{
			npc.ai[3] *= -1;
			foreach (Player player in Main.player)
			{
				player.fallStart = (int)(player.position.Y / 16f);
				player.jump = 0;
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
			}
		}
		
		if (Main.netMode != 2)
		{
		if (!Rage)
		{
			if (npc.ai[1] == 0 && npc.ai[0] % 45 == 0 && npc.ai[0] < 380)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = NPC.NewNPC((int)vector.X, (int)vector.Y, Config.npcDefs.byName["Gravity Shot"].type, npc.whoAmI);
				Main.npc[proj].velocity.X = Config.syncedRand.Next(-800,-200)/100f;
				Main.npc[proj].velocity.Y = Config.syncedRand.Next(-800,800)/100f;
				NetMessage.SendData(23, -1, -1, "", proj, 0f, 0f, 0f, 0);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
			}
			if (npc.ai[1] == 1 && npc.ai[0] % 30 == 0 && npc.ai[0] < 380)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = Projectile.NewProjectile(vector.X, vector.Y,(float)-10,0, "Nightmare Laser", 50, 0f, Main.myPlayer);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 12);
			}
		}
		else
		{
			if (npc.ai[1] == 0 && npc.ai[0] % 30 == 0 && npc.ai[0] < 380)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = NPC.NewNPC((int)vector.X, (int)vector.Y, Config.npcDefs.byName["Gravity Shot"].type, npc.whoAmI);
				Main.npc[proj].velocity.X = Config.syncedRand.Next(-800,-200)/100f;
				Main.npc[proj].velocity.Y = Config.syncedRand.Next(-800,800)/100f;
				NetMessage.SendData(23, -1, -1, "", proj, 0f, 0f, 0f, 0);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
			}
			if (npc.ai[1] == 1 && npc.ai[0] % 20 == 0 && npc.ai[0] < 380)
			{
				Vector2 vector = new Vector2(Main.npc[hitBox[0]].Center.X,Main.npc[hitBox[0]].Center.Y+Config.syncedRand.Next(-30,50));
				if (Config.syncedRand.Next(2) == 0) vector = new Vector2(Main.npc[hitBox[1]].Center.X,Main.npc[hitBox[1]].Center.Y+Config.syncedRand.Next(-50,50));
				int proj = Projectile.NewProjectile(vector.X, vector.Y,(float)-10,0, "Nightmare Laser", 50, 0f, Main.myPlayer);
				Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 12);
			}
		}
		}
	}
	
	if (!Rage && Main.rand.Next(4)==0)
	{
		int dust = Dust.NewDust(new Vector2((float) npc.position.X+120, (float) npc.position.Y+175), 56, 50, 62, 0, 0, 50, Color.White, 1.0f);
		Main.dust[dust].noGravity = false;
	}
	if (Rage && Main.rand.Next(8)==0)
	{
		int dust = Dust.NewDust(new Vector2((float) npc.position.X+120, (float) npc.position.Y+150), 56, 10, 6, 0, 0, 50, Color.White, 1.0f);
	}
	
	if (!Rage && npc.life < 8000) // 8000
	{
		Rage = true;
		Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 14);
		for (int i = 0; i<20; i++)
		{
			int dust = Dust.NewDust(new Vector2((float) npc.position.X+120, (float) npc.position.Y+175), 56, 50, 31, Config.syncedRand.Next(-3,3), Config.syncedRand.Next(-3,3), 150, Color.White, 2f);
		}
		for (int i = 0; i<15; i++)
		{
			int dust = Dust.NewDust(new Vector2((float) npc.position.X+120, (float) npc.position.Y+175), 56, 50, 6, Config.syncedRand.Next(-3,3), Config.syncedRand.Next(-3,3), 150, Color.White, 3f);
		}
		for (int i = 0; i<20; i++)
		{
			int dust = Dust.NewDust(new Vector2((float) npc.position.X+50, (float) npc.position.Y+54), 80, 86, 31, Config.syncedRand.Next(-3,3), Config.syncedRand.Next(-3,3), 200, Color.White, 3f);
		}
		Main.npc[hitBox[2]].defense = 999;
		Main.npc[hitBox[2]].soundHit = 7;
		Main.npc[hitBox[3]].defense = 10;
		Main.npc[hitBox[3]].soundHit = 1;
	}
	#endregion
	
	if (npc.whoAmI < 200)
	{
		NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
	
	if (!Main.npc[hitBox[2]].active)
	{
		Main.npc[hitBox[0]].active = false;
		Main.npc[hitBox[1]].active = false;
		Main.npc[hitBox[3]].active = false;
		npc.active = false;
	}
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	if (Rage)
	{
		npc.frame.Y = num;
	}
	else
	{
		npc.frame.Y = 0;
	}
}

public void NPCLoot()
{
}