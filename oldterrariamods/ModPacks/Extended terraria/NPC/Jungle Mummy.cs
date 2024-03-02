public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && Main.jungleTiles >= 50 && !Main.player[playerID].zoneMeteor && Main.rand.Next(7) == 0) return true;
	else return false;
}
public void AI()
{
	npc.AI(true);
	int D = Dust.NewDust(npc.position, npc.height, npc.width, 3, 1f, 1f, 100, default(Color), 1f);
	int D2 = Dust.NewDust(npc.position, npc.height, npc.width, 3, 1f, 1f, 100, default(Color), 1f);
	Main.dust[D].noGravity = true;
	Main.dust[D2].noGravity = true;
}
public void NPCLoot()
{
	int D = Dust.NewDust(npc.position, npc.height, npc.width, 3, 1f, 1f, 100, default(Color), 1f);
	int D2 = Dust.NewDust(npc.position, npc.height, npc.width, 3, 1f, 1f, 100, default(Color), 1f);
	Main.dust[D].noGravity = true;
	Main.dust[D2].noGravity = true;
}