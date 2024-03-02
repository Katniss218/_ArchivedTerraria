public void DealtNPC(Player player, NPC npc, double damage)
{
	player.statLife += (int)damage/5;
	//player.HealEffect((int)damage/5);
}

public void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
{
	myPlayer.statLife += (int)(damage*2)/5;
	//myPlayer.HealEffect((int)damage/5);
}