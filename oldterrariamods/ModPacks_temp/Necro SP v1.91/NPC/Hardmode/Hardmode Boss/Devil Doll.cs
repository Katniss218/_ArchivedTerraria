//npc.ai[2] FRAMES
int lookMode = 0; //0 = Stand, 1 = Player's Direction, 2 = Movement Direction.
bool ShieldBroken = false;
int attackPhase = -1;
int subPhase = 0;
int genericTimer = 0;
int genericTimer2 = 0;
int phaseTime = 90;
bool phaseStarted = false;

public int RangedDefenseValue() 
{ 
    return 5;
}

#region Teleport
public void Teleport(float X, float Y)
{
int dustDeath = 0;
for (int num36 = 0; num36 < 20; num36++)
{
	dustDeath = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 54, Main.rand.Next(-10,10), Main.rand.Next(-10,10), 200, Color.White, 4f);
	Main.dust[dustDeath].noGravity = true;
}
npc.position.X = X;
npc.position.Y = Y;
npc.velocity.X = 0;
npc.velocity.Y = 0;
for (int num36 = 0; num36 < 20; num36++)
{
	dustDeath = Dust.NewDust(new Vector2(X, Y), npc.width, npc.height, 54, npc.velocity.X+Main.rand.Next(-10,10), npc.velocity.Y+Main.rand.Next(-10,10), 200, Color.White, 4f);
	Main.dust[dustDeath].noGravity = true;
}
}
#endregion

#region AI
public void AI()
{
	npc.TargetClosest(true);
	
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
		Teleport(-1000,-1000);
		npc.timeLeft = 0;
	}
	
	
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
	genericTimer++;
	if (attackPhase == -1)
	{
	lookMode = 0;
	phaseTime = 120;
	}

#region Phase 0
	if (attackPhase == 0) // PHASE 0
	{
	if (!phaseStarted)
	{
	lookMode = 1;
	phaseTime = 60;
	if (Main.rand.Next(2)==0) Teleport(Main.player[npc.target].position.X-500, Main.player[npc.target].position.Y+400);
	else Teleport(Main.player[npc.target].position.X+500, Main.player[npc.target].position.Y+400);
	phaseStarted = true;
	}
	bool left = false;
	if (npc.position.X < Main.player[npc.target].position.X) left = false;
	if (npc.position.X > Main.player[npc.target].position.X) left = true;
	genericTimer2++;
	npc.velocity.Y = -15;
	if (genericTimer2 == 10)
	{
	int num54 = 0;
	if (left)
	{
	int damage = (int) (14f * npc.scale);
	num54 = Projectile.NewProjectile(vector8.X, vector8.Y,-6+Main.rand.Next(-1,1), Main.rand.Next(-10,10)/5, "Cleaver", 20, 0f, 0);
	}
	else
	{
	int damage = (int) (14f * npc.scale);
	num54 = Projectile.NewProjectile(vector8.X, vector8.Y,6+Main.rand.Next(-1,1), Main.rand.Next(-10,10)/5, "Evil Seed", 20, 0f, 0);
	}
	genericTimer2 = 0;
	}
	}
#endregion
	
#region Phase 1
	if (attackPhase == 1) // PHASE 1
	{
	if (!phaseStarted)
	{
	subPhase = Main.rand.Next(2);
	for (int lol = 0; lol < Main.projectile.Length; lol++)
	{
	    int damage = (int) (14f * npc.scale);
		if (Main.projectile[lol].active && Main.projectile[lol].type == Config.projDefs.byName["Evil Seed"].type)
		{
		subPhase = 0;
		break;
		}
	}
#endregion

#region Sub Phase
	lookMode = 0;
	phaseTime = 80;
	Teleport(Main.player[npc.target].position.X+Main.rand.Next(-25,25), Main.player[npc.target].position.Y+Main.rand.Next(-25,25)-300);
	phaseStarted = true;
	}
	genericTimer2++;
	if (genericTimer2 >= 40)
	{
	int randomrot = Main.rand.Next(-20,20)/2;
	if (subPhase == 0) // SUB PHASE 0
	{
	for (int num36 = 0; num36 < 9; num36++)
	{
	int damage = (int) (14f * npc.scale);
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float) Math.Sin(randomrot+((360/13)*(1+num36))*3),(float) Math.Cos(randomrot+((360/13)*(1+num36))*3), "Hungry Doll Head", 24, 0f, 0);
	}
	genericTimer2 = 0;
	}
	if (subPhase == 1) // SUB PHASE 1
	{
	for (int num36 = 0; num36 < 6; num36++)
	{
	int damage = (int) (14f * npc.scale);
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float) Math.Sin(randomrot+((360/10)*(1+num36)))*6,(float) Math.Cos(randomrot+((360/10)*(1+num36)))*6, "Bladed Doll Arm", 20, 0f, 0);
	Main.projectile[num54].ai[0] = npc.target;
	}
	genericTimer2 = -200;
	}
	}
	}
