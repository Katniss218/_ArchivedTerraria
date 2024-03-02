
//Methods

public void Effects(Player p, int index, int type, int time) {
	//Set buffTime
	p.buffTime[index] += 30;
	p.buffTime[index] -= p.buffTime[index] % 60;
	//Buff Effects
	ModPlayer.skillSorcerer[p.whoAmi] = true;
}

public void EffectsEnd(Player p, int index, int type, int time) {
	ModPlayer.skillSorcerer[p.whoAmi] = false;
}
