public void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff("Freeze", 120, false);
	}
}