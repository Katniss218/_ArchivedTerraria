public bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.player[playerID].zone["Comet"] && Main.rand.Next(2) == 0)
	{
		return true;
	}
	else return false;
}
public void AI()
{
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
	{
		npc.TargetClosest(true);
	}
	float num73 = 6f;
	float num74 = 0.05f;
	if (npc.type == 6)
	{
		num73 = 4f;
		num74 = 0.02f;
	}
	else
	{
		if (npc.type == 94)
		{
			num73 = 4.2f;
			num74 = 0.022f;
		}
		else
		{
			if (npc.type == 42)
			{
				num73 = 3.5f;
				num74 = 0.021f;
			}
			else
			{
				if (npc.type == Config.npcDefs.byName["Comet Tail"].type)
				{
					num73 = 1f;
					num74 = 0.03f;
				}
				else
				{
					if (npc.type == 5)
					{
						num73 = 5f;
						num74 = 0.03f;
					}
				}
			}
		}
	}
	Vector2 vector11 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
	float num75 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
	float num76 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
	num75 = (float)((int)(num75 / 8f) * 8);
	num76 = (float)((int)(num76 / 8f) * 8);
	vector11.X = (float)((int)(vector11.X / 8f) * 8);
	vector11.Y = (float)((int)(vector11.Y / 8f) * 8);
	num75 -= vector11.X;
	num76 -= vector11.Y;
	float num77 = (float)Math.Sqrt((double)(num75 * num75 + num76 * num76));
	float num78 = num77;
	bool flag9 = false;
	if (num77 > 600f)
	{
		flag9 = true;
	}
	if (num77 == 0f)
	{
		num75 = npc.velocity.X;
		num76 = npc.velocity.Y;
	}
	else
	{
		num77 = num73 / num77;
		num75 *= num77;
		num76 *= num77;
	}
	if (npc.type == 6 || npc.type == 42 || npc.type == 94 || npc.type == 139)
	{
		if (num78 > 100f || npc.type == 42 || npc.type == 94)
		{
			npc.ai[0] += 1f;
			if (npc.ai[0] > 0f)
			{
				npc.velocity.Y = npc.velocity.Y + 0.023f;
			}
			else
			{
				npc.velocity.Y = npc.velocity.Y - 0.023f;
			}
			if (npc.ai[0] < -100f || npc.ai[0] > 100f)
			{
				npc.velocity.X = npc.velocity.X + 0.023f;
			}
			else
			{
				npc.velocity.X = npc.velocity.X - 0.023f;
			}
			if (npc.ai[0] > 200f)
			{
				npc.ai[0] = -200f;
			}
		}
		if (num78 < 150f && (npc.type == 6 || npc.type == 94))
		{
			npc.velocity.X = npc.velocity.X + num75 * 0.007f;
			npc.velocity.Y = npc.velocity.Y + num76 * 0.007f;
		}
	}
	if (Main.player[npc.target].dead)
	{
		num75 = (float)npc.direction * num73 / 2f;
		num76 = -num73 / 2f;
	}
	if (npc.velocity.X < num75)
	{
		npc.velocity.X = npc.velocity.X + num74;
		if (npc.type != 6 && npc.type != 42 && npc.type != 94 && npc.type != 139 && npc.velocity.X < 0f && num75 > 0f)
		{
			npc.velocity.X = npc.velocity.X + num74;
		}
	}
	else
	{
		if (npc.velocity.X > num75)
		{
			npc.velocity.X = npc.velocity.X - num74;
			if (npc.type != 6 && npc.type != 42 && npc.type != 94 && npc.type != 139 && npc.velocity.X > 0f && num75 < 0f)
			{
				npc.velocity.X = npc.velocity.X - num74;
			}
		}
	}
	if (npc.velocity.Y < num76)
	{
		npc.velocity.Y = npc.velocity.Y + num74;
		if (npc.type != 6 && npc.type != 42 && npc.type != 94 && npc.type != 139 && npc.velocity.Y < 0f && num76 > 0f)
		{
			npc.velocity.Y = npc.velocity.Y + num74;
		}
	}
	else
	{
		if (npc.velocity.Y > num76)
		{
			npc.velocity.Y = npc.velocity.Y - num74;
			if (npc.type != 6 && npc.type != 42 && npc.type != 94 && npc.type != 139 && npc.velocity.Y > 0f && num76 < 0f)
			{
				npc.velocity.Y = npc.velocity.Y - num74;
			}
		}
	}
	if (npc.type == Config.npcDefs.byName["Comet Tail"].type)
	{
		if (num75 > 0f)
		{
			npc.spriteDirection = 1;
			npc.rotation = (float)Math.Atan2((double)num76, (double)num75);
		}
		else
		{
			if (num75 < 0f)
			{
				npc.spriteDirection = -1;
				npc.rotation = (float)Math.Atan2((double)num76, (double)num75) + 3.14f;
			}
		}
	}
	else
	{
		if (npc.type == 139)
		{
			npc.localAI[0] += 1f;
			if (npc.justHit)
			{
				npc.localAI[0] = 0f;
			}
			if (Main.netMode != 1 && npc.localAI[0] >= 120f)
			{
				npc.localAI[0] = 0f;
				if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
				{
					int num79 = 25;
					int num80 = 84;
					Projectile.NewProjectile(vector11.X, vector11.Y, num75, num76, num80, num79, 0f, Main.myPlayer);
				}
			}
			int num81 = (int)npc.position.X + npc.width / 2;
			int num82 = (int)npc.position.Y + npc.height / 2;
			num81 /= 16;
			num82 /= 16;
			if (!WorldGen.SolidTile(num81, num82))
			{
				Lighting.addLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.3f, 0.1f, 0.05f);
			}
			if (num75 > 0f)
			{
				npc.spriteDirection = 1;
				npc.rotation = (float)Math.Atan2((double)num76, (double)num75);
			}
			if (num75 < 0f)
			{
				npc.spriteDirection = -1;
				npc.rotation = (float)Math.Atan2((double)num76, (double)num75) + 3.14f;
			}
		}
		else
		{
			if (npc.type == 6 || npc.type == 94)
			{
				npc.rotation = (float)Math.Atan2((double)num76, (double)num75) - 1.57f;
			}
			else
			{
				if (npc.type == 42)
				{
					if (num75 > 0f)
					{
						npc.spriteDirection = 1;
					}
					if (num75 < 0f)
												{
													npc.spriteDirection = -1;
												}
												npc.rotation = npc.velocity.X * 0.1f;
											}
											else
											{
												npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
											}
										}
									}
								}
								if (npc.type == 6 || npc.type == Config.npcDefs.byName["Comet Tail"].type || npc.type == 42 || npc.type == 94 || npc.type == 139)
								{
									float num83 = 0.7f;
									if (npc.type == 6)
									{
										num83 = 0.4f;
									}
									if (npc.collideX)
									{
										npc.netUpdate = true;
										npc.velocity.X = npc.oldVelocity.X * -num83;
										if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
										{
											npc.velocity.X = 2f;
										}
										if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
										{
											npc.velocity.X = -2f;
										}
									}
									if (npc.collideY)
									{
										npc.netUpdate = true;
										npc.velocity.Y = npc.oldVelocity.Y * -num83;
										if (npc.velocity.Y > 0f && (double)npc.velocity.Y < 1.5)
										{
											npc.velocity.Y = 2f;
										}
										if (npc.velocity.Y < 0f && (double)npc.velocity.Y > -1.5)
										{
											npc.velocity.Y = -2f;
										}
									}
									if (npc.type == Config.npcDefs.byName["Comet Tail"].type)
									{
										int num84 = Dust.NewDust(new Vector2(npc.position.X - npc.velocity.X, npc.position.Y - npc.velocity.Y), npc.width, npc.height, 15, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
										Main.dust[num84].noGravity = true;
										Dust expr_5A7E_cp_0 = Main.dust[num84];
										expr_5A7E_cp_0.velocity.X = expr_5A7E_cp_0.velocity.X * 0.3f;
										Dust expr_5A9C_cp_0 = Main.dust[num84];
										expr_5A9C_cp_0.velocity.Y = expr_5A9C_cp_0.velocity.Y * 0.3f;
									}
									else
									{
										if (npc.type != 42 && npc.type != 139 && Main.rand.Next(20) == 0)
										{
											int num85 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 15, npc.velocity.X, 2f, 75, npc.color, npc.scale);
											Dust expr_5B51_cp_0 = Main.dust[num85];
											expr_5B51_cp_0.velocity.X = expr_5B51_cp_0.velocity.X * 0.5f;
											Dust expr_5B6F_cp_0 = Main.dust[num85];
											expr_5B6F_cp_0.velocity.Y = expr_5B6F_cp_0.velocity.Y * 0.1f;
										}
									}
								}
								else
								{
									if (Main.rand.Next(40) == 0)
									{
										int num86 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 15, npc.velocity.X, 2f, 0, default(Color), 1f);
										Dust expr_5C0C_cp_0 = Main.dust[num86];
										expr_5C0C_cp_0.velocity.X = expr_5C0C_cp_0.velocity.X * 0.5f;
										Dust expr_5C2A_cp_0 = Main.dust[num86];
										expr_5C2A_cp_0.velocity.Y = expr_5C2A_cp_0.velocity.Y * 0.1f;
									}
								}
								if ((npc.type == 6 || npc.type == 94) && npc.wet)
								{
									if (npc.velocity.Y > 0f)
									{
										npc.velocity.Y = npc.velocity.Y * 0.95f;
									}
									npc.velocity.Y = npc.velocity.Y - 0.3f;
									if (npc.velocity.Y < -2f)
									{
										npc.velocity.Y = -2f;
									}
								}
								if (npc.type == 42)
								{
									if (npc.wet)
									{
										if (npc.velocity.Y > 0f)
										{
											npc.velocity.Y = npc.velocity.Y * 0.95f;
										}
										npc.velocity.Y = npc.velocity.Y - 0.5f;
										if (npc.velocity.Y < -4f)
										{
											npc.velocity.Y = -4f;
										}
										npc.TargetClosest(true);
									}
									if (npc.ai[1] == 101f)
									{
										Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 17);
										npc.ai[1] = 0f;
									}
									if (Main.netMode != 1)
									{
										npc.ai[1] += (float)Main.rand.Next(5, 20) * 0.1f * npc.scale;
										if (npc.ai[1] >= 130f)
										{
											if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
											{
												float num87 = 8f;
												Vector2 vector12 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)(npc.height / 2));
												float num88 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector12.X + (float)Main.rand.Next(-20, 21);
												float num89 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector12.Y + (float)Main.rand.Next(-20, 21);
												if ((num88 < 0f && npc.velocity.X < 0f) || (num88 > 0f && npc.velocity.X > 0f))
												{
													float num90 = (float)Math.Sqrt((double)(num88 * num88 + num89 * num89));
													num90 = num87 / num90;
													num88 *= num90;
													num89 *= num90;
													int num91 = (int)(13f * npc.scale);
													int num92 = 55;
													int num93 = Projectile.NewProjectile(vector12.X, vector12.Y, num88, num89, num92, num91, 0f, Main.myPlayer);
													Main.projectile[num93].timeLeft = 300;
													npc.ai[1] = 101f;
													npc.netUpdate = true;
												}
												else
												{
													npc.ai[1] = 0f;
												}
											}
											else
											{
												npc.ai[1] = 0f;
											}
										}
									}
								}
								if (npc.type == 139 && flag9)
								{
									if ((npc.velocity.X > 0f && num75 > 0f) || (npc.velocity.X < 0f && num75 < 0f))
									{
										if (Math.Abs(npc.velocity.X) < 12f)
										{
											npc.velocity.X = npc.velocity.X * 1.05f;
										}
									}
									else
									{
										npc.velocity.X = npc.velocity.X * 0.9f;
									}
								}
								if (Main.netMode != 1 && npc.type == 94 && !Main.player[npc.target].dead)
								{
									if (npc.justHit)
									{
										npc.localAI[0] = 0f;
									}
									npc.localAI[0] += 1f;
									if (npc.localAI[0] == 180f)
									{
										if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
										{
											NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2) + npc.velocity.X), (int)(npc.position.Y + (float)(npc.height / 2) + npc.velocity.Y), 112, 0);
										}
										npc.localAI[0] = 0f;
									}
								}
								if ((Main.dayTime && npc.type != 6 && npc.type != Config.npcDefs.byName["Comet Tail"].type && npc.type != 42 && npc.type != 94) || Main.player[npc.target].dead)
								{
									npc.velocity.Y = npc.velocity.Y - num74 * 2f;
									if (npc.timeLeft > 10)
									{
										npc.timeLeft = 10;
									}
								}
								if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
								{
									npc.netUpdate = true;
									return;
								}
							}
public void NPCLoot()
{
	int dust = Dust.NewDust(npc.position, npc.height, npc.width, 15, 0f, 0f, 100, new Color(), 1f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].velocity.X *= 0.5f;
	Main.dust[dust].velocity.Y *= 0.5f;
}