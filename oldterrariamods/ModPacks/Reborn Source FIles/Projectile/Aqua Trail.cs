public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 29, 0, 0, 100, color, 2.0f);
	Main.dust[dust].noGravity = true;
}

public void Initialize()
{
    projectile.timeLeft = 20+Main.rand.Next(15);
}

public void Kill()
{
    
    if(projectile.ai[0] > 5)
    {
    }
    else
    {
        int index = -1;
        float range = 500f;
        foreach(Player P in Main.player)
        {
            float newrange = SMDfloat(P,projectile);
            if(newrange < range)
            {
                index = P.whoAmi;
                range = newrange;
            }
        }
        if(index > -1)
        {
            float num48 = 20f-projectile.ai[0]*2;
            Vector2 Velocz = SMDV2(Main.player[index],projectile);
            
            float num51 = SMDfloat(Main.player[index],projectile);
	        num51 = num48 / num51;
	        Velocz.X *= num51;
	        Velocz.Y *= num51; 
		    int damage = projectile.damage;
		    int type = projectile.type;
            int zzz = Projectile.NewProjectile(projectile.position.X, projectile.position.Y,Velocz.X,Velocz.Y, type, damage, 0f, Main.myPlayer);
            Main.projectile[zzz].ai[0] = projectile.ai[0]+1;
            NetMessage.SendData(27, -1, -1, "", zzz, 0f, 0f, 0f, 0);
        }
    }
    projectile.active = false;
}





public float SMDfloat(object var1,object var2)
{
#region returns float of distance
    float dist = 0;
    Vector2[] A1 = new Vector2[2];
    object varz = var1;
    for (int i = 0; i < 2; i++)
    {
    if (i == 0)
        varz = var1;
    if (i == 1)
        varz = var2;
    if (varz is Player)
    {
        Player pl = (Player)varz;
        A1[i] = new Vector2(pl.position.X+(pl.width/2),pl.position.Y+(pl.height/2));
    }
    if (varz is Projectile)
    {
        Projectile pl = (Projectile)varz;
        A1[i] = new Vector2(pl.position.X+(pl.width/2),pl.position.Y+(pl.height/2));
    }
    if (varz is NPC)
    {
        NPC pl = (NPC)varz;
        A1[i] = new Vector2(pl.position.X+(pl.width/2),pl.position.Y+(pl.height/2));
    }	 
    }
    
    return Vector2.Distance(A1[0],A1[1]);
#endregion
}



public Vector2 SMDV2(object var1,object var2)
{
#region returns vector2 of the distance
    float dist = 0;
    Vector2[] A1 = new Vector2[2];
    object varz = var1;
    for (int i = 0; i < 2; i++)
    {
    if (i == 0)
        varz = var1;
    if (i == 1)
        varz = var2;
    if (varz is Player)
    {
        Player pl = (Player)varz;
        A1[i] = new Vector2(pl.position.X+(pl.width/2),pl.position.Y+(pl.height/2));
    }
    if (varz is Projectile)
    {
        Projectile pl = (Projectile)varz;
        A1[i] = new Vector2(pl.position.X+(pl.width/2),pl.position.Y+(pl.height/2));
    }
    if (varz is NPC)
    {
        NPC pl = (NPC)varz;
        A1[i] = new Vector2(pl.position.X+(pl.width/2),pl.position.Y+(pl.height/2));
    }	 
    }
    
    return A1[0]-A1[1];
#endregion
}