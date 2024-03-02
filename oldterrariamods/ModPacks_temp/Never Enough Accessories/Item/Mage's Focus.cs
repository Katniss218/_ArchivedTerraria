
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
	if(ModPlayer.skillMage[p.whoAmi]) {
		for(int l=0;l<10;l++) {
			if(p.buffType[l] == Config.buffDefs.ID["Mystic Stance"]) {
				p.DelBuff(l);
				break;
			}
		}
	}
}

public static void Effects(Player p) {
	p.statManaMax2 += 60;
	p.statDefense += 4;
	//Glowing Eyes Effect
	if(ModPlayer.drawAuras && ModPlayer.focusTick == 0) {
		int dust = Dust.NewDust(p.position + new Vector2(6f+(p.direction*3.5f),7f),2,2,76,0f,-3f,200,new Color(0,255,255),1.5f);
		Main.dust[dust].noGravity = true;
	}
	if(Main.netMode != 2) {
		if(Main.mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && Main.oldMouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Released) {
			//Use skill
			if(ModPlayer.skillMage[p.whoAmi]) {
				for(int l=0;l<10;l++) {
					if(p.buffType[l] == Config.buffDefs.ID["Mystic Stance"]) {
						p.DelBuff(l);
						break;
					}
				}
			} else {
				p.AddBuff("Mystic Stance",120,false);
			}
		}
	}
}
