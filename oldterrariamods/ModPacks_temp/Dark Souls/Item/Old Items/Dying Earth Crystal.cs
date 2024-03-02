public void UseItem(Player player, int playerID)
{
    Main.NewText("The Lich King has awoken!", 175, 75, 255);
    NPC.SpawnOnPlayer(playerID, "Earth Fiend Lich");
}

public bool CanUse(Player Pr, int PID)
{
     return !NPC.AnyNPCs(Config.npcDefs.byName["Earth Fiend Lich"].type);
}