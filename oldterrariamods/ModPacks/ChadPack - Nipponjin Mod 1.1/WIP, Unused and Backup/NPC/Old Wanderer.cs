public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Soul of Honor"){
				return true;
				}
			}
		}
	}
	return false;
}

public static string SetName() {

	int result = Main.rand.Next(5);
	string name = "";
	
	if (result == 0) 
        { 
          name = "Daichi"; //means "Great Wisdom"
        }
	else if (result == 1)
		{
		  name = "Hisao"; //means "Long-lived Man"
		}
	else if (result == 2)
		{
		  name = "Kei"; //means "Wise"
		}
	else  if (result == 3)
		{
		  name = "Takao"; //means "Respectful Man"
		}
	else  if (result == 4)
		{
		  name = "Kenji"; //means "Studying Second Son"
		}
	return name;
}

public void Initialize(){
	npc.name="Old Wanderer";
}

public static string Chat() {

	int result = Main.rand.Next(11);
	string text = "";

	if (result == 0) 
        { 
          text = "No, my name isnt agist, im just very, very old and wise."; 
        }
	else  if (result == 1) 
        { 
          text = "I was sprited by Wooren! He did a very good job."; 
        }
	else  if (result == 2)
		{
		  text = "Wisdom comes with aging.";
		}
	else  if (result == 3)
		{
		  text = "Some people of my age wish they were your age again, so they can play sports without breaking their legs... I disagree. If I would be your age again, I wouldnt be this wise, would I?";
		}
	else  if (result == 4)
		{
		  text = "Wanna know my age? They say that I'm over one thousand years old... Lets keep it at a simple ninehundred.";
		}
	else  if (result == 5)
		{
		  text = "There is no being old. There is feeling old.";
		}
	else  if (result == 6)
		{
		  text = "Wanna play chess? What, afraid to lose?";
		}
	else  if (result == 7)
		{
		  text = "Nice mod is this, isnt it?";
		}
	else  if (result == 8)
		{
		  text = "Want some sushi?";
		}
	else  if (result == 9)
		{
		  text = "Im not the only person thats over fivehundred years old and still alive. I am the only one to be over ninehundred years old though.";
		}
	else  if (result == 10)
		{
		  text = "Not everything in this mod is made by Chadwick. Most things are.";
		}
	return text;
}

public static void SetupShop(Chest chest) {
	int index=0;
	
	chest.item[index].SetDefaults("Robot Hat");
	chest.item[index].value = 100;
	index++;
}