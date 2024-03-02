public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff("Freeze", 480);
	}
}

public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(3) == 0)
	{
		enemyPlayer.AddBuff("Frozen", 120, false);
	}
}