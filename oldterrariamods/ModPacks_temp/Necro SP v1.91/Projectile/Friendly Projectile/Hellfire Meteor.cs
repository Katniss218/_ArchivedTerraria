public void AI()
{
	if (projectile.light > 0f)
	{
		Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.light, projectile.light * 0.8f, projectile.light * 0.6f);
	}
	int num10 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1f);
	if (Main.rand.Next(2) == 0)
	{
		Main.dust[num10].noGravity = true;
		Main.dust[num10].scale *= 2f;
	}
	int num11 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
	if (Main.rand.Next(2) == 0)
	{
		Main.dust[num11].noGravity = true;
		Main.dust[num11].scale *= 2f;
	}
	projectile.AI(true);
}

public void Kill()
{
	for (int num61 = 0; num61 < 10; num61++)
	{
		Color newColor = default(Color);
		Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, newColor, 1.5f);
	}
	for (int num62 = 0; num62 < 5; num62++)
	{
		Color newColor = default(Color);
		int num63 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, newColor, 2.5f);
		Main.dust[num63].noGravity = true;
		Dust expr_1D3F = Main.dust[num63];
		expr_1D3F.velocity *= 3f;
		newColor = default(Color);
		num63 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, newColor, 1.5f);
		Dust expr_1DA6 = Main.dust[num63];
		expr_1DA6.velocity *= 2f;
	}
	Vector2 arg_1E01_0 = new Vector2(projectile.position.X, projectile.position.Y);
	Vector2 vector2 = default(Vector2);
	int num64 = Gore.NewGore(arg_1E01_0, vector2, Main.rand.Next(61, 64), 1f);
	Gore expr_1E10 = Main.gore[num64];
	expr_1E10.velocity *= 0.4f;
	Gore expr_1E32_cp_0 = Main.gore[num64];
	expr_1E32_cp_0.velocity.X = expr_1E32_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
	Gore expr_1E60_cp_0 = Main.gore[num64];
	expr_1E60_cp_0.velocity.Y = expr_1E60_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
	Vector2 arg_1EB9_0 = new Vector2(projectile.position.X, projectile.position.Y);
	vector2 = default(Vector2);
	num64 = Gore.NewGore(arg_1EB9_0, vector2, Main.rand.Next(61, 64), 1f);
	Gore expr_1EC8 = Main.gore[num64];
	expr_1EC8.velocity *= 0.4f;
	Gore expr_1EEA_cp_0 = Main.gore[num64];
	expr_1EEA_cp_0.velocity.X = expr_1EEA_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
	Gore expr_1F18_cp_0 = Main.gore[num64];
	expr_1F18_cp_0.velocity.Y = expr_1F18_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
	if (projectile.owner == Main.myPlayer)
	{
		projectile.penetrate = -1;
		projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
		projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
		projectile.width = 64;
		projectile.height = 64;
		projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
		projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
		Rectangle rectangle = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
		if (projectile.friendly)
		{
			int myPlayer = Main.myPlayer;
			if (Main.player[myPlayer].active && !Main.player[myPlayer].dead && !Main.player[myPlayer].immune && (!projectile.ownerHitCheck || Collision.CanHit(Main.player[projectile.owner].position, Main.player[projectile.owner].width, Main.player[projectile.owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
			{
				Rectangle value = new Rectangle((int)Main.player[myPlayer].position.X, (int)Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
				if (rectangle.Intersects(value))
				{
					if (Main.player[myPlayer].position.X + (float)(Main.player[myPlayer].width / 2) < projectile.position.X + (float)(projectile.width / 2))
					{
						projectile.direction = -1;
					}
					else
					{
						projectile.direction = 1;
					}
					int num2 = Main.DamageVar((float)projectile.damage);
					projectile.StatusPlayer(myPlayer);
					Main.player[myPlayer].Hurt(num2, projectile.direction, true, false, " was slain...", false);
					//Lang.deathMsg(projectile.owner, -1, projectile.whoAmI, -1)
					if (Main.netMode != 0)
					{
						NetMessage.SendData(26, -1, -1, " was slain...", myPlayer, (float)projectile.direction, (float)num2, 1f, 0);
					}
				}
			}
			int num3 = (int)(projectile.position.X / 16f);
			int num4 = (int)((projectile.position.X + (float)projectile.width) / 16f) + 1;
			int num5 = (int)(projectile.position.Y / 16f);
			int num6 = (int)((projectile.position.Y + (float)projectile.height) / 16f) + 1;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY;
			}
			for (int i = num3; i < num4; i++)
			{
				for (int j = num5; j < num6; j++)
				{
					if (Main.tile[i, j] != null && Main.tileCut[(int)Main.tile[i, j].type] && Main.tile[i, j + 1] != null && Main.tile[i, j + 1].type != 78)
					{
						WorldGen.KillTile(i, j, false, false, false);
						if (Main.netMode != 0)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0f, 0);
						}
					}
				}
			}
		}
		if (projectile.damage > 0)
		{
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && (((!Main.npc[k].friendly || (Main.npc[k].type == 22 && projectile.owner < 255 && Main.player[projectile.owner].killGuide)) && projectile.friendly) || (Main.npc[k].friendly && projectile.hostile)) && (projectile.owner < 0 || Main.npc[k].immune[projectile.owner] == 0))
				{
					if (Main.npc[k].noTileCollide || !projectile.ownerHitCheck || Collision.CanHit(Main.player[projectile.owner].position, Main.player[projectile.owner].width, Main.player[projectile.owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height))
					{
						Rectangle value2 = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
						if (rectangle.Intersects(value2))
						{
							if (projectile.timeLeft > 1)
							{
								projectile.timeLeft = 1;
							}
							bool flag2 = false;
							if (projectile.melee && Main.rand.Next(1, 101) <= Main.player[projectile.owner].meleeCrit)
							{
								flag2 = true;
							}
							if (projectile.ranged && Main.rand.Next(1, 101) <= Main.player[projectile.owner].rangedCrit)
							{
								flag2 = true;
							}
							if (projectile.magic && Main.rand.Next(1, 101) <= Main.player[projectile.owner].magicCrit)
							{
								flag2 = true;
							}
							int num7 = Main.DamageVar((float)projectile.damage);
							projectile.StatusNPC(k);
							Main.npc[k].StrikeNPC(num7, projectile.knockBack, projectile.direction, flag2, false);
							if (Main.netMode != 0)
							{
								if (flag2)
								{
									NetMessage.SendData(28, -1, -1, "", k, (float)num7, projectile.knockBack, (float)projectile.direction, 1);
								}
								else
								{
									NetMessage.SendData(28, -1, -1, "", k, (float)num7, projectile.knockBack, (float)projectile.direction, 0);
								}
							}
							if (projectile.penetrate != 1)
							{
								Main.npc[k].immune[projectile.owner] = 10;
							}
							if (projectile.penetrate > 0)
							{
								projectile.penetrate--;
								if (projectile.penetrate == 0)
								{
									break;
								}
							}
						}
					}
				}
			}
		}
		if (projectile.damage > 0 && Main.player[Main.myPlayer].hostile)
		{
			for (int l = 0; l < 255; l++)
			{
				if (l != projectile.owner && Main.player[l].active && !Main.player[l].dead && !Main.player[l].immune && Main.player[l].hostile && projectile.playerImmune[l] <= 0 && (Main.player[Main.myPlayer].team == 0 || Main.player[Main.myPlayer].team != Main.player[l].team) && (!projectile.ownerHitCheck || Collision.CanHit(Main.player[projectile.owner].position, Main.player[projectile.owner].width, Main.player[projectile.owner].height, Main.player[l].position, Main.player[l].width, Main.player[l].height)))
				{
					Rectangle value3 = new Rectangle((int)Main.player[l].position.X, (int)Main.player[l].position.Y, Main.player[l].width, Main.player[l].height);
					if (rectangle.Intersects(value3))
					{
						if (projectile.timeLeft > 1)
						{
							projectile.timeLeft = 1;
						}
						bool flag3 = false;
						if (projectile.melee && Main.rand.Next(1, 101) <= Main.player[projectile.owner].meleeCrit)
						{
							flag3 = true;
						}
						int num8 = Main.DamageVar((float)projectile.damage);
						if (!Main.player[l].immune)
						{
							projectile.StatusPvP(l);
						}
						Main.player[l].Hurt(num8, projectile.direction, true, false, " was slain...", flag3);
						if (Main.netMode != 0)
						{
							if (flag3)
							{
								NetMessage.SendData(26, -1, -1, " was slain...", l, (float)projectile.direction, (float)num8, 1f, 1);
							}
							else
							{
								NetMessage.SendData(26, -1, -1, " was slain...", l, (float)projectile.direction, (float)num8, 1f, 0);
							}
						}
						projectile.playerImmune[l] = 40;
						if (projectile.penetrate > 0)
						{
							projectile.penetrate--;
							if (projectile.penetrate == 0)
							{
								break;
							}
						}
					}
				}
			}
		}
		if (Main.netMode != 2 && projectile.hostile && Main.myPlayer < 255 && projectile.damage > 0)
		{
			int myPlayer2 = Main.myPlayer;
			if (Main.player[myPlayer2].active && !Main.player[myPlayer2].dead && !Main.player[myPlayer2].immune)
			{
				Rectangle value6 = new Rectangle((int)Main.player[myPlayer2].position.X, (int)Main.player[myPlayer2].position.Y, Main.player[myPlayer2].width, Main.player[myPlayer2].height);
				if (rectangle.Intersects(value6))
				{
					int hitDirection = projectile.direction;
					if (Main.player[myPlayer2].position.X + (float)(Main.player[myPlayer2].width / 2) < projectile.position.X + (float)(projectile.width / 2))
					{
						hitDirection = -1;
					}
					else
					{
						hitDirection = 1;
					}
					int num9 = Main.DamageVar((float)projectile.damage);
					if (!Main.player[myPlayer2].immune)
					{
						projectile.StatusPlayer(myPlayer2);
					}
					Main.player[myPlayer2].Hurt(num9 * 2, hitDirection, false, false, " was slain...", false);
					//Lang.deathMsg(-1, -1, projectile.whoAmI, -1)
				}
			}
		}
	}
	projectile.active = false;
}

public static void DealtNPC(NPC npc, double damage, Player player)
{
	for (int num25 = 0; num25 < 1000; num25++)
	{
		if (Main.projectile[num25].active && Main.projectile[num25].type == Config.projDefs.byName["Hellfire Meteor"].type && Main.myPlayer == Main.projectile[num25].owner)
		{
			int num10 = Projectile.NewProjectile(Main.projectile[num25].position.X, Main.projectile[num25].position.Y, 0, 0, Config.projDefs.byName["Hellfire Meteor"].type, 0, 255f, Main.myPlayer);
			Main.projectile[num10].Kill();
		}
	}
}

public static void DealtPVP(double damage, Player enemyPlayer) 
{
	for (int num25 = 0; num25 < 1000; num25++)
	{
		if (Main.projectile[num25].active && Main.projectile[num25].type == Config.projDefs.byName["Hellfire Meteor"].type && Main.myPlayer == Main.projectile[num25].owner)
		{
			int num10 = Projectile.NewProjectile(Main.projectile[num25].position.X, Main.projectile[num25].position.Y, 0, 0, Config.projDefs.byName["Hellfire Meteor"].type, 0, 255f, Main.myPlayer);
			Main.projectile[num10].Kill();
		}
	}
}