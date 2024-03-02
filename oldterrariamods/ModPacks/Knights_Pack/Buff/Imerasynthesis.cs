
public static void Effects (Player player)
	{
	player.lifeRegen = 3;
	if (Main.rand.Next(10)==0)
		{
		int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 74, player.velocity.X, -4f, 100, new Color(), 1.0f);
		Main.dust[dust].noGravity = true;
		}
	}