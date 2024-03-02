
//Methods

public void EffectsStart(Player p, int index, int type, int time) {
	if(ModPlayer.skillRangerCooldown[p.whoAmi]) {
		p.DelBuff(index);
	}
}

public void Effects(Player p, int index, int type, int time) {
	//Set buffTime
	p.buffTime[index] += 30;
	p.buffTime[index] -= p.buffTime[index] % 60;
	//Buff Effects
	ModPlayer.skillRanger[p.whoAmi] = true;
	if(p.controlUseTile) {
		return;
	}
	switch(p.buffTime[index]) {
		case 60:
			p.rangedDamage *= 5.0f;
			break;
		case 120:
			p.rangedDamage *= 7.5f;
			break;
		case 180:
			p.rangedDamage *= 10.0f;
			break;
	}
	if(p.inventory[p.selectedItem].ranged && p.controlUseItem) {
		p.DelBuff(index);
		p.AddBuff("Recalibrate Equipment",60 + (p.inventory[p.selectedItem].useTime * 12),false);
	}
}

public void EffectsEnd(Player p, int index, int type, int time) {
	ModPlayer.skillRanger[p.whoAmi] = false;
}
