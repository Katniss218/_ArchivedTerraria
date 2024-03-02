public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
    if (Main.rand.Next(2) >= 0)//100% chance to occur
	{
        npc.AddBuff("Paralyzed", 360, false);
	} 
}