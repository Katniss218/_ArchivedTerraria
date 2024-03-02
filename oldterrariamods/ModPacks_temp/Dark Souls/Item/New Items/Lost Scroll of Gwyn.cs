public void UseItem(Player player, int playerID){
if(Main.bloodMoon == false){
Main.NewText("Lord Gwyn ignores your call... you must enter The Abyss to summon the Lord of Cinder!", 175, 75, 255);
}
if(Main.bloodMoon == true){
Main.NewText("Defeat me, and you shall inherit the fire of this world... ", 175, 75, 255);
NPC.SpawnOnPlayer(playerID, "Gwyn");
}

}





