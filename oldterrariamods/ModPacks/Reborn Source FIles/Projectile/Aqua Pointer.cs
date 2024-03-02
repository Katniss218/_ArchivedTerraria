public void AI()
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 29, 0, 0, 100, color, 2.0f);
	Main.dust[dust].noGravity = true;
}

public void Initialize()
{
    projectile.timeLeft = 2;
}

public void Kill()
{
    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

	Vector2 vector8 = new Vector2(projectile.position.X + (projectile.width * 0.5f), projectile.position.Y + (projectile.height / 2));
		float num48 = 20f;
		int damage = 14;
		int type = Config.projectileID["Aqua Trail"];
        Main.PlaySound(2, (int) vector8.X, (int) vector8.Y, 17);
		float rotation =projectile.rotation;
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, projectile.owner);
		
		num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation+0.4) * num48)*-1),(float)((Math.Sin(rotation+0.4) * num48)*-1), type, damage, 0f, projectile.owner);

		num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation-0.4) * num48)*-1),(float)((Math.Sin(rotation-0.4) * num48)*-1), type, damage, 0f, projectile.owner);
        
        num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation+0.8) * num48)*-1),(float)((Math.Sin(rotation-0.4) * num48)*-1), type, damage, 0f, projectile.owner);
        
        num54 = Projectile.NewProjectile(vector8.X, vector8.Y-80,(float)((Math.Cos(rotation-0.8) * num48)*-1),(float)((Math.Sin(rotation-0.4) * num48)*-1), type, damage, 0f, projectile.owner);

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