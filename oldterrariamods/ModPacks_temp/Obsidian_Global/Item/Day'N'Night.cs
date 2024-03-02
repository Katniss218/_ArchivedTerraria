public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.dayTime = false;
Main.time = 0.0;
Main.NewText("A magic night starts...", 175, 75, 255);
}else{
Main.dayTime = true;
Main.time = 0.0;
Main.NewText("A magic day starts...", 175, 75, 255);
}
}