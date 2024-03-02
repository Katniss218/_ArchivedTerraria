public void Effects(Player P) 
{
    P.fireWalk = true;
	P.jumpBoost = true;
	if (P.controlLeft)
	{
		if (P.velocity.X > -7) P.velocity.X -= 0.31f;
		if (P.velocity.X < -7 && P.velocity.X > -14)
		{
			P.velocity.X -= 0.29f;
		}
	}
	if (P.controlRight)
	{
		if (P.velocity.X < 7) P.velocity.X += 0.31f;
		if (P.velocity.X > 7 && P.velocity.X < 14)
		{
			P.velocity.X += 0.31f;
		}
	}
}
