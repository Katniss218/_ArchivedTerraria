public bool runonce = false;
public void Effects(Player P)
{
	if (!runonce)
	{
		P.breathCD += 5;
		runonce = true;
	}
}