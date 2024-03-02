public void DealtNPC(double damage, Player player)
{
	if (Main.rand.Next(2) == 0)
	{
	npc.ai[2] = 1;
	}
}

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].townNPCs <= 0f && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 16.0)) && Main.player[playerID].position.Y > ((Main.worldSurface * 6)))
    {
	if (Main.player[playerID].position.X < ((Main.worldSurface * 45.0)) && Main.player[playerID].position.X > ((Main.worldSurface * 38.0)) && Main.hardMode && Main.rand.Next(30)==1) return true;
	else if (Main.player[playerID].position.X > ((Main.worldSurface * 160.0)) && Main.player[playerID].position.X < ((Main.worldSurface * 167.0)) && Main.hardMode && Main.rand.Next(30)==1) return true;
    return false;
    }
    return false;

    	int closeTownNPCs = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Phantom Lord"].type)
	{
	return false;
	}
	if (!Main.bloodMoon && Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(Main.player[playerID].position,Main.npc[num36].position) < 1500)
	{
	closeTownNPCs++;
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
	npc.TargetClosest();
	npc.netUpdate = false;
	npc.ai[1]++;

#region Mob Spawn
	if (npc.ai[1] >= 800 && Main.netMode != 1)
	{
		int PhantomMinionspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Phantom Minion", 0);
		npc.ai[1] = 20-Main.rand.Next(80);
		if (Main.netMode == 2 && PhantomMinionspawn < 200)
		{
			NetMessage.SendData(23, -1, -1, "", PhantomMinionspawn, 0f, 0f, 0f, 0);
		}       
    }
#endregion

	if (npc.ai[2] == 1 && Main.netMode != 2)
	{
	npc.ai[2] = 0;
	npc.velocity.Y = Main.rand.Next(-10,-2);
	npc.velocity.X = Main.rand.Next(-10,10)/10;
	npc.ai[0] = 1;
	}
	npc.TargetClosest();
	if (Main.player[npc.target].position.X < npc.position.X)
	{
	if (npc.velocity.X > -6) {npc.velocity.X -= 0.3f; npc.netUpdate = true;}
	}
	if (Main.player[npc.target].position.X > npc.position.X)
	{
	if (npc.velocity.X < 6) {npc.velocity.X += 0.3f; npc.netUpdate = true;}
	}
	
	if (Main.player[npc.target].position.Y < npc.position.Y && npc.velocity.Y > 4)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.3f;
	else npc.velocity.Y -= 0.015f;
	}
	if (Main.player[npc.target].position.Y > npc.position.Y && npc.velocity.Y < -4)
	{
	if (npc.velocity.Y < 0f) npc.velocity.Y += 0.3f;
	else npc.velocity.Y += 0.015f;
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 27, 0, 0, 50, Color.White, 2.5f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }
}
#endregion