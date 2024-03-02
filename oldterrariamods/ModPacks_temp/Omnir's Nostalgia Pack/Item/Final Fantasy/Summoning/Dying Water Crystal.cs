public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, "Omnirs The Water Fiend Kraken");
}

public bool CanUse(Player Pr,int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Omnirs The Water Fiend Kraken"].type);
}