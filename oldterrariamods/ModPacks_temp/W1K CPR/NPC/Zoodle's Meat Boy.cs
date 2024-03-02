public void AI()
{
	if (Config.syncedRand.Next(2)==0)
	{
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 5, 0, 0, 50, Color.White, 1.0f);
    Main.dust[dust].noGravity = true;
	}

	//npc.rotation += 0.3f;
    //npc.ai[0]; // Player's ID
	
	npc.target = (int) npc.ai[0];
	
	bool buffOn = false;
	for(int num36 = 0; num36 < 10; num36++)
	{
		if (Main.player[npc.target].buffType[num36] == Config.buffDefs.ID["Zoodle's Meat Boy"])
		{
		buffOn = true;
		if (Main.player[npc.target].buffTime[num36] < 590)
		{
		Main.player[npc.target].buffTime[num36] = 600;
		}
		}
	}
	if (!buffOn)
	{
	npc.active = false;
	}
	
	if (Main.player[npc.target].position.X+100 < npc.position.X || Main.player[npc.target].position.X-100 > npc.position.X || Main.player[npc.target].position.Y+100 < npc.position.Y || Main.player[npc.target].position.Y-100 > npc.position.Y)
	{
	if (Main.player[npc.target].position.X+100 < npc.position.X)
	{
	if (npc.velocity.X > -10) {npc.velocity.X -= 0.6f;}
	}
	else if (Main.player[npc.target].position.X-100 > npc.position.X)
	{
	if (npc.velocity.X < 10) {npc.velocity.X += 0.6f;}
	}
	if (Main.player[npc.target].position.Y+100 < npc.position.Y)
	{
	if (npc.velocity.Y > -10) npc.velocity.Y -= 0.6f;
	}
	else if (Main.player[npc.target].position.Y-100 > npc.position.Y)
	{
	if (npc.velocity.Y < 10) npc.velocity.Y += 0.6f;
	}
	}
	else
	{
	npc.velocity.X *= 0.94f; npc.velocity.Y *= 0.94f;
	npc.ai[2]++;
	if (npc.ai[2] == 60)
	{
	npc.velocity.X += Config.syncedRand.Next(-5,5);
	npc.velocity.Y += Config.syncedRand.Next(-5,5);
	npc.ai[2] = 0;
	}
	}
	
	if (npc.position.X > Main.player[npc.target].position.X)
	{
	npc.spriteDirection = 1;
	}
	else
	{
	npc.spriteDirection = -1;
	}
}

public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Meat Boy Gore 1", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Meat Boy Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Meat Boy Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Meat Boy Gore 2", 1f, -1);
Gore.NewGore(vector8, new Vector2((float)Config.syncedRand.Next(-30, 31) * 0.2f, (float)Config.syncedRand.Next(-30, 31) * 0.2f), "Meat Boy Gore 2", 1f, -1);
}
}