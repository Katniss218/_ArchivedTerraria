public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.dayTime = false;
Main.NewText("I raise it into the air, and it turns to dust.", 175, 75, 255);
}else{
Main.dayTime = true;
Main.NewText("I raise it into the air, and it burns away.", 175, 75, 255);
}
}