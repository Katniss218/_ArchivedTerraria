bool immuneFlash = true;
bool TimeLock = false;
public void AI()
{
	npc.AI(true);
	npc.ai[0]++;
    npc.position+=npc.velocity*1.5f;
	if(npc.ai[0] <= 1 || npc.ai[0] >= 300)
	{
		immuneFlash = false;
		npc.dontTakeDamage = false;
		TimeLock = true;
	}
	else if(npc.ai[0] >= 2)
	{
		immuneFlash = true;
		npc.dontTakeDamage = true;
	}
	if(npc.justHit)
	{
		TimeLock = false;
		npc.ai[0] = 2;
	}
	if(TimeLock)
	{
		npc.ai[0] = 0;
	}
}
public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris-X Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris-X Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris-X Gore 3", 1f, -1);

}
public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	npc.frameCounter += 1.0;
	if (immuneFlash)
	{
	if (npc.frameCounter >= 0 && npc.frameCounter < 5)
	{
		npc.frame.Y = num*8;
	}
	if (npc.frameCounter >= 5 && npc.frameCounter < 10)
	{
		npc.frame.Y = num*9;
	}
	if (npc.frameCounter >= 10 && npc.frameCounter < 15)
	{
		npc.frame.Y = num*10;
	}
	if (npc.frameCounter >= 15 && npc.frameCounter < 20)
	{
		npc.frame.Y = num*11;
	}
	if (npc.frameCounter >= 20 && npc.frameCounter < 25)
	{
		npc.frame.Y = num*12;
	}
	if (npc.frameCounter >= 25 && npc.frameCounter < 30)
	{
		npc.frame.Y = num*13;
	}
	if (npc.frameCounter >= 30 && npc.frameCounter < 35)
	{
		npc.frame.Y = num*14;
	}
	if (npc.frameCounter >= 35 && npc.frameCounter < 40)
	{
		npc.frame.Y = num*15;
	}
	if (npc.frameCounter >= 40)
	{
		npc.frameCounter = 0;
	}
	}
	else
	{
	if (npc.frameCounter >= 0 && npc.frameCounter < 5)
	{
		npc.frame.Y = 0;
	}
	if (npc.frameCounter >= 5 && npc.frameCounter < 10)
	{
		npc.frame.Y = num;
	}
	if (npc.frameCounter >= 10 && npc.frameCounter < 15)
	{
		npc.frame.Y = num*2;
	}
	if (npc.frameCounter >= 15 && npc.frameCounter < 20)
	{
		npc.frame.Y = num*3;
	}
	if (npc.frameCounter >= 20 && npc.frameCounter < 25)
	{
		npc.frame.Y = num*4;
	}
	if (npc.frameCounter >= 25 && npc.frameCounter < 30)
	{
		npc.frame.Y = num*5;
	}
	if (npc.frameCounter >= 30 && npc.frameCounter < 35)
	{
		npc.frame.Y = num*6;
	}
	if (npc.frameCounter >= 35 && npc.frameCounter < 40)
	{
		npc.frame.Y = num*7;
	}
	if (npc.frameCounter >= 45)
	{
		npc.frameCounter = 0;
	}
	}
}