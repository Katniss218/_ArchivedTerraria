public void AI()
{
											if (projectile.type == 96 && projectile.localAI[0] == 0f)
											{
												projectile.localAI[0] = 1f;
												Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
											}
											if (projectile.type == Config.projDefs.byName["Freeze Bolt"].type)
											{
												int num40 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f);
												Main.dust[num40].noGravity = true;
												if (Main.rand.Next(10) == 0)
												{
													num40 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.4f);
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
														int num43 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
														Main.dust[num43].noGravity = true;
														Dust expr_225D_cp_0 = Main.dust[num43];
														expr_225D_cp_0.velocity.X = expr_225D_cp_0.velocity.X * 0.3f;
														Dust expr_227B_cp_0 = Main.dust[num43];
														expr_227B_cp_0.velocity.Y = expr_227B_cp_0.velocity.Y * 0.3f;
													}
												}
											}
											if (projectile.type != Config.projDefs.byName["Freeze Bolt"].type && projectile.type != 96)
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
	if (projectile.ai[0] >= 6f)
	{
		projectile.position += projectile.velocity;
		projectile.Kill();
	}
	else
	{
		if (projectile.type == Config.projDefs.byName["Freeze Bolt"].type && projectile.velocity.Y > 4f)
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
}
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff("Freeze", 240);
	}
}

public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(4) == 0)
	{
		enemyPlayer.AddBuff("Frozen", 240, false);
	}
}