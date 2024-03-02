public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.NewText("The Wyvern Mage is not present in this dimension... Retry at night!", 175, 75, 255);
}
if(Main.dayTime == false){
Main.NewText("It was a mistake to come here, Red... ", 175, 75, 255);
NPC.SpawnOnPlayer(playerID, "Wyvern Mage");
}

}
