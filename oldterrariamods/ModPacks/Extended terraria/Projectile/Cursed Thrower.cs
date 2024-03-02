public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(5) == 0)
	{
		npc.AddBuff(39, 300);
	}
}
public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(5) == 0)
	{
		enemyPlayer.AddBuff(39, 300, false);
	}
}