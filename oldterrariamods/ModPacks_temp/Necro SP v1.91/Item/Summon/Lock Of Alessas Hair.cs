public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, "Pyramid Head");
}

public bool CanUse(Player Pr,int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Pyramid Head"].type);
}