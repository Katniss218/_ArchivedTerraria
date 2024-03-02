/*public bool CanUse(Player P,int PID)
{
      int count = 0;
      for(int i = 0; i < Main.projectile.Length; i++)
      {
          Projectile Pr = Main.projectile[i];
          if(Pr.active && Pr.owner == PID && Pr.type == Config.projDefs.byName["Berserker Nightmare"].type) count++;
      }
      if(count >= 2) return false;
      return true;
}*/


public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
    //int ShotAmt = 2;
    //int spread = 40;
    //float spreadMult = 0.05f;

    //for(int i = 0; i < ShotAmt; i++)
    //{
    float vX = ShootVelocity.X; // +(float)Main.rand.Next(-spread,spread+1) * spreadMult;
    float vY = ShootVelocity.Y; // +(float)Main.rand.Next(-spread,spread+1) * spreadMult;

    Projectile.NewProjectile(ShootPos.X,ShootPos.Y,vX,vY,projType,Damage,knockback,owner);
    //}
    Projectile.NewProjectile(ShootPos.X,ShootPos.Y,-vX,vY,projType,Damage,knockback,owner);

    return false;
}
