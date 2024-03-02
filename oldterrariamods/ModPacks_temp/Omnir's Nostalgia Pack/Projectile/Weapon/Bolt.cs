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
	    if(Main.rand.Next(4)==0)
        {
            if(projectile.owner == Main.myPlayer) Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, "Bolt", 1, false, 0);
        }
    }
    projectile.active = false;
}
#endregion