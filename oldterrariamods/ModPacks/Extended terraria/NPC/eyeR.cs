public void AI()
{
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
		npc.TargetClosest(true);
	}
	bool dead2 = Main.player[npc.target].dead;
	float num317 = npc.position.X + (float)(npc.width / 2) - Main.player[npc.target].position.X - (float)(Main.player[npc.target].width / 2);
	float num318 = npc.position.Y + (float)npc.height - 59f - Main.player[npc.target].position.Y - (float)(Main.player[npc.target].height / 2);
	float num319 = (float)Math.Atan2((double)num318, (double)num317) + 1.57f;
	if (num319 < 0f)
	{
		num319 += 6.283f;
	}
	else
	{
		if ((double)num319 > 6.283)
		{
			num319 -= 6.283f;
		}
	}
	float num320 = 0.1f;
	if (npc.rotation < num319)
	{
		if ((double)(num319 - npc.rotation) > 3.1415)
		{
			npc.rotation -= num320;
		}
		else
		{
			npc.rotation += num320;
		}
	}
	else
	{
		if (npc.rotation > num319)
		{
			if ((double)(npc.rotation - num319) > 3.1415)
			{
				npc.rotation += num320;
			}
			else
			{
				npc.rotation -= num320;
			}
		}
	}
	if (npc.rotation > num319 - num320 && npc.rotation < num319 + num320)
	{
		npc.rotation = num319;
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
	if (npc.rotation > num319 - num320 && npc.rotation < num319 + num320)
	{
		npc.rotation = num319;
	}
	if (Main.rand.Next(5) == 0)
	{
		int num321 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
		Dust expr_146B6_cp_0 = Main.dust[num321];
		expr_146B6_cp_0.velocity.X = expr_146B6_cp_0.velocity.X * 0.5f;
		Dust expr_146D6_cp_0 = Main.dust[num321];
		expr_146D6_cp_0.velocity.Y = expr_146D6_cp_0.velocity.Y * 0.1f;
	}
	if (Main.dayTime || dead2)
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
				float num322 = 7f;
				float num323 = 0.1f;
				int num324 = 1;
				if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
				{
					num324 = -1;
				}
				Vector2 vector32 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num325 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num324 * 300) - vector32.X;
				float num326 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 300f - vector32.Y;
				float num327 = (float)Math.Sqrt((double)(num325 * num325 + num326 * num326));
				float num328 = num327;
				num327 = num322 / num327;
				num325 *= num327;
				num326 *= num327;
				if (npc.velocity.X < num325)
				{
					npc.velocity.X = npc.velocity.X + num323;
					if (npc.velocity.X < 0f && num325 > 0f)
					{
						npc.velocity.X = npc.velocity.X + num323;
					}
				}
				else
				{
					if (npc.velocity.X > num325)
					{
						npc.velocity.X = npc.velocity.X - num323;
						if (npc.velocity.X > 0f && num325 < 0f)
						{
							npc.velocity.X = npc.velocity.X - num323;
						}
					}
				}
				if (npc.velocity.Y < num326)
				{
					npc.velocity.Y = npc.velocity.Y + num323;
					if (npc.velocity.Y < 0f && num326 > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + num323;
					}
				}
				else
				{
					if (npc.velocity.Y > num326)
					{
						npc.velocity.Y = npc.velocity.Y - num323;
						if (npc.velocity.Y > 0f && num326 < 0f)
						{
							npc.velocity.Y = npc.velocity.Y - num323;
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
					if (npc.position.Y + (float)npc.height < Main.player[npc.target].position.Y && num328 < 400f)
					{
						if (!Main.player[npc.target].dead)
						{
							npc.ai[3] += 1f;
						}
						if (npc.ai[3] >= 60f)
						{
							npc.ai[3] = 0f;
							vector32 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
							num325 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector32.X;
							num326 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector32.Y;
							if (Main.netMode != 1)
							{
								float num329 = 9f;
								int num330 = 70;
								int num331 = 88;
								num327 = (float)Math.Sqrt((double)(num325 * num325 + num326 * num326));
								num327 = num329 / num327;
								num325 *= num327;
								num326 *= num327;
								num325 += (float)Main.rand.Next(-40, 41) * 0.08f;
								num326 += (float)Main.rand.Next(-40, 41) * 0.08f;
								vector32.X += num325 * 15f;
								vector32.Y += num326 * 15f;
								Projectile.NewProjectile(vector32.X, vector32.Y, num325, num326, num331, num330, 0f, Main.myPlayer);
							}
						}
					}
				}
			}
			else
			{
				if (npc.ai[1] == 1f)
				{
					npc.rotation = num319;
					float num332 = 12f;
					Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					float num333 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
					float num334 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
					float num335 = (float)Math.Sqrt((double)(num333 * num333 + num334 * num334));
					num335 = num332 / num335;
					npc.velocity.X = num333 * num335;
					npc.velocity.Y = num334 * num335;
					npc.ai[1] = 2f;
				}
				else
				{
					if (npc.ai[1] == 2f)
					{
						npc.ai[2] += 1f;
						if (npc.ai[2] >= 25f)
						{
							npc.velocity.X = npc.velocity.X * 0.96f;
							npc.velocity.Y = npc.velocity.Y * 0.96f;
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
						if (npc.ai[2] >= 70f)
						{
							npc.ai[3] += 1f;
							npc.ai[2] = 0f;
							npc.target = 255;
							npc.rotation = num319;
							if (npc.ai[3] >= 4f)
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
						for (int num336 = 0; num336 < 2; num336++)
						{
							Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 143, 1f);
							Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
							Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
						}
						for (int num337 = 0; num337 < 20; num337++)
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
				npc.damage = (int)((double)npc.defDamage * 1.2);
				npc.defense = npc.defDefense + 15;
				npc.soundHit = 4;
				if (npc.ai[1] == 0f)
				{
					float num338 = 8f;
					float num339 = 0.15f;
					Vector2 vector34 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					float num340 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector34.X;
					float num341 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 300f - vector34.Y;
					float num342 = (float)Math.Sqrt((double)(num340 * num340 + num341 * num341));
					num342 = num338 / num342;
					num340 *= num342;
					num341 *= num342;
					if (npc.velocity.X < num340)
					{
						npc.velocity.X = npc.velocity.X + num339;
						if (npc.velocity.X < 0f && num340 > 0f)
						{
							npc.velocity.X = npc.velocity.X + num339;
						}
					}
					else
					{
						if (npc.velocity.X > num340)
						{
							npc.velocity.X = npc.velocity.X - num339;
							if (npc.velocity.X > 0f && num340 < 0f)
							{
								npc.velocity.X = npc.velocity.X - num339;
							}
						}
					}
					if (npc.velocity.Y < num341)
					{
						npc.velocity.Y = npc.velocity.Y + num339;
						if (npc.velocity.Y < 0f && num341 > 0f)
						{
							npc.velocity.Y = npc.velocity.Y + num339;
						}
					}
					else
					{
						if (npc.velocity.Y > num341)
						{
							npc.velocity.Y = npc.velocity.Y - num339;
							if (npc.velocity.Y > 0f && num341 < 0f)
							{
								npc.velocity.Y = npc.velocity.Y - num339;
							}
						}
					}
					npc.ai[2] += 1f;
					if (npc.ai[2] >= 300f)
					{
						npc.ai[1] = 1f;
						npc.ai[2] = 0f;
						npc.ai[3] = 0f;
						npc.TargetClosest(true);
						npc.netUpdate = true;
					}
					vector34 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					num340 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector34.X;
					num341 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector34.Y;
					npc.rotation = (float)Math.Atan2((double)num341, (double)num340) - 1.57f;
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
						if (npc.localAI[1] > 140f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
						{
							npc.localAI[1] = 0f;
							float num343 = 9f;
							int num344 = 67;
							int num345 = 100;
							num342 = (float)Math.Sqrt((double)(num340 * num340 + num341 * num341));
							num342 = num343 / num342;
							num340 *= num342;
							num341 *= num342;
							vector34.X += num340 * 15f;
							vector34.Y += num341 * 15f;
							Projectile.NewProjectile(vector34.X, vector34.Y, num340, num341, num345, num344, 0f, Main.myPlayer);
							return;
						}
					}
				}
				else
				{
					int num346 = 1;
					if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
					{
						num346 = -1;
					}
					float num347 = 8f;
					float num348 = 0.2f;
					Vector2 vector35 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					float num349 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num346 * 340) - vector35.X;
					float num350 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector35.Y;
					float num351 = (float)Math.Sqrt((double)(num349 * num349 + num350 * num350));
					num351 = num347 / num351;
					num349 *= num351;
					num350 *= num351;
					if (npc.velocity.X < num349)
					{
						npc.velocity.X = npc.velocity.X + num348;
						if (npc.velocity.X < 0f && num349 > 0f)
						{
							npc.velocity.X = npc.velocity.X + num348;
						}
					}
					else
					{
						if (npc.velocity.X > num349)
						{
							npc.velocity.X = npc.velocity.X - num348;
							if (npc.velocity.X > 0f && num349 < 0f)
							{
								npc.velocity.X = npc.velocity.X - num348;
							}
						}
					}
					if (npc.velocity.Y < num350)
					{
						npc.velocity.Y = npc.velocity.Y + num348;
						if (npc.velocity.Y < 0f && num350 > 0f)
						{
							npc.velocity.Y = npc.velocity.Y + num348;
						}
					}
					else
					{
						if (npc.velocity.Y > num350)
						{
							npc.velocity.Y = npc.velocity.Y - num348;
							if (npc.velocity.Y > 0f && num350 < 0f)
							{
								npc.velocity.Y = npc.velocity.Y - num348;
							}
						}
					}
					vector35 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					num349 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector35.X;
					num350 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector35.Y;
					npc.rotation = (float)Math.Atan2((double)num350, (double)num349) - 1.57f;
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
						if (npc.localAI[1] > 45f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
						{
							npc.localAI[1] = 0f;
							float num352 = 9f;
							int num353 = 70;
							int num354 = 100;
							num351 = (float)Math.Sqrt((double)(num349 * num349 + num350 * num350));
							num351 = num352 / num351;
							num349 *= num351;
							num350 *= num351;
							vector35.X += num349 * 15f;
							vector35.Y += num350 * 15f;
							Projectile.NewProjectile(vector35.X, vector35.Y, num349, num350, num354, num353, 0f, Main.myPlayer);
						}
					}
					npc.ai[2] += 1f;
					if (npc.ai[2] >= 200f)
					{
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.ai[3] = 0f;
						npc.TargetClosest(true);
						npc.netUpdate = true;
						return;
					}
				}
			}
		}
	}
}