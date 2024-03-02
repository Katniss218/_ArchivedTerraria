public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 17)
    {
        projectile.Kill();
        return;
    }
	projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
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
			if (Main.myPlayer == projectile.owner)
			{
				int num14 = projectile.type;
				if (projectile.ai[1] >= 8f)
				{
					num14++;
				}
				int num15 = Projectile.NewProjectile(projectile.position.X + projectile.velocity.X + (float)(projectile.width / 2), projectile.position.Y + projectile.velocity.Y + (float)(projectile.height / 2), projectile.velocity.X, projectile.velocity.Y, num14, projectile.damage, projectile.knockBack, projectile.owner);
				Main.projectile[num15].damage = projectile.damage;
				Main.projectile[num15].ai[1] = projectile.ai[1] + 1f;
				NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
				return;
			}
		}
	}
	else
	{
		if (projectile.alpha < 170 && projectile.alpha + 5 >= 170)
		{
			Color newColor;
			for (int j = 0; j < 3; j++)
			{
				Vector2 arg_10C2_0 = projectile.position;
				int arg_10C2_1 = projectile.width;
				int arg_10C2_2 = projectile.height;
				int arg_10C2_3 = 18;
				float arg_10C2_4 = projectile.velocity.X * 0.025f;
				float arg_10C2_5 = projectile.velocity.Y * 0.025f;
				int arg_10C2_6 = 170;
				newColor = default(Color);
				Dust.NewDust(arg_10C2_0, arg_10C2_1, arg_10C2_2, arg_10C2_3, arg_10C2_4, arg_10C2_5, arg_10C2_6, newColor, 1.2f);
			}
			Vector2 arg_1105_0 = projectile.position;
			int arg_1105_1 = projectile.width;
			int arg_1105_2 = projectile.height;
			int arg_1105_3 = 14;
			float arg_1105_4 = 0f;
			float arg_1105_5 = 0f;
			int arg_1105_6 = 170;
			newColor = default(Color);
			Dust.NewDust(arg_1105_0, arg_1105_1, arg_1105_2, arg_1105_3, arg_1105_4, arg_1105_5, arg_1105_6, newColor, 1.1f);
		}
		projectile.alpha += 5;
		if (projectile.alpha >= 255)
		{
			projectile.Kill();
			return;
		}
	}
}
