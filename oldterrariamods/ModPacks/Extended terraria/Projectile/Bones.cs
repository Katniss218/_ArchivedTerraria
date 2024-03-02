public void AI()
{
					if (projectile.type == 93 && Main.rand.Next(5) == 0)
					{
						int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 0.3f);
						Dust expr_63E_cp_0 = Main.dust[num5];
						expr_63E_cp_0.velocity.X = expr_63E_cp_0.velocity.X * 0.3f;
						Dust expr_65C_cp_0 = Main.dust[num5];
						expr_65C_cp_0.velocity.Y = expr_65C_cp_0.velocity.Y * 0.3f;
					}
					projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * (float)projectile.direction;
					if (projectile.type == 69 || projectile.type == 70)
					{
						projectile.ai[0] += 1f;
						if (projectile.ai[0] >= 10f)
						{
							projectile.velocity.Y = projectile.velocity.Y + 0.25f;
							projectile.velocity.X = projectile.velocity.X * 0.99f;
						}
					}
					else
					{
						projectile.ai[0] += 1f;
						if (projectile.ai[0] >= 20f)
						{
							projectile.velocity.Y = projectile.velocity.Y + 0.4f;
							projectile.velocity.X = projectile.velocity.X * 0.97f;
						}
						else
						{
							if (projectile.type == 48 || projectile.type == 54 || projectile.type == 93)
							{
								projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
							}
						}
					}
					if (projectile.velocity.Y > 16f)
					{
						projectile.velocity.Y = 16f;
					}
					if (projectile.type == 54 && Main.rand.Next(20) == 0)
					{
						Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 40, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.75f);
						return;
					}
}
public void Kill()
{
	Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
	for (int num54 = 0; num54 < 10; num54++)
	{
		Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 26, 0f, 0f, 0, default(Color), 0.8f);
	}
	projectile.active = false;
}
