public bool runonce = false;
public void Effects(Player P)
{
	if (Collision.WetCollision(P.position, P.width, P.height))
	{
		P.meleeDamage += 0.1f;
		P.magicDamage += 0.1f;
		P.rangedDamage += 0.1f;
	}
	if (!runonce)
	{
		P.breathCD += 5;
		runonce = true;
	}
}