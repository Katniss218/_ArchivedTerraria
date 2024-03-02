#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Waking Mask"].type)
	{
	return false;
	}
	}
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && (y >= Main.rockLayer) && (y <= Main.rockLayer *25);
	bool undergroundJungle = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneHoly;
	if (Main.hardMode && undergroundJungle)
	{
	if (Main.rand.Next(20)==1)
	{
	return true;
	}
	}
	return false;
    int closeTownNPCs = 0;
    if (!Main.bloodMoon)
    {
    Vector2 playerPosition = Main.player[playerID].position + new Vector2(Main.player[playerID].width/2,Main.player[playerID].height/2);
    for (int num36 = 0; num36 < 200; num36++)
    {
    Vector2 npcPosition = Main.npc[num36].position + new Vector2(Main.npc[num36].width/2,Main.npc[num36].height/2);
    if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(playerPosition,npcPosition) < 1500)
    {
    closeTownNPCs++;
    }
    }
    }
    if (closeTownNPCs == 1 && Main.rand.Next(3) == 0) return false;
    if (closeTownNPCs == 2 && Main.rand.Next(2) == 0) return false;
    if (closeTownNPCs == 3 && Main.rand.Next(3) <= 1) return false;
    if (closeTownNPCs >= 4) return false;
}
#endregion

#region AI
public void AI()
{
npc.TargetClosest(true);

if (npc.ai[1] == 0) // First AI
{
if (Main.player[npc.target].position.X < npc.position.X)
{
if (npc.velocity.X > -6) npc.velocity.X -= 0.20f;
}

if (Main.player[npc.target].position.X > npc.position.X)
{
if (npc.velocity.X < 6) npc.velocity.X += 0.20f;
}

if (Main.player[npc.target].position.Y < npc.position.Y+280)
{
if (npc.velocity.Y < 0)
{
if (npc.velocity.Y > -4) npc.velocity.Y -= 0.6f;
}
else npc.velocity.Y -= 0.8f;
}

if (Main.player[npc.target].position.Y > npc.position.Y+280)
{
if (npc.velocity.Y > 0)
{
if (npc.velocity.Y < 4) npc.velocity.Y += 0.7f;
}
else npc.velocity.Y += 0.8f;
}

#region Projectile
npc.ai[0]++;

if (npc.ai[0] >= 100)
{
float Speed = 22f;
Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
int damage = 50;
int type = Config.projectileID["Enemy Curse Ball"];
Main.PlaySound(12, (int) npc.position.X, (int) npc.position.Y, 9);
float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
Main.projectile[num54].timeLeft = 60;
npc.ai[0] = 0;
}
if (Main.rand.Next(6) == 0)
{
// npc is this npc, NPC is the class name - could use this.position and this.width instead
// only variables and functions that are static are allowed to be accessed using the class name
int dust = Dust.NewDust(npc.position, npc.width, npc.height, 55, 0f, 0f, 200, npc.color, 1f);
Main.dust[dust].velocity *= 0.4f;
}

if (Main.rand.Next(40) == 0)
{
Main.PlaySound(16, (int)npc.position.X, (int)npc.position.Y, 1);
}
}
#endregion

if (npc.ai[1] == 1) // Second AI
{
// NPC AI HERE
}

npc.ai[2] += 1;
if (npc.ai[2] >= 600)
{
if (npc.ai[1] == 0) npc.ai[1] = 1;
else npc.ai[1] = 0;
}
}

#endregion

#region Loot
public void NPCLoot()
{
	//generate particle effect
	Color color = new Color();
	Rectangle rectangle = new Rectangle((int)npc.position.X,(int)(npc.position.Y + ((npc.height - npc.width)/2)),npc.width,npc.width);//npc.frame;
	int count = 50;
	float vectorReduce = .4f;
	for (int i = 1; i <= count; i++)
	    {
		//int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 57, 0, 0, 50, Color.White, 2.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        if (npc.life <= 0)
        {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Waking Mask Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Waking Mask Gore 2", 1f, -1);
        }
}
#endregion