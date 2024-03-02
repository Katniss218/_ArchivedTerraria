float customAi1;
bool fireFrame = false;

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) {
	bool nospecialbiome = !Main.player[Main.myPlayer].zoneJungle && !Main.player[Main.myPlayer].zoneEvil && !Main.player[Main.myPlayer].zoneHoly && !Main.player[Main.myPlayer].zoneMeteor && !Main.player[Main.myPlayer].zoneDungeon;
	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104); // Not necessary at all to use but needed to make all this work.
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && !sky && !surface && !underground && !underworld && (y <= Main.rockLayer *25) && !Main.player[Main.myPlayer].zoneJungle;
	bool undergroundJungle = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneHoly;
    

	if(Main.worldName == "Nightmare"){
if (Main.dayTime && surface)
					{
if(Main.rand.Next(25)==0){
return true;
    }
}
return false;
}
return false;
}
#endregion

#region AI
public void AI()
{
	npc.netUpdate = false;
    npc.ai[0]++; // Timer Scythe
    npc.ai[1]++; // Timer Teleport
    // npc.ai[2] Shots

  
    if (Main.rand.Next(2)==0)
    {
	    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, 0, 0, 100, Color.White, 2.0f);
	    Main.dust[dust].noGravity = true;
    }

#region Projectile
    if (Main.netMode != 2)
    {
    if (npc.ai[0] >= 30 && npc.ai[2] < 3)
    {
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
        float num48 = 1f;
        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        int damage = 30;
        int type = Config.projectileID["Molten Rock"];
        float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, Main.myPlayer);
		Main.projectile[num54].scale = 1.5f;
        npc.ai[0] = 0;
        npc.ai[2]++;
		fireFrame = true;
    }
	if (npc.ai[0] >= 15) fireFrame = false;
    }

	if (npc.ai[1] >= 40)
	{
			npc.velocity.X *= 0.97f;
			npc.velocity.Y *= 0.97f;
	}

    customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (customAi1 >= 10f)
    {
        npc.TargetClosest(true);
		if (Main.rand.Next(30)==1)
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
				int damage = 60;//(int) (14f * npc.scale);
				int type = Config.projectileID["Necro Boom"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 200;
				Main.projectile[num54].aiStyle=23;
                Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
    }
#endregion
	
    if (npc.ai[1] >= 300)
    {
		Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
		for (int num36 = 0; num36 < 10; num36++)
		{
	    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, 0, 0, 100, Color.White, 2.0f);
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
        npc.position.X = Main.player[npc.target].position.X + (float) ((150* Math.Cos(npc.ai[3]))*-1);
        npc.position.Y = Main.player[npc.target].position.Y + (float) ((150* Math.Sin(npc.ai[3]))*-1);
		}
	}
		
	if (npc.position.X > Main.player[npc.target].position.X)
	{
		npc.spriteDirection = -1;
	}
	else npc.spriteDirection = 1;
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
	if (fireFrame)
	{
		npc.frame.Y = num;
	}
	else npc.frame.Y = 0;
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 27, 0, 0, 50, Color.White, 3f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }
}
#endregion