#endregion
	
#region Phase 2
	if (attackPhase == 2) // PHASE 2
	{
	if (!phaseStarted)
	{
	lookMode = 2;
	phaseTime = 90;
	npc.position.X = Main.player[npc.target].position.X + (float) ((600* Math.Cos((float) (Main.rand.Next(360)*(Math.PI/180))))*-1);
    npc.position.Y = Main.player[npc.target].position.Y + (float) ((600* Math.Sin((float) (Main.rand.Next(360)*(Math.PI/180))))*-1);
    Vector2 vector7 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
    float rotation = (float) Math.Atan2(vector7.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector7.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
    npc.velocity.X = (float) (Math.Cos(rotation) * 16)*-1;
    npc.velocity.Y = (float) (Math.Sin(rotation) * 16)*-1;
	phaseStarted = true;
	}
	genericTimer2++;
	if (genericTimer2 >= 10)
	{
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation += Main.rand.Next(-25,25)/50;
	    int damage = (int) (14f * npc.scale);
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * 0.5)*-1),(float)((Math.Sin(rotation) * 0.5)*-1), "Active Doll Head", 24, 0f, 0);
		genericTimer2 = 0;
	}
	}
#endregion
	
#region Phase 3
	if (attackPhase == 3) // PHASE 3
	{
	if (!phaseStarted)
	{
	lookMode = 2;
	phaseTime = 180;
	npc.position.X = Main.player[npc.target].position.X + (float) ((600* Math.Cos((float) (Main.rand.Next(360)*(Math.PI/180))))*-1);
    npc.position.Y = Main.player[npc.target].position.Y + (float) ((600* Math.Sin((float) (Main.rand.Next(360)*(Math.PI/180))))*-1);
	phaseStarted = true;
	}
	Vector2 vector7 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
	float rotation = (float) Math.Atan2(vector7.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector7.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
	npc.velocity.X = (float) (Math.Cos(rotation) * 5)*-1;
    npc.velocity.Y = (float) (Math.Sin(rotation) * 5)*-1;
	genericTimer2++;
	if (genericTimer2 >= 8)
	{
		rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation += Main.rand.Next(-50,50)/100;
	    int damage = (int) (14f * npc.scale);
		int num54 = Projectile.NewProjectile(vector8.X+Main.rand.Next(90), vector8.Y+Main.rand.Next(-100,100),(float)((Math.Cos(rotation) * (0.5f+(Main.rand.Next(-3,3)/10)))*-1),(float)((Math.Sin(rotation) * (0.5f+(Main.rand.Next(-3,3)/10)))*-1), "Screaming Doll Head", 18, 0f, 0);
		genericTimer2 = 0;
	}
	}
	
	if (genericTimer >= phaseTime)
	{
	attackPhase = Main.rand.Next(4);
	genericTimer = 0;
	genericTimer2 = 0;
	phaseStarted = false;
	}
}
#endregion
#endregion

#region Frame
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
	
	if (Main.rand.Next(2) == 0)
	{
	if (npc.frame.Y == 0) Dust.NewDust(new Vector2((float) npc.position.X+40, (float) npc.position.Y+36), 10, 10, 5, 0, 0, 50, Color.White, 1.0f);
	if (npc.frame.Y == num) Dust.NewDust(new Vector2((float) npc.position.X+28, (float) npc.position.Y+36), 10, 10, 5, 0, 0, 50, Color.White, 1.0f);
	if (npc.frame.Y == num*2) Dust.NewDust(new Vector2((float) npc.position.X+30, (float) npc.position.Y+36), 10, 10, 5, 0, 0, 50, Color.White, 1.0f);
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 0, 255, 255, 0, color, 2f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/4)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/4)));
        }
	    Gore.NewGore(npc.position,npc.velocity,"Devil Doll Gore 1",1.1f,-1);
	    Gore.NewGore(npc.position,npc.velocity,"Devil Doll Gore 2",1.1f,-1);
	    Gore.NewGore(npc.position,npc.velocity,"Devil Doll Gore 3",1.1f,-1);
	    Gore.NewGore(npc.position,npc.velocity,"Devil Doll Gore 4",1.1f,-1);
	    Gore.NewGore(npc.position,npc.velocity,"Devil Doll Gore 4",1.1f,-1);
	    Gore.NewGore(npc.position,npc.velocity,"Devil Doll Gore 5",1.1f,-1);
	    Gore.NewGore(npc.position,npc.velocity,"Devil Doll Gore 5",1.1f,-1);
}
#endregion

