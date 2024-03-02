public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
	int ShotAmt = 1;
	int spread = 40;
	int a = 0;
	float spreadMult = 0.05f;
	for (int i = 0; i < ShotAmt; i++)
	{
		float vX = ShootVelocity.X+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
		float vY = ShootVelocity.Y+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
		a = Projectile.NewProjectile(ShootPos.X,ShootPos.Y,vX,vY,projType,Damage,knockback,owner);
		Main.projectile[a].friendly = true;
		Main.projectile[a].color = new Color(165, 107, 67, 255);
		Main.PlaySound(2, -1, -1, 11);
	}
	return false;
}