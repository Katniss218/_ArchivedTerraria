public bool runonce = false;
public void Effects(Player P)
{
	if (Collision.WetCollision(P.position, P.width, P.height))
	{
		P.meleeCrit += 5;
		P.magicCrit += 5;
		P.rangedCrit += 5;
	}
	if (!runonce)
	{
		P.breathCD += 5;
		runonce = true;
	}
}
public void SetBonus(Player P)
{
	P.setBonus = "Flipper Effect";
	P.accFlipper = true;
}