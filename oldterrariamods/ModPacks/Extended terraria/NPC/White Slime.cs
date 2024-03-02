public bool SpawnNPC(int x, int y, int playerID) 
{
	if ((Main.invasionType != 1 && Main.invasionType != 2) && Main.tileCount[147] >= 50 && Main.dayTime && Main.rand.Next(3) == 0)
	{
		return true;
	}
	else return false;
}
public void DamagePlayer(Player player, ref int damage)
{
	if (ModPlayer.isImmuneToSlimes)
	{
		npc.damage = 0;
	}
	else
	{
		if (Main.rand.Next(7) == 0)
		{
			player.AddBuff("Frozen", 180, false);
			//player.AddBuff(23, 180, false);
		}
	}
}
public void NPCLoot()
{
	Dust.NewDust(npc.position, npc.width, npc.height, 4, 0.2f, 0.2f, 100, default(Color), 1f);
	Dust.NewDust(npc.position, npc.width, npc.height, 4, 0.2f, 0.2f, 100, default(Color), 1f);
	Dust.NewDust(npc.position, npc.width, npc.height, 4, 0.2f, 0.2f, 100, default(Color), 1f);
}