#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.player[playerID].townNPCs <= 0f && !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneMeteor && Main.player[playerID].position.Y < ((Main.rockLayer * 33.0)) && Main.player[playerID].position.Y > ((Main.worldSurface * 12)))
    {
	    if (Main.hardMode && Main.player[playerID].position.X < ((Main.worldSurface * 150.0)) && Main.player[playerID].position.X > ((Main.worldSurface * 130.0)) && Main.rand.Next(40)==1) return true;
	    else if (Main.hardMode && Main.player[playerID].position.X > ((Main.worldSurface * 160.0)) && Main.player[playerID].position.X < ((Main.worldSurface * 175.0)) && Main.rand.Next(60)==1) return true;
        else if (Main.hardMode && Main.rand.Next(40)==1) return true;
	    return false;
    }
    return false;
}
#endregion

#region Mob Spawn
public void AI()
{
	npc.TargetClosest();
	npc.netUpdate = false;
	npc.ai[1]++;
	if (npc.ai[1] >= 1800 && Main.netMode != 1)
	{
		int ZombieSpitterspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Zombie Spitter", 0);
		npc.ai[1] = 20-Main.rand.Next(60);
		if (Main.netMode == 2 && ZombieSpitterspawn < 200)
		{
			NetMessage.SendData(23, -1, -1, "", ZombieSpitterspawn, 0f, 0f, 0f, 0);
		}
        int UndeadCrusherspawn = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Undead Crusher", 0);
		npc.ai[1] = 20-Main.rand.Next(60);
		if (Main.netMode == 2 && UndeadCrusherspawn < 200)
		{
			NetMessage.SendData(23, -2, -2, "", UndeadCrusherspawn, 0f, 0f, 0f, 0);
		}
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 54, 0, 0, 50, Color.White, 1.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Zombie Spitter",0);
        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Undead Crusher",0);
}
#endregion