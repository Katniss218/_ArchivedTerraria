public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(3) == 0)
	{
		npc.AddBuff("Dark Inferno", 540);
	}
}

public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(3) == 0)
	{
		enemyPlayer.AddBuff("Dark Inferno", 540, false);
	}
}