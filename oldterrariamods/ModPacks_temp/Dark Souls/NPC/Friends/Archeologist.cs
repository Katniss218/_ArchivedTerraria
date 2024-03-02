// public static bool SpawnNPC(int x, int y, int playerID) {
	// if(Main.player[playerID].zoneJungle){
		// return true;}
	// return false;
// }

public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Mysterious Idol"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public void Initialize() 
{
	if(Main.chrName[npc.type] == null){ Main.chrName[npc.type] = SetName(); }
}

public static string SetName() {
	return "Archeologist";
}



public static string Chat() {
	string[] dialogs = {
	"Remember, X never marks the spot.", 
	"The report of my undeath was an exaggeration.", 
	"I *hate* snakes.",
	"Seen any fortune or glory lately?",
	"Trust me.",
	"Ha! You think THESE boulder traps are bad..."
	};
	int choice = Main.rand.Next(0, dialogs.Length);
	return dialogs[choice];
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Archeologist Head Gore",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Archeologist Arm Gore",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Archeologist Arm Gore",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Archeologist Leg Gore",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Archeologist Leg Gore",1f,-1);
}

public static void SetupShop(Chest chest) {
	int index=0;
	chest.item[index].SetDefaults("Mysterious Idol");
	index++;
	chest.item[index].SetDefaults("Meteor Shot");
	index++;
	chest.item[index].SetDefaults("Wooden Arrow");
	index++;
	chest.item[index].SetDefaults("Torch");
	index++;
	chest.item[index].SetDefaults("Mana Potion");
	index++;
	chest.item[index].SetDefaults("Healing Potion");
	index++;
	chest.item[index].SetDefaults("Purification Powder");
	index++;
	chest.item[index].SetDefaults("Night Owl Potion");
	index++;
	chest.item[index].SetDefaults("Bottled Water");
	index++;
	chest.item[index].SetDefaults("Glowing Mushroom");
	index++;
	chest.item[index].SetDefaults("Familiar Wig");
	index++;
	chest.item[index].SetDefaults("Poisoned Knife");
	index++;
	chest.item[index].SetDefaults("Grenade");
	index++;
	chest.item[index].SetDefaults("Cosmic Watch");
	index++;
}