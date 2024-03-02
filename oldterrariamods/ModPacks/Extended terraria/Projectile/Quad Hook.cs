public void AI()
{
										Main.chainTexture = Main.goreTexture[Config.goreID["Quad Whip Chain"]];
										if (Main.player[projectile.owner].dead)
										{
											projectile.Kill();
											return;
										}
										Vector2 vector3 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
										float num20 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector3.X;
										float num21 = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - vector3.Y;
										float num22 = (float)Math.Sqrt((double)(num20 * num20 + num21 * num21));
										projectile.rotation = (float)Math.Atan2((double)num21, (double)num20) - 1.57f;
										if (projectile.ai[0] == 0f)
										{
											if ((num22 > 300f && projectile.type == 13) || (num22 > 400f && projectile.type == 32) || (num22 > 440f && projectile.type == 73) || (num22 > 440f && projectile.type == 74) || (num22 > 400f && projectile.type == Config.projDefs.byName["Quad Hook"].type))
											{
												projectile.ai[0] = 1f;
											}
											int num23 = (int)(projectile.position.X / 16f) - 1;
											int num24 = (int)((projectile.position.X + (float)projectile.width) / 16f) + 2;
											int num25 = (int)(projectile.position.Y / 16f) - 1;
											int num26 = (int)((projectile.position.Y + (float)projectile.height) / 16f) + 2;
											if (num23 < 0)
											{
												num23 = 0;
											}
											if (num24 > Main.maxTilesX)
											{
												num24 = Main.maxTilesX;
											}
											if (num25 < 0)
											{
												num25 = 0;
											}
											if (num26 > Main.maxTilesY)
											{
												num26 = Main.maxTilesY;
											}
											for (int n = num23; n < num24; n++)
											{
												int num27 = num25;
												while (num27 < num26)
												{
													if (Main.tile[n, num27] == null)
													{
														Main.tile[n, num27] = new Tile();
													}
													Vector2 vector4;
													vector4.X = (float)(n * 16);
													vector4.Y = (float)(num27 * 16);
													if (projectile.position.X + (float)projectile.width > vector4.X && projectile.position.X < vector4.X + 16f && projectile.position.Y + (float)projectile.height > vector4.Y && projectile.position.Y < vector4.Y + 16f && Main.tile[n, num27].active && Main.tileSolid[(int)Main.tile[n, num27].type])
													{
														if (Main.player[projectile.owner].grapCount < 10)
														{
															Main.player[projectile.owner].grappling[Main.player[projectile.owner].grapCount] = projectile.whoAmI;
															Main.player[projectile.owner].grapCount++;
														}
														if (Main.myPlayer == projectile.owner)
														{
															int num28 = 0;
															int num29 = -1;
															int num30 = 100000;
															if (projectile.type == 73 || projectile.type == 74) // || projectile.type == Config.projDefs.byName["Quad Hook"].type)
															{
																for (int num31 = 0; num31 < 1000; num31++)
																{
																	if (num31 != projectile.whoAmI && Main.projectile[num31].active && Main.projectile[num31].owner == projectile.owner && Main.projectile[num31].aiStyle == 7 && Main.projectile[num31].ai[0] == 4f)
																	{
																		Main.projectile[num31].Kill();
																	}
																}
															}
															else
															{
																for (int num32 = 0; num32 < 1000; num32++)
																{
																	if (Main.projectile[num32].active && Main.projectile[num32].owner == projectile.owner && Main.projectile[num32].aiStyle == 7)
																	{
																		if (Main.projectile[num32].timeLeft < num30)
																		{
																			num29 = num32;
																			num30 = Main.projectile[num32].timeLeft;
																		}
																		num28++;
																	}
																}
																if (num28 > 4)
																{
																	Main.projectile[num29].Kill();
																}
															}
														}
														WorldGen.KillTile(n, num27, true, true, false);
														Main.PlaySound(0, n * 16, num27 * 16, 1);
														projectile.velocity.X = 0f;
														projectile.velocity.Y = 0f;
														projectile.ai[0] = 2f;
														projectile.position.X = (float)(n * 16 + 8 - projectile.width / 2);
														projectile.position.Y = (float)(num27 * 16 + 8 - projectile.height / 2);
														projectile.damage = 0;
														projectile.netUpdate = true;
														if (Main.myPlayer == projectile.owner)
														{
															NetMessage.SendData(13, -1, -1, "", projectile.owner, 0f, 0f, 0f, 0);
															break;
														}
														break;
													}
													else
													{
														num27++;
													}
												}
												if (projectile.ai[0] == 2f)
												{
													return;
												}
											}
											return;
										}
										if (projectile.ai[0] == 1f)
										{
											float num33 = 11f;
											if (projectile.type == 32)
											{
												num33 = 15f;
											}
											if (projectile.type == 73 || projectile.type == 74)
											{
												num33 = 17f;
											}
											if (projectile.type == Config.projDefs.byName["Quad Hook"].type)
											{
												num33 = 21f;
											}
											if (num22 < 24f)
											{
												projectile.Kill();
											}
											num22 = num33 / num22;
											num20 *= num22;
											num21 *= num22;
											projectile.velocity.X = num20;
											projectile.velocity.Y = num21;
											return;
										}
										if (projectile.ai[0] == 2f)
										{
											int num34 = (int)(projectile.position.X / 16f) - 1;
											int num35 = (int)((projectile.position.X + (float)projectile.width) / 16f) + 2;
											int num36 = (int)(projectile.position.Y / 16f) - 1;
											int num37 = (int)((projectile.position.Y + (float)projectile.height) / 16f) + 2;
											if (num34 < 0)
											{
												num34 = 0;
											}
											if (num35 > Main.maxTilesX)
											{
												num35 = Main.maxTilesX;
											}
											if (num36 < 0)
											{
												num36 = 0;
											}
											if (num37 > Main.maxTilesY)
											{
												num37 = Main.maxTilesY;
											}
											bool flag = true;
											for (int num38 = num34; num38 < num35; num38++)
											{
												for (int num39 = num36; num39 < num37; num39++)
												{
													if (Main.tile[num38, num39] == null)
													{
														Main.tile[num38, num39] = new Tile();
													}
													Vector2 vector5;
													vector5.X = (float)(num38 * 16);
													vector5.Y = (float)(num39 * 16);
													if (projectile.position.X + (float)(projectile.width / 2) > vector5.X && projectile.position.X + (float)(projectile.width / 2) < vector5.X + 16f && projectile.position.Y + (float)(projectile.height / 2) > vector5.Y && projectile.position.Y + (float)(projectile.height / 2) < vector5.Y + 16f && Main.tile[num38, num39].active && Main.tileSolid[(int)Main.tile[num38, num39].type])
													{
														flag = false;
													}
												}
											}
											if (flag)
											{
												projectile.ai[0] = 1f;
												return;
											}
											if (Main.player[projectile.owner].grapCount < 10)
											{
												Main.player[projectile.owner].grappling[Main.player[projectile.owner].grapCount] = projectile.whoAmI;
												Main.player[projectile.owner].grapCount++;
												return;
											}
										}
}

public void Initialize()
{
	Main.chainTexture = Main.goreTexture[Config.goreID["Quad Whip Chain"]];
}

public void PostKill()
{
	Main.chainTexture = Main.goreTexture[Config.goreID["Grapple Chain"]];
}