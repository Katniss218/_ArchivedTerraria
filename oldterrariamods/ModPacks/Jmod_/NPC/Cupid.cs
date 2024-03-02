public static bool TownSpawn() {
	if(Main.snowTiles >= 25
       && Main.hardMode)
          return true;
	else 
          return false;
}
public static string SetName() {
	if(Main.rand.Next(2)==2)
	  return "Cupid";
        else
	  return "Cupid";
}
public static string Chat() {

	int result = Main.rand.Next(7);
	string text = "";

	if (result == 0) 
        { 
          text = "Buy some of my love potions. Not to much I need some for myself too."; 
        }
	else if (result == 1) 
        { 
          text = "I'm brothers with that Elf over there!."; 
        }
	else if (result == 2)
        { 
          text = "Yes, I do make chocolates."; 
        }
	else if (result == 3)
        { 
          text = "Oh, you got a magic mirror? I'll trade you!"; 
        }
	else if (result == 4)
        { 
          text = "Happy Valentines Day!"; 
        }
	else if (result == 5)
        { 
          text = "I just wish that I could have a better house than this."; 
        }
	else if (result == 6)
        { 
          text = "So, you have a girlfriend?"; 
        }
	return text;

}
public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Rose");
	index++;
	chest.item[index].SetDefaults("Heart of Chocolates");
	index++;;
	chest.item[index].SetDefaults("Wool");
	index++;
	chest.item[index].SetDefaults("Lover Boots");
	index++;;
	chest.item[index].SetDefaults("Pinecone");
	index++;}