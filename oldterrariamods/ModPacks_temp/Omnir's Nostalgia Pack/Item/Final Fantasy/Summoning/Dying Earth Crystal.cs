public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, "Omnirs The Earth Fiend Lich");
}

public bool CanUse(Player Pr, int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Omnirs The Earth Fiend Lich"].type);
}