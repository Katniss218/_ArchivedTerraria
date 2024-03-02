public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0) 
	{
        // Add the buff 
		npc.AddBuff("Gold Inferno", 240);
	}
}
public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(4) == 0) 
	{
        // Add the buff 
		enemyPlayer.AddBuff("Gold Inferno", 240, false);
	}
}