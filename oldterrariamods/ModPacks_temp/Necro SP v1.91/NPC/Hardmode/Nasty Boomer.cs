public float lifetime = 0f;

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Nasty Boomer"].type)
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
	if (Main.rand.Next(100) == 0)
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

lifetime += 1f;

if ((Main.player[npc.target].position.X / 2) < (npc.position.X / 2))
{
if (npc.velocity.X > -15) {npc.velocity.X -= 0.22f;}
}

if ((Main.player[npc.target].position.X / 2) > (npc.position.X / 2))
{
if (npc.velocity.X < 15) {npc.velocity.X += 0.22f;}
}

if ((Main.player[npc.target].position.Y / 2) > (npc.position.Y / 2))
{
if (npc.velocity.Y < 15) {npc.velocity.Y += 0.22f;}
}

if ((Main.player[npc.target].position.Y / 2) < (npc.position.Y / 2))
{
if (npc.velocity.Y > -15) {npc.velocity.Y -= 0.22f;}
}
#endregion

#region Projectile
Vector2 NPC_Center = npc.position+new Vector2(npc.width/2,npc.height/2);
Player P = Main.player[npc.target];
Vector2 Player_Center = P.position+new Vector2(P.width/2,P.height/2);
float Distance = Vector2.Distance(NPC_Center,Player_Center);

if(Distance < 40f){
int num54 = Projectile.NewProjectile(this.npc.position.X,this.npc.position.Y,0,1,"Bomb",20,1f,Main.myPlayer);
Main.projectile[num54].hostile = true;
Main.projectile[num54].friendly = true;
Main.projectile[num54].timeLeft = 1;
Main.projectile[num54].damage = 30;
npc.life = 0;
}
if(lifetime > 300f){
int num54 = Projectile.NewProjectile(this.npc.position.X,this.npc.position.Y,0,1,"Bomb",20,1f,Main.myPlayer);
Main.projectile[num54].hostile = true;
Main.projectile[num54].friendly = true;
Main.projectile[num54].timeLeft = 1;
Main.projectile[num54].damage = 30;
npc.life = 0;
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 5, 0, 0, 50, Color.White, 1.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(npc.position,npc.velocity,"Boomer Gore 1",1.2f,-1);
        Gore.NewGore(npc.position,npc.velocity,"Boomer Gore 2",1.2f,-1);
        Gore.NewGore(npc.position,npc.velocity,"Boomer Gore 3",1.2f,-1);
        Gore.NewGore(npc.position,npc.velocity,"Boomer Gore 2",1.2f,-1);
        Gore.NewGore(npc.position,npc.velocity,"Boomer Gore 3",1.2f,-1);
        }
}
#endregion