public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Slice of Cheese"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
	  return "Simon";
        else
	  return "Gregg";
}

public static string Chat() {

	int result = Main.rand.Next(5);
	string text = "";

	if (result == 0) 
        { 
          text = "Food really is magical!"; 
        }
	else if (result == 1) 
        { 
          text = "Ever try to eat a pie in one bite?"; 
        }
	else  if (result == 2)
        { 
          text = "I uh, cant actually cook..."; 
        }
	else  if (result == 3)
        { 
          text = "Food can give you that little boost you need!"; 
        }
	else  if (result == 4)
        { 
          text = "You hungry? Then make some food pal!"; 
        }
	return text;

}

public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Apple");
	chest.item[index].value = 200;
	index++;
	chest.item[index].SetDefaults("Slice of Cheese");
	chest.item[index].value = 200;
	index++;
	chest.item[index].SetDefaults("Flour");
	chest.item[index].value = 200;
	index++;
	chest.item[index].SetDefaults("Hunk of Meat");
	chest.item[index].value = 200;
	index++;
	chest.item[index].SetDefaults("Lettuce");
	chest.item[index].value = 200;
	index++;
	chest.item[index].SetDefaults("Milk");
	chest.item[index].value = 200;
	index++;
	chest.item[index].SetDefaults("Tomato");
	chest.item[index].value = 200;
	index++;
	chest.item[index].SetDefaults("Chocolate");
	chest.item[index].value = 200;
	index++;
}