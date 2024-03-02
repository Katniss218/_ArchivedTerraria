float customAi1;
int choasHealed = 0;
float customspawn1 = 0;
int chargeDamage = 0;
bool chargeDamageFlag = false;
/*
	Didnt change the files names so that its obvious that Omnir made this mob xD
	I only recoloured it.
	I used this mob (with permission) because I hate starting sprites from scratch, especially large ones :X
	
	- Chadwick
*/

#region AI
public void AI() 
{
    if (npc.life <= 0)
    {
        if (customspawn1 <= 0) 
	    {
		    int Spawned = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Omnir - Chaos Death Animation", 0);
		    Main.npc[Spawned].velocity.Y = 0;
		    Main.npc[Spawned].velocity.X = 0;
		    npc.ai[0] = 20-Main.rand.Next(80);
            customspawn1 += 1f;
		    if (Main.netMode == 2)
		    {
		        NetMessage.SendData(23, -1, -1, "", Spawned, 0f, 0f, 0f, 0);
		    }
	    }
    }
    bool flag25 = false;
    npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (npc.ai[1] >= 10f)
    {
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
            npc.damage= 200;
            chargeDamage ++;
        }
        if (chargeDamage >= 50)
        {
            chargeDamageFlag = false;
            npc.damage= 50;
            chargeDamage = 0;
        }
		if (Main.rand.Next(140)==1)
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
				int damage = 70;
				int type = Config.projectileID["Amaterasu Sun Mega"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
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
				int damage = 30;
				int type = Config.projectileID["Amaterasu Sun"];//44;//0x37; //14;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 100;
				Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				npc.ai[1] = 1f;
            }
            npc.netUpdate=true;
        }
        //{
        //    if (choasHealed >= 2 && choasHealed <= 3)
        //    {
        //        if (Main.rand.Next(500)==1)
        //        {
        //            npc.life += 40000;
        //            if(npc.life > npc.lifeMax) npc.life = npc.lifeMax;
        //            float num48 = 8f;
        //            Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        //            float speedX = 0;
        //            float speedY = 0;
        //            float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
        //            num51 = num48 / num51;
        //            speedX *= 0;
        //            speedY *= 0;
        //            int damage = 0;//(int) (14f * npc.scale);
        //            int type = Config.projectileID["Enemy Spell Effect Healing"];//44;//0x37; //14;
        //            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
        //            Main.projectile[num54].timeLeft = 0;
        //            Main.projectile[num54].aiStyle=1;
        //                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 4);
        //            npc.ai[1] = 1f;
        //            npc.netUpdate=true;
        //            choasHealed += 1;
        //        }
        //    }
        //}
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
    if (Main.player[npc.target].dead)
	{
	    if (npc.timeLeft > 10)
	    {
		    npc.timeLeft = 10;
		    return;
	    }
    }
	Lighting.addLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.4f, 0f, 0f);
    return;
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
}
#endregion

#region Magic Defense
public int MagicDefenseValue() 
{ 
    return 65;
}
#endregion

public void NPCLoot ()
{


	NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Omnir - Chaos Death Animation", 0);



}