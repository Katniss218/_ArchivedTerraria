//npc.ai[2] FRAMES
int lookMode = 0; //0 = Stand, 1 = Player's Direction, 2 = Movement Direction.
int attackPhase = -1;
int subPhase = 0;
int genericTimer = 0;
int genericTimer2 = 0;
int phaseTime = 90;
bool phaseStarted = false;

public void Teleport(float X, float Y)
{
int dustDeath = 0;
for (int num36 = 0; num36 < 20; num36++)
{
	dustDeath = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 54, Config.syncedRand.Next(-10,10), Config.syncedRand.Next(-10,10), 200, Color.White, 4f);
	Main.dust[dustDeath].noGravity = true;
}
npc.position.X = X;
npc.position.Y = Y;
npc.velocity.X = 0;
npc.velocity.Y = 0;
for (int num36 = 0; num36 < 20; num36++)
{
	dustDeath = Dust.NewDust(new Vector2(X, Y), npc.width, npc.height, 54, npc.velocity.X+Config.syncedRand.Next(-10,10), npc.velocity.Y+Config.syncedRand.Next(-10,10), 200, Color.White, 4f);
	Main.dust[dustDeath].noGravity = true;
}
}

public void AI()
{
	npc.netUpdate = false;
	npc.TargetClosest(true);
	
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
		Teleport(-1000,-1000);
		npc.timeLeft = 0;
	}
	
	for(int num36 = 0; num36 < 10; num36++)
	{
		if (Main.player[npc.target].buffType[num36] == 18)
		{
		Main.player[npc.target].buffType[num36] = 0;
		Main.player[npc.target].buffTime[num36] = 0;
		if (Main.netMode != 2 && Main.myPlayer == npc.target)
		{
		Main.NewText("What a horrible night to have your Gravitation buff dispelled by Okiku.", 150, 150, 150);
		}
		break;
		}
	}
	
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
	genericTimer++;
	if (attackPhase == -1)
	{
	lookMode = 0;
	phaseTime = 120;
	}
	
	if (attackPhase == 0) // PHASE 0
	{
	if (!phaseStarted)
	{
	lookMode = 1;
	phaseTime = 60;
	if (Config.syncedRand.Next(2)==0) Teleport(Main.player[npc.target].position.X-500, Main.player[npc.target].position.Y+400);
	else Teleport(Main.player[npc.target].position.X+500, Main.player[npc.target].position.Y+400);
	phaseStarted = true;
	}
	bool left = false;
	if (npc.position.X < Main.player[npc.target].position.X) left = false;
	if (npc.position.X > Main.player[npc.target].position.X) left = true;
	genericTimer2++;
	npc.velocity.Y = -15;
	if (genericTimer2 == 15)
	{
	int num54 = 0;
	if (left)
	{
	num54 = Projectile.NewProjectile(vector8.X, vector8.Y,-6+Config.syncedRand.Next(-1,1), Config.syncedRand.Next(-10,10)/5, "Bloody Cross", 45, 0f, Main.myPlayer);
	}
	else
	{
	num54 = Projectile.NewProjectile(vector8.X, vector8.Y,6+Config.syncedRand.Next(-1,1), Config.syncedRand.Next(-10,10)/5, "Bloody Cross", 45, 0f, Main.myPlayer);
	}
	genericTimer2 = 0;
	}
	}
	
	if (attackPhase == 1) // PHASE 1
	{
	if (!phaseStarted)
	{
	subPhase = Config.syncedRand.Next(2);
	for (int lol = 0; lol < Main.projectile.Length; lol++)
	{
		if (Main.projectile[lol].active && Main.projectile[lol].type == Config.projDefs.byName["Hack Mask"].type)
		{
		subPhase = 0;
		break;
		}
	}
	lookMode = 0;
	phaseTime = 90;
	Teleport(Main.player[npc.target].position.X+Config.syncedRand.Next(-50,50), Main.player[npc.target].position.Y+Config.syncedRand.Next(-50,50)-300);
	phaseStarted = true;
	}
	genericTimer2++;
	if (genericTimer2 >= 40)
	{
	int randomrot = Config.syncedRand.Next(-20,20)/2;
	if (subPhase == 0) // SUB PHASE 0
	{
	for (int num36 = 0; num36 < 9; num36++)
	{
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float) Math.Sin(randomrot+((360/13)*(1+num36))*3),(float) Math.Cos(randomrot+((360/13)*(1+num36))*3), "Bloody Saw", 50, 0f, Main.myPlayer);
	}
	genericTimer2 = 0;
	}
	if (subPhase == 1) // SUB PHASE 1
	{
	for (int num36 = 0; num36 < 6; num36++)
	{
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float) Math.Sin(randomrot+((360/10)*(1+num36)))*6,(float) Math.Cos(randomrot+((360/10)*(1+num36)))*6, "Hack Mask", 50, 0f, Main.myPlayer);
	Main.projectile[num54].ai[0] = npc.target;
	}
	genericTimer2 = -200;
	}
	}
	}
	
	if (attackPhase == 2) // PHASE 2
	{
	if (!phaseStarted)
	{
	lookMode = 2;
	phaseTime = 120;
	npc.position.X = Main.player[npc.target].position.X + (float) ((800* Math.Cos((float) (Config.syncedRand.Next(360)*(Math.PI/180))))*-1);
    npc.position.Y = Main.player[npc.target].position.Y + (float) ((800* Math.Sin((float) (Config.syncedRand.Next(360)*(Math.PI/180))))*-1);
    Vector2 vector7 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
    float rotation = (float) Math.Atan2(vector7.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector7.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
    npc.velocity.X = (float) (Math.Cos(rotation) * 16)*-1;
    npc.velocity.Y = (float) (Math.Sin(rotation) * 16)*-1;
	phaseStarted = true;
	}
	genericTimer2++;
	npc.velocity.X *= 0.99f;
	npc.velocity.Y *= 0.99f;
	if (genericTimer2 >= 22)
	{
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation += Config.syncedRand.Next(-50,50)/100;
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * 0.5)*-1),(float)((Math.Sin(rotation) * 0.5)*-1), "Bloody Saw", 50, 0f, Main.myPlayer);
		genericTimer2 = 0;
	}
	}
	
	if (attackPhase == 3) // PHASE 3
	{
	if (!phaseStarted)
	{
	lookMode = 2;
	phaseTime = 180;
	npc.position.X = Main.player[npc.target].position.X + (float) ((600* Math.Cos((float) (Config.syncedRand.Next(360)*(Math.PI/180))))*-1);
    npc.position.Y = Main.player[npc.target].position.Y + (float) ((600* Math.Sin((float) (Config.syncedRand.Next(360)*(Math.PI/180))))*-1);
	phaseStarted = true;
	}
	Vector2 vector7 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
	float rotation = (float) Math.Atan2(vector7.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector7.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
	npc.velocity.X = (float) (Math.Cos(rotation) * 5)*-1;
    npc.velocity.Y = (float) (Math.Sin(rotation) * 5)*-1;
	genericTimer2++;
	if (genericTimer2 >= 12)
	{
		rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation += Config.syncedRand.Next(-50,50)/100;
		int num54 = Projectile.NewProjectile(vector8.X+Config.syncedRand.Next(-100,100), vector8.Y+Config.syncedRand.Next(-100,100),(float)((Math.Cos(rotation) * (0.5f+(Config.syncedRand.Next(-3,3)/10)))*-1),(float)((Math.Sin(rotation) * (0.5f+(Config.syncedRand.Next(-3,3)/10)))*-1), "Bloody Knife", 45, 0f, Main.myPlayer);
		genericTimer2 = 0;
	}
	}
	
	if (genericTimer >= phaseTime)
	{
	attackPhase = Config.syncedRand.Next(4);
	genericTimer = 0;
	genericTimer2 = 0;
	phaseStarted = false;
	}













}

