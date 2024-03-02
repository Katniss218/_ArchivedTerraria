bool TailSpawned = false;

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && Main.player[playerID].zoneDungeon && Main.rand.Next(5) == 0)
	{
	return true;
	}
	return false;

    int closeTownNPCs = 0;
	if (!Main.bloodMoon)
	{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(Main.player[playerID].position,Main.npc[num36].position) < 1500)
	{
	closeTownNPCs++;
	}
	}
	}
	if (closeTownNPCs == 1 && Main.rand.Next(3) == 0) return false;
	if (closeTownNPCs == 2 && Main.rand.Next(2) == 0) return false;
	if (closeTownNPCs == 3 && Main.rand.Next(3) <= 1) return false;
	if (closeTownNPCs >= 4) return false;

}
#endregion

#region AI
public void AI()
{
	npc.AI(true);
	if (!TailSpawned)
	{
	int Previous = npc.whoAmI;
	for (int num36 = 0; num36 < 14; num36++)
	{
		int lol = 0;
		if (num36 >= 0 && num36 < 13)
		{
		lol = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "White Dragon Body", npc.whoAmI);
		}
		else
		{
		lol = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "White Dragon Tail", npc.whoAmI);
		}
		Main.npc[lol].realLife = npc.whoAmI;
		Main.npc[lol].ai[2] = (float)npc.whoAmI;
		Main.npc[lol].ai[1] = (float)Previous;
		Main.npc[Previous].ai[0] = (float)lol;
		NetMessage.SendData(23, -1, -1, "", lol, 0f, 0f, 0f, 0);
		Previous = lol;
	}
	TailSpawned = true;
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 0, 0, 0, 50, Color.White, 2.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "White Dragon Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "White Dragon Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "White Dragon Gore 3", 1f, -1);
        }
}
#endregion