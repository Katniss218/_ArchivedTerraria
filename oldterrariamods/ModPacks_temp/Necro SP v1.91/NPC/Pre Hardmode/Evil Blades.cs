#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].zoneDungeon && Main.rand.Next(25)==1) 
    return true;
	return false;
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
if (npc.velocity.X > -8) npc.velocity.X -= 0.20f;
}

if (Main.player[npc.target].position.X > npc.position.X)
{
if (npc.velocity.X < 8) npc.velocity.X += 0.20f;
}

if (Main.player[npc.target].position.Y < npc.position.Y+50)
{
if (npc.velocity.Y < 0)
{
if (npc.velocity.Y > -4) npc.velocity.Y -= 0.6f;
}
else npc.velocity.Y -= 0.8f;
}

if (Main.player[npc.target].position.Y > npc.position.Y+50)
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
int type = Config.projectileID["Blade Shard"];
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
#endregion

if (Main.rand.Next(40) == 0)
{
Main.PlaySound(16, (int)npc.position.X, (int)npc.position.Y, 1);
}
}

if (npc.ai[1] == 1)
{

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
NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Evil Saw",0);
}
#endregion