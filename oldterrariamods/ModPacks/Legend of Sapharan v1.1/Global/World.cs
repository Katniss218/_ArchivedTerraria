public static bool PoGoblinInvasion;
public static int PoGoblinInvasionCount;
// ----------------------------------------------------------------------------
public static void Initialize() {
	PoGoblinInvasion=false;
	PoGoblinInvasionCount = 0;
}
// ----------------------------------------------------------------------------
public static void StartPoGoblinInvasion() {
    PoGoblinInvasion = true;
    PoGoblinInvasionCount = 0;
    if (Main.netMode == 0) Main.NewText("The Poison Goblin Army has attacked!!", 255, 50, 175);
    else if (Main.netMode == 2) NetMessage.SendData(25, -1, -1, "The Poison Goblin Army has attacked!!", 255, 255f, 50f, 175f, 0);
}
// ----------------------------------------------------------------------------
public static void EndPoGoblinInvasion() {
    PoGoblinInvasion = false;
    PoGoblinInvasionCount = 0;
    if (Main.netMode == 0) Main.NewText("The Poison Goblin Army has been defeated!", 255, 50, 175);
    else if (Main.netMode == 2) NetMessage.SendData(25, -1, -1, "The Poison Goblin Army has been defeated!", 255, 255f, 50f, 175f, 0);
}
//--------------------------------------------------------------------------------
public static void UpdateWorld() {
    if (ModWorld.PoGoblinInvasion)
	{
		ModWorld.PoGoblinInvasionCount++;
		if (ModWorld.PoGoblinInvasionCount >= 10800)
		{
			ModWorld.EndPoGoblinInvasion();
		}
	}
}

public void Save(BinaryWriter W) {
    W.Write(PoGoblinInvasion);
    W.Write(PoGoblinInvasionCount);
}
public void Load(BinaryReader R, int V) {
    PoGoblinInvasion = R.ReadBoolean();
    PoGoblinInvasionCount = R.ReadInt32();
}