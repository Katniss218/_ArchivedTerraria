public void UseItem(Player player, int playerID)
{
    NPC.SpawnOnPlayer(playerID, "Omnirs Chaos");
}

public bool CanUse(Player Pr,int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Omnirs Chaos"].type);
}