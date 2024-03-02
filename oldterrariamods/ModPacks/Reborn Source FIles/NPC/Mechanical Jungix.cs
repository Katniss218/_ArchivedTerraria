//npc.ai[2] FRAMES

public bool SpawnNPC(int x, int y, int playerID)
{
	return false; //hehehehehe
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Phoenix"].type)
	{
	return false;
	}
	}
	if (Main.hardMode)
	{
	bool nospecialbiome = !Main.player[Main.myPlayer].zoneJungle && !Main.player[Main.myPlayer].zoneEvil && !Main.player[Main.myPlayer].zoneHoly && !Main.player[Main.myPlayer].zoneMeteor && !Main.player[Main.myPlayer].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && !sky && !surface && !underground && !underworld && (y <= Main.rockLayer *25) && !Main.player[Main.myPlayer].zoneJungle;
	bool undergroundJungle = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneHoly;
	if (Main.rand.Next(2) == 0)
	{
	return true;
	}
	}
	return false;
}

public void Initialize()
{
npc.name="Mechanical Junglix";
    npc.ai[2] = -(Main.rand.Next(0,240));
}
public void AI()
{
Lighting.addLight((int)((this.npc.position.X + (float)(this.npc.width / 2)) / 16f), (int)((this.npc.position.Y + (float)(this.npc.height / 2)) / 16f), 0.3f, 0.9f, 0.3f);  

	npc.netUpdate = true;
	npc.ai[2]++;
	npc.ai[1]++;
	if (npc.ai[0] > 0) npc.ai[0] -= 1.2f;
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
	npc.TargetClosest(true);
	}
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 18, npc.velocity.X, npc.velocity.Y, 200, color, 0.5f+npc.ai[0]/75);
    Main.dust[dust].noGravity = true;
	
	if (npc.ai[3] == 0)
	{
	npc.alpha = 0;
	npc.dontTakeDamage = false;
	npc.damage = 50;
	if (npc.ai[2] < 600)
	{
	if (Main.player[npc.target].position.X < vector8.X)
	{
	if (npc.velocity.X > -8) {npc.velocity.X -= 0.22f;}
	}
	if (Main.player[npc.target].position.X > vector8.X)
	{
	if (npc.velocity.X < 8) {npc.velocity.X += 0.22f;}
	}
	
	if (Main.player[npc.target].position.Y < vector8.Y+300)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
	else npc.velocity.Y -= 0.07f;
	}
	if (Main.player[npc.target].position.Y > vector8.Y+300)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
	else npc.velocity.Y += 0.07f;
	}
	
	if (npc.ai[1] >= 0 && npc.ai[2] > 120 && npc.ai[2] < 600)
	{
		float num48 = 30f;
		int damage = 25;
		int type = Config.projectileID["Miracle Sprouter"];
        Main.PlaySound(2, (int) vector8.X, (int) vector8.Y, 17);
		float rotation = (float) Math.Atan2(vector8.Y-80-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 300;			
		num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation+0.4) * num48)*-1),(float)((Math.Sin(rotation+0.4) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 300;
		num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation-0.4) * num48)*-1),(float)((Math.Sin(rotation-0.4) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].timeLeft = 300;
		npc.ai[1] = -90-Main.rand.Next(50);
	}
	}
	else if (npc.ai[2] >= 600 && npc.ai[2] < 1200)
	{
		npc.velocity.X *= 0.98f;
		npc.velocity.Y *= 0.98f;
		if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
		{
			float rotation = (float) Math.Atan2((vector8.Y)-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), (vector8.X)-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			npc.velocity.X = (float) (Math.Cos(rotation) * 25)*-1;
			npc.velocity.Y = (float) (Math.Sin(rotation) * 25)*-1;
		}
        if((npc.ai[2]+1)%150 == 0)
        {
            float num48 = 20f;
		    int damage = 18;
		    int type = Config.projectileID["Jungix Phaser"];
            Main.PlaySound(2, (int) vector8.X, (int) vector8.Y, 17);
		    float rotation = (float) Math.Atan2(vector8.Y-80-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
        }
	}
	else npc.ai[2] = -Main.rand.Next(120);
	}
	else
	{
	npc.ai[3]++;
	npc.alpha = 200;
	npc.damage = 20;
	npc.dontTakeDamage = true;
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
	if (npc.ai[3] == 100)
	{
	npc.ai[3] = 1;
	npc.life += 250;
    if(npc.life > npc.lifeMax) npc.life = npc.lifeMax;
	}
	if (npc.ai[1] >= 0)
	{
	npc.ai[3] = 0;
	for (int num36 = 0; num36 < 40; num36++)
	{
	Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 18, 0, 0, 0, color, 3f);
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

public void DealtNPC(double damage, Player player)
{
	npc.ai[0] += (float) damage;
	if (npc.ai[0] > 600)
	{
		npc.ai[3] = 1;
		Color color = new Color();
		for (int num36 = 0; num36 < 50; num36++)
		{
		int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 4, 0, 0, 100, color, 3f);
		}
		for (int num36 = 0; num36 < 20; num36++)
		{
		int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 18, 0, 0, 100, color, 3f);
		}
		npc.ai[1] = -300;
		npc.ai[0] = 0;
	}
}

public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mechanical Jungix GORE 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mechanical Jungix GORE 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mechanical Jungix GORE 3", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mechanical Jungix GORE 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mechanical Jungix GORE 3", 1f, -1);
}
}