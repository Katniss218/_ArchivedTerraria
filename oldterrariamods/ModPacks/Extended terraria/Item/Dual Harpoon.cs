//public bool CanUse(Player player, int pID) {
//	int use = 2;
//	bool canuse = true;
	//This code is used by boomerangs to limit the amount of boomerang projectiles that can be thrown.
//	for (int m = 0; m < 1000; m++)
//	{
//		if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == this.item.shoot)
//		{
//			use-=1;
//			break;
//		}
//	}
//	if(use<=0)
//	{
//		canuse=false;
//	}
//	return canuse;
//}

public bool CanUse(Player P,int PID)
{
      int count = 0;
      for(int i = 0; i < Main.projectile.Length; i++)
      {
          Projectile Pr = Main.projectile[i];
          if(Pr.active && Pr.owner == PID && Pr.type == Config.projDefs.byName["Dual Harpoon"].type) count++;
      }
      if(count >= 2) return false;
      return true;
}


public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
    int ShotAmt = 2;
    int spread = 60;
    float spreadMult = 0.05f;

    for(int i = 0; i < ShotAmt; i++)
    {
        float vX = ShootVelocity.X+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
        float vY = ShootVelocity.Y+(float)Main.rand.Next(-spread,spread+1) * spreadMult;

        Projectile.NewProjectile(ShootPos.X,ShootPos.Y,vX,vY,projType,Damage,knockback,owner);
    }

    return false;
}
