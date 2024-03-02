public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Horn"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
	  return "John";
        else
	  return "Paul";
}

public static string Chat() {

	int result = Main.rand.Next(5);
	string text = "";

	if (result == 0) 
        { 
          text = "Need a manual? I got yah covered!"; 
        }
	else if (result == 1) 
        { 
          text = "Strike while the Iron is hot."; 
        }
	else  if (result == 2)
        { 
          text = "That's got a nice ring to it."; 
        }
	else  if (result == 3)
        { 
          text = "I was out there mining too, did you see me?"; 
        }
	else  if (result == 4)
        { 
          text = "*ting *ting *ting"; 
        }
	return text;

}

public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Copper Bar");
	chest.item[index].value = 500;
	index++;
	chest.item[index].SetDefaults("Iron Bar");
	chest.item[index].value = 800;
	index++;
	chest.item[index].SetDefaults("Silver Bar");
	chest.item[index].value = 800;
	index++;
	chest.item[index].SetDefaults("Gold Bar");
	chest.item[index].value = 1000;
	index++;
	chest.item[index].SetDefaults("Manual");
	chest.item[index].value = 10000;
	index++;
}

public void NPCLoot()
{
    Gore.NewGore(npc.position,npc.velocity,"BlackSmith Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"BlackSmith Leg",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"BlackSmith Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"BlackSmith Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"BlackSmith Arm",1f,-1);
}