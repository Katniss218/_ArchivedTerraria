
public void AI()
{
    Projectile P = projectile;
    Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
    if(P.wet)P.Kill();
    int DustIndex = Dust.NewDust(
    new Vector2(P.position.X + P.velocity.X, P.position.Y + P.velocity.Y), 
    P.width, 
    P.height, 
    57, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 0.2f, 100, default(Color), 1f);
    Main.dust[DustIndex].noGravity = true;
    P.rotation = (float)Math.Atan2((double)P.velocity.Y, (double)P.velocity.X) + (float)(Math.PI/2);
}

public void Kill()
{
    Projectile P = projectile;
    for (int num70 = 0; num70 < 15; num70++)
    {
        int DustIndex = Dust.NewDust(
        new Vector2(P.position.X + P.velocity.X, P.position.Y + P.velocity.Y), 
        P.width, 
        P.height, 
        57, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 0.2f, 100, default(Color), 1f);
        Main.dust[DustIndex].velocity *= 1.4f;
    }
    P.active = false; //remove for epic fire shower
}