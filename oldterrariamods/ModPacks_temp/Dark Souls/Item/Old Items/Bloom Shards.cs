public static void DealtNPC(Player player, NPC npc, double damage)
{
	player.statLife += (int)damage/10;
	player.HealEffect((int)damage/10);
}

public static void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
{
	myPlayer.statLife += (int)damage/20;
	myPlayer.HealEffect((int)damage/20);
}
