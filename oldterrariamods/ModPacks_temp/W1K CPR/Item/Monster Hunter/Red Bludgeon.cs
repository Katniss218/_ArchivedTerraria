public static void DealtNPC(Player player, NPC npc, double damage)
{
	if (Main.rand.Next(2) == 0) //50% chance to occur
	{
		npc.AddBuff(31, 180, false);
	}
}