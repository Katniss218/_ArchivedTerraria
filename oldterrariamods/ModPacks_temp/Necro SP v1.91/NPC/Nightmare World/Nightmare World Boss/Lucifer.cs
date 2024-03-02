//npc.ai[0] = 0; TIMER AI
//npc.ai[1] = 0; Triden't NPC ID
//npc.ai[2] = 0; Phase
bool OptionSpawned = false;
bool InitPhase = false;
bool TeleportBack = false;
bool Rage = false;
float RotSpeed;
bool RotDir;
int RotBall;
float globalTemp;

/*
Phase IDs
-1 = Idle
0 = Side Shooting (Raining Projectiles)
1 = Side Shooting (Direct Projectiles)
2 = Top Shooting (Raining Projectiles)
3 = Top Shooting (Slow Moving Flamethrower)
4 = Center Shooting (Wide)
5 = Center Shooting (Wide-Fast)
6 = Center Shooting (Aimed)
*/

public int RangedDefenseValue() 
{ 
    return 5;
}

public int MagicDefenseValue() 
{ 
    return 4;
}


#region Initialize
public void Initialize()
{
RotSpeed = 0.015f;
npc.alpha = 0;
npc.ai[2] = -1;
npc.ai[0] = Config.syncedRand.Next(400,800);
}
#endregion

#region Teleport
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
#endregion

