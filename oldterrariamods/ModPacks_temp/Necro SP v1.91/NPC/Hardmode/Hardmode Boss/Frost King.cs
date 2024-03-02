static float j = 0;
static float m = 0;
static float n = 0;
bool haspanicked = false;
int phase = 100;
int attackindex = 0;
float customAi1;

#region AI
public void AI()
{

int num54;
this.npc.TargetClosest(true);
if (Main.player[this.npc.target].position.Y-350 > this.npc.position.Y) {
this.npc.directionY = 1;
}
else {
this.npc.directionY = -1;
}		

#region Text			
if (Main.player[this.npc.target].dead) {

Main.NewText("The Yeti King has sent you to an icey grave");
this.npc.active = false;
int dust = Dust.NewDust(this.npc.position, 20, 20, 17, 0.5f, 0.5f, 100, Color.Red);
Main.dust[dust].noGravity = true;
}

if (this.npc.life < 4000 && !haspanicked) {
haspanicked = true;
Main.NewText("Now is a good time to panic!");
attackindex = 0;
phase = 0;
}
#endregion


					if (this.npc.direction == -1 && this.npc.velocity.X > -2f)
					{
						this.npc.velocity.X = this.npc.velocity.X - 0.4f;
						if (this.npc.velocity.X > 2f)
						{
							this.npc.velocity.X = this.npc.velocity.X - 0.4f;
						}
						else
						{
							if (this.npc.velocity.X > 0f)
							{
								this.npc.velocity.X = this.npc.velocity.X + 0.08f;
							}
						}
						if (this.npc.velocity.X < -2f)
						{
							this.npc.velocity.X = -2f;
						}
					}
					else
					{
						if (this.npc.direction == 1 && this.npc.velocity.X < 4f)
						{
							this.npc.velocity.X = this.npc.velocity.X + 0.1f;
							if (this.npc.velocity.X < -2f)
							{
								this.npc.velocity.X = this.npc.velocity.X + 0.1f;
							}
							else
							{
								if (this.npc.velocity.X < 0f)
								{
									this.npc.velocity.X = this.npc.velocity.X - 0.08f;
								}
							}
							if (this.npc.velocity.X > 2f)
							{
								this.npc.velocity.X = 2f;
							}
						}
					}
					if (this.npc.directionY == -1 && (double)this.npc.velocity.Y > -1.5)
					{
						this.npc.velocity.Y = this.npc.velocity.Y - 0.08f;

						if ((double)this.npc.velocity.Y < -1.5)
						{
							this.npc.velocity.Y = -1.5f;
						}
					}
					else
					{
						if (this.npc.directionY == 1 && (double)this.npc.velocity.Y < 1.5)
						{
							this.npc.velocity.Y = this.npc.velocity.Y + 0.08f;
							if ((double)this.npc.velocity.Y > 1.5)
							{
								this.npc.velocity.Y = 1.5f;
							}
						}
					}
#endregion

#region Projectile		
if (phase > 1000) {
phase = 0;
attackindex++;
}		

if (attackindex > 4) {
attackindex = 0;
}
phase++;
if (this.npc.life < 4000) {
attackindex = 5;
}

if (attackindex == 0) {
if (((int)Main.time % 140) < 1) 
for (int i = 0; i < 6; i++) {
int damage = 130;
j += (float)1;
m = (float)Math.Sin(j)*2.5f;
n = (float)Math.Cos(j)*2.5f;
num54 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,m,n,"Jagged Icicle",40,0f,Main.myPlayer);
if (this.npc.life > 14000) Main.projectile[num54].timeLeft = 610;
else Main.projectile[num54].timeLeft = 915;
}
	}

else if (attackindex == 1 || attackindex == 2) {
if (((int)Main.time % 140 < 1 && this.npc.life > 14000) || phase < 5 || ((int)Main.time % 70 < 1 && this.npc.life <= 14000)) 
{ 
m = (this.npc.position.X-Main.player[this.npc.target].position.X)/-100;
n = (this.npc.position.Y-Main.player[this.npc.target].position.Y)/-100;
}
if (((int)Main.time % 80 < 1 && this.npc.life > 14000) || ((int)Main.time % 50 < 5 && this.npc.life <= 14000)) 
{ 
num54 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,m,n,"Jagged Icicle",50,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 90;
}
	}  

else if (attackindex == 3 || attackindex == 4) {
if ((int)Main.time % 90 < 1) 
{ 
m = (this.npc.position.X-Main.player[this.npc.target].position.X)/-3000;
n = (this.npc.position.Y-Main.player[this.npc.target].position.Y)/-3000;
}
if ((int)Main.time % 90 < 1) {
num54 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,m,n,"Parasnowman",50,0f,Main.myPlayer); 
Main.projectile[num54].timeLeft = 200;
 
if (this.npc.life <= 14000) {
num54 = Projectile.NewProjectile(this.npc.position.X+120,this.npc.position.Y+50,m,n,"Jagged Icicle",50,0f,Main.myPlayer); 
Main.projectile[num54].timeLeft = 100; 
}
}

if (((int)Main.time % 90) < 1)  {
for (int i = 0; i < 6; i++) {
j += (float)1;
m = (float)Math.Sin(j)*2.5f;
n = (float)Math.Cos(j)*2.5f;
int damage = 72;
num54 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,m,n,"Jagged Icicle",40,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 100;
}
}
}  

if (attackindex == 5) {
if (((int)Main.time % 80) < 1) 
for (int i = 0; i < 6; i++) {
j += (float)1;
m = (float)Math.Sin(j)*3f;
n = (float)Math.Cos(j)*3f;
int damage = 72;
num54 = Projectile.NewProjectile(this.npc.position.X+40,this.npc.position.Y+100,m,n,"Parasnowbomb",40,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 400;
}
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 59, 0, 0, 50, Color.White, 3.0f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Frost King Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Frost King Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Frost King Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Frost King Gore 4", 1f, -1);
        }
}
#endregion