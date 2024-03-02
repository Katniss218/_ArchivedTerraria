public void AI()
{
	if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
	{
		projectile.alpha = 255;
	}
	if (projectile.ai[1] < 0f)
	{
		if (projectile.velocity.X > 0f)
		{
			projectile.rotation += 0.3f;
		}
		else
		{
			projectile.rotation -= 0.3f;
		}
		int num125 = (int)(projectile.position.X / 16f) - 1;
		int num126 = (int)((projectile.position.X + (float)projectile.width) / 16f) + 2;
		int num127 = (int)(projectile.position.Y / 16f) - 1;
		int num128 = (int)((projectile.position.Y + (float)projectile.height) / 16f) + 2;
		if (num125 < 0)
		{
			num125 = 0;
		}
		if (num126 > Main.maxTilesX)
		{
			num126 = Main.maxTilesX;
		}
		if (num127 < 0)
		{
			num127 = 0;
		}
		if (num128 > Main.maxTilesY)
		{
			num128 = Main.maxTilesY;
		}
		int num129 = (int)projectile.position.X + 4;
		int num130 = (int)projectile.position.Y + 4;
		for (int num131 = num125; num131 < num126; num131++)
		{
			for (int num132 = num127; num132 < num128; num132++)
			{
				if (Main.tile[num131, num132] != null && Main.tile[num131, num132].active && Main.tile[num131, num132].type != (ushort)Config.tileDefs.ID["Obsidian 2"] && Main.tileSolid[(int)Main.tile[num131, num132].type] && !Main.tileSolidTop[(int)Main.tile[num131, num132].type])
				{
					Vector2 vector15;
					vector15.X = (float)(num131 * 16);
					vector15.Y = (float)(num132 * 16);
					if ((float)(num129 + 8) > vector15.X && (float)num129 < vector15.X + 16f && (float)(num130 + 8) > vector15.Y && (float)num130 < vector15.Y + 16f)
					{
						projectile.Kill();
					}
				}
			}
		}
		int num133 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, 0f, 0f, 0, default(Color), 1f);
		Main.dust[num133].noGravity = true;
		Main.dust[num133].velocity *= 0.3f;
		return;
	}
	if (projectile.ai[0] < 0f)
	{
		if (projectile.ai[0] == -1f)
		{
			for (int num134 = 0; num134 < 10; num134++)
			{
				int num135 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, 0f, 0f, 0, default(Color), 1.1f);
				Main.dust[num135].noGravity = true;
				Main.dust[num135].velocity *= 1.3f;
			}
		}
		else
		{
			if (Main.rand.Next(30) == 0)
			{
				int num136 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num136].velocity *= 0.2f;
			}
		}
		int num137 = (int)projectile.position.X / 16;
		int num138 = (int)projectile.position.Y / 16;
		if (Main.tile[num137, num138] == null || !Main.tile[num137, num138].active)
		{
			projectile.Kill();
		}
		projectile.ai[0] -= 1f;
		if (projectile.ai[0] <= -300f && (Main.myPlayer == projectile.owner || Main.netMode == 2) && Main.tile[num137, num138].active && Main.tile[num137, num138].type == (ushort)Config.tileDefs.ID["Obsidian 2"])
		{
			WorldGen.KillTile(num137, num138, false, false, false);
			if (Main.netMode == 1)
			{
				NetMessage.SendData(17, -1, -1, "", 0, (float)num137, (float)num138, 0f, 0);
			}
			projectile.Kill();
			return;
		}
	}
	else
	{
		int num139 = (int)(projectile.position.X / 16f) - 1;
		int num140 = (int)((projectile.position.X + (float)projectile.width) / 16f) + 2;
		int num141 = (int)(projectile.position.Y / 16f) - 1;
		int num142 = (int)((projectile.position.Y + (float)projectile.height) / 16f) + 2;
		if (num139 < 0)
		{
			num139 = 0;
		}
		if (num140 > Main.maxTilesX)
		{
			num140 = Main.maxTilesX;
		}
		if (num141 < 0)
		{
			num141 = 0;
		}
		if (num142 > Main.maxTilesY)
		{
			num142 = Main.maxTilesY;
		}
		int num143 = (int)projectile.position.X + 4;
		int num144 = (int)projectile.position.Y + 4;
		for (int num145 = num139; num145 < num140; num145++)
		{
			for (int num146 = num141; num146 < num142; num146++)
			{
				if (Main.tile[num145, num146] != null && Main.tile[num145, num146].active && Main.tile[num145, num146].type != (ushort)Config.tileDefs.ID["Obsidian 2"] && Main.tileSolid[(int)Main.tile[num145, num146].type] && !Main.tileSolidTop[(int)Main.tile[num145, num146].type])
				{
					Vector2 vector16;
					vector16.X = (float)(num145 * 16);
					vector16.Y = (float)(num146 * 16);
					if ((float)(num143 + 8) > vector16.X && (float)num143 < vector16.X + 16f && (float)(num144 + 8) > vector16.Y && (float)num144 < vector16.Y + 16f)
					{
						projectile.Kill();
					}
				}
			}
		}
		/*if (projectile.lavaWet)
		{
			projectile.Kill();
		}*/
		if (projectile.active)
		{
			int num147 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, 0f, 0f, 0, default(Color), 1f);
			Main.dust[num147].noGravity = true;
			Main.dust[num147].velocity *= 0.3f;
			int num148 = (int)projectile.ai[0];
			int num149 = (int)projectile.ai[1];
			if (projectile.velocity.X > 0f)
			{
				projectile.rotation += 0.3f;
			}
			else
			{
				projectile.rotation -= 0.3f;
			}
			if (Main.myPlayer == projectile.owner)
			{
				int num150 = (int)((projectile.position.X + (float)(projectile.width / 2)) / 16f);
				int num151 = (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f);
				bool flag2 = false;
				if (num150 == num148 && num151 == num149)
				{
					flag2 = true;
				}
				if (((projectile.velocity.X <= 0f && num150 <= num148) || (projectile.velocity.X >= 0f && num150 >= num148)) && ((projectile.velocity.Y <= 0f && num151 <= num149) || (projectile.velocity.Y >= 0f && num151 >= num149)))
				{
					flag2 = true;
				}
				if (flag2)
				{
					if (WorldGen.PlaceTile(num148, num149, (ushort)Config.tileDefs.ID["Obsidian 2"], false, false, projectile.owner, 0))
					{
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 1, (float)((int)projectile.ai[0]), (float)((int)projectile.ai[1]), 56f, 0);
						}
						projectile.damage = 0;
						projectile.ai[0] = -1f;
						projectile.velocity *= 0f;
						projectile.alpha = 255;
						projectile.position.X = (float)(num148 * 16);
						projectile.position.Y = (float)(num149 * 16);
						projectile.netUpdate = true;
						return;
					}
					projectile.ai[1] = -1f;
					return;
				}
			}
		}
	}
}

public void Kill()
{
	if (projectile.type == Config.projDefs.byName["Obsidian"].type)
	{
		if (projectile.ai[0] >= 0f)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 7);
			for (int num16 = 0; num16 < 10; num16++)
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, 0f, 0f, 0, default(Color), 1f);
			}
		}
		int num17 = (int)projectile.position.X / 16;
		int num18 = (int)projectile.position.Y / 16;
		if (Main.tile[num17, num18] == null)
		{
			Main.tile[num17, num18] = new Tile();
		}
		if (Main.tile[num17, num18].type == (ushort)Config.tileDefs.ID["Obsidian 2"] && Main.tile[num17, num18].active)
		{
			WorldGen.KillTile(num17, num18, false, false, false);
		}
		projectile.active = false;
	}
}