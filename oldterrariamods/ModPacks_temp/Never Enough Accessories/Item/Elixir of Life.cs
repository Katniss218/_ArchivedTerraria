
//Methods

public void UseItem(Player p, int playerID) {
	int old_statLife = p.statLife;
	p.statLife += 80;
	if(p.statLife > p.statLifeMax) {
		p.statLife = p.statLifeMax;
	}
	p.HealEffect(p.statLife - old_statLife);
	p.AddBuff("Immortal's Sickness",300,false);
}

public bool CanUse(Player player, int playerID) {
	if(player.statLife < player.statLifeMax && !ModPlayer.immortalSickness[playerID]) {
		return true;
	}
	return false;
}
