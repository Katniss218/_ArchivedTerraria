public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Coral"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
	  return "Sam";
        else
	  return "Max";
}

public static string Chat() {

	int result = Main.rand.Next(5);
	string text = "";

	if (result == 0) 
        { 
          text = "Look what i found in the ocean!"; 
        }
	else if (result == 1) 
        { 
          text = "I got the best deals anywhere!"; 
        }
	else  if (result == 2)
        { 
          text = "I had to wrestle this out of a sharks mouth!"; 
        }
	else  if (result == 3)
        { 
          text = "I saw a mermaid! no, really!"; 
        }
	else  if (result == 4)
        { 
          text = "Want a fishing rod?"; 
        }
	return text;

}

public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Thor Hammer Melee");
	chest.item[index].value = 80000;
	index++;
	chest.item[index].SetDefaults("Thorium Bar");
	chest.item[index].value = 1000;
	index++;
	chest.item[index].SetDefaults("Breathing Reed");
	chest.item[index].value = 8000;
	index++;
	chest.item[index].SetDefaults("Fishing Rod");
	chest.item[index].value = 1000;
	index++;
	chest.item[index].SetDefaults("Coral");
	chest.item[index].value = 500;
	index++;
}