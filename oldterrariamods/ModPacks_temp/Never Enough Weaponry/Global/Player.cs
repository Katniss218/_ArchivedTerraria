
//Globals
private static List<int> spaceWeaponry;

private Item spaceBattery = Config.itemDefs.byName["Space Battery"];

//Methods

public void Initialize() {
	spaceWeaponry = new List<int>(new int[7] {198,199,200,201,202,203,514});
	spaceWeaponry.Add(Config.itemDefs.byName["Blue Blazesaber"].type);
	spaceWeaponry.Add(Config.itemDefs.byName["Green Blazesaber"].type);
	spaceWeaponry.Add(Config.itemDefs.byName["Purple Blazesaber"].type);
	spaceWeaponry.Add(Config.itemDefs.byName["Red Blazesaber"].type);
	spaceWeaponry.Add(Config.itemDefs.byName["White Blazesaber"].type);
	spaceWeaponry.Add(Config.itemDefs.byName["Yellow Blazesaber"].type);
}

public void UpdatePlayer(Player p) {
	//If Holding a Space Battery, apply effects
	for (int l=44;l<48;l++) {
		if(p.inventory[l].ammo == spaceBattery.ammo) {
			p.spaceGun = true;
			int selectedItemType = p.inventory[p.selectedItem].type;
			if(spaceWeaponry.Contains(selectedItemType)) {
				if(selectedItemType == /*Laser Rifle*/514) {
					p.manaCost -= 0.25f;
					if(p.manaCost < 0f) {
						p.manaCost = 0f;
					}
				} else {
					p.meleeDamage *= 1.03f;
					p.meleeCrit += 3;
				}
			}
		}
	}
}