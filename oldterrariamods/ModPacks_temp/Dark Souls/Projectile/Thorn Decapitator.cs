

//public void DamageNPC(NPC npc, ref int damage, ref float knockback) 
//{

//npc.AddBuff(20, 600);

//}

public void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(2) == 0) //50% chance to occur
	{
		npc.AddBuff(20, 300, false);
	}
}

//public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
//{
	
//		npc.AddBuff(20, 600);
	
//}