//spawn only if a player has certain item(s)
public static bool TownSpawn() 
{
    if (!NPC.AnyNPCs(Config.npcDefs.byName["Master Librarian"].type)) return true;
    return false;
}

public static string SetName() {
	return "Master Librarian";
}

//randomly select a dialog option
public static string Chat() {
	string[] dialogs = {
	"Oh! Its you, master. What do you need?", 
	"Young master, I cannot aid one who opposes the Master!", 
	"Really? In that case, just tell me what you need.",
	};
	int choice = Main.rand.Next(0, dialogs.Length);
	return dialogs[choice];
}


public static void SetupShop(Chest chest) {
	int index=0;
	chest.item[index].SetDefaults("Lesser Healing Potion");
	index++;
	chest.item[index].SetDefaults("Shuriken");
	index++;
	chest.item[index].SetDefaults("Mace");
	index++;
	chest.item[index].SetDefaults("Ring of Pales");
	index++;
}