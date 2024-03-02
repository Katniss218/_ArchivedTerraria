public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Soul of Honor"){
				return true;
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

	int result = Main.rand.Next(17);
	string text = "";
	string merchantName = Main.chrName[17];
    string gunDealerName = Main.chrName[19];
    string demolitionName = Main.chrName[38];
    string clothierName = Main.chrName[54];
    string tinkerName = Main.chrName[107];
    string playerName = Main.player[Main.myPlayer].name;

	if (result == 0) 
        { 
          text = "Im just very, very old and wise."; 
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
		  text = "Nice mod is this, isnt it? Did you possibly see my katana? Or my book of wisdom?";
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
	else  if (result == 11)
		{
		  text = "Hello there, "+playerName+"... And how are you doing? Interested in some sushi?";
		}
	else  if (result == 12)
		{
		  text = "Thanks for playing this mod, "+playerName+"!";
		}
	else  if (result == 13)
		{
		  text = "I used to have a very powerful katana, and a book of wisdom... I lost them both. If you manage to get me them back, I shall give you a Sun Amulet!";
		}
	else  if (result == 14)
		{
		  text = "Can you find my katana and my book for me? I will give you the Sun Amulet!";
		}
	else  if (result == 15)
		{
		  text = "I remember that I left my book in a chest somewhere, and a Jiang Shi took my katana!";
		}
	else  if (result == 16)
		{
		  text = "You people with your hophip, your drugs and your Oppan Gabbang Style...";
		}
	return text;

}

public void NPCLoot ()
{


	Gore.NewGore(npc.position,npc.velocity,"Old Wanderer 1",1f,-1);



}

public static void SetupShop(Chest chest) {
	int index=0;
	
	chest.item[index].SetDefaults("Sushi");
	chest.item[index].value = 500;
	index++;
	chest.item[index].SetDefaults("Ancient Japanese Shield");
	chest.item[index].value = 100000;
	index++;
	chest.item[index].SetDefaults("Seed");
	index++;
	chest.item[index].SetDefaults("Tanabata Cake");
	chest.item[index].value = 5000;
	index++;
}

public static string ChatFuncName() {
    return "Trading";
}
public void ChatFunc() {

    TradingInterface.Create();
    Main.npcChatText = "";
    Main.playerInventory = true;
}
public class TradingInterface : Interfaceable {
    public static void Create() {
        Config.npcInterface = new InterfaceObj(new TradingInterface(), 3, 3);
        Config.npcInterface.AddItemSlot(150,250);
        Config.npcInterface.AddItemSlot(200,250); // i might move the slots
        Config.npcInterface.AddItemSlot(150,320);
        Config.npcInterface.AddText("Place your offer here", 145, 225, false, 0.9f);
        Config.npcInterface.AddText("Wanderers offer", 150, 295, false,0.9f);
    }
    public void ButtonClicked(int button) {
    }
    public bool CanPlaceSlot(int slot, Item mouseItem) {

        if(slot==2) {
            if(mouseItem.type==0 || mouseItem.stack==0) return true;
            else return false;
        }
        return true;
    }
    public void PlaceSlot(int slot) {

        Item[] itemSlots = Config.npcInterface.itemSlots;
        if(slot!=2){
            if(itemSlots[0]!= null || itemSlots[1]!= null){itemSlots[2]=new Item();}

			string outputItem = null;
			switch(itemSlots[0].name){
				case "The wanderers Old Katana":
					switch(itemSlots[1].name){
						case "The Book of Wisdom":
							outputItem = "Sun Amulet";
							break;
					}
					break;
				case "The Book of Wisdom":
					switch(itemSlots[1].name){
						case "The wanderers Old Katana":
							outputItem = "Sun Amulet";
							break;
					}
					break;
			}
			itemSlots[2].SetDefaults(outputItem);
		}else{
            itemSlots[0]=new Item();
            itemSlots[1]=new Item();
            itemSlots[2]=new Item();
        }
    }
    public bool DropSlot(int slot) {
        if(slot==2) return false;
        return true;
    }
}