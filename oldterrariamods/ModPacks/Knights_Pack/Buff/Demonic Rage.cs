
public static void Effects (Player player)
	{
	player.meleeDamage *= 1.5f;
	player.meleeSpeed *= 1.25f;
	player.meleeCrit += 5;
	if (player.direction == -1)
		{
		Color color = new Color();
		float pX = player.position.X + player.width * 0.225f;
		float pY = player.position.Y + player.height * 0.175f;
    		int dust = Dust.NewDust(new Vector2(pX, pY), 4, 4, 6, player.velocity.X * 2f, player.velocity.Y * 2f, 100, color, 1.2f);
		Main.dust[dust].noGravity = true;
		}
	else
		{
		Color color = new Color();
		float pX = player.position.X + player.width * 0.4125f;
		float pY = player.position.Y + player.height * 0.175f;
    		int dust = Dust.NewDust(new Vector2(pX, pY), 4, 4, 6, player.velocity.X * 2f, player.velocity.Y * 2f, 100, color, 1.2f);
		Main.dust[dust].noGravity = true;
		}
	}