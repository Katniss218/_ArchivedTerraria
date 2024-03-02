public bool SpawnNPC(int x, int y, int playerID)
{
	if (Main.hardMode && ModWorld.superHardmode)
	{
		if (Main.player[playerID].zoneEvil && y > Main.rockLayer && y < Main.maxTilesY - 200 && !Main.player[playerID].zoneDungeon && Main.rand.Next(15) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}

public void AI()
{
						int num5 = 60;
						if (npc.type == Config.npcDefs.byName["Corrupted Elemental"].type)
						{
							num5 = 20;
							if (npc.ai[3] == -120f)
							{
								npc.velocity *= 0f;
								npc.ai[3] = 0f;
								Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
								Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
								float num6 = npc.oldPos[2].X + (float)npc.width * 0.5f - vector.X;
								float num7 = npc.oldPos[2].Y + (float)npc.height * 0.5f - vector.Y;
								float num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
								num8 = 2f / num8;
								num6 *= num8;
								num7 *= num8;
								for (int j = 0; j < 20; j++)
								{
									int num9 = Dust.NewDust(npc.position, npc.width, npc.height, 54, num6, num7, 200, default(Color), 2f);
									Main.dust[num9].noGravity = true;
									Dust expr_19EE_cp_0 = Main.dust[num9];
									expr_19EE_cp_0.velocity.X = expr_19EE_cp_0.velocity.X * 2f;
									int asdf = Dust.NewDust(npc.position, npc.width, npc.height, 58, num6, num7, 200, default(Color), 2f);
									Main.dust[asdf].noGravity = true;
									Dust dust_asdf = Main.dust[asdf];
									dust_asdf.velocity.X = dust_asdf.velocity.X * 2f;
								}
								for (int o = 0; o < 20; o++)
								{
									int num10 = Dust.NewDust(npc.oldPos[2], npc.width, npc.height, 54, -num6, -num7, 200, default(Color), 2f);
									Main.dust[num10].noGravity = true;
									Dust expr_1A6F_cp_0 = Main.dust[num10];
									expr_1A6F_cp_0.velocity.X = expr_1A6F_cp_0.velocity.X * 2f;
									int asdf2 = Dust.NewDust(npc.oldPos[2], npc.width, npc.height, 58, -num6, -num7, 200, default(Color), 2f);
									Main.dust[asdf2].noGravity = true;
									Dust dust_asdf2 = Main.dust[asdf2];
									dust_asdf2.velocity.X = dust_asdf2.velocity.X * 2f;
								}
							}
						}
						bool flag2 = false;
						bool flag3 = true;
						if (npc.type == 47 || npc.type == 67 || npc.type == 109 || npc.type == 110 || npc.type == 111 || npc.type == Config.npcDefs.byName["Corrupted Elemental"].type)
						{
							flag3 = false;
						}
						if ((npc.type != 110 && npc.type != 111) || npc.ai[2] <= 0f)
						{
							if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
							{
								flag2 = true;
							}
							if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)num5 || flag2)
							{
								npc.ai[3] += 1f;
							}
							else
							{
								if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
								{
									npc.ai[3] -= 1f;
								}
							}
							if (npc.ai[3] > (float)(num5 * 10))
							{
								npc.ai[3] = 0f;
							}
							if (npc.justHit)
							{
								npc.ai[3] = 0f;
							}
							if (npc.ai[3] == (float)num5)
							{
								npc.netUpdate = true;
							}
						}
						if ((!Main.dayTime || (double)npc.position.Y > Main.worldSurface * 16.0 || npc.type == 26 || npc.type == 27 || npc.type == 28 || npc.type == 31 || npc.type == 47 || npc.type == 67 || npc.type == 73 || npc.type == 77 || npc.type == 78 || npc.type == 79 || npc.type == 80 || npc.type == 110 || npc.type == 111 || npc.type == Config.npcDefs.byName["Corrupted Elemental"].type) && npc.ai[3] < (float)num5)
						{
							if ((npc.type == 3 || npc.type == 21 || npc.type == 31 || npc.type == 77 || npc.type == 110 || npc.type == 132) && Main.rand.Next(1000) == 0)
							{
								Main.PlaySound(14, (int)npc.position.X, (int)npc.position.Y, 1);
							}
							if ((npc.type == 78 || npc.type == 79 || npc.type == 80) && Main.rand.Next(500) == 0)
							{
								Main.PlaySound(26, (int)npc.position.X, (int)npc.position.Y, 1);
							}
							npc.TargetClosest(true);
						}
						else
						{
							if ((npc.type != 110 && npc.type != 111) || npc.ai[2] <= 0f)
							{
								if (Main.dayTime && (double)(npc.position.Y / 16f) < Main.worldSurface && npc.timeLeft > 10)
								{
									npc.timeLeft = 10;
								}
								if (npc.velocity.X == 0f)
								{
									if (npc.velocity.Y == 0f)
									{
										npc.ai[0] += 1f;
										if (npc.ai[0] >= 2f)
										{
											npc.direction *= -1;
											npc.spriteDirection = npc.direction;
											npc.ai[0] = 0f;
										}
									}
								}
								else
								{
									npc.ai[0] = 0f;
								}
								if (npc.direction == 0)
								{
									npc.direction = 1;
								}
							}
						}
						if (npc.type == Config.npcDefs.byName["Corrupted Elemental"].type)
						{
							if (npc.velocity.X < -3f || npc.velocity.X > 3f)
							{
								if (npc.velocity.Y == 0f)
								{
									npc.velocity *= 0.8f;
								}
							}
							else
							{
								if (npc.velocity.X < 3f && npc.direction == 1)
								{
									if (npc.velocity.Y == 0f && npc.velocity.X < 0f)
									{
										npc.velocity.X = npc.velocity.X * 0.99f;
									}
									npc.velocity.X = npc.velocity.X + 0.07f;
									if (npc.velocity.X > 3f)
									{
										npc.velocity.X = 3f;
									}
								}
								else
								{
									if (npc.velocity.X > -3f && npc.direction == -1)
									{
										if (npc.velocity.Y == 0f && npc.velocity.X > 0f)
										{
											npc.velocity.X = npc.velocity.X * 0.99f;
										}
										npc.velocity.X = npc.velocity.X - 0.07f;
										if (npc.velocity.X < -3f)
										{
											npc.velocity.X = -3f;
										}
									}
								}
							}
						}
						else
						{
							if (npc.type == 27 || npc.type == 77 || npc.type == 104)
							{
								if (npc.velocity.X < -2f || npc.velocity.X > 2f)
								{
									if (npc.velocity.Y == 0f)
									{
										npc.velocity *= 0.8f;
									}
								}
								else
								{
									if (npc.velocity.X < 2f && npc.direction == 1)
									{
										npc.velocity.X = npc.velocity.X + 0.07f;
										if (npc.velocity.X > 2f)
										{
											npc.velocity.X = 2f;
										}
									}
									else
									{
										if (npc.velocity.X > -2f && npc.direction == -1)
										{
											npc.velocity.X = npc.velocity.X - 0.07f;
											if (npc.velocity.X < -2f)
											{
												npc.velocity.X = -2f;
											}
										}
									}
								}
							}
							else
							{
								if (npc.type == 109)
								{
									if (npc.velocity.X < -2f || npc.velocity.X > 2f)
									{
										if (npc.velocity.Y == 0f)
										{
											npc.velocity *= 0.8f;
										}
									}
									else
									{
										if (npc.velocity.X < 2f && npc.direction == 1)
										{
											npc.velocity.X = npc.velocity.X + 0.04f;
											if (npc.velocity.X > 2f)
											{
												npc.velocity.X = 2f;
											}
										}
										else
										{
											if (npc.velocity.X > -2f && npc.direction == -1)
											{
												npc.velocity.X = npc.velocity.X - 0.04f;
												if (npc.velocity.X < -2f)
												{
													npc.velocity.X = -2f;
												}
											}
										}
									}
								}
								else
								{
									if (npc.type == 21 || npc.type == 26 || npc.type == 31 || npc.type == 47 || npc.type == 73 || npc.type == 140)
									{
										if (npc.velocity.X < -1.5f || npc.velocity.X > 1.5f)
										{
											if (npc.velocity.Y == 0f)
											{
												npc.velocity *= 0.8f;
											}
										}
										else
										{
											if (npc.velocity.X < 1.5f && npc.direction == 1)
											{
												npc.velocity.X = npc.velocity.X + 0.07f;
												if (npc.velocity.X > 1.5f)
												{
													npc.velocity.X = 1.5f;
												}
											}
											else
											{
												if (npc.velocity.X > -1.5f && npc.direction == -1)
												{
													npc.velocity.X = npc.velocity.X - 0.07f;
													if (npc.velocity.X < -1.5f)
													{
														npc.velocity.X = -1.5f;
													}
												}
											}
										}
									}
									else
									{
										if (npc.type == 67)
										{
											if (npc.velocity.X < -0.5f || npc.velocity.X > 0.5f)
											{
												if (npc.velocity.Y == 0f)
												{
													npc.velocity *= 0.7f;
												}
											}
											else
											{
												if (npc.velocity.X < 0.5f && npc.direction == 1)
												{
													npc.velocity.X = npc.velocity.X + 0.03f;
													if (npc.velocity.X > 0.5f)
													{
														npc.velocity.X = 0.5f;
													}
												}
												else
												{
													if (npc.velocity.X > -0.5f && npc.direction == -1)
													{
														npc.velocity.X = npc.velocity.X - 0.03f;
														if (npc.velocity.X < -0.5f)
														{
															npc.velocity.X = -0.5f;
														}
													}
												}
											}
										}
										else
										{
											if (npc.type == 78 || npc.type == 79 || npc.type == 80)
											{
												float num11 = 1f;
												float num12 = 0.05f;
												if (npc.life < npc.lifeMax / 2)
												{
													num11 = 2f;
													num12 = 0.1f;
												}
												if (npc.type == 79)
												{
													num11 *= 1.5f;
												}
												if (npc.velocity.X < -num11 || npc.velocity.X > num11)
												{
													if (npc.velocity.Y == 0f)
													{
														npc.velocity *= 0.7f;
													}
												}
												else
												{
													if (npc.velocity.X < num11 && npc.direction == 1)
													{
														npc.velocity.X = npc.velocity.X + num12;
														if (npc.velocity.X > num11)
														{
															npc.velocity.X = num11;
														}
													}
													else
													{
														if (npc.velocity.X > -num11 && npc.direction == -1)
														{
															npc.velocity.X = npc.velocity.X - num12;
															if (npc.velocity.X < -num11)
															{
																npc.velocity.X = -num11;
															}
														}
													}
												}
											}
											else
											{
												if (npc.type != 110 && npc.type != 111)
												{
													if (npc.velocity.X < -1f || npc.velocity.X > 1f)
													{
														if (npc.velocity.Y == 0f)
														{
															npc.velocity *= 0.8f;
														}
													}
													else
													{
														if (npc.velocity.X < 1f && npc.direction == 1)
														{
															npc.velocity.X = npc.velocity.X + 0.07f;
															if (npc.velocity.X > 1f)
															{
																npc.velocity.X = 1f;
															}
														}
														else
														{
															if (npc.velocity.X > -1f && npc.direction == -1)
															{
																npc.velocity.X = npc.velocity.X - 0.07f;
																if (npc.velocity.X < -1f)
																{
																	npc.velocity.X = -1f;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						if (npc.type == 110 || npc.type == 111)
						{
							if (npc.confused)
							{
								npc.ai[2] = 0f;
							}
							else
							{
								if (npc.ai[1] > 0f)
								{
									npc.ai[1] -= 1f;
								}
								if (npc.justHit)
								{
									npc.ai[1] = 30f;
									npc.ai[2] = 0f;
								}
								int num13 = 70;
								if (npc.type == 111)
								{
									num13 = 180;
								}
								if (npc.ai[2] > 0f)
								{
									npc.TargetClosest(true);
									if (npc.ai[1] == (float)(num13 / 2))
									{
										float num14 = 11f;
										if (npc.type == 111)
										{
											num14 = 9f;
										}
										Vector2 vector2 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
										float num15 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector2.X;
										float num16 = Math.Abs(num15) * 0.1f;
										float num17 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector2.Y - num16;
										num15 += (float)Main.rand.Next(-40, 41);
										num17 += (float)Main.rand.Next(-40, 41);
										float num18 = (float)Math.Sqrt((double)(num15 * num15 + num17 * num17));
										npc.netUpdate = true;
										num18 = num14 / num18;
										num15 *= num18;
										num17 *= num18;
										int num19 = 35;
										if (npc.type == 111)
										{
											num19 = 11;
										}
										int num20 = 82;
										if (npc.type == 111)
										{
											num20 = 81;
										}
										vector2.X += num15;
										vector2.Y += num17;
										if (Main.netMode != 1)
										{
											Projectile.NewProjectile(vector2.X, vector2.Y, num15, num17, num20, num19, 0f, Main.myPlayer);
										}
										if (Math.Abs(num17) > Math.Abs(num15) * 2f)
										{
											if (num17 > 0f)
											{
												npc.ai[2] = 1f;
											}
											else
											{
												npc.ai[2] = 5f;
											}
										}
										else
										{
											if (Math.Abs(num15) > Math.Abs(num17) * 2f)
											{
												npc.ai[2] = 3f;
											}
											else
											{
												if (num17 > 0f)
												{
													npc.ai[2] = 2f;
												}
												else
												{
													npc.ai[2] = 4f;
												}
											}
										}
									}
									if (npc.velocity.Y != 0f || npc.ai[1] <= 0f)
									{
										npc.ai[2] = 0f;
										npc.ai[1] = 0f;
									}
									else
									{
										npc.velocity.X = npc.velocity.X * 0.9f;
										npc.spriteDirection = npc.direction;
									}
								}
								if (npc.ai[2] <= 0f && npc.velocity.Y == 0f && npc.ai[1] <= 0f && !Main.player[npc.target].dead && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
								{
									float num21 = 10f;
									Vector2 vector3 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
									float num22 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector3.X;
									float num23 = Math.Abs(num22) * 0.1f;
									float num24 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector3.Y - num23;
									num22 += (float)Main.rand.Next(-40, 41);
									num24 += (float)Main.rand.Next(-40, 41);
									float num25 = (float)Math.Sqrt((double)(num22 * num22 + num24 * num24));
									if (num25 < 700f)
									{
										npc.netUpdate = true;
										npc.velocity.X = npc.velocity.X * 0.5f;
										num25 = num21 / num25;
										num22 *= num25;
										num24 *= num25;
										npc.ai[2] = 3f;
										npc.ai[1] = (float)num13;
										if (Math.Abs(num24) > Math.Abs(num22) * 2f)
										{
											if (num24 > 0f)
											{
												npc.ai[2] = 1f;
											}
											else
											{
												npc.ai[2] = 5f;
											}
										}
										else
										{
											if (Math.Abs(num22) > Math.Abs(num24) * 2f)
											{
												npc.ai[2] = 3f;
											}
											else
											{
												if (num24 > 0f)
												{
													npc.ai[2] = 2f;
												}
												else
												{
													npc.ai[2] = 4f;
												}
											}
										}
									}
								}
								if (npc.ai[2] <= 0f)
								{
									if (npc.velocity.X < -1f || npc.velocity.X > 1f)
									{
										if (npc.velocity.Y == 0f)
										{
											npc.velocity *= 0.8f;
										}
									}
									else
									{
										if (npc.velocity.X < 1f && npc.direction == 1)
										{
											npc.velocity.X = npc.velocity.X + 0.07f;
											if (npc.velocity.X > 1f)
											{
												npc.velocity.X = 1f;
											}
										}
										else
										{
											if (npc.velocity.X > -1f && npc.direction == -1)
											{
												npc.velocity.X = npc.velocity.X - 0.07f;
												if (npc.velocity.X < -1f)
												{
													npc.velocity.X = -1f;
												}
											}
										}
									}
								}
							}
						}
						if (npc.type == 109 && Main.netMode != 1 && !Main.player[npc.target].dead)
						{
							if (npc.justHit)
							{
								npc.ai[2] = 0f;
							}
							npc.ai[2] += 1f;
							if (npc.ai[2] > 450f)
							{
								Vector2 vector4 = new Vector2(npc.position.X + (float)npc.width * 0.5f - (float)(npc.direction * 24), npc.position.Y + 4f);
								int num26 = 3 * npc.direction;
								int num27 = -5;
								int num28 = Projectile.NewProjectile(vector4.X, vector4.Y, (float)num26, (float)num27, 75, 0, 0f, Main.myPlayer);
								Main.projectile[num28].timeLeft = 300;
								npc.ai[2] = 0f;
							}
						}
						bool flag4 = false;
						if (npc.velocity.Y == 0f)
						{
							int num29 = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
							int num30 = (int)npc.position.X / 16;
							int num31 = (int)(npc.position.X + (float)npc.width) / 16;
							for (int l = num30; l <= num31; l++)
							{
								if (Main.tile[l, num29] == null)
								{
									return;
								}
								if (Main.tile[l, num29].active && Main.tileSolid[(int)Main.tile[l, num29].type])
								{
									flag4 = true;
									break;
								}
							}
						}
						if (flag4)
						{
							int num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)(15 * npc.direction)) / 16f);
							int num33 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
							if (npc.type == 109)
							{
								num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 16) * npc.direction)) / 16f);
							}
							if (Main.tile[num32, num33] == null)
							{
								Main.tile[num32, num33] = new Tile();
							}
							if (Main.tile[num32, num33 - 1] == null)
							{
								Main.tile[num32, num33 - 1] = new Tile();
							}
							if (Main.tile[num32, num33 - 2] == null)
							{
								Main.tile[num32, num33 - 2] = new Tile();
							}
							if (Main.tile[num32, num33 - 3] == null)
							{
								Main.tile[num32, num33 - 3] = new Tile();
							}
							if (Main.tile[num32, num33 + 1] == null)
							{
								Main.tile[num32, num33 + 1] = new Tile();
							}
							if (Main.tile[num32 + npc.direction, num33 - 1] == null)
							{
								Main.tile[num32 + npc.direction, num33 - 1] = new Tile();
							}
							if (Main.tile[num32 + npc.direction, num33 + 1] == null)
							{
								Main.tile[num32 + npc.direction, num33 + 1] = new Tile();
							}
							if (Main.tile[num32, num33 - 1].active && Main.tile[num32, num33 - 1].type == 10 && flag3)
							{
								npc.ai[2] += 1f;
								npc.ai[3] = 0f;
								if (npc.ai[2] >= 60f)
								{
									if (!Main.bloodMoon && (npc.type == 3 || npc.type == 132))
									{
										npc.ai[1] = 0f;
									}
									npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
									npc.ai[1] += 1f;
									if (npc.type == 27)
									{
										npc.ai[1] += 1f;
									}
									if (npc.type == 31)
									{
										npc.ai[1] += 6f;
									}
									npc.ai[2] = 0f;
									bool flag5 = false;
									if (npc.ai[1] >= 10f)
									{
										flag5 = true;
										npc.ai[1] = 10f;
									}
									WorldGen.KillTile(num32, num33 - 1, true, false, false);
									if ((Main.netMode != 1 || !flag5) && flag5 && Main.netMode != 1)
									{
										if (npc.type == 26)
										{
											WorldGen.KillTile(num32, num33 - 1, false, false, false);
											if (Main.netMode == 2)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)num32, (float)(num33 - 1), 0f, 0);
											}
										}
										else
										{
											bool flag6 = WorldGen.OpenDoor(num32, num33, npc.direction);
											if (!flag6)
											{
												npc.ai[3] = (float)num5;
												npc.netUpdate = true;
											}
											if (Main.netMode == 2 && flag6)
											{
												NetMessage.SendData(19, -1, -1, "", 0, (float)num32, (float)num33, (float)npc.direction, 0);
											}
										}
									}
								}
							}
							else
							{
								if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
								{
									if (Main.tile[num32, num33 - 2].active && Main.tileSolid[(int)Main.tile[num32, num33 - 2].type])
									{
										if (Main.tile[num32, num33 - 3].active && Main.tileSolid[(int)Main.tile[num32, num33 - 3].type])
										{
											npc.velocity.Y = -8f;
											npc.netUpdate = true;
										}
										else
										{
											npc.velocity.Y = -7f;
											npc.netUpdate = true;
										}
									}
									else
									{
										if (Main.tile[num32, num33 - 1].active && Main.tileSolid[(int)Main.tile[num32, num33 - 1].type])
										{
											npc.velocity.Y = -6f;
											npc.netUpdate = true;
										}
										else
										{
											if (Main.tile[num32, num33].active && Main.tileSolid[(int)Main.tile[num32, num33].type])
											{
												npc.velocity.Y = -5f;
												npc.netUpdate = true;
											}
											else
											{
												if (npc.directionY < 0 && npc.type != 67 && (!Main.tile[num32, num33 + 1].active || !Main.tileSolid[(int)Main.tile[num32, num33 + 1].type]) && (!Main.tile[num32 + npc.direction, num33 + 1].active || !Main.tileSolid[(int)Main.tile[num32 + npc.direction, num33 + 1].type]))
												{
													npc.velocity.Y = -8f;
													npc.velocity.X = npc.velocity.X * 1.5f;
													npc.netUpdate = true;
												}
												else
												{
													if (flag3)
													{
														npc.ai[1] = 0f;
														npc.ai[2] = 0f;
													}
												}
											}
										}
									}
								}
								if ((npc.type == 31 || npc.type == 47 || npc.type == 77 || npc.type == 104) && npc.velocity.Y == 0f && Math.Abs(npc.position.X + (float)(npc.width / 2) - (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))) < 100f && Math.Abs(npc.position.Y + (float)(npc.height / 2) - (Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2))) < 50f && ((npc.direction > 0 && npc.velocity.X >= 1f) || (npc.direction < 0 && npc.velocity.X <= -1f)))
								{
									npc.velocity.X = npc.velocity.X * 2f;
									if (npc.velocity.X > 3f)
									{
										npc.velocity.X = 3f;
									}
									if (npc.velocity.X < -3f)
									{
										npc.velocity.X = -3f;
									}
									npc.velocity.Y = -4f;
									npc.netUpdate = true;
								}
								if (npc.type == Config.npcDefs.byName["Corrupted Elemental"].type && npc.velocity.Y < 0f)
								{
									npc.velocity.Y = npc.velocity.Y * 1.1f;
								}
							}
						}
						else
						{
							if (flag3)
							{
								npc.ai[1] = 0f;
								npc.ai[2] = 0f;
							}
						}
						if (Main.netMode != 1 && npc.type == Config.npcDefs.byName["Corrupted Elemental"].type && npc.ai[3] >= (float)num5)
						{
							int num34 = (int)Main.player[npc.target].position.X / 16;
							int num35 = (int)Main.player[npc.target].position.Y / 16;
							int num36 = (int)npc.position.X / 16;
							int num37 = (int)npc.position.Y / 16;
							int num38 = 20;
							int num39 = 0;
							bool flag7 = false;
							if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
							{
								num39 = 100;
								flag7 = true;
							}
							while (!flag7)
							{
								if (num39 >= 100)
								{
									return;
								}
								num39++;
								int num40 = Main.rand.Next(num34 - num38, num34 + num38);
								int num41 = Main.rand.Next(num35 - num38, num35 + num38);
								for (int m = num41; m < num35 + num38; m++)
								{
									if ((m < num35 - 4 || m > num35 + 4 || num40 < num34 - 4 || num40 > num34 + 4) && (m < num37 - 1 || m > num37 + 1 || num40 < num36 - 1 || num40 > num36 + 1) && Main.tile[num40, m].active)
									{
										bool flag8 = true;
										if (npc.type == 32 && Main.tile[num40, m - 1].wall == 0)
										{
											flag8 = false;
										}
										else
										{
											if (Main.tile[num40, m - 1].lava)
											{
												flag8 = false;
											}
										}
										if (flag8 && Main.tileSolid[(int)Main.tile[num40, m].type] && !Collision.SolidTiles(num40 - 1, num40 + 1, m - 4, m - 1))
										{
											npc.position.X = (float)(num40 * 16 - npc.width / 2);
											npc.position.Y = (float)(m * 16 - npc.height);
											npc.netUpdate = true;
											npc.ai[3] = -120f;
										}
									}
								}
							}
						}
					}