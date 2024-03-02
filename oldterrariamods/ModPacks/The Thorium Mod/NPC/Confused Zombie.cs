public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Blood"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
	  return "Bloat";
        else
	  return "Bile";
}

public static string Chat() {

	int result = Main.rand.Next(5);
	string text = "";

	if (result == 0) 
        { 
          text = "*Groan*"; 
        }
	else if (result == 1) 
        { 
          text = "You... zombie...?"; 
        }
	else  if (result == 2)
        { 
          text = "Shackle... Blood... Make... Forget..."; 
        }
	else  if (result == 3)
        { 
          text = "Got... Brains?"; 
        }
	else  if (result == 4)
        { 
          text = "I smell... Blooood..."; 
        }
	return text;

}

public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Mad Brain");
	chest.item[index].value = 5000;
	index++;
	chest.item[index].SetDefaults("Defensive Brain");
	chest.item[index].value = 5000;
	index++;
	chest.item[index].SetDefaults("Wealthy Brain");
	chest.item[index].value = 5000;
	index++;
	chest.item[index].SetDefaults("Big Brain");
	chest.item[index].value = 5000;
	index++;
	chest.item[index].SetDefaults("Shackle");
	chest.item[index].value = 10000;
	index++;
	chest.item[index].SetDefaults("Blood");
	chest.item[index].value = 800;
	index++;
	chest.item[index].SetDefaults("Rotten Chunk");
	chest.item[index].value = 1000;
	index++;
	chest.item[index].SetDefaults("Deathweed");
	chest.item[index].value = 800;
	index++;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"Impaled Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Impaled Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Impaled Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Impaled Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Impaled Arm",1f,-1);
}