#region AI
public void AI()
{
	npc.netUpdate = true;
	//npc.ai[0]++;
	npc.ai[1]++;
	
	if (npc.life <= npc.lifeMax/4)
	{
		if (Main.rand.Next(4)==0)
		{
			int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62, 0, 0, 100, Color.White, 2.0f);
			Main.dust[dust].noGravity = true;
		}
		Rage = true;
	}
	else Rage = false;
	
	#region Player is dead
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
	npc.TargetClosest(true);
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
	#endregion
	
	#region Spawn Trident
	if (OptionSpawned == false)
	{
	int RealLifeId = 0;
	RotBall = NPC.NewNPC((int) ((npc.position.X+(npc.width/2)-(Main.npc[RotBall].width))+Math.Sin(npc.rotation+((360/10)*(1+RotBall)))*75), (int) ((npc.position.Y+(npc.height/2)-(Main.npc[RotBall].height))+Math.Cos(npc.rotation+((360/10)*(1+RotBall)))*75), "Trident of Lucifer", 0);
	Main.npc[RotBall].ai[0] = RotBall;
	Main.npc[RotBall].ai[1] = npc.whoAmI;
	for (int num35 = 0; num35 < 20; num35++)
	{
		int dustDeath = Dust.NewDust(new Vector2(Main.npc[RotBall].position.X, Main.npc[RotBall].position.Y), Main.npc[RotBall].width, Main.npc[RotBall].height, 54, Config.syncedRand.Next(-10,10), Config.syncedRand.Next(-10,10), 200, Color.White, 4f);
		Main.dust[dustDeath].noGravity = true;
	}
	OptionSpawned = true;
	}
	#endregion
	
	#region AI Trident
	if (npc.ai[2] == -1)
	{
	if (RotDir == true)
	{
		if (Rage) RotSpeed += 0.00015f;
		else RotSpeed += 0.0001f;
	}
	if (RotDir == false)
	{
		if (Rage) RotSpeed -= 0.00015f;
		else RotSpeed -= 0.0001f;
	}
	if (RotSpeed > 0.05f) RotDir = false;
	if (RotSpeed < 0.01f) RotDir = true;
	}
	if (npc.ai[2] >= 0 && npc.ai[2] <= 3)
	{
		if (RotSpeed > 0.01f) RotSpeed = 0.01f;
	}
	
	npc.ai[3] += RotSpeed;
	Main.npc[RotBall].rotation += 0.3f*RotSpeed*15;
	Main.npc[RotBall].position.X = (float) ((npc.position.X+(npc.width/2)-(Main.npc[RotBall].width/2))+Math.Sin(npc.ai[3]+((2*Math.PI)/6)*(Main.npc[RotBall].ai[0]+1))*120*(RotSpeed*50));
	Main.npc[RotBall].position.Y = (float) ((npc.position.Y+(npc.height/2)-(Main.npc[RotBall].height/2))+Math.Cos(npc.ai[3]+((2*Math.PI)/6)*(Main.npc[RotBall].ai[0]+1))*120*(RotSpeed*50));
	#endregion
	
	#region AI Lucifer
	npc.ai[0]--;
	if (npc.ai[0] <= 0)
	{
		if (npc.ai[2] == -1) npc.ai[2] = Config.syncedRand.Next(7);
		else npc.ai[2] = -1;
		InitPhase = false;
	}
	
	if (!InitPhase)
	{
		if (npc.ai[2] == -1)
		{
			if (Rage) npc.ai[0] = Config.syncedRand.Next(300,600);
			else npc.ai[0] = Config.syncedRand.Next(400,800);
			if (TeleportBack) Teleport(Main.player[npc.target].Center.X, Main.player[npc.target].Center.Y-300);
			TeleportBack = false;
		}
		if (npc.ai[2] == 0 || npc.ai[2] == 1)
		{
			if (Rage) npc.ai[0] = 60*1.5f;
			else npc.ai[0] = 60*2.5f;
			int direction,direction2;
			if (Config.syncedRand.Next(2) == 0) direction = 1;
			else direction = -1;
			if (Config.syncedRand.Next(2) == 0) direction2 = 1;
			else direction2 = -1;
			Teleport(Main.player[npc.target].Center.X+(400*direction), Main.player[npc.target].Center.Y+(400*direction2));
			TeleportBack = true;
			globalTemp = direction2;
		}
		if (npc.ai[2] == 2 || npc.ai[2] == 3)
		{
			if (Rage) npc.ai[0] = 60*1.5f;
			else npc.ai[0] = 60*2.5f;
			int direction;
			if (Config.syncedRand.Next(2) == 0) direction = 1;
			else direction = -1;
			Teleport(Main.player[npc.target].Center.X+(400*direction), Main.player[npc.target].Center.Y-450);
			TeleportBack = true;
			globalTemp = direction;
		}
		if (npc.ai[2] == 4 || npc.ai[2] == 5 || npc.ai[2] == 6)
		{
			npc.ai[0] = (60*4)-1;
			globalTemp = Config.syncedRand.Next(-20,20)/2f;
		}
		InitPhase = true;
	}
	
	if (Rage && Config.syncedRand.Next(50) == 0) Projectile.NewProjectile(npc.Center.X+Config.syncedRand.Next(-500,500), npc.Center.Y+Config.syncedRand.Next(-500,500), 0, 0, "Dark Explosion", 50, 0f, Main.myPlayer);
	else if (Config.syncedRand.Next(25) == 0) Projectile.NewProjectile(npc.Center.X+Config.syncedRand.Next(-500,500), npc.Center.Y+Config.syncedRand.Next(-500,500), 0, 0, "Dark Explosion", 50, 0f, Main.myPlayer);
	
	if (npc.ai[2] == -1)
	{
		if (Main.player[npc.target].Center.X < npc.Center.X)
		{
		if (npc.velocity.X > -8) {npc.velocity.X -= 0.15f;}
		}
		if (Main.player[npc.target].Center.X > npc.Center.X)
		{
		if (npc.velocity.X < 8) {npc.velocity.X += 0.15f;}
		}
		
		if (Main.player[npc.target].Center.Y < npc.Center.Y+250)
		{
		if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.6f;
		else npc.velocity.Y -= 0.05f;
		}
		if (Main.player[npc.target].Center.Y > npc.Center.Y+250)
		{
		if (npc.velocity.Y < 0f) npc.velocity.Y += 0.6f;
		else npc.velocity.Y += 0.05f;
		}
	}
	
	if (npc.ai[2] == 0 || npc.ai[2] == 1)
	{
		npc.velocity.X = 0;
		if (Rage) npc.velocity.Y = (-10*globalTemp);
		else npc.velocity.Y = (-6*globalTemp);
		int direction;
		if (npc.Center.X < Main.player[npc.target].Center.X) direction = 1;
		else direction = -1;
		float Multiplier = 1f;
		if (Rage) Multiplier = 0.75f;
		if (npc.ai[2] == 0 && npc.ai[0] % Math.Round(7*Multiplier) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(8+Config.syncedRand.Next(-2,2))*direction, Config.syncedRand.Next(-10,-5)/2f, "Inferno Shot", 45, 0f, Main.myPlayer);
		else if (npc.ai[2] == 1 && npc.ai[0] % Math.Round(12*Multiplier) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(6+Config.syncedRand.Next(-1,1))*direction, Config.syncedRand.Next(-10,10)/4f, "Ripper Flame", 45, 0f, Main.myPlayer);
	}
	if (npc.ai[2] == 2 || npc.ai[2] == 3)
	{
		if (Rage) npc.velocity.X = (-12*globalTemp);
		else npc.velocity.X = (-8*globalTemp);
		npc.velocity.Y = 0;
		float Multiplier = 1f;
		if (Rage) Multiplier = 0.75f;
		if (npc.ai[2] == 2 && npc.ai[0] % Math.Round(6*Multiplier) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Config.syncedRand.Next(-10,10)/3f, 0, "Inferno Shot", 45, 0f, Main.myPlayer);
		else if (npc.ai[2] == 3 && npc.ai[0] % Math.Round(10*Multiplier) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Config.syncedRand.Next(-10,10)/3f, 8+Config.syncedRand.Next(-1,1), "Comet Shot", 45, 0f, Main.myPlayer);
	}
	if (npc.ai[2] == 4 || npc.ai[2] == 5 || npc.ai[2] == 6)
	{
		npc.velocity *= 0.95f;
		float Multiplier = 1f;
		if (Rage) Multiplier = 0.75f;
		if (npc.ai[2] == 4 && npc.ai[0] % Math.Round(10*Multiplier) == 0)
		{
			globalTemp += 0.3f;
			for (int num36 = 0; num36 < 3; num36++)
			{
				int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(float) Math.Sin(globalTemp+(((Math.PI*2)/3)*(1+num36)))*10,(float) Math.Cos(globalTemp+(((Math.PI*2)/3)*(1+num36)))*10, "Spirit Shot", 50, 0f, Main.myPlayer);
			}
		}
		if (npc.ai[2] == 5 && npc.ai[0] % Math.Round(25*Multiplier) == 0)
		{
			globalTemp += Config.syncedRand.Next(-20,20)/2f;
			for (int num36 = 0; num36 < 9; num36++)
			{
				int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(float) Math.Sin(globalTemp+(((Math.PI*2)/9)*(1+num36)))*7,(float) Math.Cos(globalTemp+(((Math.PI*2)/9)*(1+num36)))*7, "Dancing Flame", 50, 0f, Main.myPlayer);
			}
		}
		if (npc.ai[2] == 6)
		{
			int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0, 0, 50, Color.White, 1f+(((60*4)-npc.ai[0])/50f));
			Main.dust[dust].noGravity = true;
			int Wait = 120;
			if (Rage) Wait = 180;
			if (npc.ai[0] <= Wait && npc.ai[0] % 4 == 0)
			{
				float rotation = (float) Math.Atan2(npc.Center.Y-Main.player[npc.target].Center.Y, npc.Center.X-Main.player[npc.target].Center.X);
				int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(float)((Math.Cos(rotation) * 15)*-1),(float)((Math.Sin(rotation) * 15)*-1), "Infernal Flamethrower", 50, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 180;
				num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(float)((Math.Cos(rotation+0.05f) * 15)*-1),(float)((Math.Sin(rotation+0.05f) * 15)*-1), "Infernal Flamethrower", 50, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 180;
				num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(float)((Math.Cos(rotation-0.05f) * 15)*-1),(float)((Math.Sin(rotation-0.05f) * 15)*-1), "Infernal Flamethrower", 50, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 180;
			}
		}
	}
	#endregion
	
	if (Main.netMode == 2 && npc.whoAmI < 200)
	{
		NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
}
#endregion

#region Frame
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
}
#endregion

#region Loot
public void NPCLoot()
{
	Main.npc[RotBall].active = false;
    if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lucifer Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lucifer Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lucifer Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lucifer Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lucifer Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lucifer Gore 4", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lucifer Gore 5", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lucifer Gore 5", 1f, -1);
    }
}
#endregion
