//npc.ai[2] FRAMES
bool tailSpawned = false;
int Tail = 0;
bool tailGore = false;
float TimerAI = 0;

//public void Initialize()
//{
//	Audio.Player.Play("Sound/Metroid- Zero Mission Music - Ridley Boss Theme");
//}

public void AI()
{
	npc.netUpdate = true;
	npc.netAlways = true;
	if (Main.netMode < 1) TimerAI += 1;
	if (Main.netMode == 1) TimerAI += 0.75f;
	
	if (!tailSpawned && Main.netMode != 1)
	{
		Tail = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Ridley Tail", npc.whoAmI);
		Main.npc[Tail].ai[0] = npc.whoAmI;
		tailSpawned = true;
		if (Main.netMode == 2 && Tail < 200)
		{
			NetMessage.SendData(23, -1, -1, "", Tail, 0f, 0f, 0f, 0);
		}
	}
	
	if (!Main.npc[Tail].active && !tailGore)
	{
		Vector2 vectorTail = new Vector2(Main.npc[Tail].position.X + (Main.npc[Tail].width * 0.5f), Main.npc[Tail].position.Y + (Main.npc[Tail].height / 2));
		Gore.NewGore(vectorTail, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ridley Gore 5", 1f, -1);
		for (int num36 = 0; num36 < 10; num36++)
		{
			Gore.NewGore(vectorTail, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "ridleyTail", 1f, -1);
		}
		tailGore = true;
	}
	
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
	npc.TargetClosest(true);
	}
	
	if (Main.player[npc.target].dead)
	{
	npc.velocity.Y -= 0.4f;
	if (npc.timeLeft > 10)
	{
		npc.timeLeft = 10;
		return;
	}
	}
	
	if (npc.position.X+(npc.width/2) < Main.player[npc.target].position.X+(Main.player[npc.target].width/2))
	{
	npc.spriteDirection = -1;
	}
	else npc.spriteDirection = 1;
	
	int direction = 0;
	if (npc.spriteDirection == 1) direction = -200;
	if (npc.spriteDirection == -1) direction = 200;
	if (Main.player[npc.target].position.X < npc.position.X+(npc.width/2)+direction)
	{
	if (npc.velocity.X > -8) {npc.velocity.X -= 0.22f;}
	}
	if (Main.player[npc.target].position.X > npc.position.X+(npc.width/2)+direction)
	{
	if (npc.velocity.X < 8) {npc.velocity.X += 0.22f;}
	}
	
	if (Main.player[npc.target].position.Y < npc.position.Y+400)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
	else npc.velocity.Y -= 0.07f;
	}
	if (Main.player[npc.target].position.Y > npc.position.Y+400)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
	else npc.velocity.Y += 0.07f;
	}
	
	if ((!Main.npc[Tail].active && (int)TimerAI == 200) || (int)TimerAI == 500)
	{
	Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, SoundHandler.soundID["Ridley"]);
	}
	
	if (npc.spriteDirection == 1) direction = -50;
	if (npc.spriteDirection == -1) direction = 50;
	if ((!Main.npc[Tail].active && (int)TimerAI == 210) || (int)TimerAI == 520)
	{
		float num48 = 8f;
		if (!Main.npc[Tail].active) num48 = 12f;
		Vector2 vector8 = new Vector2(npc.position.X+direction + (npc.width * 0.5f), npc.position.Y-10 + (npc.height / 2));
		int damage = 40;
		int type = Config.projectileID["Flame Shot"];
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation+= -0.6f+(Config.syncedRand.Next(10)/100);
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 300;
		Main.projectile[num54].tileCollide=false;
	}
	if ((!Main.npc[Tail].active && (int)TimerAI == 220) || (int)TimerAI == 535)
	{
		float num48 = 8f;
		if (!Main.npc[Tail].active) num48 = 12f;
		Vector2 vector8 = new Vector2(npc.position.X+direction + (npc.width * 0.5f), npc.position.Y-10 + (npc.height / 2));
		int damage = 40;
		int type = Config.projectileID["Flame Shot"];
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation+= -0.3f+(Config.syncedRand.Next(10)/100);
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 300;
		Main.projectile[num54].tileCollide=false;
	}
	if ((!Main.npc[Tail].active && (int)TimerAI == 230) || (int)TimerAI == 550)
	{
		float num48 = 8f;
		if (!Main.npc[Tail].active) num48 = 12f;
		Vector2 vector8 = new Vector2(npc.position.X+direction + (npc.width * 0.5f), npc.position.Y-10 + (npc.height / 2));
		int damage = 40;
		int type = Config.projectileID["Flame Shot"];
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation += +(Config.syncedRand.Next(10)/100);
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 300;
		Main.projectile[num54].tileCollide=false;
	}
	if ((!Main.npc[Tail].active && (int)TimerAI == 240) || (int)TimerAI == 565)
	{
		float num48 = 8f;
		if (!Main.npc[Tail].active) num48 = 12f;
		Vector2 vector8 = new Vector2(npc.position.X+direction + (npc.width * 0.5f), npc.position.Y-10 + (npc.height / 2));
		int damage = 40;
		int type = Config.projectileID["Flame Shot"];
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation+= +0.3f+(Config.syncedRand.Next(10)/100);
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 300;
		Main.projectile[num54].tileCollide=false;
	}
	if ((!Main.npc[Tail].active && (int)TimerAI >= 250) || (int)TimerAI >= 580)
	{
		float num48 = 8f;
		if (!Main.npc[Tail].active) num48 = 12f;
		Vector2 vector8 = new Vector2(npc.position.X+direction + (npc.width * 0.5f), npc.position.Y-10 + (npc.height / 2));
		int damage = 40;
		int type = Config.projectileID["Flame Shot"];
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation+= +0.6f+(Config.syncedRand.Next(10)/100);
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 300;
		Main.projectile[num54].tileCollide=false;
		TimerAI = 0;
	}
	
	if (Main.netMode == 2 && npc.whoAmI < 200)
	{
	NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
}

