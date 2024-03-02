public void DamagePlayer(Player P, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		P.AddBuff(23, 120);
	}
}