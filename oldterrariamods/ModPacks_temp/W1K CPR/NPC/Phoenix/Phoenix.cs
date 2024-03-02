int oldLife = 0;
float TimerAI = 0;
float TimerProjectile = 0;

public void Initialize(){
 npc.name="Firax";
 oldLife = npc.life;
}

public void AI()
{
	npc.netUpdate = true;
	TimerAI++;
	
	if (npc.life < oldLife)
	{
		npc.ai[0] += oldLife - npc.life;
	}
	oldLife = npc.life;
	
	if (npc.ai[0] > 600)
	{
		npc.ai[3] = 1;
		for (int num36 = 0; num36 < 50; num36++)
		{
		int dustExp = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 4, 0, 0, 100, Color.White, 3f);
		}
		for (int num36 = 0; num36 < 20; num36++)
		{
		int dustExp = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 6, 0, 0, 100, Color.White, 3f);
		}
		TimerProjectile = -300;
		npc.ai[0] = 0;
		npc.life += 750;
		if(npc.life > npc.lifeMax) npc.life = npc.lifeMax;
	}
	
	if (npc.ai[0] > 0)
	{
	if (Main.netMode == 0) npc.ai[0] -= 0.75f;
	if (Main.netMode != 0) npc.ai[0] -= 0.50f;
	}
	
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active || Main.player[npc.target].position.Y > (Main.maxTilesY-250)*16)
	{
	npc.TargetClosest(true);
	}
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 6, npc.velocity.X, npc.velocity.Y, 200, color, 0.5f+npc.ai[0]/75);
    Main.dust[dust].noGravity = true;
	
	if (npc.ai[3] == 0)
	{
	if (Main.netMode == 0) TimerProjectile++;
	if (Main.netMode != 0) TimerProjectile += 0.75f;
	npc.alpha = 0;
	npc.dontTakeDamage = false;
	npc.damage = 25;
	if (TimerAI < 600)
	{
	if (Main.player[npc.target].position.X < vector8.X)
	{
	if (npc.velocity.X > -8) {npc.velocity.X -= 0.2f;}
	}
	if (Main.player[npc.target].position.X > vector8.X)
	{
	if (npc.velocity.X < 8) {npc.velocity.X += 0.2f;}
	}
	
	if (Main.player[npc.target].position.Y < vector8.Y+300)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.6f;
	else npc.velocity.Y -= 0.05f;
	}
	if (Main.player[npc.target].position.Y > vector8.Y+300)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.6f;
	else npc.velocity.Y += 0.05f;
	}
	
	if (TimerProjectile >= 0 && TimerAI > 120 && TimerAI < 600 && Main.netMode != 2)
	{
		float num48 = 40f;
		int damage = 14;
		int type = Config.projectileID["Fire Trails"];
        Main.PlaySound(2, (int) vector8.X, (int) vector8.Y, 17);
		float rotation = (float) Math.Atan2(vector8.Y-80-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));	
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation+0.2) * num48)*-1),(float)((Math.Sin(rotation+0.4) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 400;
		num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation-0.2) * num48)*-1),(float)((Math.Sin(rotation-0.4) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 400;
		TimerProjectile = -90;
	}
	}
	else if (TimerAI >= 600 && TimerAI < 1200)
	{
		npc.velocity.X *= 0.98f;
		npc.velocity.Y *= 0.98f;
		if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
		{
			float rotation = (float) Math.Atan2((vector8.Y)-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), (vector8.X)-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			npc.velocity.X = (float) (Math.Cos(rotation) * 25)*-1;
			npc.velocity.Y = (float) (Math.Sin(rotation) * 25)*-1;
		}
	}
	else TimerAI = 0;
	}
	else
	{
	npc.alpha = 200;
	npc.damage = 10;
	npc.dontTakeDamage = true;
	if (Main.netMode == 0) npc.ai[3]++;
	if (Main.netMode != 0) npc.ai[3] += 0.75f;
	if (Main.player[npc.target].position.X < vector8.X)
	{
	if (npc.velocity.X > -6) {npc.velocity.X -= 0.22f;}
	}
	if (Main.player[npc.target].position.X > vector8.X)
	{
	if (npc.velocity.X < 6) {npc.velocity.X += 0.22f;}
	}
	if (Main.player[npc.target].position.Y < vector8.Y)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
	else npc.velocity.Y -= 0.07f;
	}
	if (Main.player[npc.target].position.Y > vector8.Y)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
	else npc.velocity.Y += 0.07f;
	}
	if (npc.ai[3] >= 180)
	{
	npc.ai[3] = 0;
	for (int num36 = 0; num36 < 40; num36++)
	{
	Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 6, 0, 0, 0, color, 3f);
	}
	}
	}
    if (Main.player[npc.target].dead)
	{
	npc.velocity.Y -= 0.04f;
	if (npc.timeLeft > 10)
	{
		npc.timeLeft = 10;
		return;
	}
}
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	if (npc.velocity.X < 0)
	{
	npc.spriteDirection = -1;
	}
	else
	{
	npc.spriteDirection = 1;
	}
	npc.rotation = npc.velocity.X * 0.08f;
	npc.frameCounter += 1.0;
	if (npc.frameCounter >= 4.0)
	{
		npc.frame.Y = npc.frame.Y + num;
		npc.frameCounter = 0.0;
	}
	if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
	{
		npc.frame.Y = 0;
	}
	if (npc.ai[3] == 0)
	{
	npc.alpha = 0;
	}
	else
	{
	npc.alpha = 200;
	}
}

public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Phoenix GORE 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Phoenix GORE 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Phoenix GORE 3", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Phoenix GORE 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Phoenix GORE 3", 1f, -1);
}
}