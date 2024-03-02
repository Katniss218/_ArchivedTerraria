public void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff(20, 60, false);
	}
}