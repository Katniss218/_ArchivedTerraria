public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, "Samael");
}

public bool CanUse(Player Pr,int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Samael"].type);
}