public void UseItem(Player player, int playerID){
if(Main.dayTime == true){
Main.NewText("Nothing happens...", 175, 75, 255);
}
if(Main.dayTime == false){
Main.NewText("Thy death will only fuel my immortality, Red... ", 175, 75, 255);
for(int i=0; i<1;i++){
NPC.NewNPC((int)Main.player[Main.myPlayer].position.X+(i*300), (int)Main.player[Main.myPlayer].position.Y-800, Config.npcDefs.byName["Seath the Scaleless Head"].type, 0);
}

}
}


public bool CanUse(Player Pr,int PID)
{
    return !NPC.AnyNPCs(Config.npcDefs.byName["Seath the Scaleless Head"].type);
}