public void FindFrame(int currentFrame)
{
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 100, Color.White, 1f);
    Main.dust[dust].noGravity = true;
	
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}

	if (lookMode == 0)
	{
	npc.frame.Y = 0;
	}
	if (lookMode == 1)
	{
	if (Main.player[npc.target].position.X < npc.position.X) npc.frame.Y = num;
	if (Main.player[npc.target].position.X > npc.position.X) npc.frame.Y = num*2;
	}
	if (lookMode == 2)
	{
	if (npc.velocity.X < -1f) npc.frame.Y = num;
	if (npc.velocity.X > 1f) npc.frame.Y = num*2;
	if (npc.velocity.X > -1f && npc.velocity.X < 1f) npc.frame.Y = 0;
	}
	
	if (Config.syncedRand.Next(2) == 0)
	{
	if (npc.frame.Y == 0) Dust.NewDust(new Vector2((float) npc.position.X+40, (float) npc.position.Y+36), 10, 10, 5, 0, 0, 50, Color.White, 1.0f);
	if (npc.frame.Y == num) Dust.NewDust(new Vector2((float) npc.position.X+28, (float) npc.position.Y+36), 10, 10, 5, 0, 0, 50, Color.White, 1.0f);
	if (npc.frame.Y == num*2) Dust.NewDust(new Vector2((float) npc.position.X+30, (float) npc.position.Y+36), 10, 10, 5, 0, 0, 50, Color.White, 1.0f);
	}
}


public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Okiku Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Okiku Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Okiku Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Okiku Gore 3", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Okiku Gore 3", 1f, -1);
for (int num36 = 0; num36 < 50; num36++)
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 5, Config.syncedRand.Next(-5,5), Config.syncedRand.Next(-5,5), 100, color, 2f);
}
}
}