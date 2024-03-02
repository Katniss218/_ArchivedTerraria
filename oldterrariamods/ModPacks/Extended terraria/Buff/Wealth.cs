bool effect = false;
public void Effects(Player P)
{
	effect = true;
}
public void EffectsEnd(Player P)
{
	effect = false;
	
}
public void DamageNPC(Player P,NPC N, ref int DMG, ref float kb)
{
	if (effect)
	{
		N.AddBuff("Wealth", 52000);
		/*if (N.life <= 1)
		{
			if (Main.rand.Next(20) == 0)
			{
				N.value *= 2;
			}
		}*/
	}
}