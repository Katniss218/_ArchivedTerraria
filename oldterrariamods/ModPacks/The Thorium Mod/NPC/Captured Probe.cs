public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Soul of Might"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
	  return "Infrared";
        else
	  return "Microwave";
}

public static string Chat() {

	int result = Main.rand.Next(5);
	string text = "";

	if (result == 0) 
        { 
          text = "Get me out of this thing!"; 
        }
	else if (result == 1) 
        { 
          text = "Atleast make me a robot wife."; 
        }
	else  if (result == 2)
        { 
          text = "My master will return, and you will suffer."; 
        }
	else  if (result == 3)
        { 
          text = "Why do you keep me alive!"; 
        }
	else  if (result == 4)
        { 
          text = "I serve no purpose to you!"; 
        }
	return text;

}
