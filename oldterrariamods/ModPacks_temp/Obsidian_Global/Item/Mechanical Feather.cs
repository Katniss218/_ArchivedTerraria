public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.NewText("The evil corrupted Wyvern deny your call... Retry at night !", 175, 75, 255);
}
if(Main.dayTime == false){
Main.NewText("A sinister cry echoes from the skies... ", 175, 75, 255);

NPC.NewNPC((int)Main.player[Main.myPlayer].position.X-(300), (int)Main.player[Main.myPlayer].position.Y+900, Config.npcDefs.byName["Dark Wyvern Head"].type, 0);

NPC.NewNPC((int)Main.player[Main.myPlayer].position.X+(300), (int)Main.player[Main.myPlayer].position.Y-900, Config.npcDefs.byName["Dark Wyvern Head"].type, 0);

}
}