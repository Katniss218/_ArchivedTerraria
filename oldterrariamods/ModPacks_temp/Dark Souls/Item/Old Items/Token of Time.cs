public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.dayTime = false;
Main.time = 0.00;
Main.NewText("I raise it into the air, and a magic night starts. ", 175, 75, 255);
}else{
Main.dayTime = true;
Main.time = 0.00;
Main.NewText("I raise it into the air, and a magic day starts.", 175, 75, 255);
}
}