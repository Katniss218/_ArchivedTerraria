public bool SpawnNPC(int x, int y, int playerID) 
{
	if (y > Main.maxTilesY - 200 && Main.hardMode && Main.rand.Next(3) == 0)
	{
		return true;
	}
	else
	{
		return false;
	}
}
public void AI()
{
	npc.AI(true);
	int num9 = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0.1f, 0.1f, 100, default(Color), 2f);
	Main.dust[num9].noGravity = true;
}