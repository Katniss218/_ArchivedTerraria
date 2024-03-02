public void UseItem(Player player, int playerID) {
        Main.PlaySound(15, -1, -1, 0);
	NPC.SpawnOnPlayer(playerID, 4);
        NPC.SpawnOnPlayer(playerID, 4);
        NPC.SpawnOnPlayer(playerID, 4);

Item.NewItem(
        (int) player.position.X,
        (int) player.position.Y,
        (int) player.width,
        (int) player.height,
        86, //Type
        Main.rand.Next(7, 15), //Stack
        false,
        0 //Prefix
        );

}

public bool CanUse(Player player, int playerID)
{
	if (!Main.dayTime)
	{
		return true;
	}
	return false;
}