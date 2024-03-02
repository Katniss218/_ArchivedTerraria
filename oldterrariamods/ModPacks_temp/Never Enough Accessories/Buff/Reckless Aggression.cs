
//Methods

//public void EffectsStart(Player p, int index, int type, int time) {}

public void Effects(Player p, int index, int type, int time) {
	//Set buffTime
	p.buffTime[index] += 30;
	p.buffTime[index] -= p.buffTime[index] % 60;
	//Buff Effects
	ModPlayer.skillWarrior[p.whoAmi] = true;
	switch(p.buffTime[index]) {
		case 60:
			p.statDefense -= 8;
			p.moveSpeed *= 1.05f;
			p.meleeSpeed *= 1.1f;
			p.meleeDamage *= 1.2f;
			break;
		case 120:
			p.statDefense -= 16;
			p.moveSpeed *= 1.1f;
			p.meleeSpeed *= 1.2f;
			p.meleeDamage *= 1.4f;
			break;
		case 180:
			p.statDefense -= 32;
			p.moveSpeed *= 1.2f;
			p.meleeSpeed *= 1.4f;
			p.meleeDamage *= 1.8f;
			break;
	}
}

public void EffectsEnd(Player p, int index, int type, int time) {
	ModPlayer.skillWarrior[p.whoAmi] = false;
}
