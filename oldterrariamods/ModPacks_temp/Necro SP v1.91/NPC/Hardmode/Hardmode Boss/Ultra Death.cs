bool isSeiryuSpawned = false;
bool isHarpySpawned = false;
int harpy = 0;
int seiryu = 0;
float customAi1;

public void DamagePlayer(Player P, ref int damage)
{
	if (Main.rand.Next(5) == 1)
	{
		P.AddBuff(36, 600);
	} // buff
}

#region AI
public void AI()
{
	npc.netUpdate = false;
    npc.ai[0]++; // Timer Scythe
    npc.ai[1]++; // Timer Teleport
    // npc.ai[2] Shots

	if (npc.life > 15000)
	{
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 200, color, 4f);
    Main.dust[dust].noGravity = true;
	}
	else if (npc.life <= 10000)
	{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 140, color, 6f);
    Main.dust[dust].noGravity = true;
	}
#endregion

#region Mob Spawn
	if (npc.life <= 60000)
	{
		if (!isHarpySpawned)
		{
			harpy = NPC.NewNPC((int) npc.position.X+(npc.width*2), (int) npc.position.Y+(npc.height/2), "Mechanical Necro Harpy", 0);
			Main.npc[harpy].target = npc.target;
			isHarpySpawned = true;
		}
	}
	if (npc.life <= 20000)
	{
		if (!isSeiryuSpawned)
		{
			seiryu = NPC.NewNPC((int) npc.position.X+(npc.width*2), (int) npc.position.Y+(npc.height/2), "Mechanical Seiryu Head", 0);
			Main.npc[seiryu].target = npc.target;
			isSeiryuSpawned = true;
		}
	}	
#endregion

#region Scythe Attack
    if (Main.netMode != 2)
    {
    if (npc.ai[0] >= 12 && npc.ai[2] < 5)
    {
        float num48 = 0.5f;
        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        int damage = 95;
        int type = Config.projectileID["Power Scythe"];
        float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, 0);
        npc.ai[0] = 0;
        npc.ai[2]++;
    }
    }

	if (npc.ai[1] >= 40)
	{
			npc.velocity.X *= 0.97f;
			npc.velocity.Y *= 0.97f;
	}
	
    if ((npc.ai[1] >= 200 && npc.life > 2000) || (npc.ai[1] >= 120 && npc.life <= 2000))
    {
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
		for (int num36 = 0; num36 < 10; num36++)
		{
		Color color = new Color();
		int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X+Main.rand.Next(-10,10), npc.velocity.Y+Main.rand.Next(-10,10), 200, color, 4f);
		Main.dust[dust].noGravity = true;
		}
		//if (Main.netMode != 1)
		//{
		npc.ai[3] = (float) (Main.rand.Next(360)*(Math.PI/180));
		//}
		npc.ai[2] = 0;
        npc.ai[1] = 0;
		if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
		{
		npc.TargetClosest(true);
		}
		if (Main.player[npc.target].dead)
		{
		npc.position.X = 0;
        npc.position.Y = 0;
		if (npc.timeLeft > 10)
		{
			npc.timeLeft = 10;
			return;
		}
		}
		else
		{
        npc.position.X = Main.player[npc.target].position.X + (float) ((600* Math.Cos(npc.ai[3]))*-1);
        npc.position.Y = Main.player[npc.target].position.Y + (float) ((600* Math.Sin(npc.ai[3]))*-1);
        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
        npc.velocity.X = (float) (Math.Cos(rotation) * 14)*-1;
        npc.velocity.Y = (float) (Math.Sin(rotation) * 14)*-1;
		}
	}
		
	if (npc.velocity.X > 0)
	{
		npc.spriteDirection = 1;
	}
	else npc.spriteDirection = -1;
	
    //npc.netUpdate = true;
#endregion

#region Sickle Attack
        customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
        if (customAi1 >= 10f)
        npc.TargetClosest(true);
        {
            if (Main.rand.Next(50)==1)
            {
			float num48 = 8f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			{
				float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				num51 = num48 / num51;
				speedX *= num51;
				speedY *= num51;
				int damage = 80;
				int type = Config.projectileID["Soul Collecter"];
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            }
            npc.netUpdate=true;
        }
		if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))           
        {
		    if (Main.rand.Next(45)==1)
            {
			    float num48 = 8f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 90;
				    int type = Config.projectileID["Soul Reaper"];
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 100;
				    Main.projectile[num54].aiStyle=23;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
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
	if ((npc.velocity.X > -2 && npc.velocity.X < 2) && (npc.velocity.Y > -2 && npc.velocity.Y < 2))
	{
	npc.frameCounter = 0;
	npc.frame.Y = 0;
	}
	else
	{
	npc.frameCounter += 1.0;
	}
	if (npc.frameCounter >= 1.0)
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
	//generate particle effect
	Color color = new Color();
	Rectangle rectangle = new Rectangle((int)npc.position.X,(int)(npc.position.Y + ((npc.height - npc.width)/2)),npc.width,npc.width);//npc.frame;
	int count = 50;
	float vectorReduce = .4f;
	for (int i = 1; i <= count; i++)
	    {
		//int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 27, 0, 0, 50, Color.White, 3.5f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Death Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Death Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Death Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Death Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Death Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Death Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Death Gore 3", 1f, -1);
        }
}
#endregion