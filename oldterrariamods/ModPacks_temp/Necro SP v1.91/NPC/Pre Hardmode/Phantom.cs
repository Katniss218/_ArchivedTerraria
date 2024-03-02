#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
    bool oSky = (y < (Main.maxTilesY * 0.1f));
    bool oSurface = (y >= (Main.maxTilesY * 0.1f) && y < (Main.maxTilesY * 0.2f));
    bool oUnderSurface = (y >= (Main.maxTilesY * 0.2f) && y < (Main.maxTilesY * 0.3f));
    bool oUnderground = (y >= (Main.maxTilesY * 0.3f) && y < (Main.maxTilesY * 0.4f));
    bool oCavern = (y >= (Main.maxTilesY * 0.4f) && y < (Main.maxTilesY * 0.6f));
    bool oMagmaCavern = (y >= (Main.maxTilesY * 0.6f) && y < (Main.maxTilesY * 0.8f));
    bool oUnderworld = (y >= (Main.maxTilesY * 0.8f));
	if ((oCavern || oMagmaCavern) && Main.rand.Next(15)==1) return true;
	else if (oCavern && Main.rand.Next(40)==1) return true;
    return false;
}
#endregion

#region AI
public void AI()
{
	npc.TargetClosest();
	npc.netUpdate = false;

	if (npc.ai[1] == 1 && Main.netMode != 2)
	{
	npc.ai[1] = 0;
	npc.velocity.Y = Main.rand.Next(-10,-2);
	npc.velocity.X = Main.rand.Next(-10,10)/10;
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 27, 0, 0, 50, Color.White, 2f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }
}
#endregion