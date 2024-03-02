public void UseItem(Player P, int PID) {
	NPC.SpawnOnPlayer(PID, "Slogra");
	NPC.SpawnOnPlayer(PID, "Gaibon");
	Main.PlaySound(15, -1, -1, 0);
}

public bool CanUse(Player Pr, int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Slogra"].type) && 
			!NPC.AnyNPCs(Config.npcDefs.byName["Gaibon"].type);
}