#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 3)
    {
        projectile.frame = 0;
        return;
    }
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
    }
    projectile.active = false;
}
#endregion