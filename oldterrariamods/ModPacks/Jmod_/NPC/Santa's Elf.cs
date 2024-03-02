public static bool TownSpawn() {
	if(Main.snowTiles >= 25
       && Main.hardMode)
          return true;
	else 
          return false;
}
public static string SetName() {
	if(Main.rand.Next(2)==2)
	  return "Elf";
        else
	  return "Elf";
}
public static string Chat() {

	int result = Main.rand.Next(7);
	string text = "";

	if (result == 0) 
        { 
          text = "I don't get why Santa doesn't come all year and I do"; 
        }
	else if (result == 1) 
        { 
          text = "Even though it's July these Stockings are still great."; 
        }
	else if (result == 2)
        { 
          text = "Yes, I do make teddy bears."; 
        }
	else if (result == 3)
        { 
          text = "Oh, you got a magic mirror? I'll trade you!"; 
        }
	else if (result == 4)
        { 
          text = "Merry Christmas!"; 
        }
	else if (result == 5)
        { 
          text = "I just wish that I could have a better house than this."; 
        }
	else if (result == 6)
        { 
          text = "Do any of this kids want to sit on my lap?"; 
        }
	return text;

}
public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Candy Cane Block");
	index++;
	chest.item[index].SetDefaults("Green Candy Cane Block");
	index++;;
	chest.item[index].SetDefaults("Blue Stocking");
	index++;
	chest.item[index].SetDefaults("Blue Ornament");
	index++;
	chest.item[index].SetDefaults("Wool");
	index++;
}