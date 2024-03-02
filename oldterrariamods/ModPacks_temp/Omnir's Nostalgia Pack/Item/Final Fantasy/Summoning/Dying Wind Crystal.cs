public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, "Omnirs The Wind Fiend Tiamat");
}

public bool CanUse(Player Pr,int PID)
{
    return !NPC.AnyNPCs(Config.npcDefs.byName["Omnirs The Wind Fiend Tiamat"].type);
}