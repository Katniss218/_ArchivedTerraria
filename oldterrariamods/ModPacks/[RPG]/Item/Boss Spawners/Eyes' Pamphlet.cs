public void UseItem(Player player, int playerID) {
        Main.PlaySound(15, -1, -1, 0);
	NPC.SpawnOnPlayer(playerID, 4);
        NPC.SpawnOnPlayer(playerID, 4);
        NPC.SpawnOnPlayer(playerID, 4);
        NPC.SpawnOnPlayer(playerID, 4);
        NPC.SpawnOnPlayer(playerID, 4);
}
public bool CanUse(Player player, int playerID)
{
	if (!Main.dayTime)
	{
		return true;
	}
	return false;
}