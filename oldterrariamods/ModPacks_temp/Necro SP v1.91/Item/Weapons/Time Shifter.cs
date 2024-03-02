public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.dayTime = false;
Main.time = 0.0;
Main.NewText("What a terrible night to have a cursed mod...", 175, 75, 255);
}else{
Main.dayTime = true;
Main.time = 0.0;
Main.NewText("Day break bring safety...for now", 175, 75, 255);
}
}