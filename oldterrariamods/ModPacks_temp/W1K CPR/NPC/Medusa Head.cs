bool firstFrame = false;

/*public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && Main.player[playerID].zoneDungeon)
	{

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
	if (closeTownNPCs == 1 && Config.syncedRand.Next(3) == 0) return false;
	if (closeTownNPCs == 2 && Config.syncedRand.Next(2) == 0) return false;
	if (closeTownNPCs == 3 && Config.syncedRand.Next(3) <= 1) return false;
	if (closeTownNPCs >= 4) return false;

	if (Config.syncedRand.Next(2) == 0)
	{
	return true;
	}
	}
	return false;
}*/

public void AI()
{
	Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 44, npc.velocity.X, npc.velocity.Y, 200, color, 1f);
    Main.dust[dust].noGravity = true;
	npc.TargetClosest();
	if (!firstFrame)
	{
		if (npc.velocity.Y == 0 && npc.velocity.X == 0)
		{
		if (Config.syncedRand.Next(2) == 0)
		{
		npc.velocity.X = -3;
		npc.spriteDirection = 1;
		npc.position.X = Main.player[npc.target].position.X + Config.syncedRand.Next(600,1200);
		}
		else
		{
		npc.velocity.X = 3;
		npc.spriteDirection = -1;
		npc.position.X = Main.player[npc.target].position.X - Config.syncedRand.Next(600,1200);
		}
		npc.position.Y = Main.player[npc.target].position.Y + Config.syncedRand.Next(-300,300);
		for (int num36 = 0; num36 < 5; num36++)
		{
			dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 44, Config.syncedRand.Next(-10,10)*2, Config.syncedRand.Next(-10,10)*2, 200, Color.White, 4f);
			Main.dust[dust].noGravity = true;
		}
		firstFrame = true;
	}
	
	if (Config.syncedRand.Next(2)==0)
	{
		npc.ai[0] = 1;
	}
	else
	{
		npc.ai[0] = -1;
	}
	}
	
	if (npc.ai[0] == 1)
	{
		npc.velocity.Y += 0.2f;
		if (npc.velocity.Y > 6) npc.ai[0] = -1;
	}
	else
	{
		npc.velocity.Y -= 0.2f;
		if (npc.velocity.Y < -6) npc.ai[0] = 1;
	}
	
	if (Main.netMode == 2 && npc.whoAmI < 200)
	{
		NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
}

public void FindFrame(int currentFrame)
{
	if (npc.velocity.X > 0) npc.spriteDirection = -1;
	else npc.spriteDirection = 1;
}

public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Medusa Head Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Medusa Head Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Medusa Head Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Medusa Head Gore 3", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Medusa Head Gore 3", 1f, -1);
}
}