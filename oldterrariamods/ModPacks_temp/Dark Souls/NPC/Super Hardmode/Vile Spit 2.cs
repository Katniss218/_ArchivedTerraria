public void AI()
{
	if (npc.target == 255)
	{
		npc.TargetClosest(true);
		float num157 = 6f;
		if (npc.type == 25)
		{
			num157 = 5f;
		}
		if (npc.type == Config.npcDefs.byName["Vile Spit 2"].type)
		{
			num157 = 7f;
		}
		float modify = (npc.ai[3] == -1 ? -(1.57f / 2f) : (1.57f / 2f));
		Vector2 vector15 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
		float num158 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(Math.Cos(Main.player[npc.target].velocity.X + modify)) - vector15.X;
		float num159 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) + (float)(Math.Sin(Main.player[npc.target].velocity.Y + modify)) - vector15.Y;
		float num160 = (float)Math.Sqrt((double)(num158 * num158 + num159 * num159));
		num160 = num157 / num160;
		npc.velocity.X = num158 * num160;
		npc.velocity.Y = num159 * num160;
	}
	if (npc.type == Config.npcDefs.byName["Vile Spit 2"].type)
	{
		npc.ai[0] += 1f;
		if (npc.ai[0] > 3f)
		{
			npc.ai[0] = 3f;
		}
		if (npc.ai[0] == 2f)
		{
			npc.position += npc.velocity;
			Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 9);
			for (int num161 = 0; num161 < 20; num161++)
			{
				int num162 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 18, 0f, 0f, 100, default(Color), 1.8f);
				Main.dust[num162].velocity *= 1.3f;
				Main.dust[num162].velocity += npc.velocity;
				Main.dust[num162].noGravity = true;
			}
		}
	}
	if (npc.type == Config.npcDefs.byName["Vile Spit 2"].type && Collision.SolidCollision(npc.position, npc.width, npc.height))
	{
		if (Main.netMode != 1)
		{
			int num163 = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
			int num164 = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
			int num165 = 8;
			for (int num166 = num163 - num165; num166 <= num163 + num165; num166++)
			{
				for (int num167 = num164 - num165; num167 < num164 + num165; num167++)
				{
					if ((double)(Math.Abs(num166 - num163) + Math.Abs(num167 - num164)) < (double)num165 * 0.5)
					{
						if (Main.tile[num166, num167].type == 2)
						{
							Main.tile[num166, num167].type = 23;
							WorldGen.SquareTileFrame(num166, num167, true);
							if (Main.netMode == 2)
							{
								NetMessage.SendTileSquare(-1, num166, num167, 1);
							}
						}
						else
						{
							if (Main.tile[num166, num167].type == 1)
							{
								Main.tile[num166, num167].type = 25;
								WorldGen.SquareTileFrame(num166, num167, true);
								if (Main.netMode == 2)
								{
									NetMessage.SendTileSquare(-1, num166, num167, 1);
								}
							}
							else
							{
								if (Main.tile[num166, num167].type == 53)
								{
									Main.tile[num166, num167].type = 112;
									WorldGen.SquareTileFrame(num166, num167, true);
									if (Main.netMode == 2)
									{
										NetMessage.SendTileSquare(-1, num166, num167, 1);
									}
								}
								else
								{
									if (Main.tile[num166, num167].type == 109)
									{
										Main.tile[num166, num167].type = 23;
										WorldGen.SquareTileFrame(num166, num167, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendTileSquare(-1, num166, num167, 1);
										}
									}
									else
									{
										if (Main.tile[num166, num167].type == 117)
										{
											Main.tile[num166, num167].type = 25;
											WorldGen.SquareTileFrame(num166, num167, true);
											if (Main.netMode == 2)
											{
												NetMessage.SendTileSquare(-1, num166, num167, 1);
											}
										}
										else
										{
											if (Main.tile[num166, num167].type == 116)
											{
												Main.tile[num166, num167].type = 112;
												WorldGen.SquareTileFrame(num166, num167, true);
												if (Main.netMode == 2)
												{
													NetMessage.SendTileSquare(-1, num166, num167, 1);
												}
											}
											else if (Main.tile[num166, num167].type == 57)
											{
												Main.tile[num166, num167].type = 25;
												WorldGen.SquareTileFrame(num166, num167, true);
												if (Main.netMode == 2)
												{
													NetMessage.SendTileSquare(-1, num166, num167, 1);
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
		npc.StrikeNPC(999, 0f, 0, false, false);
	}
	if (npc.timeLeft > 100)
	{
		npc.timeLeft = 100;
	}
	for (int num168 = 0; num168 < 2; num168++)
	{
		if (npc.type == 30)
		{
			int num169 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 27, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
			Main.dust[num169].noGravity = true;
			Main.dust[num169].velocity *= 0.3f;
			Dust expr_A82B_cp_0 = Main.dust[num169];
			expr_A82B_cp_0.velocity.X = expr_A82B_cp_0.velocity.X - npc.velocity.X * 0.2f;
			Dust expr_A855_cp_0 = Main.dust[num169];
			expr_A855_cp_0.velocity.Y = expr_A855_cp_0.velocity.Y - npc.velocity.Y * 0.2f;
		}
		else
		{
			if (npc.type == 33)
			{
				int num170 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 29, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
				Main.dust[num170].noGravity = true;
				Dust expr_A90C_cp_0 = Main.dust[num170];
				expr_A90C_cp_0.velocity.X = expr_A90C_cp_0.velocity.X * 0.3f;
				Dust expr_A92A_cp_0 = Main.dust[num170];
				expr_A92A_cp_0.velocity.Y = expr_A92A_cp_0.velocity.Y * 0.3f;
			}
			else
			{
				if (npc.type == Config.npcDefs.byName["Vile Spit 2"].type)
				{
					int num171 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 18, npc.velocity.X * 0.1f, npc.velocity.Y * 0.1f, 80, default(Color), 1.3f);
					Main.dust[num171].velocity *= 0.3f;
					Main.dust[num171].noGravity = true;
				}
				else
				{
					Lighting.addLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 1f, 0.3f, 0.1f);
					int num172 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 6, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
					Main.dust[num172].noGravity = true;
					Dust expr_AABD_cp_0 = Main.dust[num172];
					expr_AABD_cp_0.velocity.X = expr_AABD_cp_0.velocity.X * 0.3f;
					Dust expr_AADB_cp_0 = Main.dust[num172];
					expr_AADB_cp_0.velocity.Y = expr_AADB_cp_0.velocity.Y * 0.3f;
				}
			}
		}
	}
	npc.rotation += 0.4f * (float)npc.direction;
	return;
}

public void DamagePlayer(Player player, ref int damage) //hook works!
{
	
	if (Main.rand.Next(2) == 0)
	{
                
		player.AddBuff(36, 600, false); //broken armor
        player.AddBuff(20, 3600, false); //poisoned
		player.AddBuff("Curse Buildup", 18000, false); //-20 life if counter hits 30
				
	}
    
	//	if (Main.rand.Next(20) == 0 && player.statLifeMax > 20) 

	//{

	//			Main.NewText("You have been cursed!");
	//	player.statLifeMax -= 20;
	//}
}