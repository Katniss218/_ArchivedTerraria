public bool CanUse(Player P, int pID)
{
	if (ModPlayer.HasBuff(21)) return false;
	return true;
}