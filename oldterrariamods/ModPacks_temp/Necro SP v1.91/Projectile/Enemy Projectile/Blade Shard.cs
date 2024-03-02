public static void DealtNPC(NPC npc, double damage, Player player)
{
	npc.AddBuff(39, 420, false);
}

public static void DealtPVP(double damage, Player enemyPlayer) 
{
	enemyPlayer.AddBuff(39, 420, true);
}