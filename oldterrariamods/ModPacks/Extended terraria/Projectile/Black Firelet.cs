/*public void AI()
{
											if (projectile.type == 96 && projectile.localAI[0] == 0f)
											{
												projectile.localAI[0] = 1f;
												Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
											}
											if (projectile.type == 27)
											{
												int num40 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 29, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f);
												Main.dust[num40].noGravity = true;
												if (Main.rand.Next(10) == 0)
												{
													num40 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 29, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.4f);
												}
											}
											else
											{
												if (projectile.type == 95 || projectile.type == 96)
												{
													int num41 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 75, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f * projectile.scale);
													Main.dust[num41].noGravity = true;
												}
												else
												{
													for (int num42 = 0; num42 < 2; num42++)
													{
														int num43 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
														Main.dust[num43].noGravity = true;
														Dust expr_225D_cp_0 = Main.dust[num43];
														expr_225D_cp_0.velocity.X = expr_225D_cp_0.velocity.X * 0.3f;
														Dust expr_227B_cp_0 = Main.dust[num43];
														expr_227B_cp_0.velocity.Y = expr_227B_cp_0.velocity.Y * 0.3f;
														int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 58, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
														Main.dust[dust].noGravity = true;
														Dust dusty = Main.dust[dust];
														dusty.velocity.X = dusty.velocity.X * 0.3f;
														Dust dusty2 = Main.dust[dust];
														dusty2.velocity.Y = dusty2.velocity.Y * 0.3f;
													}
												}
											}
											if (projectile.type != 27 && projectile.type != 96)
											{
												projectile.ai[1] += 1f;
											}
											if (projectile.ai[1] >= 20f)
											{
												projectile.velocity.Y = projectile.velocity.Y + 0.2f;
											}
											projectile.rotation += 0.3f * (float)projectile.direction;
											if (projectile.velocity.Y > 16f)
											{
												projectile.velocity.Y = 16f;
												return;
											}
}
public bool tileCollide(Vector2 CollideVel)
{
	Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
	projectile.ai[0] += 1f;
	if (projectile.ai[0] >= 3f)
	{
		projectile.position += projectile.velocity;
		projectile.Kill();
	}
	else
	{
		if (projectile.type == Config.projDefs.byName["Black Firelet"].type && projectile.velocity.Y > 4f)
		{
			if (projectile.velocity.Y != CollideVel.Y)
			{
				projectile.velocity.Y = -CollideVel.Y * 0.8f;
			}
		}
		else
		{
			if (projectile.velocity.Y != CollideVel.Y)
			{
				projectile.velocity.Y = -CollideVel.Y;
			}
		}
		if (projectile.velocity.X != CollideVel.X)
		{
			projectile.velocity.X = -CollideVel.X;
		}
	}
	return false;
}*/
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(5) == 0)
	{
		npc.AddBuff("Dark Inferno", 240);
	}
}

public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(5) == 0)
	{
		enemyPlayer.AddBuff("Dark Inferno", 240, false);
	}
}