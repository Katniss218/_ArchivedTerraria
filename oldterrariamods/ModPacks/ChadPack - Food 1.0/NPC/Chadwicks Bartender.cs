public static bool TownSpawn() {
	for(int i = 0; i < Main.player.Length; i++){
		for(int j = 0; j < Main.player[i].inventory.Length; j++){
			if (Main.player[i].inventory[j].name=="Ale"){
				return true;
			}
		}
	}
	return false;
}

public static string SetName() {

	int cc = Main.rand.Next(3);
	
	if (cc == 0) return "Bill";
	else if (cc == 1) return "Joe";
	else if (cc == 2) return "Ali";
	return "ChadwicksBartender_SetName(3)";
}

/*public void Initialize(){
	npc.name="Bartender";
}*/

public static string Chat() {

	int cc = Main.rand.Next(6);

	if(ModPlayer.AppleQuest){
		if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type != Config.itemDefs.byName["Apple"].type) return "Pretty sure I asked you for some apples.";
		else{
			if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack < 10) return "Im sorry, I really do need more apples than that.";
			else if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack >= 10){
				ModPlayer.sellAppleCider = true;
				ModPlayer.AppleQuest = false;
				Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 10;
				Main.NewText ("[Quest] Quest Finished: My cider brings all the boys to the yard!");
				return "Thanks! Ill be making lotsa apple cider from this!";
				Main.PlaySound(7, -1, -1, 1);
			}
		}
	}
	else{
		if (cc == 0){ 
			return "Thanks for playing this mod, "+Main.player[Main.myPlayer].name+"!"; 
		}
		else  if (cc == 1){ 
			return "Want some beer? Its basically ale, but just a little bit stronger!"; 
		}
		else  if (cc == 2){
			if(!ModPlayer.sellAppleCider){
				ModPlayer.AppleQuest = true;
				ModPlayer.AppleNeeded = 10;
				Main.NewText ("[Quest] Quest Added: My cider brings all the boys to the yard!");
				return "Can you bring me ten apples for my apple cider?";
			}
			else return "Howdy! Care for some apple cider?";
		}
		else  if (cc == 3) return "Did you know that you can drink yourself to death in Terraria? No? Thats because you cant.";
		else  if (cc == 4) return "Getting drunk is more fun in multiplayer. Good times, good times... ";
		else  if (cc == 5) return "I dont know why I always have these plates with me. Ask Chad.";
	}
	return "ChadwicksBartender_Chat(6)";
}

public void NPCLoot ()
{


	Gore.NewGore(npc.position,npc.velocity,"Chadwicks Bartender 1",1f,-1);
    Gore.NewGore(npc.position,npc.velocity,"Chadwicks Bartender 2",1f,-1);
    Gore.NewGore(npc.position,npc.velocity,"Chadwicks Bartender 2",1f,-1);
    Gore.NewGore(npc.position,npc.velocity,"Chadwicks Bartender 3",1f,-1);
    Gore.NewGore(npc.position,npc.velocity,"Chadwicks Bartender 3",1f,-1);



}

public static void SetupShop(Chest chest) {
	int index=0;
	
	chest.item[index].SetDefaults("Ale");
	index++;
	chest.item[index].SetDefaults("Beer");
	index++;
	if(ModPlayer.sellAppleCider){
		chest.item[index].SetDefaults("Apple Cider");
		index++;
	}
}