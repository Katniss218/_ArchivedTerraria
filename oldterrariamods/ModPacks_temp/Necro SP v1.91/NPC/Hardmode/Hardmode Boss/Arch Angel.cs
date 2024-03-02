float customAi1;

#region AI
public void AI() {
	npc.TargetClosest(true);

	if (Main.player[npc.target].position.X < npc.position.X)
	{
		if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
	}

	if (Main.player[npc.target].position.X > npc.position.X)
	{
		if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
	}

	if (Main.player[npc.target].position.Y < npc.position.Y+200)
	{
		if (npc.velocity.Y < 0)
		{
			if (npc.velocity.Y > -4) npc.velocity.Y -= 0.8f;
		}
		else npc.velocity.Y -= 0.6f;
	}

	if (Main.player[npc.target].position.Y > npc.position.Y+200)
	{
		if (npc.velocity.Y > 0)
		{
			if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
		}
		else npc.velocity.Y += 0.6f;
	}
	if (npc.life > 5550)
	{
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 57, npc.velocity.X, npc.velocity.Y, 140, color, 3f);
    Main.dust[dust].noGravity = true;
	}
	else if (npc.life <= 5000)
	{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 57, npc.velocity.X, npc.velocity.Y, 140, color, 4f);
    Main.dust[dust].noGravity = true;
	}
#endregion

#region Projectile
    customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (customAi1 >= 10f)
    {
        npc.TargetClosest(true);
        if (Main.rand.Next(300)==1)
        {
        int FemaleAngelspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Armored Angel", 0);
		npc.ai[1] = 20-Main.rand.Next(150);
		if (Main.netMode == 2 && FemaleAngelspawn < 200)
		{
			NetMessage.SendData(23, -1, -1, "", FemaleAngelspawn, 0f, 0f, 0f, 0);
		}
        }
        npc.ai[0]++;
	    if (npc.ai[0] >= 800)
	    {
		npc.velocity.X *= 0.98f;
		npc.velocity.Y *= 0.98f;
		Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
		if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
		{
			float rotation = (float) Math.Atan2((vector8.Y)-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), (vector8.X)-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			npc.velocity.X = (float) (Math.Cos(rotation) * 25)*-1;
			npc.velocity.Y = (float) (Math.Sin(rotation) * 25)*-1;
		}
	    }

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
				int type = Config.projectileID["Enemy Holy Light"];
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
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
				    int damage = 55;
				    int type = Config.projectileID["Enemy Angel Feather"];
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 100;
				    Main.projectile[num54].aiStyle=23;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(200)==1)
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
				    int type = Config.projectileID["Enemy Rainbow Shot"];
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 100;
				    Main.projectile[num54].aiStyle=23;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
        }

		//if ((Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
		//{
        //    npc.noTileCollide = false;
        //    npc.noGravity = false;
        //}
		//if ((!Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
		//{
        //    npc.noTileCollide = true;
        //    npc.noGravity = true;
        //    npc.velocity.Y = 0f;
        //    if (npc.position.Y > Main.player[npc.target].position.Y)
        //    {
	    //        if (Main.rand.Next(20)==1) 
        //        {
        //            npc.velocity.Y -= 3f;
        //        }
        //    }
        //    if (npc.position.Y < Main.player[npc.target].position.Y)
        //    {
	    //       if (Main.rand.Next(20)==1) 
        //        {
        //            npc.velocity.Y += 8f;
        //        }
        //    }
        //}
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 57, 0, 0, 100, Color.White, 3.0f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Arch Angel Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Arch Angel Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Arch Angel Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Arch Angel Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Arch Angel Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Arch Angel Gore 4", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Arch Angel Gore 5", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Arch Angel Gore 5", 1f, -1);
        }
}
#endregion