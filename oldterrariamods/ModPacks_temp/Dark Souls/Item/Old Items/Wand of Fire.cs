public bool CanUse(Player player, int playerID)
{
	if (player.wet) return false;
	else return true;
}