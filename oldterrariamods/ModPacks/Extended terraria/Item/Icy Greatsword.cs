public void DamageNPC(Player player, NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(5) == 0) 
	{
        // Add the buff 
		npc.AddBuff("Freeze", 180);
	}
}
public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(5) == 0) 
	{
        // Add the buff 
		enemyPlayer.AddBuff("Frozen", 180, false);
	}
}