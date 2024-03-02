public static void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(2) == 0) //50% chance to occur
	{
		npc.AddBuff(31, 180, false);
	}
}