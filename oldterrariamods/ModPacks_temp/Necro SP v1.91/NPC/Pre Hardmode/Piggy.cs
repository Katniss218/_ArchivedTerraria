#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.player[playerID].townNPCs <= 0f && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 16.0)) && Main.player[playerID].position.Y > ((Main.worldSurface * 6)))
    {
	if (Main.player[playerID].position.X < ((Main.worldSurface * 45.0)) && Main.player[playerID].position.X > ((Main.worldSurface * 38.0)) && Main.rand.Next(60)==1) return true;
	else if (Main.player[playerID].position.X > ((Main.worldSurface * 160.0)) && Main.player[playerID].position.X < ((Main.worldSurface * 167.0)) && Main.rand.Next(90)==1) return true;
	else if (Main.rand.Next(5)==1) return true;
    return false;
    }
    return false;

	int closeTownNPCs = 0;
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Piggy"].type)
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 5, 0, 0, 50, Color.White, 1.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        if (npc.life <= 0)
        {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Piggy Gore 1", 0.9f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Piggy Gore 2", 0.9f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Piggy Gore 3", 0.9f, -1);
        }
}
#endregion