
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
	if(ModPlayer.skillSorcerer[p.whoAmi]) {
		for(int l=0;l<10;l++) {
			if(p.buffType[l] == Config.buffDefs.ID["Overcharge"]) {
				p.DelBuff(l);
				break;
			}
		}
	}
}

public static void Effects(Player p) {
	p.magicDamage *= 1.08f;
	p.statDefense += 2;
	if(Main.netMode != 2) {
		if(Main.mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && Main.oldMouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Released) {
			//Use skill
			if(ModPlayer.skillSorcerer[p.whoAmi]) {
				for(int l=0;l<10;l++) {
					if(p.buffType[l] == Config.buffDefs.ID["Overcharge"]) {
						p.DelBuff(l);
						break;
					}
				}
			} else {
				p.AddBuff("Overcharge",60,false);
			}
		}
	}
}
