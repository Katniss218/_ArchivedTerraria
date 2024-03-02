//npc.ai[2] FRAMES

public static bool SpawnNPC(int x, int y, int playerID)
{
	int closeTownNPCs = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Yian Kut-Ku"].type)
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

	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	if (!Main.dayTime && sky)
	{
	if (!Main.hardMode && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && Config.syncedRand.Next(50) == 0) return true;
	if (Main.hardMode && Config.syncedRand.Next(75) == 0) return true;
	}
	return false;
}

public void AI()
{
	npc.netUpdate = true;
	npc.ai[2]++;
	npc.ai[1]++;
	
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
	npc.TargetClosest(true);
	}
	if (npc.ai[2] < 600)
	{
	if (Main.player[npc.target].Center.X < npc.Center.X)
	{
	if (npc.velocity.X > -8) {npc.velocity.X -= 0.10f;}
	}
	if (Main.player[npc.target].Center.X > npc.Center.X)
	{
	if (npc.velocity.X < 8) {npc.velocity.X += 0.10f;}
	}
	
	if (Main.player[npc.target].Center.Y < npc.Center.Y+300)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.4f;
	else npc.velocity.Y -= 0.03f;
	}
	if (Main.player[npc.target].Center.Y > npc.Center.Y+300)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.4f;
	else npc.velocity.Y += 0.03f;
	}
	
	if (npc.ai[1] >= 0 && npc.ai[2] > 180 && npc.ai[2] < 600)
	{
		float num48 = 9f;
			Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
			int damage = 10;
			int type = Config.projectileID["Flame Shot"];
            Main.PlaySound(2, (int) npc.Center.X, (int) npc.Center.Y, 17);
			float rotation = (float) Math.Atan2(vector8.Y-Main.player[npc.target].Center.Y, vector8.X-Main.player[npc.target].Center.X);
		if (Main.netMode != 2)
		{
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
			Main.projectile[num54].timeLeft = 300;
			Main.projectile[num54].tileCollide=false;
		}
		npc.ai[1] = -90;
	}
	}
	else if (npc.ai[2] >= 600 && npc.ai[2] < 1200)
	{
		npc.velocity.X *= 0.98f;
		npc.velocity.Y *= 0.98f;
		if ((npc.velocity.X < 1f) && (npc.velocity.X > -1f) && (npc.velocity.Y < 1f) && (npc.velocity.Y > -1f))
		{
			float rotation = (float) Math.Atan2(npc.Center.Y-Main.player[npc.target].Center.Y, npc.Center.X-Main.player[npc.target].Center.X);
			npc.velocity.X = (float) (Math.Cos(rotation) * 15)*-1;
			npc.velocity.Y = (float) (Math.Sin(rotation) * 15)*-1;
		}
	}
	else npc.ai[2] = 0;
	
	if (Main.player[npc.target].dead)
	{
	npc.velocity.Y -= 0.04f;
	if (npc.timeLeft > 10)
	{
		npc.timeLeft = 10;
		return;
	}
	}
	
	if (Main.netMode == 2 && npc.whoAmI < 200)
	{
		NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	if (npc.velocity.X < 0)
	{
	npc.spriteDirection = -1;
	}
	else
	{
	npc.spriteDirection = 1;
	}
	npc.rotation = npc.velocity.X * 0.06f;
	npc.frameCounter += 1.0;
	if (npc.frameCounter >= 5.0)
	{
		npc.frame.Y = npc.frame.Y + num;
		npc.frameCounter = 0.0;
	}
	if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
	{
		npc.frame.Y = 0;
	}
}

public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.Center, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Yian Kut Ku Gore 1", 1f, -1);
Gore.NewGore(npc.Center, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Yian Kut Ku Gore 2", 1f, -1);
Gore.NewGore(npc.Center, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Yian Kut Ku Gore 3", 1f, -1);
Gore.NewGore(npc.Center, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Yian Kut Ku Gore 2", 1f, -1);
}
}