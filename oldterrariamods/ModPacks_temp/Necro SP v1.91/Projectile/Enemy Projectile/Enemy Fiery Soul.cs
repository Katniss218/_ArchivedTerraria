#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 5)
	{
        projectile.frame = 0;
		return;
	}
    if (projectile.ai[0] == 0f)
    {
	    projectile.alpha -= 50;
	    if (projectile.alpha <= 0)
	    {
		    projectile.alpha = 0;
		    projectile.ai[0] = 1f;
		    if (projectile.ai[1] == 0f)
		    {
			    projectile.ai[1] += 1f;
			    projectile.position += projectile.velocity * 1f;
		    }
	    }
    }
    Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y,
    projectile.width, projectile.height);
    Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player
    [Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);
    if (projrec.Intersects(prec))
    {
        Main.player[Main.myPlayer].AddBuff(24, 900, false);
    }
	if (projectile.timeLeft > 60)
	{
		projectile.timeLeft = 60;
	}
	if (projectile.ai[0] > 7f)
	{
		float num152 = 1f;
		if (projectile.ai[0] == 8f)
		{
			num152 = 0.25f;
		}
		else
		{
			if (projectile.ai[0] == 9f)
			{
				num152 = 0.5f;
			}
			else
			{
				if (projectile.ai[0] == 10f)
				{
					num152 = 0.75f;
				}
			}
		}
		projectile.ai[0] += 1f;
		int num153 = 6;
		if (num153 == 6 || Main.rand.Next(2) == 0)
		{
			for (int num154 = 0; num154 < 1; num154++)
			{
				Vector2 arg_670C_0 = new Vector2(projectile.position.X, projectile.position.Y);
				int arg_670C_1 = projectile.width;
				int arg_670C_2 = projectile.height;
				int arg_670C_3 = num153;
				float arg_670C_4 = projectile.velocity.X * 0.2f;
				float arg_670C_5 = projectile.velocity.Y * 0.2f;
				int arg_670C_6 = 100;
				Color newColor = default(Color);
				int num155 = Dust.NewDust(arg_670C_0, arg_670C_1, arg_670C_2, arg_670C_3, arg_670C_4, arg_670C_5, arg_670C_6, newColor, 1f);
				if (Main.rand.Next(3) != 0 || (num153 == 75 && Main.rand.Next(3) == 0))
				{
					Main.dust[num155].noGravity = true;
					Main.dust[num155].scale *= 3f;
					Dust expr_6767_cp_0 = Main.dust[num155];
					expr_6767_cp_0.velocity.X = expr_6767_cp_0.velocity.X * 2f;
					Dust expr_6785_cp_0 = Main.dust[num155];
					expr_6785_cp_0.velocity.Y = expr_6785_cp_0.velocity.Y * 2f;
				}
				Main.dust[num155].scale *= 1.5f;
				Dust expr_67BC_cp_0 = Main.dust[num155];
				expr_67BC_cp_0.velocity.X = expr_67BC_cp_0.velocity.X * 1.2f;
				Dust expr_67DA_cp_0 = Main.dust[num155];
				expr_67DA_cp_0.velocity.Y = expr_67DA_cp_0.velocity.Y * 1.2f;
				Main.dust[num155].scale *= num152;
				if (num153 == 75)
				{
					Dust expr_680F = Main.dust[num155];
					expr_680F.velocity += projectile.velocity;
					if (!Main.dust[num155].noGravity)
					{
						Dust expr_683C = Main.dust[num155];
						expr_683C.velocity *= 0.5f;
					}
				}
			}
		}
	}
	else
	{
		projectile.ai[0] += 1f;
	}
	projectile.rotation += 0.3f * (float)projectile.direction;
	return;
}
#endregion