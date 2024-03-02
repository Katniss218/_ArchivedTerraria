public bool CanUse(Player player, int pID) {
	bool canuse = true;
	if (!Main.dayTime) canuse = true;
	else
	{
		canuse = false;
	}
	if (NPC.AnyNPCs(Config.npcDefs.byName["Dark Cloud"].type)) canuse = false;
	return canuse;
}

public static void UseItem(Player player, int playerID) {


NPC.NewNPC((int)player.position.X-700, (int)player.position.Y-500, Config.npcDefs.byName["Dark Cloud"].type, 1);
Main.NewText("Your shadow self has manifested from your darkest fears...");



}



//public bool CanUse(Player Pr,int PID)
//{
//    return !NPC.AnyNPCs(Config.npcDefs.byName["Omnirs The Wind Fiend Tiamat"].type);
//}



