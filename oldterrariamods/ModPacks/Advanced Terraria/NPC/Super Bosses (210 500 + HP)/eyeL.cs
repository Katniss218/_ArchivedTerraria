public void AI()
{
	for (int i = 0; i < npc.buffType.Length; i++)
	{
		if(npc.buffType[i] == Config.buffID["Freeze"])
		{
			npc.DelBuff(i);
			i=0;
		}
	}
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
		npc.TargetClosest(true);
	}
	bool dead3 = Main.player[npc.target].dead;
	float num355 = npc.position.X + (float)(npc.width / 2) - Main.player[npc.target].position.X - (float)(Main.player[npc.target].width / 2);
	float num356 = npc.position.Y + (float)npc.height - 59f - Main.player[npc.target].position.Y - (float)(Main.player[npc.target].height / 2);
	float num357 = (float)Math.Atan2((double)num356, (double)num355) + 1.57f;
	if (num357 < 0f)
	{
		num357 += 6.283f;
	}
	else
	{
		if ((double)num357 > 6.283)
		{
			num357 -= 6.283f;
		}
	}
	float num358 = 0.15f;
	if (npc.rotation < num357)
	{
		if ((double)(num357 - npc.rotation) > 3.1415)
		{
			npc.rotation -= num358;
		}
		else
		{
			npc.rotation += num358;
		}
	}
	else
	{
		if (npc.rotation > num357)
		{
			if ((double)(npc.rotation - num357) > 3.1415)
			{
				npc.rotation += num358;
			}
			else
			{
				npc.rotation -= num358;
			}
		}
	}
	if (npc.rotation > num357 - num358 && npc.rotation < num357 + num358)
	{
		npc.rotation = num357;
	}
	if (npc.rotation < 0f)
	{
		npc.rotation += 6.283f;
	}
	else
	{
		if ((double)npc.rotation > 6.283)
		{
			npc.rotation -= 6.283f;
		}
	}
	if (npc.rotation > num357 - num358 && npc.rotation < num357 + num358)
	{
		npc.rotation = num357;
	}
	if (Main.rand.Next(5) == 0)
	{
		int num359 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
		Dust expr_16307_cp_0 = Main.dust[num359];
		expr_16307_cp_0.velocity.X = expr_16307_cp_0.velocity.X * 0.5f;
		Dust expr_16327_cp_0 = Main.dust[num359];
		expr_16327_cp_0.velocity.Y = expr_16327_cp_0.velocity.Y * 0.1f;
	}
	if (Main.dayTime || dead3)
	{
		npc.velocity.Y = npc.velocity.Y - 0.04f;
		if (npc.timeLeft > 10)
		{
			npc.timeLeft = 10;
			return;
		}
	}
	else
	{
		if (npc.ai[0] == 0f)
		{
			if (npc.ai[1] == 0f)
			{
				npc.TargetClosest(true);
				float num360 = 12f;
				float num361 = 0.4f;
				int num362 = 1;
				if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
				{
					num362 = -1;
				}
				Vector2 vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num363 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num362 * 400) - vector36.X;
				float num364 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector36.Y;
				float num365 = (float)Math.Sqrt((double)(num363 * num363 + num364 * num364));
				num365 = num360 / num365;
				num363 *= num365;
				num364 *= num365;
				if (npc.velocity.X < num363)
				{
					npc.velocity.X = npc.velocity.X + num361;
					if (npc.velocity.X < 0f && num363 > 0f)
					{
						npc.velocity.X = npc.velocity.X + num361;
					}
				}
				else
				{
					if (npc.velocity.X > num363)
					{
						npc.velocity.X = npc.velocity.X - num361;
						if (npc.velocity.X > 0f && num363 < 0f)
						{
							npc.velocity.X = npc.velocity.X - num361;
						}
					}
				}
				if (npc.velocity.Y < num364)
				{
					npc.velocity.Y = npc.velocity.Y + num361;
					if (npc.velocity.Y < 0f && num364 > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + num361;
					}
				}
				else
				{
					if (npc.velocity.Y > num364)
					{
						npc.velocity.Y = npc.velocity.Y - num361;
						if (npc.velocity.Y > 0f && num364 < 0f)
						{
							npc.velocity.Y = npc.velocity.Y - num361;
						}
					}
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= 600f)
				{
					npc.ai[1] = 1f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
					npc.target = 255;
					npc.netUpdate = true;
				}
				else
				{
					if (!Main.player[npc.target].dead)
					{
						npc.ai[3] += 1f;
					}
					if (npc.ai[3] >= 60f)
					{
						npc.ai[3] = 0f;
						vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						num363 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector36.X;
						num364 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector36.Y;
						if (Main.netMode != 1)
						{
							float num366 = 12f;
							int num367 = 55;
							int num368 = Config.projDefs.byName["Dark Flames"].type;
							num365 = (float)Math.Sqrt((double)(num363 * num363 + num364 * num364));
							num365 = num366 / num365;
							num363 *= num365;
							num364 *= num365;
							num363 += (float)Main.rand.Next(-40, 41) * 0.05f;
							num364 += (float)Main.rand.Next(-40, 41) * 0.05f;
							vector36.X += num363 * 4f;
							vector36.Y += num364 * 4f;
							Projectile.NewProjectile(vector36.X, vector36.Y, num363, num364, num368, num367, 0f, Main.myPlayer);
						}
					}
				}
			}
			else
			{
				if (npc.ai[1] == 1f)
				{
					npc.rotation = num357;
					float num369 = 13f;
					Vector2 vector37 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					float num370 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector37.X;
					float num371 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector37.Y;
					float num372 = (float)Math.Sqrt((double)(num370 * num370 + num371 * num371));
					num372 = num369 / num372;
					npc.velocity.X = num370 * num372;
					npc.velocity.Y = num371 * num372;
					npc.ai[1] = 2f;
				}
				else
				{
					if (npc.ai[1] == 2f)
					{
						npc.ai[2] += 1f;
						if (npc.ai[2] >= 8f)
						{
							npc.velocity.X = npc.velocity.X * 0.9f;
							npc.velocity.Y = npc.velocity.Y * 0.9f;
							if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
							{
								npc.velocity.X = 0f;
							}
							if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
							{
								npc.velocity.Y = 0f;
							}
						}
						else
						{
							npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
						}
						if (npc.ai[2] >= 42f)
						{
							npc.ai[3] += 1f;
							npc.ai[2] = 0f;
							npc.target = 255;
							npc.rotation = num357;
							if (npc.ai[3] >= 10f)
							{
								npc.ai[1] = 0f;
								npc.ai[3] = 0f;
							}
							else
							{
								npc.ai[1] = 1f;
							}
						}
					}
				}
			}
			if ((double)npc.life < (double)npc.lifeMax * 0.5)
			{
				npc.ai[0] = 1f;
				npc.ai[1] = 0f;
				npc.ai[2] = 0f;
				npc.ai[3] = 0f;
				npc.netUpdate = true;
				return;
			}
		}
		else
		{
			if (npc.ai[0] == 1f || npc.ai[0] == 2f)
			{
				if (npc.ai[0] == 1f)
				{
					npc.ai[2] += 0.005f;
					if ((double)npc.ai[2] > 0.5)
					{
						npc.ai[2] = 0.5f;
					}
				}
				else
				{
					npc.ai[2] -= 0.005f;
					if (npc.ai[2] < 0f)
					{
						npc.ai[2] = 0f;
					}
				}
				npc.rotation += npc.ai[2];
				npc.ai[1] += 1f;
				if (npc.ai[1] == 100f)
				{
					npc.ai[0] += 1f;
					npc.ai[1] = 0f;
					if (npc.ai[0] == 3f)
					{
						npc.ai[2] = 0f;
					}
					else
					{
						Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 1);
						for (int num373 = 0; num373 < 2; num373++)
						{
							Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 144, 1f);
							Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
							Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
						}
						for (int num374 = 0; num374 < 20; num374++)
						{
							Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
						}
						Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
					}
				}
				Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
				npc.velocity.X = npc.velocity.X * 0.98f;
				npc.velocity.Y = npc.velocity.Y * 0.98f;
				if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
				{
					npc.velocity.X = 0f;
				}
				if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
				{
					npc.velocity.Y = 0f;
					return;
				}
			}
			else
			{
				npc.soundHit = 4;
				npc.damage = (int)((double)npc.defDamage * 1.5);
				npc.defense = npc.defDefense + 25;
				if (npc.ai[1] == 0f)
				{
					float num375 = 4f;
					float num376 = 0.1f;
					int num377 = 1;
					if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
					{
						num377 = -1;
					}
					Vector2 vector38 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					float num378 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num377 * 180) - vector38.X;
					float num379 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector38.Y;
					float num380 = (float)Math.Sqrt((double)(num378 * num378 + num379 * num379));
					num380 = num375 / num380;
					num378 *= num380;
					num379 *= num380;
					if (npc.velocity.X < num378)
					{
						npc.velocity.X = npc.velocity.X + num376;
						if (npc.velocity.X < 0f && num378 > 0f)
						{
							npc.velocity.X = npc.velocity.X + num376;
						}
					}
					else
					{
						if (npc.velocity.X > num378)
						{
							npc.velocity.X = npc.velocity.X - num376;
							if (npc.velocity.X > 0f && num378 < 0f)
							{
								npc.velocity.X = npc.velocity.X - num376;
							}
						}
					}
					if (npc.velocity.Y < num379)
					{
						npc.velocity.Y = npc.velocity.Y + num376;
						if (npc.velocity.Y < 0f && num379 > 0f)
						{
							npc.velocity.Y = npc.velocity.Y + num376;
						}
					}
					else
					{
						if (npc.velocity.Y > num379)
						{
							npc.velocity.Y = npc.velocity.Y - num376;
							if (npc.velocity.Y > 0f && num379 < 0f)
							{
								npc.velocity.Y = npc.velocity.Y - num376;
							}
						}
					}
					npc.ai[2] += 1f;
					if (npc.ai[2] >= 400f)
					{
						npc.ai[1] = 1f;
						npc.ai[2] = 0f;
						npc.ai[3] = 0f;
						npc.target = 255;
						npc.netUpdate = true;
					}
					if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
					{
						npc.localAI[2] += 1f;
						if (npc.localAI[2] > 22f)
						{
							npc.localAI[2] = 0f;
							Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 34);
						}
						if (Main.netMode != 1)
						{
							npc.localAI[1] += 1f;
							if ((double)npc.life < (double)npc.lifeMax * 0.75)
							{
								npc.localAI[1] += 1f;
							}
							if ((double)npc.life < (double)npc.lifeMax * 0.5)
							{
								npc.localAI[1] += 1f;
							}
							if ((double)npc.life < (double)npc.lifeMax * 0.25)
							{
								npc.localAI[1] += 1f;
							}
							if ((double)npc.life < (double)npc.lifeMax * 0.1)
							{
								npc.localAI[1] += 2f;
							}
							if (npc.localAI[1] > 8f)
							{
								npc.localAI[1] = 0f;
								float num381 = 6f;
								int num382 = 60;
								int num383 = Config.projDefs.byName["Dark Thrower"].type;
								vector38 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
								num378 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector38.X;
								num379 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector38.Y;
								num380 = (float)Math.Sqrt((double)(num378 * num378 + num379 * num379));
								num380 = num381 / num380;
								num378 *= num380;
								num379 *= num380;
								num379 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num378 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num379 += npc.velocity.Y * 0.5f;
								num378 += npc.velocity.X * 0.5f;
								vector38.X -= num378 * 1f;
								vector38.Y -= num379 * 1f;
								Projectile.NewProjectile(vector38.X, vector38.Y, num378, num379, num383, num382, 0f, Main.myPlayer);
								return;
							}
						}
					}
				}
				else
				{
					if (npc.ai[1] == 1f)
					{
						Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
						npc.rotation = num357;
						float num384 = 14f;
						Vector2 vector39 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						float num385 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector39.X;
						float num386 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector39.Y;
						float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
						num387 = num384 / num387;
						npc.velocity.X = num385 * num387;
						npc.velocity.Y = num386 * num387;
						npc.ai[1] = 2f;
						return;
					}
					if (npc.ai[1] == 2f)
					{
						npc.ai[2] += 1f;
						if (npc.ai[2] >= 50f)
						{
							npc.velocity.X = npc.velocity.X * 0.93f;
							npc.velocity.Y = npc.velocity.Y * 0.93f;
							if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
							{
								npc.velocity.X = 0f;
							}
							if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
							{
								npc.velocity.Y = 0f;
							}
						}
						else
						{
							npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
						}
						if (npc.ai[2] >= 80f)
						{
							npc.ai[3] += 1f;
							npc.ai[2] = 0f;
							npc.target = 255;
							npc.rotation = num357;
							if (npc.ai[3] >= 6f)
							{
								npc.ai[1] = 0f;
								npc.ai[3] = 0f;
								return;
							}
							npc.ai[1] = 1f;
							return;
						}
					}
				}
			}
		}
	}
}