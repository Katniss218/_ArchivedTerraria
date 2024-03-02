//npc.ai[2] FRAMES
float RotSpeed;
bool RotDir;
bool OptionSpawned = false;
bool ShieldBroken = false;
bool Transform = false;

public void Initialize()
{
RotSpeed = 0.015f;
npc.alpha = 255;
}

public void ChangeFirePhase(int a)
{
	for (int num36 = 0; num36 < 200; num36++)
	{
		if (Main.npc[num36].ai[1] == npc.whoAmI && Main.npc[num36].type == Config.npcDefs.byName["Damned Soul"].type)
		{
		Main.npc[num36].ai[2] = a;
		}
	}
}

/*public static bool SpawnNPC(int x, int y, int playerID)
{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Dark Shogun Mask"].type)
	{
	return false;
	}
	}
	return true;
}*/

public void AI()
{
	if (!Transform)
	{
	npc.TargetClosest(true);
	
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
		int dustDeath = 0;
		for (int num36 = 0; num36 < 20; num36++)
		{
			dustDeath = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 54, Main.rand.Next(-10,10), Main.rand.Next(-10,10), 200, Color.White, 4f);
			Main.dust[dustDeath].noGravity = true;
		}
		npc.position.X = -1000;
		npc.position.Y = -1000;
		npc.velocity.X = 0;
		npc.velocity.Y = 0;
		npc.timeLeft = 0;
	}
	
	if (Main.player[npc.target].position.X+(Main.player[npc.target].width/2)	< npc.position.X+(npc.width/2)-500 || Main.player[npc.target].position.X+(Main.player[npc.target].width/2) > npc.position.X+(npc.width/2)+500 || Main.player[npc.target].position.Y+(Main.player[npc.target].height/2) < npc.position.Y+(npc.height/2)-500 || Main.player[npc.target].position.Y+(Main.player[npc.target].height/2) > npc.position.Y+(npc.height/2)+500)
	{
		float rotation = (float) Math.Atan2((npc.position.Y+(npc.height/2))-(Main.player[npc.target].position.Y+(Main.player[npc.target].height/2)), (npc.position.X+(npc.width/2))-(Main.player[npc.target].position.X+(Main.player[npc.target].width/2)));
		Main.player[npc.target].position.X += (float) (Math.Cos(rotation)*5);
		Main.player[npc.target].position.Y += (float) (Math.Sin(rotation)*5);
	}
	
	if (OptionSpawned == false)
	{
	int RealLifeId = 0;
	for (int num36 = 0; num36 < 6; num36++)
	{
	int rotball = NPC.NewNPC((int) ((npc.position.X+(npc.width/2)-(Main.npc[num36].width))+Math.Sin(npc.rotation+((360/10)*(1+num36)))*300), (int) ((npc.position.Y+(npc.height/2)-(Main.npc[num36].height))+Math.Cos(npc.rotation+((360/10)*(1+num36)))*300), "Damned Soul", 0);
	Main.npc[rotball].ai[0] = num36;
	Main.npc[rotball].ai[1] = npc.whoAmI;
	for (int num35 = 0; num35 < 20; num35++)
	{
		int dustDeath = Dust.NewDust(new Vector2(Main.npc[rotball].position.X, Main.npc[rotball].position.Y), Main.npc[rotball].width, Main.npc[rotball].height, 54, Main.rand.Next(-10,10), Main.rand.Next(-10,10), 200, Color.White, 4f);
		Main.dust[dustDeath].noGravity = true;
	}
	if (num36 == 0)
	{
	RealLifeId = rotball;
	}
	else
	{
	Main.npc[rotball].realLife = RealLifeId;
	}
	}
	OptionSpawned = true;
	}
	
	npc.netUpdate = true;
	npc.ai[2] += 4;
	if (Main.netMode != 2) npc.ai[1]++;
	
	if (ShieldBroken)
	{
	if (RotSpeed < 0.03f) RotSpeed += 0.0003f;
	npc.dontTakeDamage = false;
	}
	else
	{
	if (RotDir == true)
	{
		RotSpeed += 0.00005f;
	}
	if (RotDir == false)
	{
		RotSpeed -= 0.00005f;
	}
	if (RotSpeed > 0.02f) RotDir = false;
	if (RotSpeed < 0.01f) RotDir = true;
	npc.dontTakeDamage = true;
	}
	npc.ai[3] += RotSpeed;
	
	for (int num36 = 0; num36 < 200; num36++)
	{
		if (Main.npc[num36].ai[1] == npc.whoAmI && Main.npc[num36].type == Config.npcDefs.byName["Damned Soul"].type)
		{
			if (Main.npc[num36].life <= 1000)
			{
			ShieldBroken = true;
			Main.npc[num36].dontTakeDamage = true;
			}
			else
			{
			ShieldBroken = false;
			Main.npc[num36].dontTakeDamage = false;
			}
			Main.npc[num36].scale = (RotSpeed*200)/2;
			Main.npc[num36].position.X = (float) ((npc.position.X+(npc.width/2)-(Main.npc[num36].width/2))+Math.Sin(npc.ai[3]+((2*Math.PI)/6)*(Main.npc[num36].ai[0]+1)/*((360/10)*(1+Main.npc[num36].ai[0]))*/)*120*(RotSpeed*200));
			Main.npc[num36].position.Y = (float) ((npc.position.Y+(npc.height/2)-(Main.npc[num36].height/2))+Math.Cos(npc.ai[3]+((2*Math.PI)/6)*(Main.npc[num36].ai[0]+1)/*((360/10)*(1+Main.npc[num36].ai[0]))*/)*120*(RotSpeed*200));
			if (Main.npc[num36].ai[0] == 5) break;
		}
	}
	
	if (npc.ai[2] < 600)
	{
	if (Main.player[npc.target].position.X+(Main.player[npc.target].width/2) < npc.position.X+(npc.width/2))
	{
	if (npc.velocity.X > -2) {npc.velocity.X -= 0.05f;}
	}
	if (Main.player[npc.target].position.X+(Main.player[npc.target].width/2) > npc.position.X+(npc.width/2))
	{
	if (npc.velocity.X < 2) {npc.velocity.X += 0.05f;}
	}
	
	if (Main.player[npc.target].position.Y+(Main.player[npc.target].height/2) < npc.position.Y+(npc.height/2))
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.2f;
	else npc.velocity.Y -= 0.01f;
	}
	if (Main.player[npc.target].position.Y+(Main.player[npc.target].height/2) > npc.position.Y+(npc.height/2))
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.2f;
	else npc.velocity.Y += 0.01f;
	}
	npc.ai[2] = 0;
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
	
	if (npc.life <= 1000) //debug
	{
	Transform = true;
	npc.ai[3] = 1;
	npc.ai[2] = 0;
	}
	
	}
	else
	{
	npc.ai[2]++;
	npc.velocity.X = 0;
	npc.velocity.Y = 0;
	if (RotSpeed > 0.002f) RotSpeed -= 0.0001f;
	npc.dontTakeDamage = true;
	npc.ai[3] *= 1.01f;
	for (int num36 = 0; num36 < 200; num36++)
	{
		if (Main.npc[num36].ai[1] == npc.whoAmI && Main.npc[num36].type == Config.npcDefs.byName["Damned Soul"].type)
		{
			Main.npc[num36].damage = 0;
			Main.npc[num36].dontTakeDamage = true;
			Main.npc[num36].scale = 3;
			Main.npc[num36].position.X = (float) ((npc.position.X+(npc.width/2)-(Main.npc[num36].width/2))+Math.Sin(npc.ai[3]+((2*Math.PI)/6)*(Main.npc[num36].ai[0]+1)/*((360/10)*(1+Main.npc[num36].ai[0]))*/)*120*(RotSpeed*200));
			Main.npc[num36].position.Y = (float) ((npc.position.Y+(npc.height/2)-(Main.npc[num36].height/2))+Math.Cos(npc.ai[3]+((2*Math.PI)/6)*(Main.npc[num36].ai[0]+1)/*((360/10)*(1+Main.npc[num36].ai[0]))*/)*120*(RotSpeed*200));
			if (Main.npc[num36].ai[0] == 5) break;
		}
	}
	
	if (npc.ai[2] > 300 && npc.ai[2] < 600)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	}
	if (npc.ai[2] > 600 && npc.ai[2] < 900)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, Main.rand.Next(-20,20)*2, Main.rand.Next(-20,20)*2, 100, color, 4f);
	Main.dust[dust].noGravity = true;
	}
	if (npc.ai[2] > 900)
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
	
	if (npc.ai[2] > 1200)
	{
	for (int num36 = 0; num36 < 50; num36++)
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
	for (int num36 = 0; num36 < 200; num36++)
	{
	Main.npc[num36].active = false;
	if (Main.npc[num36].ai[0] == 5) break;
	}
	NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Dark Dragon Mask", 0);
	npc.active = false;
	}
	}
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

Main.NewText("A sonic boom shakes the Earth", 175, 75, 255);

Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){


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