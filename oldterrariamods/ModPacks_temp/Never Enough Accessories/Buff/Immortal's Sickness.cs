
//Methods

public void Effects(Player p,int buffIndex,int buffType,int buffTime) {
	ModPlayer.immortalSickness[p.whoAmi] = true;
}

public void EffectsEnd(Player p,int buffIndex,int buffType,int buffTime) {
	ModPlayer.immortalSickness[p.whoAmi] = false;
}
