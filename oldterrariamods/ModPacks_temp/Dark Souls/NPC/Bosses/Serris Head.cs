bool TailSpawned = false;
bool SpeedBoost = false;
bool TimeLock = false;
int SoundDelay = 0;
int srs = 0;
int Previous = 0;
public void AI()
{
	npc.AI(true);
	npc.ai[0]++;
	if(npc.ai[0] <= 1 || npc.ai[0] >= 400)
	{
		SpeedBoost = false;
		TimeLock = true;
		SoundDelay = 0;
		npc.dontTakeDamage = false;
		npc.damage = 80;
		Main.npc[srs].damage = 80;
		if (!TailSpawned)
		{
			Previous = npc.whoAmI;
			for (int num36 = 0; num36 < 15; num36++)
			{
				if (num36 >= 0 && num36 < 14)
				{
					srs = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Serris Body", npc.whoAmI);
				}
				else
				{
					srs = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Serris Tail", npc.whoAmI);
				}
				Main.npc[srs].realLife = npc.whoAmI;
				Main.npc[srs].ai[2] = (float)npc.whoAmI;
				Main.npc[srs].ai[1] = (float)Previous;
				Main.npc[Previous].ai[0] = (float)srs;
				NetMessage.SendData(23, -1, -1, "", srs, 0f, 0f, 0f, 0);
				Previous = srs;
			}
			TailSpawned = true;
		}
	}
	else if(npc.ai[0] >= 2)
	{
		npc.dontTakeDamage = true;
		npc.position+=npc.velocity*1.5f;
		SpeedBoost = true;
		SoundDelay++;
		npc.damage = 110;
		Main.npc[srs].damage = 110;
		if(SoundDelay > 14)
		{
			Main.PlaySound(2,(int)npc.position.X,(int)npc.position.Y,SoundHandler.soundID["Speed Booster"]);
			SoundDelay = 0;
		}
	}
	if(npc.justHit)
	{
		TimeLock = false;
		npc.ai[0] = 2;
		Main.PlaySound(15,(int)npc.position.X,(int)npc.position.Y,0);
	}
	if(TimeLock)
	{
		npc.ai[0] = 0;
	}
	
}
public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
Main.npc[srs].active = false;
Main.npc[Previous].active = false;
NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), "Serris-X", 0);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Serris Gore 3", 1f, -1);
}
public void FindFrame(int currentFrame)
{
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	npc.frameCounter += 1.0;
	if(SpeedBoost)
	{
		if(npc.frameCounter >= 0 && npc.frameCounter < 15)
		{
			npc.frame.Y = num;
		}
		if(npc.frameCounter >= 15 && npc.frameCounter < 30)
		{
			npc.frame.Y = num*2;
		}
		if(npc.frameCounter >= 30)
		{
			npc.frameCounter = 0;
		}
	}
	else
	{
		npc.frame.Y = 0;
		npc.frameCounter = 0;
	}
}