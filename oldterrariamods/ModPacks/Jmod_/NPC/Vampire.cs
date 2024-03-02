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
          text = "Happy Halloween!."; 
        }
	else if (result == 2)
        { 
          text = "Want to see something spooky? Go look in the mirror!"; 
        }
	else if (result == 3)
        { 
          text = "Oh, you got a magic mirror? I'll trade you!"; 
        }
	else if (result == 4)
        { 
          text = "Why does everyone think I suck blood? I like jelly instead."; 
        }
	else if (result == 5)
        { 
          text = "I just wish that I could have a better house than this."; 
        }
	else if (result == 6)
        { 
          text = "GHOSTS! GHOSTS EVERYWHERE!"; 
        }
	return text;

}
public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Little Pumpkin");
	index++;
	chest.item[index].SetDefaults("Carved Pumpkin");
	index++;;
	chest.item[index].SetDefaults("Wool");
	index++;
}