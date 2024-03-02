public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
	if (ModPlayer.HasBuff("Pierce"))
	{
		int a = Projectile.NewProjectile(ShootPos.X, ShootPos.Y, ShootVelocity.X, ShootVelocity.Y, projType, Damage, knockback, owner);
		if (Main.projectile[a].penetrate > 0)
		{
			Main.projectile[a].penetrate++;
		}
		//Main.projectile[Projectile.NewProjectile(ShootPos.X, ShootPos.Y, ShootVelocity.X, ShootVelocity.Y, projType, Damage, knockback, owner)].penetrate++;
	}
	return !ModPlayer.HasBuff("Pierce");
}
