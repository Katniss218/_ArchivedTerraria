public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(4) == 0)
	{
		player.AddBuff(20, 150, false);
	}
}

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode)
	{
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);

	if (!Main.dayTime && sky)
	{
	if (Main.rand.Next(5) == 0)
	{
	return true;
	}
	}
	}
	return false;

    int closeTownNPCs = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Valkarie"].type)
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
	if (npc.ai[0] == 0)
	{
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
	
	if (Main.player[npc.target].position.Y < npc.position.Y && npc.velocity.Y > -8)
	{
	if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.3f;
	else npc.velocity.Y -= 0.015f;
	}
	if (Main.player[npc.target].position.Y > npc.position.Y && npc.velocity.Y < 8)
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 59, 0, 0, 50, Color.White, 2.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
        if (npc.life <= 0)
        {
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Valkarie Gore 1", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Valkarie Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Valkarie Gore 2", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Valkarie Gore 3", 1f, -1);
        Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Valkarie Gore 3", 1f, -1);
        }
}
#endregion

