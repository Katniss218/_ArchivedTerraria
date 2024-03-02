
//Methods

private static int indexItem(Player p, int type) {
	for(int l=0;l<40;l++) {
		if(p.inventory[l].type == type) {
			return l;
		}
	}
	return -1;
}

public static void Effects(Player p) {
	p.pStone = true;
	//If wearing Philosopher's Stone and life <75%, check for Elixir of Life
	int criticalLife = (int)((float)p.statLifeMax * 0.75);
	if(p.statLife < criticalLife) {
		int index = indexItem(p,Config.itemDefs.byName["Elixir of Life"].type);
		if(index != -1) {
			int old_statLife = p.statLife;
			p.statLife += 80;
			if(p.statLife > p.statLifeMax) {
				p.statLife = p.statLifeMax;
			}
			p.HealEffect(p.statLife - old_statLife);
			Main.PlaySound(2, (int)p.position.X, (int)p.position.Y, p.inventory[index].useSound);
			p.AddBuff("Immortal's Sickness",300,false);
			Item item = p.inventory[index];
			item.stack--;
			if (item.stack < 1) {
				item.active = false;
				item.name = "";
				item.type = 0;
			}
		}
	}
}
