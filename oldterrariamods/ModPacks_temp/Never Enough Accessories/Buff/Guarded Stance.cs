
//Methods

//public void EffectsStart(Player p, int index, int type, int time) {}

public void Effects(Player p, int index, int type, int time) {
	//Set buffTime
	p.buffTime[index] += 30;
	p.buffTime[index] -= p.buffTime[index] % 60;
	//Buff Effects
	ModPlayer.skillGuardian[p.whoAmi] = true;
	p.baseSpeed *= 0.5f;
	p.baseMaxSpeed *= 0.5f;
	switch(p.buffTime[index]) {
		case 60:
			p.statDefense += 10;
			break;
		case 120:
			p.statDefense += 20;
			break;
		case 180:
			p.statDefense += 40;
			break;
	}
}

public void EffectsEnd(Player p, int index, int type, int time) {
	ModPlayer.skillGuardian[p.whoAmi] = false;
}
