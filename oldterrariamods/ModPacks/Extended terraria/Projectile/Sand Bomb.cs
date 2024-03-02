


public void PreKill() {

int Damage = 20;

 int ShotAmt = 10;
 int spread = 360;
 float spreadMult = 0.05f;
 for (int i = 0; i < ShotAmt; i++)
    {
        float vX = projectile.velocity.X+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
        float vY = projectile.velocity.Y+(float)Main.rand.Next(-spread,spread+1) * spreadMult;

        Projectile.NewProjectile(projectile.position.X,projectile.position.Y,vX,vY,42,20,Damage,projectile.whoAmI);

    }



}