int count = 0;
public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
	int ShotAmt = 3;
	int spread = 24;
	float spreadMult = 0.05f;
	for (int i = 0; i < ShotAmt; i++)
	{
		float vX = ShootVelocity.X+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
		float vY = ShootVelocity.Y+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
		Projectile.NewProjectile(ShootPos.X,ShootPos.Y,vX,vY,projType,Damage,knockback,owner);
		Main.PlaySound(2, -1, -1, 11);
	}
	return false;
}
public bool UseAmmo(Player P, bool currentState, Item counter)
{
	if (count >= 4)
	{
		count = 0;
		return true;
	}
	else
	{
		count += 1;
		return false;
	}
	return true;
}