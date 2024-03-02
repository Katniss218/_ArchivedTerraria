float customAi1;

public int RangedDefenseValue() 
{ 
    return 5;
}

#region AI
public void AI() 
{
    bool flag25 = false;
    npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (npc.ai[1] >= 10f)
    {
        npc.TargetClosest(true);
    }
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
        npc.velocity.Y -= .02f;
    }
    if (npc.position.Y < Main.player[npc.target].position.Y)
    {
        npc.velocity.Y += .02f;
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
	float num270 = .5f;
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
	if (npc.directionY == -1 && (double)npc.velocity.Y > -1.5)
	{
		npc.velocity.Y = npc.velocity.Y - 0.04f;
		if ((double)npc.velocity.Y > 1.5)
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
		if ((double)npc.velocity.Y < -1.5)
		{
			npc.velocity.Y = -1.5f;
		}
	}
	else
	{
		if (npc.directionY == 1 && (double)npc.velocity.Y < 2.5)
		{
			npc.velocity.Y = npc.velocity.Y + 0.04f;
			if ((double)npc.velocity.Y < -1.5)
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
			if ((double)npc.velocity.Y > 1.5)
			{
				npc.velocity.Y = 2.5f;
			}
		}
	}
#endregion

#region Projectile
    customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (customAi1 >= 10f)
    {
        npc.TargetClosest(true);
		if (Main.rand.Next(60)==1)
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
				    int type = Config.projectileID["Charge Star"];//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 100;
				    Main.projectile[num54].aiStyle=23;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }

		if (Main.rand.Next(80)==1)
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
				int type = Config.projectileID["Enemy Elecric Shot"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 500;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
		if (Main.rand.Next(100)==1)
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
				int type = Config.projectileID["Enemy Brimstone Shot"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 500;
				Main.projectile[num54].aiStyle=1;
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
				int damage = 110;
				int type = Config.projectileID["Mini Whirl Pool Ball"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 500;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
    }
}
#endregion

#region Frames
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 5, 0, 0, 50, Color.White, 3f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        if (npc.life <= 0)
        {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Beast Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Beast Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Beast Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Beast Gore 4", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Beast Gore 4", 1f, -1);
        }
}
#endregion