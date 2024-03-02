

#region Kill
public void Kill()
{
    if (!projectile.active)
    {
	    return;
    }
    projectile.timeLeft = 0;
    {
        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        for (int num40 = 0; num40 < 20; num40++)
        {
            Projectile.NewProjectile(projectile.position.X + (float)(projectile.width), projectile.position.Y + (float)(projectile.height), 0, 0, Config.projectileID["Enemy Spell Poison Field"], 45, 1f, projectile.owner);
            Vector2 arg_1394_0 = new Vector2(projectile.position.X - projectile.velocity.X, projectile.position.Y - projectile.velocity.Y);
            int arg_1394_1 = projectile.width;
            int arg_1394_2 = projectile.height;
            int arg_1394_3 = 15;
            float arg_1394_4 = 0f;
            float arg_1394_5 = 0f;
	        int arg_1394_6 = 100;
		    Color newColor = default(Color);
		    int num41 = Dust.NewDust(arg_1394_0, arg_1394_1, arg_1394_2, arg_1394_3, arg_1394_4, arg_1394_5, arg_1394_6, newColor, 2f);
		    Main.dust[num41].noGravity = true;
		    Dust expr_13B1 = Main.dust[num41];
		    expr_13B1.velocity *= 2f;
		    Vector2 arg_1422_0 = new Vector2(projectile.position.X - projectile.velocity.X, projectile.position.Y - projectile.velocity.Y);
		    int arg_1422_1 = projectile.width;
		    int arg_1422_2 = projectile.height;
		    int arg_1422_3 = 15;
		    float arg_1422_4 = 0f;
		    float arg_1422_5 = 0f;
		    int arg_1422_6 = 100;
		    newColor = default(Color);
		    num41 = Dust.NewDust(arg_1422_0, arg_1422_1, arg_1422_2, arg_1422_3, arg_1422_4, arg_1422_5, arg_1422_6, newColor, 1f);
        }
    }
    if (projectile.owner == Main.myPlayer)
    {
        if (Main.netMode != 0)
        {
            NetMessage.SendData(29, -1, -1, "", projectile.identity, (float)projectile.owner, 0f, 0f, 0);
        }
        int num98 = -1;
        if (projectile.aiStyle == 10)
        {
            int num99 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
            int num100 = (int)(projectile.position.Y + (float)(projectile.width / 2)) / 16;
            int num101 = 0;
            int num102 = 2;
            if (!Main.tile[num99, num100].active)
            {
                WorldGen.PlaceTile(num99, num100, num101, false, true, -1, 0);
                if (Main.tile[num99, num100].active && (int)Main.tile[num99, num100].type == num101)
			    {
				    NetMessage.SendData(17, -1, -1, "", 1, (float)num99, (float)num100, (float)num101, 0);
			    }
			    else
			    {
			        if (num102 > 0)
				    {
				        num98 = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, num102, 1, false, 0);
				    }
			    }
		    }
		    else
		    {
		        if (num102 > 0)
			    {
				    num98 = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, num102, 1, false, 0);
			    }
		    }
	    }
	    if (Main.netMode == 1 && num98 >= 0)
	    {
		    NetMessage.SendData(21, -1, -1, "", num98, 0f, 0f, 0f, 0);
	    }
    }
    projectile.active = false;
}
#endregion


