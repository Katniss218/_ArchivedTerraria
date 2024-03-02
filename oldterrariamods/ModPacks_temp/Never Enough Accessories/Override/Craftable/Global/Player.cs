
//Globals
public static readonly List<int> classAccessories = new List<int>(new int[] {
	Config.itemDefs.byName["Warrior's Spark"].type,
	Config.itemDefs.byName["Warrior's Focus"].type,
	Config.itemDefs.byName["Warrior's Soul"].type,
	Config.itemDefs.byName["Guardian's Spark"].type,
	Config.itemDefs.byName["Guardian's Focus"].type,
	Config.itemDefs.byName["Guardian's Soul"].type,
	Config.itemDefs.byName["Gunslinger's Spark"].type,
	Config.itemDefs.byName["Gunslinger's Focus"].type,
	Config.itemDefs.byName["Gunslinger's Soul"].type,
	Config.itemDefs.byName["Ranger's Spark"].type,
	Config.itemDefs.byName["Ranger's Focus"].type,
	Config.itemDefs.byName["Ranger's Soul"].type,
	Config.itemDefs.byName["Sorcerer's Spark"].type,
	Config.itemDefs.byName["Sorcerer's Focus"].type,
	Config.itemDefs.byName["Sorcerer's Soul"].type,
	Config.itemDefs.byName["Mage's Spark"].type,
	Config.itemDefs.byName["Mage's Focus"].type,
	Config.itemDefs.byName["Mage's Soul"].type
});

public static bool[] immortalSickness = new bool[Main.player.Length];
public static bool[] skillWarrior = new bool[Main.player.Length];
public static bool[] skillGuardian = new bool[Main.player.Length];
public static bool[] skillGunslinger = new bool[Main.player.Length];
public static bool[] skillRanger = new bool[Main.player.Length];
public static bool[] skillRangerCooldown = new bool[Main.player.Length];
public static bool[] skillSorcerer = new bool[Main.player.Length];
public static bool[] skillMage = new bool[Main.player.Length];
public static bool drawAuras = true;
public static int crosshairX = -64;
public static int crosshairY = -64;
public static int focusTick = 0;


//Methods

public void Save(BinaryWriter binarywriter) {
	binarywriter.Write(drawAuras);
}

public void Load(BinaryReader binaryreader, int version) {
	drawAuras = binaryreader.ReadBoolean();
}

public void PreUpdatePlayer(Player p) {
	crosshairX = -64;
	crosshairY = -64;
}

public void UpdatePlayer(Player p) {
	//Focus tick
	focusTick++;
	if(focusTick >= 10) {
		focusTick = 0;
	}
}

public void PostKill(Player P,double Damage,int hitDirection,bool pvp,string deathText) {
	//Buffs are gone after death
	immortalSickness[P.whoAmi] = false;
	skillWarrior[P.whoAmi] = false;
	skillGuardian[P.whoAmi] = false;
	skillGunslinger[P.whoAmi] = false;
	skillRanger[P.whoAmi] = false;
	skillRangerCooldown[P.whoAmi] = false;
	skillSorcerer[P.whoAmi] = false;
	skillMage[P.whoAmi] = false;
}
