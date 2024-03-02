bool firstFrame = false;

public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode)
	{

	int closeTownNPCs = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Ivy Plant"].type)
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

	bool undergroundJungle = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneJungle;

	if (undergroundJungle && Config.syncedRand.Next(200) == 0)
	{
	return true;
	}
	}
	return false;
}

public void AI()
{
	npc.TargetClosest();
	if (!firstFrame)
	{
		npc.damage = 0;
		npc.dontTakeDamage = true;
		npc.alpha = 150;
		npc.position = Main.player[npc.target].position;
		firstFrame = true;
	}
	
	if (npc.ai[0] >= 60*5)
	{
	npc.damage = 120;
	npc.dontTakeDamage = false;
	npc.alpha = 0;
	npc.ai[1]++;
	if (npc.ai[1] >= 90 && Main.netMode != 1)
	{
		int nogoodflyspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "No Good Fly", 0);
		npc.ai[1] = 20-40;
		if (Main.netMode == 2 && nogoodflyspawn < 200)
		{
			NetMessage.SendData(23, -1, -1, "", nogoodflyspawn, 0f, 0f, 0f, 0);
		}
	}
	if (npc.ai[2] == 1)
	{
	npc.ai[2] = 0;
	float num48 = 1f;
	int damageproj = 30;
	int type = Config.projectileID["Poisonous Gas"];
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
	if (Main.player[npc.target].position.X > vector8.X-250 && Main.player[npc.target].position.X < vector8.X+250 && Main.player[npc.target].position.Y > vector8.Y-150 && Main.player[npc.target].position.Y < vector8.Y+150)
	{
	Main.player[npc.target].AddBuff(20, 150, false);
	}
	float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
	if (Main.netMode != 2)
	{
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damageproj, 0f, Main.myPlayer);
	Main.projectile[num54].timeLeft = 75;
	}
	}
	}
	else
	{
	npc.ai[0]++;
	}
	if (Main.time % 2 == 0 && Main.netMode == 2 && npc.whoAmI < 200)
	{
	NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
}

public void DealtNPC(double damage, Player player)
{
	if (Config.syncedRand.Next(2) == 0)
	{
	npc.ai[2] = 1;
	}
	if (Main.netMode == 2 && npc.whoAmI < 200)
	{
	NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
}

public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0)
{
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ivy Plant Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ivy Plant Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ivy Plant Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ivy Plant Gore 3", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ivy Plant Gore 3", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ivy Plant Gore 3", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ivy Plant Gore 3", 1f, -1);
}
}