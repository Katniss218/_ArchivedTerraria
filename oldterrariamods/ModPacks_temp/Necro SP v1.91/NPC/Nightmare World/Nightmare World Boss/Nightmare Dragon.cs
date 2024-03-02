float customAi1;
int chargeDamage = 0;
bool chargeDamageFlag = false;

#region AI
public void AI() 
{ 
    bool flag25 = false;
    npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (npc.ai[1] >= 10f)
    {

#region Charge
        npc.TargetClosest(true);
		if (Main.rand.Next(220)==1) 
        {
            chargeDamageFlag = true;
            Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
            float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
            npc.velocity.X = (float) (Math.Cos(rotation) * 14)*-1;
            npc.velocity.Y = (float) (Math.Sin(rotation) * 14)*-1;
			npc.ai[1] = 1f;
            npc.netUpdate=true;
        }
        if (chargeDamageFlag == true)
        {
            npc.damage= 140;
            chargeDamage ++;
        }
        if (chargeDamage >= 50)
        {
            chargeDamageFlag = false;
            npc.damage= 50;
            chargeDamage = 0;
        }
#endregion

#region Projectile
		if (Main.rand.Next(1000)==1)
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
				int type = Config.projectileID["Enemy Inferno Storm Ball"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 0;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(1000)==1)
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
				int damage = 0;
				int type = Config.projectileID["Enemy Fire Dragon Spawn Ball"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 0;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(1000)==1)
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
				int damage = (int) (14f * npc.scale);
				int type = Config.projectileID["Enemy Water Dragon Spawn Ball"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 0;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(800)==1)
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
				int type = Config.projectileID["Enemy Comet Shot"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 80;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(500)==1)
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
				int type = Config.projectileID["Enemy Fire Ripper Ball"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 0;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(1000)==1)
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
				int damage = 100;
				int type = Config.projectileID["Enemy Dark Tornado"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 500;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(220)==1)
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
				int type = Config.projectileID["Enemy Inferno Ball"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(220)==1)
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
				int type = Config.projectileID["Enemy Ripper Flame"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(220)==1)
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
				int type = Config.projectileID["Enemy Fury Ball"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 60;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
    }
#endregion

    if (npc.justHit)
    {
       npc.ai[2] = 0f;
	}
	if (npc.ai[2] >= 0f)
	{
		int num258 = 16;
		bool flag26 = false;
		bool flag27 = false;
		if (npc.position.X > npc.ai[0] - (float)num258 && npc.position.X < npc.ai[0] + (float)num258)
		{
		    flag26 = true;
		}
		else
		{
		   if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
		    {
				flag26 = true;
		    }
		}
		num258 += 24;
		if (npc.position.Y > npc.ai[1] - (float)num258 && npc.position.Y < npc.ai[1] + (float)num258)
		{
			flag27 = true;
		}
		if (flag26 && flag27)
		{
			npc.ai[2] += 1f;
			if (npc.ai[2] >= 30f && num258 == 16)
			{
				flag25 = true;
			}
			if (npc.ai[2] >= 60f)
			{
				npc.ai[2] = -200f;
				npc.direction *= -1;
				npc.velocity.X = npc.velocity.X * -1f;
				npc.collideX = false;
			}
		}
		else
		{
			npc.ai[0] = npc.position.X;
			npc.ai[1] = npc.position.Y;
			npc.ai[2] = 0f;
		}
		npc.TargetClosest(true);
	}
	else
	{
		npc.ai[2] += 1f;
		if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2))
		{
			npc.direction = -1;
		}
		else
		{
		    npc.direction = 1;
		}
	}
	int num259 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
	int num260 = (int)((npc.position.Y + (float)npc.height) / 16f);
    if (npc.position.Y > Main.player[npc.target].position.Y)
    {
        npc.velocity.Y -= .22f;
        if (npc.velocity.Y < -2)
        {
            npc.velocity.Y = -2;
        }
    }
    if (npc.position.Y < Main.player[npc.target].position.Y)
    {
        npc.velocity.Y += .22f;
        if (npc.velocity.Y > 2)
        {
            npc.velocity.Y = 2;
        }
    }
	if (npc.collideX)
	{
		npc.velocity.X = npc.oldVelocity.X * -0.4f;
		if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
		{
			npc.velocity.X = 1f;
		}
		if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
		{
			npc.velocity.X = -1f;
		}
	}
	if (npc.collideY)
	{
		npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
		if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
		{
			npc.velocity.Y = 1f;
		}
		if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
		{
			npc.velocity.Y = -1f;
		}
	}
	float num270 = 2.5f;
	if (npc.direction == -1 && npc.velocity.X > -num270)
	{
		npc.velocity.X = npc.velocity.X - 0.1f;
		if (npc.velocity.X > num270)
		{
			npc.velocity.X = npc.velocity.X - 0.1f;
		}
		else
		{
			if (npc.velocity.X > 0f)
			{
				npc.velocity.X = npc.velocity.X + 0.05f;
			}
		}
		if (npc.velocity.X < -num270)
		{
			npc.velocity.X = -num270;
		}
	}
	else
	{
		if (npc.direction == 1 && npc.velocity.X < num270)
		{
			npc.velocity.X = npc.velocity.X + 0.1f;
			if (npc.velocity.X < -num270)
			{
				npc.velocity.X = npc.velocity.X + 0.1f;
			}
			else
		    {
				if (npc.velocity.X < 0f)
				{
					npc.velocity.X = npc.velocity.X - 0.05f;
				}
			}
			if (npc.velocity.X > num270)
			{
				npc.velocity.X = num270;
			}
		}
	}
	if (npc.directionY == -1 && (double)npc.velocity.Y > -2.5)
	{
		npc.velocity.Y = npc.velocity.Y - 0.04f;
		if ((double)npc.velocity.Y > 2.5)
		{
			npc.velocity.Y = npc.velocity.Y - 0.05f;
		}
		else
		{
			if (npc.velocity.Y > 0f)
			{
				npc.velocity.Y = npc.velocity.Y + 0.03f;
			}
		}
		if ((double)npc.velocity.Y < -2.5)
		{
			npc.velocity.Y = -2.5f;
		}
	}
	else
	{
		if (npc.directionY == 1 && (double)npc.velocity.Y < 2.5)
		{
			npc.velocity.Y = npc.velocity.Y + 0.04f;
			if ((double)npc.velocity.Y < -2.5)
			{
				npc.velocity.Y = npc.velocity.Y + 0.05f;
			}
			else
			{
				if (npc.velocity.Y < 0f)
				{
					npc.velocity.Y = npc.velocity.Y - 0.03f;
				}
			}
			if ((double)npc.velocity.Y > 2.5)
			{
				npc.velocity.Y = 2.5f;
			}
		}
	}
	if (npc.life > 5550)
	{
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 200, color, 2.0f);
    Main.dust[dust].noGravity = true;
	}
	else if (npc.life <= 5000)
	{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 100, color, 4f);
    Main.dust[dust].noGravity = true;
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
	if (npc.ai[3] == 0)
	{
	npc.alpha = 0;
	}
	else
	{
	npc.alpha = 200;
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 54, 0, 0, 50, Color.White, 3f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        if(Main.netMode != 1)
        {
        ModWorld.Bone();
        }
        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Nightmare Dragon Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Nightmare Dragon Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Nightmare Dragon Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Nightmare Dragon Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Nightmare Dragon Gore 4", 1f, -1);
        }
}
#endregion
