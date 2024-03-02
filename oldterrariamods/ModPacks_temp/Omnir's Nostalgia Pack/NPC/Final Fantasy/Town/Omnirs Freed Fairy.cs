bool dropOxyale = false;
int freedFairyTimer = 0;

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
	if (npc.frameCounter >= 8.0)
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

#region Chat
public static string Chat() 
{
    return "Thank you for freeing me! Have the Oxyale I recovered from the bottom of the sping";
}
#endregion

#region AI
public void AI() 
{
    if (dropOxyale == false)
    {
        bool flag25 = false;
        bool flag15 = false;
        this.npc.directionY = -1;
        if (this.npc.direction == 0)
        {
	        this.npc.direction = 1;
        }
        for (int num131 = 0; num131 < 255; num131++)
        {
	        if (Main.player[num131].active && Main.player[num131].talkNPC == this.npc.whoAmI)
	        {
		        flag15 = true;
		        if (this.npc.ai[0] != 0f)
		        {
			        this.npc.netUpdate = true;
		        }
		        this.npc.ai[0] = 0f;
		        this.npc.ai[1] = 300f;
		        this.npc.ai[2] = 100f;
		        if (Main.player[num131].position.X + (float)(Main.player[num131].width / 2) < this.npc.position.X + (float)(this.npc.width / 2))
		        {
			        this.npc.direction = -1;
		        }
		        else
		        {
			        this.npc.direction = 1;
		        }        
                freedFairyTimer++;
                if (freedFairyTimer > 200)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, "Oxyale", 1, false, 0);
                    dropOxyale = true;
                    return;
                }
	        }
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
            npc.velocity.Y -= .2f;
            if (npc.velocity.Y < -1.8f)
            {
                npc.velocity.Y = -1.8f;
            }
        }
        if (npc.position.Y < Main.player[npc.target].position.Y)
        {
            npc.velocity.Y += .2f;
            if (npc.velocity.Y > 1.8f)
            {
                npc.velocity.Y = 1.8f;
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
    }
    if (Main.player[npc.target].dead || dropOxyale == true)
	{
        npc.townNPC = false;
        npc.velocity.Y = npc.velocity.Y - 0.04f;
	    if (npc.timeLeft > 10)
	    {
		    npc.timeLeft = 10;
		    return;
	    }
    }
	Lighting.addLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.6f, 0.3f, 0.0f);
    return;
}
#endregion
