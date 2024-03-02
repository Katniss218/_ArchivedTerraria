int count = 0;
public bool PreShoot(Player P,Vector2 pos, Vector2 vel, int type, int dmg, float kb, int PID)
{
 int amt = 2, spr = 24;
 float mult = 0.05f;
 for (int i = 0; i < amt; i++)
 {
  Projectile.NewProjectile(pos.X, pos.Y, vel.X + Main.rand.Next(-spr, spr + 1) * mult, vel.Y + Main.rand.Next(-spr, spr + 1) * mult, type, dmg, kb, PID);
  Main.PlaySound(2, -1, -1, 11);
 }
 return false;
}
/*public bool UseAmmo(Player P)
{
	foreach (Item I in P.inventory)
	{
		if (I == null || I.type == item.type) continue;
		if (I.shoot == item.useAmmo)
		{
			if (--I.stack <= 0)
			I.SetDefaults(0);
			break;
		}
	}
	return true;
}*/