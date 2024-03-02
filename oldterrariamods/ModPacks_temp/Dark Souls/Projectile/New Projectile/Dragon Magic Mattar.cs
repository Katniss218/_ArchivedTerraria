
Vector2 Sa,Sb;
public void Initialize()
{
    Sa = projectile.position;
    Sb = projectile.velocity;
    int r = 7;
    projectile.velocity = new Vector2(Main.rand.Next(r*2 +1)-r,Main.rand.Next(r*2 +1)-r);
}

public void AI()
{
    Projectile P = projectile;
    Player Pr = Main.player[P.owner];
    int Radius = 2;

    int Dustiness = 1;
    float Speediness = 0.3f;

    Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
    for(int zzz = 0; zzz < Dustiness; zzz++)
    {
        int DI = Dust.NewDust(P.position+new Vector2(-Radius,-Radius),P.width+2*Radius,P.height+2*Radius,66,0,0,100,new Color(180,180, Main.DiscoB),0.7f);
	    Dust D = Main.dust[DI];
        D.velocity *= 0.1f;
	    D.velocity += P.velocity * 0.2f;
	    D.noGravity = true;
    }

    float num48 = 4f;
    Vector2 vector6 = PC;
    float num49 = Sa.X-vector6.X;
    float num50 = Sa.Y-vector6.Y;
    float num51 = (float)Math.Sqrt((double)(num49 * num49 + num50 * num50));
    num51 = (float)Math.Sqrt((double)(num49 * num49 + num50 * num50));
    if (num51 > num48)
    {
        num51 = num48 / num51;
        num49 *= num51;
        num50 *= num51;
    }
    int num56 = (int)(num49 * 1000f);
    int num57 = (int)(P.velocity.X * 1000f);
    int num58 = (int)(num50 * 1000f);
    int num59 = (int)(P.velocity.Y * 1000f);
    if (num56 != num57 || num58 != num59)
    {
        P.netUpdate = true;
    }
    P.velocity.X += num49*Speediness;
    P.velocity.Y += num50*Speediness;
    Sa+=Sb;
}