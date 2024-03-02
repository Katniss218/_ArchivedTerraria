#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
    if (Main.myPlayer == playerID)
	{
	if (!Main.dayTime && !Main.player[playerID].zoneJungle && Main.rand.Next(45)==0)
	{
	return true;
	}
	}
	return false;

    int closeTownNPCs = 0;
    if (!Main.bloodMoon)
    {
    Vector2 playerPosition = Main.player[playerID].position + new Vector2(Main.player[playerID].width/2,Main.player[playerID].height/2);
    for (int num36 = 0; num36 < 200; num36++)
    {
    Vector2 npcPosition = Main.npc[num36].position + new Vector2(Main.npc[num36].width/2,Main.npc[num36].height/2);
    if (Main.npc[num36].active && Main.npc[num36].townNPC && Vector2.Distance(playerPosition,npcPosition) < 1500)
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
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Fly Catcher Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Fly Catcher Gore 2", 1f, -1);    
        }
}
#endregion
