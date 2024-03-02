public void UseStyle(Player player)
{
	float backX = 23f; // move the weapon back
	float downY = 0f; // and down
	float cosRot = (float)Math.Cos(player.itemRotation);
	float sinRot = (float)Math.Sin(player.itemRotation);
	//Align
	player.itemLocation.X = player.itemLocation.X - (backX * cosRot * player.direction) - (downY * sinRot * player.gravDir);
	player.itemLocation.Y = player.itemLocation.Y - (backX * sinRot * player.direction) + (downY * cosRot * player.gravDir);
}

public bool PreShoot(Player P,Vector2 Pos,Vector2 Velo,int type,int DMG,float KB,int owner)
{
	//knockback is used to represent length of laser in tiles (roughly 50 across a normal screen)
    Projectile.NewProjectile(Pos.X,Pos.Y,Velo.X,Velo.Y,type,DMG,35,owner);
	//sound fix for multiplayer
	Projectile.NewProjectile(Pos.X,Pos.Y,2,14,Config.projDefs.byName["NetSound"].type,0,0,owner);
    return false;
}