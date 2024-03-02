int breathCD = 45;
//int previous = 0;
bool
    breath = false,
    tailD = false;
public void AI()
{
	if (npc.type == 117 && npc.localAI[1] == 0f)
	{
		npc.localAI[1] = 1f;
		Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 13);
		int num94 = 1;
		if (npc.velocity.X < 0f)
		{
			num94 = -1;
		}
		for (int num95 = 0; num95 < 20; num95++)
		{
			Dust.NewDust(new Vector2(npc.position.X - 20f, npc.position.Y - 20f), npc.width + 40, npc.height + 40, 5, (float)(num94 * 8), -1f, 0, default(Color), 1f);
		}
	}
	if (npc.type >= 13 && npc.type <= 15)
	{
		npc.realLife = -1;
	}
	else
	{
		if (npc.ai[3] > 0f)
		{
			npc.realLife = (int)npc.ai[3];
		}
	}
	if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
	{
		npc.TargetClosest(true);
	}
	if (Main.player[npc.target].dead && npc.timeLeft > 300)
	{
		npc.timeLeft = 300;
	}
	if (Main.netMode != 1)
	{
		if (npc.type == Config.npcDefs.byName["Dragon Lord Head"].type && npc.ai[0] == 0f)
		{
			npc.ai[3] = (float)npc.whoAmI;
			npc.realLife = npc.whoAmI;
			int num96 = npc.whoAmI;
			for (int num97 = 0; num97 < 14; num97++)
			{
				int num98 = Config.npcDefs.byName["Dragon Lord Body"].type;
				if (num97 == 1 || num97 == 8)
				{
					num98 = Config.npcDefs.byName["Dragon Lord Legs"].type;
				}
				else
				{
					if (num97 == 11)
					{
						num98 = Config.npcDefs.byName["Dragon Lord Body 2"].type;
					}
					else
					{
						if (num97 == 12)
						{
							num98 = Config.npcDefs.byName["Dragon Lord Body 3"].type;
						}
						else
						{
							if (num97 == 13)
							{
								num98 = Config.npcDefs.byName["Dragon Lord Tail"].type;
							}
						}
					}
				}
				int num99 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), num98, npc.whoAmI);
				Main.npc[num99].ai[2] = (float)npc.whoAmI;
				Main.npc[num99].realLife = npc.whoAmI;
				Main.npc[num99].ai[1] = (float)num96;
				Main.npc[num96].ai[0] = (float)num99;
				NetMessage.SendData(23, -1, -1, "", num99, 0f, 0f, 0f, 0);
				num96 = num99;
			}
		}
		if ((npc.type == 7 || npc.type == 8 || npc.type == 10 || npc.type == 11 || npc.type == 13 || npc.type == 14 || npc.type == 39 || npc.type == 40 || npc.type == 95 || npc.type == 96 || npc.type == 98 || npc.type == 99 || npc.type == 117 || npc.type == 118) && npc.ai[0] == 0f)
		{
			if (npc.type == 7 || npc.type == 10 || npc.type == 13 || npc.type == 39 || npc.type == 95 || npc.type == 98 || npc.type == 117)
			{
				if (npc.type < 13 || npc.type > 15)
				{
					npc.ai[3] = (float)npc.whoAmI;
					npc.realLife = npc.whoAmI;
				}
				npc.ai[2] = (float)Main.rand.Next(8, 13);
				if (npc.type == 10)
				{
					npc.ai[2] = (float)Main.rand.Next(4, 7);
				}
				if (npc.type == 13)
				{
					npc.ai[2] = (float)Main.rand.Next(45, 56);
				}
				if (npc.type == 39)
				{
					npc.ai[2] = (float)Main.rand.Next(12, 19);
				}
				if (npc.type == 95)
				{
					npc.ai[2] = (float)Main.rand.Next(6, 12);
				}
				if (npc.type == 98)
				{
					npc.ai[2] = (float)Main.rand.Next(20, 26);
				}
				if (npc.type == 117)
				{
					npc.ai[2] = (float)Main.rand.Next(3, 6);
				}
				npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), npc.type + 1, npc.whoAmI);
			}
			else
			{
				if ((npc.type == 8 || npc.type == 11 || npc.type == 14 || npc.type == 40 || npc.type == 96 || npc.type == 99 || npc.type == 118) && npc.ai[2] > 0f)
				{
					npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), npc.type, npc.whoAmI);
				}
				else
				{
					npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), npc.type + 1, npc.whoAmI);
				}
			}
			if (npc.type < 13 || npc.type > 15)
			{
				Main.npc[(int)npc.ai[0]].ai[3] = npc.ai[3];
				Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
			}
			Main.npc[(int)npc.ai[0]].ai[1] = (float)npc.whoAmI;
			Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1f;
			npc.netUpdate = true;
		}
		if ((npc.type == 8 || npc.type == 9 || npc.type == 11 || npc.type == 12 || npc.type == 40 || npc.type == 41 || npc.type == 96 || npc.type == 97 || npc.type == 99 || npc.type == 100 || (npc.type > 87 && npc.type <= 92) || npc.type == 118 || npc.type == 119) && (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].aiStyle != npc.aiStyle))
		{
			npc.life = 0;
			npc.HitEffect(0, 10.0);
			npc.active = false;
		}
		if ((npc.type == 7 || npc.type == 8 || npc.type == 10 || npc.type == 11 || npc.type == 39 || npc.type == 40 || npc.type == 95 || npc.type == 96 || npc.type == 98 || npc.type == 99 || (npc.type >= 87 && npc.type < 92) || npc.type == 117 || npc.type == 118) && (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].aiStyle != npc.aiStyle))
		{
			npc.life = 0;
			npc.HitEffect(0, 10.0);
			npc.active = false;
		}
		if (npc.type == 13 || npc.type == 14 || npc.type == 15)
		{
			if (!Main.npc[(int)npc.ai[1]].active && !Main.npc[(int)npc.ai[0]].active)
			{
				npc.life = 0;
				npc.HitEffect(0, 10.0);
				npc.active = false;
			}
			if (npc.life == 0)
			{
				bool flag10 = true;
				for (int num106 = 0; num106 < 200; num106++)
				{
					if (Main.npc[num106].active && (Main.npc[num106].type == 13 || Main.npc[num106].type == 14 || Main.npc[num106].type == 15))
					{
						flag10 = false;
						break;
					}
				}
				if (flag10)
				{
					npc.boss = true;
					npc.NPCLoot();
				}
			}
		}
		if (!npc.active && Main.netMode == 2)
		{
			NetMessage.SendData(28, -1, -1, "", npc.whoAmI, -1f, 0f, 0f, 0);
		}
	}
	int num107 = (int)(npc.position.X / 16f) - 1;
	int num108 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
	int num109 = (int)(npc.position.Y / 16f) - 1;
	int num110 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
	if (num107 < 0)
	{
		num107 = 0;
	}
	if (num108 > Main.maxTilesX)
	{
		num108 = Main.maxTilesX;
	}
	if (num109 < 0)
	{
		num109 = 0;
	}
	if (num110 > Main.maxTilesY)
	{
		num110 = Main.maxTilesY;
	}
	bool flag11 = false;
	if (npc.type >= Config.npcDefs.byName["Dragon Lord Body 2"].type && npc.type <= Config.npcDefs.byName["Dragon Lord Tail"].type)
	{
		flag11 = true;
	}
	if (!flag11)
	{
		for (int num111 = num107; num111 < num108; num111++)
		{
			for (int num112 = num109; num112 < num110; num112++)
			{
				if (Main.tile[num111, num112] != null && ((Main.tile[num111, num112].active && (Main.tileSolid[(int)Main.tile[num111, num112].type] || (Main.tileSolidTop[(int)Main.tile[num111, num112].type] && Main.tile[num111, num112].frameY == 0))) || Main.tile[num111, num112].liquid > 64))
				{
					Vector2 vector13;
					vector13.X = (float)(num111 * 16);
					vector13.Y = (float)(num112 * 16);
					if (npc.position.X + (float)npc.width > vector13.X && npc.position.X < vector13.X + 16f && npc.position.Y + (float)npc.height > vector13.Y && npc.position.Y < vector13.Y + 16f)
					{
						flag11 = true;
						if (Main.rand.Next(100) == 0 && npc.type != 117 && Main.tile[num111, num112].active)
						{
							WorldGen.KillTile(num111, num112, true, true, false);
						}
						if (Main.netMode != 1 && Main.tile[num111, num112].type == 2)
						{
							byte arg_6FE2_0 = (byte)Main.tile[num111, num112 - 1].type;
						}
					}
				}
			}
		}
	}
	if (!flag11 && (npc.type == 7 || npc.type == 10 || npc.type == 13 || npc.type == 39 || npc.type == 95 || npc.type == 98 || npc.type == 117))
	{
		Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
		int num113 = 1000;
		bool flag12 = true;
		for (int num114 = 0; num114 < 255; num114++)
		{
			if (Main.player[num114].active)
			{
				Rectangle rectangle2 = new Rectangle((int)Main.player[num114].position.X - num113, (int)Main.player[num114].position.Y - num113, num113 * 2, num113 * 2);
				if (rectangle.Intersects(rectangle2))
				{
					flag12 = false;
					break;
				}
			}
		}
		if (flag12)
		{
			flag11 = true;
		}
	}
	if (npc.type >= Config.npcDefs.byName["Dragon Lord Body 2"].type && npc.type <= Config.npcDefs.byName["Dragon Lord Tail"].type)
	{
		if (npc.velocity.X < 0f)
		{
			npc.spriteDirection = 1;
		}
		else
		{
			if (npc.velocity.X > 0f)
			{
				npc.spriteDirection = -1;
			}
		}
	}
	float num115 = 8f;
	float num116 = 0.07f;
	if (npc.type == 95)
	{
		num115 = 5.5f;
		num116 = 0.045f;
	}
	if (npc.type == 10)
	{
		num115 = 6f;
		num116 = 0.05f;
	}
	if (npc.type == 13)
	{
		num115 = 10f;
		num116 = 0.07f;
	}
	if (npc.type == Config.npcDefs.byName["Dragon Lord Head"].type)
	{
		num115 = 15f;
		num116 = 0.25f;
	}
	if (npc.type == 117 && Main.wof >= 0)
	{
		float num117 = (float)Main.npc[Main.wof].life / (float)Main.npc[Main.wof].lifeMax;
		if ((double)num117 < 0.5)
		{
			num115 += 1f;
			num116 += 0.1f;
		}
		if ((double)num117 < 0.25)
		{
			num115 += 1f;
			num116 += 0.1f;
		}
		if ((double)num117 < 0.1)
		{
			num115 += 2f;
			num116 += 0.1f;
		}
	}
	Vector2 vector14 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
	float num118 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
	float num119 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
	num118 = (float)((int)(num118 / 16f) * 16);
	num119 = (float)((int)(num119 / 16f) * 16);
	vector14.X = (float)((int)(vector14.X / 16f) * 16);
	vector14.Y = (float)((int)(vector14.Y / 16f) * 16);
	num118 -= vector14.X;
	num119 -= vector14.Y;
	float num120 = (float)Math.Sqrt((double)(num118 * num118 + num119 * num119));
	if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
	{
		try
		{
			vector14 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
			num118 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector14.X;
			num119 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector14.Y;
		}
		catch
		{
		}
		npc.rotation = (float)Math.Atan2((double)num119, (double)num118) + 1.57f;
		num120 = (float)Math.Sqrt((double)(num118 * num118 + num119 * num119));
		int num121 = npc.width;
		if (npc.type >= Config.npcDefs.byName["Dragon Lord Body 2"].type && npc.type <= Config.npcDefs.byName["Dragon Lord Tail"].type)
		{
			num121 = 42;
		}
		num120 = (num120 - (float)num121) / num120;
		num118 *= num120;
		num119 *= num120;
		npc.velocity = default(Vector2);
		npc.position.X = npc.position.X + num118;
		npc.position.Y = npc.position.Y + num119;
		if (npc.type >= Config.npcDefs.byName["Dragon Lord Body 2"].type && npc.type <= Config.npcDefs.byName["Dragon Lord Tail"].type)
		{
			if (num118 < 0f)
			{
				npc.spriteDirection = 1;
				return;
			}
			if (num118 > 0f)
			{
				npc.spriteDirection = -1;
				return;
			}
		}
	}
	else
	{
		if (!flag11)
		{
			npc.TargetClosest(true);
			npc.velocity.Y = npc.velocity.Y + 0.11f;
			if (npc.velocity.Y > num115)
			{
				npc.velocity.Y = num115;
			}
			if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num115 * 0.4)
			{
				if (npc.velocity.X < 0f)
				{
					npc.velocity.X = npc.velocity.X - num116 * 1.1f;
				}
				else
				{
					npc.velocity.X = npc.velocity.X + num116 * 1.1f;
				}
			}
			else
			{
				if (npc.velocity.Y == num115)
				{
					if (npc.velocity.X < num118)
					{
						npc.velocity.X = npc.velocity.X + num116;
					}
					else
					{
						if (npc.velocity.X > num118)
						{
							npc.velocity.X = npc.velocity.X - num116;
						}
					}
				}
				else
				{
					if (npc.velocity.Y > 4f)
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X + num116 * 0.9f;
						}
						else
						{
							npc.velocity.X = npc.velocity.X - num116 * 0.9f;
						}
					}
				}
			}
		}
		else
		{
			if (npc.type != Config.npcDefs.byName["Dragon Lord Head"].type && npc.type != 117 && npc.soundDelay == 0)
			{
				float num122 = num120 / 40f;
				if (num122 < 10f)
				{
					num122 = 10f;
				}
				if (num122 > 20f)
				{
					num122 = 20f;
				}
				npc.soundDelay = (int)num122;
				//Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 1);
			}
			num120 = (float)Math.Sqrt((double)(num118 * num118 + num119 * num119));
			float num123 = Math.Abs(num118);
			float num124 = Math.Abs(num119);
			float num125 = num115 / num120;
			num118 *= num125;
			num119 *= num125;
			if ((npc.type == 13 || npc.type == 7) && !Main.player[npc.target].zoneEvil)
			{
				bool flag13 = true;
				for (int num126 = 0; num126 < 255; num126++)
				{
					if (Main.player[num126].active && !Main.player[num126].dead && Main.player[num126].zoneEvil)
					{
						flag13 = false;
					}
				}
				if (flag13)
				{
					if (Main.netMode != 1 && (double)(npc.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
					{
						npc.active = false;
						int num127 = (int)npc.ai[0];
						while (num127 > 0 && num127 < 200 && Main.npc[num127].active && Main.npc[num127].aiStyle == npc.aiStyle)
						{
							int num128 = (int)Main.npc[num127].ai[0];
							Main.npc[num127].active = false;
							npc.life = 0;
							if (Main.netMode == 2)
							{
								NetMessage.SendData(23, -1, -1, "", num127, 0f, 0f, 0f, 0);
							}
							num127 = num128;
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
						}
					}
					num118 = 0f;
					num119 = num115;
				}
			}
			bool flag14 = false;
			if (npc.type == Config.npcDefs.byName["Dragon Lord Head"].type)
			{
				if (((npc.velocity.X > 0f && num118 < 0f) || (npc.velocity.X < 0f && num118 > 0f) || (npc.velocity.Y > 0f && num119 < 0f) || (npc.velocity.Y < 0f && num119 > 0f)) && Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) > num116 / 2f && num120 < 300f)
				{
					flag14 = true;
					if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num115)
					{
						npc.velocity *= 1.1f;
					}
				}
				if (npc.position.Y > Main.player[npc.target].position.Y || (double)(Main.player[npc.target].position.Y / 16f) > Main.worldSurface || Main.player[npc.target].dead)
				{
					flag14 = true;
					if (Math.Abs(npc.velocity.X) < num115 / 2f)
					{
						if (npc.velocity.X == 0f)
						{
							npc.velocity.X = npc.velocity.X - (float)npc.direction;
						}
						npc.velocity.X = npc.velocity.X * 1.1f;
					}
					else
					{
						if (npc.velocity.Y > -num115)
						{
							npc.velocity.Y = npc.velocity.Y - num116;
						}
					}
				}
			}
			if (!flag14)
			{
				if ((npc.velocity.X > 0f && num118 > 0f) || (npc.velocity.X < 0f && num118 < 0f) || (npc.velocity.Y > 0f && num119 > 0f) || (npc.velocity.Y < 0f && num119 < 0f))
				{
					if (npc.velocity.X < num118)
					{
						npc.velocity.X = npc.velocity.X + num116;
					}
					else
					{
						if (npc.velocity.X > num118)
						{
							npc.velocity.X = npc.velocity.X - num116;
						}
					}
					if (npc.velocity.Y < num119)
					{
						npc.velocity.Y = npc.velocity.Y + num116;
					}
					else
					{
						if (npc.velocity.Y > num119)
						{
							npc.velocity.Y = npc.velocity.Y - num116;
						}
					}
					if ((double)Math.Abs(num119) < (double)num115 * 0.2 && ((npc.velocity.X > 0f && num118 < 0f) || (npc.velocity.X < 0f && num118 > 0f)))
					{
						if (npc.velocity.Y > 0f)
						{
							npc.velocity.Y = npc.velocity.Y + num116 * 2f;
						}
						else
						{
							npc.velocity.Y = npc.velocity.Y - num116 * 2f;
						}
					}
					if ((double)Math.Abs(num118) < (double)num115 * 0.2 && ((npc.velocity.Y > 0f && num119 < 0f) || (npc.velocity.Y < 0f && num119 > 0f)))
					{
						if (npc.velocity.X > 0f)
						{
							npc.velocity.X = npc.velocity.X + num116 * 2f;
						}
						else
						{
							npc.velocity.X = npc.velocity.X - num116 * 2f;
						}
					}
				}
				else
				{
					if (num123 > num124)
					{
						if (npc.velocity.X < num118)
						{
							npc.velocity.X = npc.velocity.X + num116 * 1.1f;
						}
						else
						{
							if (npc.velocity.X > num118)
							{
								npc.velocity.X = npc.velocity.X - num116 * 1.1f;
							}
						}
						if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num115 * 0.5)
						{
							if (npc.velocity.Y > 0f)
							{
								npc.velocity.Y = npc.velocity.Y + num116;
							}
							else
							{
								npc.velocity.Y = npc.velocity.Y - num116;
							}
						}
					}
					else
					{
						if (npc.velocity.Y < num119)
						{
							npc.velocity.Y = npc.velocity.Y + num116 * 1.1f;
						}
						else
						{
							if (npc.velocity.Y > num119)
							{
								npc.velocity.Y = npc.velocity.Y - num116 * 1.1f;
							}
						}
						if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num115 * 0.5)
						{
							if (npc.velocity.X > 0f)
							{
								npc.velocity.X = npc.velocity.X + num116;
							}
							else
							{
								npc.velocity.X = npc.velocity.X - num116;
							}
						}
					}
				}
			}
		}
		npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
		if (npc.type == 7 || npc.type == 10 || npc.type == 13 || npc.type == 39 || npc.type == 95 || npc.type == 98 || npc.type == 117)
		{
			if (flag11)
			{
				if (npc.localAI[0] != 1f)
				{
					npc.netUpdate = true;
				}
				npc.localAI[0] = 1f;
			}
			else
			{
				if (npc.localAI[0] != 0f)
				{
					npc.netUpdate = true;
				}
				npc.localAI[0] = 0f;
			}
			if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
			{
				npc.netUpdate = true;
				return;
			}
		}
	}
    Player nT = Main.player[npc.target];
    if (Main.rand.Next(275) == 0) {
        breath = true;
        Main.PlaySound(15, -1, -1, 0);
    }
    if (breath) {
        //while (breathCD > 0) {
        //for (int pcy = 0; pcy < 10; pcy++) {
            Projectile.NewProjectile(npc.position.X + (float)npc.width / 2f, npc.position.Y + (float)npc.height / 2f, npc.velocity.X * 3f + (float)Main.rand.Next(-2, 3), npc.velocity.Y * 3f + (float)Main.rand.Next(-2, 3), Config.projDefs.byName["Dragon's Breath"].type, 75, 1.2f, 255);
        //}
        breathCD--;
        //}
    }
    if (breathCD <= 0) {
        breath = false;
        breathCD = 90;
        Main.PlaySound(15, -1, -1, 0);
    }
    if (Main.rand.Next(333) == 0) {
        for (int pcy = 0; pcy < 10; pcy++) {
	        Projectile.NewProjectile((float)nT.position.X - 100 + Main.rand.Next(200), (float)nT.position.Y - 500f, (float)(-40 + Main.rand.Next(80)) / 10, 14.9f, Config.projDefs.byName["Flame Rain"].type, 64, 2f, 255);
            Main.PlaySound(15, -1, -1, 0);
        }
    }
    if (Main.rand.Next(660) == 0) {
        for (int pcy = 0; pcy < 10; pcy++) {
	        Projectile.NewProjectile((float)nT.position.X - 100 + Main.rand.Next(200), (float)nT.position.Y - 500f, (float)(-40 + Main.rand.Next(80)) / 10, 14.9f, Config.projDefs.byName["Dragon Meteor"].type, 80, 2f, 255);
            Main.PlaySound(15, -1, -1, 0);
        }
    }
}
public void NPCLoot()
{
    npc.netUpdate = true;
	//ModWorld.Freeze();
}