public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Sand Block"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
	  return "Karoo";
        else
	  return "Namib";
}

public static string Chat() {

	int result = Main.rand.Next(5);
	string text = "";

	if (result == 0) 
        { 
          text = "There are so many plants around here. I'm not used to it!"; 
        }
	else if (result == 1) 
        { 
          text = "Got any water?"; 
        }
	else  if (result == 2)
        { 
          text = "my camal got eaten by some hungry slimes!"; 
        }
	else  if (result == 3)
        { 
          text = "What was that? I cant hear you, i have sand in my ears."; 
        }
	else  if (result == 4)
        { 
          text = "Have you ever seen the Thunder Bird? It roams the skies."; 
        }
	return text;

}

public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Sand Block");
	chest.item[index].value = 50;
	index++;
	chest.item[index].SetDefaults("Sand Brick");
	chest.item[index].value = 50;
	index++;
	chest.item[index].SetDefaults("Sand Brick Wall");
	chest.item[index].value = 10;
	index++;
	chest.item[index].SetDefaults("Cactus");
	chest.item[index].value = 100;
	index++;
	chest.item[index].SetDefaults("Antlion Mandible");
	chest.item[index].value = 15000;
	index++;
	chest.item[index].SetDefaults("Thunder Talon");
	chest.item[index].value = 30000;
	index++;
	chest.item[index].SetDefaults("Strong Flare Gun");
	chest.item[index].value = 10000;
	index++;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Desert Travler Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Desert Travler Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Desert Travler head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Desert Travler arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Desert Travler arm",1f,-1);
}
