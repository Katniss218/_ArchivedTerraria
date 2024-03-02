
//Globals
private int wounds = 5;
private int countDamage = 0;
private int countHealing = 0;
private int oldLife = 0;

//Methods

public void Save(BinaryWriter writer) {
	//No escaping your wounds >:P
	writer.Write(wounds);
	writer.Write(countDamage);
	writer.Write(countHealing);
	writer.Write(oldLife);
}

public void Load(BinaryReader reader, int version) {
	//No escaping your wounds >:P
	wounds = reader.ReadInt32();
	countDamage = reader.ReadInt32();
	countHealing = reader.ReadInt32();
	oldLife = reader.ReadInt32();
}

public void NPCEffects(NPC n,int buffIndex,int buffType,int buffTime) {
	//Check wounds
	if(wounds <= 0) {
		n.DelBuff(buffIndex);
		return;
	}
	//Take damage every second from wounds
	countDamage++;
	if(countDamage >= 60) {
		n.StrikeNPC(wounds,0f,-1 * n.direction);
		oldLife -= wounds; //No wounds from wounds
		for(int l=0;l < wounds;l++) {
			Dust.NewDust(n.position, n.width, n.height, 5, 0f, 2f, 100, Color.Transparent, 2f);
		}
		countDamage = 0;
	}
	//Heal wounds over time
	countHealing++;
	if(countHealing >= 300) {
		wounds /= 2;
		countHealing = 0;
	}
	//Have you received a new wound?
	if(n.life < (oldLife - 10)) {
		wounds += 5;
		oldLife = n.life;
	}
	//Update State
	if(oldLife < n.life) {
		wounds -= (n.life - oldLife)/5;
		oldLife = n.life;
	}
}

public void Effects(Player p,int buffIndex,int buffType,int buffTime) {
	//Check wounds
	if(wounds <= 0) {
		p.DelBuff(buffIndex);
		return;
	}
	//Take damage every second from wounds
	countDamage++;
	if(countDamage >= 60) {
		p.Hurt(wounds,-1 * p.direction,true,false," bled to death...");
		oldLife -= wounds; //No wounds from wounds
		for(int l=0;l < wounds;l++) {
			Dust.NewDust(p.position, p.width, p.height, 5, 0f, 2f, 100, Color.Transparent, 2f);
		}
		countDamage = 0;
	}
	//Heal wounds over time
	countHealing++;
	if(countHealing >= 300) {
		wounds /= 2;
		countHealing = 0;
	}
	//Have you received a new wound?
	if(p.statLife < (oldLife - 10)) {
		wounds += 5;
		oldLife = p.statLife;
	}
	//Update State
	if(oldLife < p.statLife) {
		wounds -= (p.statLife - oldLife)/5;
		oldLife = p.statLife;
	}
}
