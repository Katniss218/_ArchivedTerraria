public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, "Chaos");
}

public bool CanUse(Player Pr,int PID) //was Player Pr
{
    return !NPC.AnyNPCs(Config.npcDefs.byName["Chaos"].type);
}