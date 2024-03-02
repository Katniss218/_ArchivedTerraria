#region AI
public void AI()
{
    projectile.ai[0] += 1f;
    if (projectile.ai[0] >= 15f)
    {
        projectile.ai[0] = 15f;
        projectile.velocity.Y = projectile.velocity.Y + 0.1f;
    }
    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
    if (projectile.velocity.Y > 16f)
    {
        projectile.velocity.Y = 16f;
        return;
    }
	int i2 = (int)(projectile.position.X + 2f) / 16;
	int j2 = (int)(projectile.position.Y + 2f) / 16;
    Lighting.addLight(i2, j2, 1f, 0f, 0f);
    for (int i = 0; i < 2; i++)
	{
	    Vector2 arg_92_0 = new Vector2(projectile.position.X, projectile.position.Y);
		int arg_92_1 = projectile.width;
		int arg_92_2 = projectile.height;
		int arg_92_3 = 55;
		float arg_92_4 = 0f;
		float arg_92_5 = 0f;
		int arg_92_6 = 0;
	    Color newColor = default(Color);
	    Dust.NewDust(arg_92_0, arg_92_1, arg_92_2, arg_92_3, arg_92_4, arg_92_5, arg_92_6, newColor, 1f);
	}
}
#endregion

#region Kill
public void Kill()
{
    int num98 = -1;
    if (!projectile.active)
    {
        return;
    }
    projectile.timeLeft = 0;
    {
        Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
        for (int i = 0; i < 10; i++)
	    {
	        Vector2 arg_92_0 = new Vector2(projectile.position.X, projectile.position.Y);
		    int arg_92_1 = projectile.width;
		    int arg_92_2 = projectile.height;
		    int arg_92_3 = 7;
		    float arg_92_4 = 0f;
		    float arg_92_5 = 0f;
		    int arg_92_6 = 0;
	        Color newColor = default(Color);
	        Dust.NewDust(arg_92_0, arg_92_1, arg_92_2, arg_92_3, arg_92_4, arg_92_5, arg_92_6, newColor, 1f);
	    }
	    if(Main.rand.Next(4)!=0)
        {
            if(projectile.owner == Main.myPlayer) Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Power Bolt", 1, false, 0);
        }
    }
    projectile.active = false;
}
#endregion