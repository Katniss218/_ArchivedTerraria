public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, "Omnir - Chaos");
}

public bool CanUse(Player Pr,int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Omnir - Chaos"].type);
}