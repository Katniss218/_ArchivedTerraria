int TimerHeal = 0;
float TimerAnim = 0;

public void AI()
{
	if (Main.netMode == 1) TimerAnim += 0.5f;
	if (Main.netMode < 1) TimerAnim++;
	if (TimerAnim > 10)
	{
	if (Config.syncedRand.Next(2)==0) npc.spriteDirection *= -1;
	TimerAnim = 0;
	}
	
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, color, 1.0f);
	Main.dust[dust].noGravity = true;

	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].realLife == npc.whoAmI) Main.npc[num36].life = npc.life;
	}
	if (Main.npc[(int) npc.ai[1]].life > 1000)
	{
	if (Main.netMode == 1) npc.ai[3] += 0.5f;
	if (Main.netMode < 1) npc.ai[3]++; 
	npc.TargetClosest();
	if (npc.ai[3] >= 0)
	{
	if (npc.life > 1000)
	{
		if (Main.netMode != 2)
		{
			float num48 = 0.5f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			rotation += Config.syncedRand.Next(-50,50)/100;
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), "Obscure Shot", 50, 0f, Main.myPlayer);
			npc.ai[3] = -200-Config.syncedRand.Next(200);
		}
	}
	else
	{
		if (Main.netMode != 2)
		{
			float num48 = 0.5f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			rotation += Config.syncedRand.Next(-50,50)/100;
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), "Obscure Shot", 50, 0f, Main.myPlayer);
			Main.projectile[num54].scale = 3;
			npc.ai[3] = -50-Config.syncedRand.Next(50);
		}
	}
	}
	if (npc.life <= 1000)
	{
	TimerHeal++;
	if (TimerHeal >= 600)
	{
		npc.life = 2000;
		TimerHeal = 0;
		for (int num36 = 0; num36 < 200; num36++)
		{
		if (Main.npc[num36].realLife == npc.whoAmI) Main.npc[num36].life = 2000;
		}
	}
	}
	}
}