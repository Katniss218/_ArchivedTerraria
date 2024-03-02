public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
    int ShotAmt = 2;
    int spread = 35;
    float spreadMult = 0.05f;
    for(int i = 0; i < ShotAmt; i++)
    {
        float vX = ShootVelocity.X+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
        float vY = ShootVelocity.Y+(float)Main.rand.Next(-spread,spread+1) * spreadMult;

        Projectile.NewProjectile(ShootPos.X,ShootPos.Y,vX,vY,projType,Damage,knockback,owner);
    }

    return false;
}