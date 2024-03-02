public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.NewText("Nothing happens...", 175, 75, 255);
}
if(Main.dayTime == false){
//Main.NewText("Thy death will only fuel my immortality, Red...", 175, 75, 255);
NPC.SpawnOnPlayer(playerID, "Abysmal Oolacile Sorcerer");
}

}
