public void UseItem(Player P, int PID)
{
	if (P.statLife >= P.statLifeMax2) return;
	if (P.statLife < P.statLifeMax2)
	{
		if (P.statLife + 60 >= P.statLifeMax2) P.statLife = P.statLifeMax2;
		else P.statLife += 60;
	}
}