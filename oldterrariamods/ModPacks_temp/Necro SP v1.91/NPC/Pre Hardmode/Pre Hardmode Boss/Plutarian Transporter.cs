public void Initialize()
{
npc.alpha = 40;
}

#region AI
public void AI()
{
npc.TargetClosest(true);

if (npc.ai[1] == 0) // First AI
{
if (Main.player[npc.target].position.X < npc.position.X)
{
if (npc.velocity.X > -8) npc.velocity.X -= 0.23f;
}

if (Main.player[npc.target].position.X > npc.position.X)
{
if (npc.velocity.X < 8) npc.velocity.X += 0.23f;
}

if (Main.player[npc.target].position.Y < npc.position.Y+300)
{
if (npc.velocity.Y < 0)
{
if (npc.velocity.Y > -4) npc.velocity.Y -= 0.7f;
}
else npc.velocity.Y -= 0.8f;
}

if (Main.player[npc.target].position.Y > npc.position.Y+300)
{
if (npc.velocity.Y > 0)
{
if (npc.velocity.Y < 4) npc.velocity.Y += 0.7f;
}
else npc.velocity.Y += 0.8f;
}
#endregion

#region Projectile
npc.ai[0]++;

if (npc.ai[0] >= 30)
{
float Speed = 22f;
Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
int damage = 40;
int type = Config.projectileID["Red Flame"];
Main.PlaySound(12, (int) npc.position.X, (int) npc.position.Y, 9);
float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
Main.projectile[num54].timeLeft = 120;
npc.ai[0] = 0;
}
if (Main.rand.Next(40) == 0)
{
// npc is this npc, NPC is the class name - could use this.position and this.width instead
// only variables and functions that are static are allowed to be accessed using the class name
int dust = Dust.NewDust(npc.position, npc.width, npc.height, 55, 0f, 0f, 200, npc.color, 4f);
Main.dust[dust].velocity *= 0.3f;
}

if (Main.rand.Next(40) == 0)
{
Main.PlaySound(16, (int)npc.position.X, (int)npc.position.Y, 1);
}
}

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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 62, 0, 0, 100, color, 1.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plutarian Warrior",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plutarian Warrior",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plutarian Warrior",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plutarian Warrior",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plague",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plague",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Jet Brain",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Genius Jet Brain",0);
}
#endregion