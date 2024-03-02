public void AI()
{
	npc.AI(true);
	if (npc.justHit)
	{
		Dust.NewDust(npc.position, npc.width, npc.height, 18, 0.2f, 0.2f, 100, default(Color), 1f);
		Dust.NewDust(npc.position, npc.width, npc.height, 18, 0.2f, 0.2f, 100, default(Color), 1f);
	}
	if (Main.hardMode) npc.damage = 39;
	else if (Main.hardMode && ModWorld.superHardmode) npc.damage = 80;
	else npc.damage = 20;
}
public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.player[playerID].townNPCs < 1 && y < (Main.maxTilesY - 200) && !Main.dayTime && !Main.player[playerID].zoneDungeon && !Main.player[playerID].zoneMeteor && Main.rand.Next(50) == 0)
	{
		return true;
	}
	else return false;
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Heavy Zombie Head",1.5f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Heavy Zombie Arm",1.5f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Heavy Zombie Arm",1.5f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Heavy Zombie Leg",1.5f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Heavy Zombie Leg",1.5f,-1);
}