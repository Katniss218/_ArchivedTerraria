

public static void UseItem(Player player, int playerID) {


if(Main.bloodMoon == true){
Main.NewText("The Blight cannot be summoned or fought while in the Abyss...", 175, 75, 255);
}
if(Main.bloodMoon == false){
NPC.NewNPC((int)player.position.X-700, (int)player.position.Y-500, Config.npcDefs.byName["Blight"].type, 1);
Main.NewText("You will be destroyed");
}




}

public bool CanUse(Player Pr,int PID)
{
    return !NPC.AnyNPCs(Config.npcDefs.byName["Blight"].type);
}



