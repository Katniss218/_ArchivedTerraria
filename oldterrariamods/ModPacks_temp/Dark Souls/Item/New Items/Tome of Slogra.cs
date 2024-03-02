public void UseItem(Player player, int playerID){
if(Main.dayTime == true)
{
Main.NewText("Slogra only awakens at night!", 175, 75, 255);
}

if(Main.dayTime == false)
{
//Main.NewText("Slogra has emerged from the depths!...", 175, 75, 255);
//Main.NewText("Gaibon has emerged from the depths!...", 175, 75, 255);
NPC.SpawnOnPlayer(playerID, "Gaibon");
NPC.SpawnOnPlayer(playerID, "Slogra Boss");
Main.PlaySound(15, -1, -1, 0);
}

}


public bool CanUse(Player Pr, int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Slogra Boss"].type) && 
			!NPC.AnyNPCs(Config.npcDefs.byName["Gaibon"].type);
}



