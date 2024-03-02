public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.NewText("The Ghost Wyvern is not present in this dimension... Retry at night!", 175, 75, 255);
}
if(Main.dayTime == false){
Main.NewText("You think death is the end? You haven't begun to understand my powers, Red... ", 175, 75, 255);
NPC.SpawnOnPlayer(playerID, "Wyvern Mage Shadow");
}

}
