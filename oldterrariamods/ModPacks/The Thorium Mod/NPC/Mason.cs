public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Cultist Badge"){
			//if (Main.player[i].HasItem("Mysterious Idol")){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {
	if(Main.rand.Next(2)==0)
	  return "Abbot";
        else
	  return "Magus";
}

public static string Chat() {

	int result = Main.rand.Next(5);
	string text = "";

	if (result == 0) 
        { 
          text = "Beware the shadows friend."; 
        }
	else if (result == 1) 
        { 
          text = "Be at peace."; 
        }
	else  if (result == 2)
        { 
          text = "Reason is the enemy of faith, my friend."; 
        }
	else  if (result == 3)
        { 
          text = "Would you like a cross?"; 
        }
	else  if (result == 4)
        { 
          text = "Do not mind my slouch, im quite old."; 
        }
	return text;

}

public static void SetupShop(Chest chest) {
	int index=0;

	chest.item[index].SetDefaults("Renew Potion");
	chest.item[index].value = 2000;
	index++;
	chest.item[index].SetDefaults("Mason Badge");
	chest.item[index].value = 20000;
	index++;
	chest.item[index].SetDefaults("Shrine");
	chest.item[index].value = 50000;
	index++;
	chest.item[index].SetDefaults("Blessing of the Mason");
	chest.item[index].value = 100000;
	index++;
	chest.item[index].SetDefaults("Cross Necklace");
	chest.item[index].value = 100000;
	index++;
}

public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Mason Robe",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mason Head",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mason Arm",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Mason Arm",1f,-1);
}