public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	npc.frameCounter += 1.0;
	if ((!Main.npc[Tail].active && (int)TimerAI >= 200) || (int)TimerAI >= 500)
	{
	if (npc.frameCounter >= 0 && npc.frameCounter < 5)
	{
		npc.frame.Y = num*4;
	}
	if (npc.frameCounter >= 5 && npc.frameCounter < 10)
	{
		npc.frame.Y = num*5;
	}
	if (npc.frameCounter >= 10 && npc.frameCounter < 15)
	{
		npc.frame.Y = num*6;
	}
	if (npc.frameCounter >= 15 && npc.frameCounter < 20)
	{
		npc.frame.Y = num*7;
	}
	if (npc.frameCounter >= 20 && npc.frameCounter < 25)
	{
		npc.frame.Y = num*6;
	}
	if (npc.frameCounter >= 25 && npc.frameCounter < 30)
	{
		npc.frame.Y = num*5;
	}
	}
	else
	{
	if (npc.frameCounter >= 0 && npc.frameCounter < 5)
	{
		npc.frame.Y = 0;
	}
	if (npc.frameCounter >= 5 && npc.frameCounter < 10)
	{
		npc.frame.Y = num;
	}
	if (npc.frameCounter >= 10 && npc.frameCounter < 15)
	{
		npc.frame.Y = num*2;
	}
	if (npc.frameCounter >= 15 && npc.frameCounter < 20)
	{
		npc.frame.Y = num*3;
	}
	if (npc.frameCounter >= 20 && npc.frameCounter < 25)
	{
		npc.frame.Y = num*2;
	}
	if (npc.frameCounter >= 25 && npc.frameCounter < 30)
	{
		npc.frame.Y = num;
	}
	}
	if (npc.frameCounter >= 30) npc.frameCounter = 0;
}

public void NPCLoot()
{
Audio.Player.Stop();
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ridley Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ridley Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ridley Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ridley Gore 4", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ridley Gore 4", 1f, -1);
if (!tailGore)
{
Vector2 vectorTail = new Vector2(Main.npc[Tail].position.X + (Main.npc[Tail].width * 0.5f), Main.npc[Tail].position.Y + (Main.npc[Tail].height / 2));
Gore.NewGore(vectorTail, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Ridley Gore 5", 1f, -1);
for (int num36 = 0; num36 < 10; num36++)
{
	Gore.NewGore(vectorTail, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "ridleyTail", 1f, -1);
}
}
}
}