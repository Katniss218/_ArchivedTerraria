
public void AI()
{
    Projectile P = projectile;
    Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
    if(P.wet)
        P.Kill();
    int DustIndex = Dust.NewDust(
    new Vector2(P.position.X + P.velocity.X, P.position.Y + P.velocity.Y), 
    P.width, 
    P.height, 
    6, 
    P.velocity.X, 
    P.velocity.Y, 
    100, 
    default(Color), 
    3f * P.scale
    );
    Main.dust[DustIndex].noGravity = true;
    float Red = 1f;
    float Green = 0.1f;
    float Blue = 0.1f;

    Lighting.addLight(
    (int)((PC.X) / 16f), 
    (int)((PC.Y) / 16f), 
    Red, 
    Green, 
    Blue
    );                

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
        6, 
        P.velocity.X, 
        P.velocity.Y, 
        100, 
        default(Color), 
        3f * P.scale
        );
        Main.dust[DustIndex].velocity *= 1.4f;
    }
    P.active = false; //remove for epic fire shower
}