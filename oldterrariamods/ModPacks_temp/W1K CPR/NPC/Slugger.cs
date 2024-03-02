int hitCooldown = 0;
bool chargeShot = false;
int chargeTimer = 0;

public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].statDefense >= 10 && !Main.dayTime)
	{

	int closeTownNPCs = 0;
	if (!Main.bloodMoon)
	{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(Main.player[playerID].position,Main.npc[num36].position) < 1500)
	{
	closeTownNPCs++;
	}
	}
	}
	if (closeTownNPCs == 1 && Config.syncedRand.Next(3) == 0) return false;
	if (closeTownNPCs == 2 && Config.syncedRand.Next(2) == 0) return false;
	if (closeTownNPCs == 3 && Config.syncedRand.Next(3) <= 1) return false;
	if (closeTownNPCs >= 4) return false;

	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);

	if (surface && Config.syncedRand.Next(10) == 0)
	{
	return true;
	}
	}
	return false;
}

public void AI()
{
	npc.AI(true);
	if (npc.velocity.Y == 0 && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && hitCooldown <= 0)
	{
		chargeShot = true;
	}
	else
	{
		chargeShot = false;
		chargeTimer = 0;
		hitCooldown -= 1;
	}
	if (chargeShot)
	{
		npc.velocity.X = 0;
		chargeTimer++;
		if (chargeTimer >= 60)
		{
			float num48 = 12f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			int damage = 10;
			int type = Config.projectileID["Baseball"];
            Main.PlaySound(2,(int)npc.position.X,(int)npc.position.Y,SoundHandler.soundID["bat_baseball_hit1"]);
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+Config.syncedRand.Next(-20,20)+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+Config.syncedRand.Next(-20,20)+(Main.player[npc.target].width * 0.5f)));
			if (Main.netMode != 2)
			{
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
			Main.projectile[num54].hostile = true;
			Main.projectile[num54].friendly = false;
			}
			hitCooldown = 300;
		}
	}
}

public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Slugger Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Slugger Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Slugger Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Slugger Gore 3", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Slugger Gore 3", 1f, -1);
}
}