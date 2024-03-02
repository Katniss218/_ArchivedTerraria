int Timer = -Main.rand.Next(800);

public void AI()
{
npc.TargetClosest(true);
Timer++;

if (!Main.npc[(int)npc.ai[1]].active)
{
	npc.life = 0;
for (int num36 = 0; num36 < 50; num36++)
{

// a dust could go here









for (int num87 = 0; num36 < 50; num36++)
{
	
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, color, 8.0f);
Main.dust[dust].noGravity = true;
	Main.dust[dust].noGravity = true;
	dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;

}





}

	npc.HitEffect(0, 10.0);
	npc.active = false;
}
if (npc.position.X > Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = 1;
}
if (npc.position.X < Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = -1;
}

	if (Timer >= 0)
	{
		if (Main.netMode != 2)
		{
			float num48 = 6f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			rotation += Main.rand.Next(-50,50)/100;
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), "Enemy Cursed Flamess", 40, 0f, 0);
			Timer = -1200-Main.rand.Next(1200);
		}
	}

if (Main.rand.Next(2)==0)
{
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y+10), npc.width, npc.height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
}

npc.AI(true);
}




