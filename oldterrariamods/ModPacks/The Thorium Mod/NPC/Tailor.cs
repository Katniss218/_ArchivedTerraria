public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Silk"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
	  return "Ruby";
        else
	  return "Sapphire";
}

public static string Chat() {

	int result = Main.rand.Next(5);
	string text = "";

	if (result == 0) 
        { 
          text = "Hello there darling! Do you need something?"; 
        }
	else if (result == 1) 
        { 
          text = "You would look so good in one of my suits!"; 
        }
	else  if (result == 2)
        { 
          text = "Please be quick. I have a lot of work to do!"; 
        }
	else  if (result == 3)
        { 
          text = "*snip snip snip* Do you need something?."; 
        }
	else  if (result == 4)
        { 
          text = "I've run out of Aquatic Silk! This is the worst possible thing!."; 
        }
	return text;

}

public static void SetupShop(Chest chest) {
	int index=0;
	
	chest.item[index].SetDefaults("Loom");
	chest.item[index].value = 10000;
	index++;
	chest.item[index].SetDefaults("Silk");
	chest.item[index].value = 800;
	index++;
	chest.item[index].SetDefaults("Ember Silk");
	chest.item[index].value = 10000;
	index++;
	chest.item[index].SetDefaults("Dream Silk");
	chest.item[index].value = 30000;
	index++;
	chest.item[index].SetDefaults("Fel-Iron Bar");
	chest.item[index].value = 30000;
	index++;
	chest.item[index].SetDefaults("Druid's Cowl");
	chest.item[index].value = 20000;
	index++;
	chest.item[index].SetDefaults("Robe");
	chest.item[index].value = 50000;
	index++;
	chest.item[index].SetDefaults("Buisness Trousers");
	chest.item[index].value = 20000;
	index++;
	chest.item[index].SetDefaults("Buisness Suit");
	chest.item[index].value = 20000;
	index++;
	chest.item[index].SetDefaults("Sunglasses");
	chest.item[index].value = 100000;
	index++;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Tailor Head Gore",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tailor Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tailor Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tailor Legs",1f,-1);
}
