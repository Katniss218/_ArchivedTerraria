//npc.ai[2] FRAMES
bool OptionSpawned = false;
bool ShieldBroken = false;
int TimerRain = 0;
int OptionId = 0;
float TimerSpawn = 0;

public void AI()
{
	npc.netUpdate = false;
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, Color.White, 1.0f);
	Main.dust[dust].noGravity = true;
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
		npc.TargetClosest(true);
	}
	
	for(int num36 = 0; num36 < 10; num36++)
	{
		if (Main.player[npc.target].buffType[num36] == 18)
		{
			Main.player[npc.target].buffType[num36] = 0;
			Main.player[npc.target].buffTime[num36] = 0;
			if (Main.netMode != 2 && Main.myPlayer == npc.target)
			{
				Main.NewText("What a horrible night to have your Gravitation buff dispelled by an unknown being.", 150, 150, 150);
			}
			break;
		}
	}
	
	if (OptionSpawned == false)
	{
		OptionId = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Shadow Dragon Head", 0);
		if (Main.netMode == 2 && OptionId < 200)
		{
			NetMessage.SendData(23, -1, -1, "", OptionId, 0f, 0f, 0f, 0);
		}
		Main.npc[OptionId].velocity.Y = -10;
		OptionSpawned = true;
	}
	
	//npc.ai[2]++;
	npc.ai[1]++;
	
	if (Main.npc[OptionId].active)
	{
	ShieldBroken = false;
	}
	else
	{
	ShieldBroken = true;
	}
	
	if (ShieldBroken)
	{
	
	if (npc.velocity.X > 9 || npc.velocity.X < -9 || npc.velocity.Y > 9 || npc.velocity.Y < -9)
	{
	npc.velocity.X = 0;
	npc.velocity.Y = 0;
	}
	if (Main.player[npc.target].position.X+(Main.player[npc.target].width/2) < npc.position.X+(npc.width/2))
	{
	if (npc.velocity.X > -8) npc.velocity.X -= 0.6f;
	}
	if (Main.player[npc.target].position.X+(Main.player[npc.target].width/2) > npc.position.X+(npc.width/2))
	{
	if (npc.velocity.X < 9) npc.velocity.X += 0.6f;
	}
	
	if (Main.player[npc.target].position.Y+(Main.player[npc.target].height/2)-200 < npc.position.Y+(npc.height/2))
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.4f;
	else npc.velocity.Y -= 0.05f;
	}
	if (Main.player[npc.target].position.Y+(Main.player[npc.target].height/2)-200 > npc.position.Y+(npc.height/2))
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.4f;
	else npc.velocity.Y += 0.1f;
	}
	
	if (npc.position.Y < Main.player[npc.target].position.Y-50)
	{
	TimerRain++;
	if (Main.netMode != 2 && TimerRain >= 2)
	{
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,Config.syncedRand.Next(-100,100)/10f,-6, "Obscure Drop", 50, 0f, Main.myPlayer);
	TimerRain = 0;
	}
	}
	if (Main.netMode < 1) TimerSpawn += 1;
	if (Main.netMode >= 1) TimerSpawn += 1f;
	if (TimerSpawn >= 600)
	{
	OptionId = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Shadow Dragon Head", 0);
	Main.npc[OptionId].velocity.Y = -10;
	TimerSpawn = 0;
	}
	}
	else
	{
	
	if (Main.npc[OptionId].position.X+(Main.npc[OptionId].width/2) < npc.position.X+(npc.width/2))
	{
	if (npc.velocity.X > -16) {npc.velocity.X -= 0.8f;}
	}
	if (Main.npc[OptionId].position.X+(Main.npc[OptionId].width/2) > npc.position.X+(npc.width/2))
	{
	if (npc.velocity.X < 16) {npc.velocity.X += 0.8f;}
	}
	
	if (Main.npc[OptionId].position.Y+(Main.npc[OptionId].height/2) < npc.position.Y+(npc.height/2))
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
	else npc.velocity.Y -= 0.2f;
	}
	if (Main.npc[OptionId].position.Y+(Main.npc[OptionId].height/2) > npc.position.Y+(npc.height/2))
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
	else npc.velocity.Y += 0.2f;
	}
	
	}
	
	if (npc.life <= 1000)
	{
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
	Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30,-10) * 0.2f), "Dragon Mask Gore 1", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30,-10) * 0.2f), "Dragon Mask Gore 2", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30,-10) * 0.2f), "Dragon Mask Gore 3", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30,-10) * 0.2f), "Dragon Mask Gore 4", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30,-10) * 0.2f), "Dragon Mask Gore 5", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30,-10) * 0.2f), "Dragon Mask Gore 6", 1f, -1);
	for (int num36 = 0; num36 < 50; num36++)
	{
	int dustDeath = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X+Config.syncedRand.Next(-10,10), npc.velocity.Y+Config.syncedRand.Next(-10,10), 200, Color.White, 4f);
	Main.dust[dustDeath].noGravity = true;
	}
	Main.npc[OptionId].life = 0;
	NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Okiku", 0);
	npc.active = false;
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