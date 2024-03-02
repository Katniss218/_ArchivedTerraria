public void AI()
{
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
		int num153 = 58;
		if (projectile.type == Config.projDefs.byName["Dark Thrower"].type)
		{
			num153 = 58;
		}
		if (num153 == 6 || Main.rand.Next(2) == 0)
		{
			for (int num154 = 0; num154 < 1; num154++)
			{
				int num155 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num153, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
				int D2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
				if (Main.rand.Next(3) != 0 || (num153 == 58 && Main.rand.Next(3) == 0))
				{
					Main.dust[num155].noGravity = true;
					Main.dust[num155].scale *= 3f;
					Dust expr_6767_cp_0 = Main.dust[num155];
					expr_6767_cp_0.velocity.X = expr_6767_cp_0.velocity.X * 2f;
					Dust expr_6785_cp_0 = Main.dust[num155];
					expr_6785_cp_0.velocity.Y = expr_6785_cp_0.velocity.Y * 2f;

					Main.dust[D2].noGravity = true;
					Main.dust[D2].scale *= 3f;
					Dust expr_6767_cp_D2 = Main.dust[D2];
					expr_6767_cp_D2.velocity.X = expr_6767_cp_D2.velocity.X * 2f;
					Dust expr_6785_cp_D2 = Main.dust[D2];
					expr_6785_cp_D2.velocity.Y = expr_6785_cp_D2.velocity.Y * 2f;
				}
				Main.dust[num155].scale *= 1.5f;
				Dust expr_67BC_cp_0 = Main.dust[num155];
				expr_67BC_cp_0.velocity.X = expr_67BC_cp_0.velocity.X * 1.2f;
				Dust expr_67DA_cp_0 = Main.dust[num155];
				expr_67DA_cp_0.velocity.Y = expr_67DA_cp_0.velocity.Y * 1.2f;
				Main.dust[num155].scale *= num152;


				Main.dust[D2].scale *= 1.5f;
				Dust expr_67BC_cp_D2 = Main.dust[D2];
				expr_67BC_cp_D2.velocity.X = expr_67BC_cp_D2.velocity.X * 1.2f;
				Dust expr_67DA_cp_D2 = Main.dust[D2];
				expr_67DA_cp_D2.velocity.Y = expr_67DA_cp_D2.velocity.Y * 1.2f;
				Main.dust[D2].scale *= num152;
				if (num153 == 75)
				{
					Main.dust[num155].velocity += projectile.velocity;
					if (!Main.dust[num155].noGravity)
					{
						Main.dust[num155].velocity *= 0.5f;
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

public void StatusPlayer(int i)
{
	if (Main.rand.Next(5) == 0)
	{
		Main.player[i].AddBuff("Dark Inferno", 300, false);
	}
}