
//Methods

//public void EffectsStart(Player p, int index, int type, int time) {}

public void Effects(Player p, int index, int type, int time) {
	//Set buffTime
	p.buffTime[index] += 30;
	p.buffTime[index] -= p.buffTime[index] % 60;
	//Buff Effects
	ModPlayer.skillMage[p.whoAmi] = true;
	p.baseSpeed *= 0.5f;
	p.baseMaxSpeed *= 0.5f;
	switch(p.buffTime[index]) {
		case 60:
			p.manaCost *= 0.75f;
			break;
		case 120:
			p.manaCost *= 0.5f;
			break;
		case 180:
			p.manaCost *= 0.25f;
			break;
	}
}

public void EffectsEnd(Player p, int index, int type, int time) {
	ModPlayer.skillMage[p.whoAmi] = false;
}
