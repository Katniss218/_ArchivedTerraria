
//Methods

public bool PreShoot(Player p,Vector2 pos,Vector2 speed,int type,int dmg,float knockback,int owner) {
	if(ModPlayer.skillSorcerer[owner] && Config.projDefs[type].magic) {
		if(p.statMana > 0) {
			//Find Buff Level
			int buffLvl = 0;
			for(int l=0;l<10;l++) {
				if(p.buffType[l] == Config.buffDefs.ID["Overcharge"]) {
					buffLvl = p.buffTime[l]/60;
					break;
				}
			}
			//Calculate damage increase
			float multiplier = 2.0f + (p.statMana * buffLvl / 25);
			int damage = (int)(dmg * multiplier);
			//Fire!
			int index = Projectile.NewProjectile(pos.X,pos.Y,speed.X,speed.Y,type,damage,knockback,owner);
			//Use up mana
			p.statMana = 0;
			return false;
		}
	}
	return true;
}

public void DamageNPC(Player p, NPC npc, ref int dmg, ref float knockback) {
	if(ModPlayer.skillSorcerer[p.whoAmi] && this.item.magic && !this.item.noMelee) {
		if(p.statMana > 0) {
			//Find Buff Level
			int buffLvl = 0;
			for(int l=0;l<10;l++) {
				if(p.buffType[l] == Config.buffDefs.ID["Overcharge"]) {
					buffLvl = p.buffTime[l]/60;
					break;
				}
			}
			//Calculate damage increase
			float multiplier = 2.0f + (p.statMana * buffLvl / 25);
			dmg = (int)(dmg * multiplier);
			//Use up mana
			p.statMana = 0;
		}
	}
}

public void DamagePVP(Player p, ref int dmg, Player target) {
	if(ModPlayer.skillSorcerer[p.whoAmi] && this.item.magic && !this.item.noMelee) {
		if(p.statMana > 0) {
			//Find Buff Level
			int buffLvl = 0;
			for(int l=0;l<10;l++) {
				if(p.buffType[l] == Config.buffDefs.ID["Overcharge"]) {
					buffLvl = p.buffTime[l]/60;
					break;
				}
			}
			//Calculate damage increase
			float multiplier = 2.0f + (p.statMana * buffLvl / 25);
			dmg = (int)(dmg * multiplier);
			//Use up mana
			p.statMana = 0;
		}
	}
}
