//npc.ai[2] FRAMES
bool OptionSpawned = false;
bool ShieldBroken = false;
bool Transform = false;
int TimerRain = 0;
int OptionId = 0;
int TimerSpawn = 0;

public void AI()
{
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
		Main.NewText("What a horrible night to have your Gravitation buff dispelled...", 150, 150, 150);
		}
		break;
		}
	}
	
	if (OptionSpawned == false)
	{
	OptionId = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Shadow Dragon Head", npc.whoAmI);
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
	
	if (npc.velocity.X > 7 || npc.velocity.X < -7 || npc.velocity.Y > 7 || npc.velocity.Y < -7)
	{
	npc.velocity.X = 0;
	npc.velocity.Y = 0;
	}
	if (Main.player[npc.target].position.X+(Main.player[npc.target].width/2)+100 < npc.position.X+(npc.width/2))
	{
	if (npc.velocity.X > -6) {float accel = (Main.rand.Next(-40,40)/10)+0.4f; npc.velocity.X -= accel;}
	}
	if (Main.player[npc.target].position.X+(Main.player[npc.target].width/2)-100 > npc.position.X+(npc.width/2))
	{
	if (npc.velocity.X < 6) {float accel = (Main.rand.Next(-40,40)/10)+0.4f; npc.velocity.X += accel;}
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
	if (TimerRain >= 2)
	{
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,Main.rand.Next(-100,100)/10,-7, "Obscure Drop", 49, 0f, 0);
	TimerRain = 0;
	}
	}
	TimerSpawn++;
	if (TimerSpawn >= 600)
	{
	OptionId = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Shadow Dragon Head", npc.whoAmI);
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
	Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30,-10) * 0.2f), "Mindflayer Gore 1", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30,-10) * 0.2f), "Mindflayer Gore 2", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30,-10) * 0.2f), "Mindflayer Gore 3", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30,-10) * 0.2f), "Mindflayer Gore 3", 1f, -1);
	Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30,-10) * 0.2f), "Mindflayer Gore 2", 1f, -1);
	
	for (int num36 = 0; num36 < 50; num36++)
	{
	int dustDeath = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X+Main.rand.Next(-10,10), npc.velocity.Y+Main.rand.Next(-10,10), 200, Color.White, 4f);
	Main.dust[dustDeath].noGravity = true;
	}
	Main.npc[OptionId].life = 0;
	NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Okiku", 0);
	npc.active = false;

	Main.NewText("??????????????????? A booming laughter echoes all around you!", 175, 75, 255);

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
	
	//if (npc.life <= 1000) //debug
	//{
	//Transform = true;
	//npc.ai[3] = 1;
	//npc.ai[2] = 0;
	//}
	
}




public void FindFrame(int currentFrame)
{

if ((npc.velocity.X > -2 && npc.velocity.X < 2) && (npc.velocity.Y > -2 && npc.velocity.Y < 2))
{
    npc.frameCounter = 0;
    npc.frame.Y = 0;
    if (npc.position.X > Main.player[npc.target].position.X)
    {
        npc.spriteDirection = -1;
    }
    else
    {
        npc.spriteDirection = 1;
    }
}
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}

	if (npc.velocity.X > 1.5f) npc.frame.Y = num;
	if (npc.velocity.X < -1.5f) npc.frame.Y = num*2;
	if (npc.velocity.X > -1.5f && npc.velocity.X < 1.5f) npc.frame.Y = 0;
	if (ShieldBroken)
	{
	if (npc.alpha > 40) npc.alpha -= 1;
	if (npc.alpha < 40) npc.alpha += 1;
	}
	else
	{
	if (npc.alpha < 200) npc.alpha += 1;
	if (npc.alpha > 200) npc.alpha -= 1;
	}
}







/*public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){

Main.NewText("??????????????????? A booming laughter echoes all around you!", 175, 75, 255);


for (int num36 = 0; num36 < 50; num36++)
{
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	}
}
}*/






