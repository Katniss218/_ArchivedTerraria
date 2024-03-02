//npc.ai[2] FRAMES
bool tailSpawned = false;
int Tail = 0;
bool tailGore = false;
float customAi1;

#region AI
public void AI()
{
	npc.netUpdate = true;
	npc.ai[2]++;
	
	if (!tailSpawned)
	{
		Tail = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Crystal Formation", 0);
		Main.npc[Tail].ai[0] = npc.whoAmI;
		tailSpawned = true;
	}
	
	if (!Main.npc[Tail].active && !tailGore)
	{
		Vector2 vectorTail = new Vector2(Main.npc[Tail].position.X + (Main.npc[Tail].width * 0.5f), Main.npc[Tail].position.Y + (Main.npc[Tail].height / 2));
		Gore.NewGore(vectorTail, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Crystal Formation Gore  1", 1f, -1);
		Gore.NewGore(vectorTail, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Crystal Formation Gore  2", 1f, -1);
		for (int num36 = 0; num36 < 10; num36++)
		{
			Gore.NewGore(vectorTail, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mother Vertabrate", 1f, -1);
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
	
	if (Main.player[npc.target].position.Y < npc.position.Y+200)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
	else npc.velocity.Y -= 0.07f;
	}
	if (Main.player[npc.target].position.Y > npc.position.Y+200)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
	else npc.velocity.Y += 0.07f;
	}
	if (npc.life > 5550)
	{
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 27, npc.velocity.X, npc.velocity.Y, 140, color, 2f);
    Main.dust[dust].noGravity = true;
	}
	else if (npc.life <= 5000)
	{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 27, npc.velocity.X, npc.velocity.Y, 140, color, 3f);
    Main.dust[dust].noGravity = true;
	}
#endregion
	
#region Progectile
    customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (customAi1 >= 10f)
    {
        npc.TargetClosest(true);
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
				int damage = 50;
				int type = Config.projectileID["Vertabrate"];
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(75)==1)
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
				int damage = 60;
				int type = Config.projectileID["Morph Ball"];
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(125)==1)
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
				int damage = 60;
				int type = Config.projectileID["Inflamed Vertabrate"];
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 27, 0, 0, 50, Color.White, 3f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plutarian Carrier",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plutarian Fighter Ship Diamond",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Plutarian Fighter Ship Ruby",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Mutated Plague",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Mutated Plague",0);

            if (!tailGore)
            {
            Vector2 vectorTail = new Vector2(Main.npc[Tail].position.X + (Main.npc[Tail].width * 0.5f), Main.npc[Tail].position.Y + (Main.npc[Tail].height / 2));
            Gore.NewGore(vectorTail, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Crystal Formation Gore  1", 1f, -1);
            Gore.NewGore(vectorTail, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Crystal Formation Gore  2", 1f, -1);
            for (int num36 = 0; num36 < 10; num36++)
                {
	            Gore.NewGore(vectorTail, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Mother Vertabrate", 1f, -1);
                }
            }
        }
}
#endregion