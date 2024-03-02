public void Effects(Player player)
{
	player.magicCrit += 10;
	player.meleeCrit += 10;
	player.rangedCrit += 10;
}

public void DealtPlayer(Player P,double DMG,NPC N)
{
	P.immuneTime += 10;
}

public void SetBonus(Player player)
{
	player.setBonus = "Mana cost for Ancient is 0";
	player.ShadowTail = true;
	player.ShadowAura = true;
}