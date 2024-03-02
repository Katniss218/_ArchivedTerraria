public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.NewText("The ancient Jungle Wyvern remains deep in slumber... Retry at night!", 175, 75, 255);
}
if(Main.dayTime == false){
Main.NewText("A rumbling thunder shakes the ground below you... ", 175, 75, 255);
for(int i=0; i<1;i++){
NPC.NewNPC((int)Main.player[Main.myPlayer].position.X+(i*300), (int)Main.player[Main.myPlayer].position.Y+900, Config.npcDefs.byName["Jungle Wyvern Head"].type, 0);
}

}
}


public bool CanUse(Player Pr,int PID)
{
    return !NPC.AnyNPCs(Config.npcDefs.byName["Jungle Wyvern Head"].type);
}
