public void AI()
{
												if (projectile.type == Config.projDefs.byName["Cube"].type)
												{
													int num44 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 63, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 3.5f);
													Main.dust[num44].noGravity = true;
													Main.dust[num44].velocity *= 1.4f;
													num44 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 63, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
												}
												else
												{
													if (projectile.type == 79)
													{
														if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
														{
															projectile.soundDelay = 10;
															Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);
														}
														for (int num45 = 0; num45 < 1; num45++)
														{
															int num46 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 63, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
															Main.dust[num46].velocity *= 0.1f;
															Main.dust[num46].velocity += projectile.velocity * 0.2f;
															Main.dust[num46].position.X = projectile.position.X + (float)(projectile.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
															Main.dust[num46].position.Y = projectile.position.Y + (float)(projectile.height / 2) + (float)Main.rand.Next(-2, 3);
															Main.dust[num46].noGravity = true;
														}
													}
													else
													{
														if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
														{
															projectile.soundDelay = 10;
															Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);
														}
														int num47 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 63, 0f, 0f, 100, default(Color), 2f);
														Main.dust[num47].velocity *= 0.3f;
														Main.dust[num47].position.X = projectile.position.X + (float)(projectile.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
														Main.dust[num47].position.Y = projectile.position.Y + (float)(projectile.height / 2) + (float)Main.rand.Next(-4, 5);
														Main.dust[num47].noGravity = true;
													}
												}
												if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f)
												{
													if (Main.player[projectile.owner].channel)
													{
														float num48 = 12f;
														if (projectile.type == 16)
														{
															num48 = 15f;
														}
														Vector2 vector6 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
														float num49 = (float)Main.mouseX + Main.screenPosition.X - vector6.X;
														float num50 = (float)Main.mouseY + Main.screenPosition.Y - vector6.Y;
														float num51 = (float)Math.Sqrt((double)(num49 * num49 + num50 * num50));
														num51 = (float)Math.Sqrt((double)(num49 * num49 + num50 * num50));
														if (num51 > num48)
														{
															num51 = num48 / num51;
															num49 *= num51;
															num50 *= num51;
															int num52 = (int)(num49 * 1000f);
															int num53 = (int)(projectile.velocity.X * 1000f);
															int num54 = (int)(num50 * 1000f);
															int num55 = (int)(projectile.velocity.Y * 1000f);
															if (num52 != num53 || num54 != num55)
															{
																projectile.netUpdate = true;
															}
															projectile.velocity.X = num49;
															projectile.velocity.Y = num50;
														}
														else
														{
															int num56 = (int)(num49 * 1000f);
															int num57 = (int)(projectile.velocity.X * 1000f);
															int num58 = (int)(num50 * 1000f);
															int num59 = (int)(projectile.velocity.Y * 1000f);
															if (num56 != num57 || num58 != num59)
															{
																projectile.netUpdate = true;
															}
															projectile.velocity.X = num49;
															projectile.velocity.Y = num50;
														}
													}
													else
													{
														if (projectile.ai[0] == 0f)
														{
															projectile.ai[0] = 1f;
															projectile.netUpdate = true;
															float num60 = 12f;
															Vector2 vector7 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
															float num61 = (float)Main.mouseX + Main.screenPosition.X - vector7.X;
															float num62 = (float)Main.mouseY + Main.screenPosition.Y - vector7.Y;
															float num63 = (float)Math.Sqrt((double)(num61 * num61 + num62 * num62));
															if (num63 == 0f)
															{
																vector7 = new Vector2(Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2), Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2));
																num61 = projectile.position.X + (float)projectile.width * 0.5f - vector7.X;
																num62 = projectile.position.Y + (float)projectile.height * 0.5f - vector7.Y;
																num63 = (float)Math.Sqrt((double)(num61 * num61 + num62 * num62));
															}
															num63 = num60 / num63;
															num61 *= num63;
															num62 *= num63;
															projectile.velocity.X = num61;
															projectile.velocity.Y = num62;
															if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
															{
																projectile.Kill();
															}
														}
													}
												}
												if (projectile.type == Config.projDefs.byName["Cube"].type)
												{
													projectile.rotation += 0.3f * (float)projectile.direction;
												}
												else
												{
													if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
													{
														projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 2.355f;
													}
												}
												if (projectile.velocity.Y > 16f)
												{
													projectile.velocity.Y = 16f;
													return;
												}
											}

public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff("Frost", 240);
	}
}