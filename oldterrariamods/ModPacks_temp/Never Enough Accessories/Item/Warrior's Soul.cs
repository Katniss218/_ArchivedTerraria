
//Methods

public static bool CanEquip(Player p) {
	for(int l=3;l<8;l++) {
		if(ModPlayer.classAccessories.Contains(p.armor[l].type)) {
			return false;
		}
	}
	if(!Codable.RunGlobalMethod("ModWorld","ExternalGetAccessorySlots",new Object[0])) {
		return true;
	}
	Item[] accSlotsPlus = (Item[])Codable.customMethodReturn;
	for(int l=0;l<accSlotsPlus.Length;l++) {
		if(ModPlayer.classAccessories.Contains(accSlotsPlus[l].type)) {
			return false;
		}
	}
	return true;
}

public static void OnUnequip(Player p) {
	if(ModPlayer.skillWarrior[p.whoAmi]) {
		for(int l=0;l<10;l++) {
			if(p.buffType[l] == Config.buffDefs.ID["Reckless Aggression"]) {
				p.DelBuff(l);
				break;
			}
		}
	}
}

public static void Effects(Player p) {
	p.meleeDamage *= 1.2f;
	p.statDefense += 16;
	//Glowing Aura Effect
	if(ModPlayer.drawAuras) {
		int dust = Dust.NewDust(p.position,p.width,p.height,76,0f,-3f,200,new Color(255,0,0),1.5f);
		Main.dust[dust].noGravity = true;
	}
	if(Main.netMode != 2) {
		if(Main.mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && Main.oldMouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Released) {
			//Use skill
			if(ModPlayer.skillWarrior[p.whoAmi]) {
				for(int l=0;l<10;l++) {
					if(p.buffType[l] == Config.buffDefs.ID["Reckless Aggression"]) {
						p.DelBuff(l);
						break;
					}
				}
			} else {
				p.AddBuff("Reckless Aggression",180,false);
			}
		}
	}
}
