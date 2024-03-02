public void Effects(Player player)
{
    player.longInvince = true;
	player.pStone = true;
}

public void DealtPlayer(Player P,double DMG,NPC N)
{
	P.immuneTime += 40;
}        