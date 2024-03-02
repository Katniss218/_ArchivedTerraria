//int cooldown = 0;
public void UseStyle(Player P) 
{
	float HalfPi = (float)(Math.PI / 2f);
	P.itemRotation -= 0.05f * P.direction;
	P.itemLocation.X -= P.direction * (P.width / 2) * (1f - (float)Math.Abs(P.itemRotation) / HalfPi);
	/*cooldown++;
	if (cooldown >= 40)
	{
		P.statMana -= 10;
		cooldown = 0;
		if (P.statMana <= 0)
		{
			P.statMana = 0;
			P.controlUseItem = false;
		}
	}*/
}