public void AI()
{
	npc.ai[0]++;
	if (npc.ai[0] < 50)
	{
		npc.rotation++;
		if (npc.ai[0] >= 49)
		{
			npc.rotation = 0;
			npc.ai[0] = 0;
		}
	}
}
public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff(31, 5*60, false);
	}
}