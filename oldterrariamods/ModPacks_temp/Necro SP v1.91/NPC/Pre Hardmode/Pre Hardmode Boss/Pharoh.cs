static float j = 0;
static float m = 0;
static float n = 0;
float centerx = -1;
float centery = -1;
int phase = 100;
int attackindex = 0;

#region AI
public void AI()
{
int num54 = 0;
if (centerx == -1) {
centerx = this.npc.position.X;
centery = this.npc.position.Y;
}

this.npc.TargetClosest(false);

#region Text
if (Main.player[this.npc.target].dead) {

Main.NewText("The Pharoh has claimed another soul for his undead army");
this.npc.active = false;
}
#endregion

if (((int)Main.time % 10) < 2) {
if (centery-Main.rand.Next(240) > this.npc.position.Y) {
this.npc.directionY = 1;
}
else {
this.npc.directionY = -1;
}	

if (centerx+Main.rand.Next(-960,960) > this.npc.position.X) {
this.npc.direction = 1;
}
else {
this.npc.direction = -1;
}	
}	

if (Main.player[this.npc.target].position.X > this.npc.position.X) 
this.npc.spriteDirection = 1;
else
this.npc.spriteDirection = -1;

					if (this.npc.direction == -1 && this.npc.velocity.X > -2f)
					{
						this.npc.velocity.X = this.npc.velocity.X - 0.1f;
						if (this.npc.velocity.X > 2f)
						{
							this.npc.velocity.X = this.npc.velocity.X - 0.1f;
						}
						else
						{
							if (this.npc.velocity.X > 0f)
							{
								this.npc.velocity.X = this.npc.velocity.X + 0.05f;
							}
						}
						if (this.npc.velocity.X < -2f)
						{
							this.npc.velocity.X = -2f;
						}
					}
					else
					{
						if (this.npc.direction == 1 && this.npc.velocity.X < 2f)
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
									this.npc.velocity.X = this.npc.velocity.X - 0.05f;
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
						this.npc.velocity.Y = this.npc.velocity.Y - 0.05f;

						if ((double)this.npc.velocity.Y < -1.5)
						{
							this.npc.velocity.Y = -1.5f;
						}
					}
					else
					{
						if (this.npc.directionY == 1 && (double)this.npc.velocity.Y < 1.5)
						{
							this.npc.velocity.Y = this.npc.velocity.Y + 0.05f;
							if ((double)this.npc.velocity.Y > 1.5)
							{
								this.npc.velocity.Y = 1.5f;
							}
						}
					}
#endregion

#region Attack 1
if (phase > 500) {
phase = 0;
attackindex++;
}		

if (attackindex > 4) {
attackindex = 0;
}

phase++;

	if (attackindex == 1) {
if (((int)Main.time % 5) < 1) { 
int damage = (int) (14f * npc.scale);
num54 = Projectile.NewProjectile(centerx+Main.rand.Next(-960,960),centery-480,0,0,"Jackle Curse",30,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 600;
}
	}
#endregion

#region Attack 2
	if (attackindex == 2) {
if (((int)Main.time % 140) < 1) {
int damage = (int) (14f * npc.scale);
num54 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,0,0,"Power Of Ra",30,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 400;
Main.projectile[num54].rotation = (float)Math.Atan2((double)(this.npc.position.Y-Main.player[this.npc.target].position.Y), (double)(this.npc.position.X-Main.player[this.npc.target].position.X));
}
	}
#endregion

#region Attack 3
	if (attackindex == 3) {
if (((int)Main.time % 80) < 1) {
int damage = (int) (14f * npc.scale);
num54 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,this.npc.spriteDirection,0,"Enemy Sand Tornado",30,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 2000;
Main.projectile[num54].ai[0] = centery;
}
	}			
}
#endregion