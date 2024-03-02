public void ModifyPlayerDrawColors(Player player,ref bool OF,ref float r,ref float g,ref float b,ref float a)
	{
	r *= 0.8f;
	g *= 0.6f;
	b *= 0.9f;
	}

public static void Effects (Player player)
	{
	player.lifeRegenTime = 0;
	player.lifeRegen = -2;
	if (player.statDefense >= 20)
		{
		player.statDefense *= 2;
		}
	else
		{
		player.statDefense += 20;
		}
	player.ShadowTail = true;
	player.blind = true;
	player.enemySpawns = true;
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X - player.width * 20f, (float) player.position.Y - player.height * 7f), 1000, 1000, (int)Main.rand.Next(77), 20, 0, 100, color, 2.0f);
	Main.dust[dust].noGravity = true;
	}