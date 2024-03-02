public int T = Config.buffID["Exhausted"];
public bool exhausted = false;

public void FrameEffect (Player player)
	{
	for (int i = 0; i < 10; i++)
		{
		if (player.buffTime[i] > 0)
			{
        		if (player.buffType[i] == T)
				{
				exhausted = true;
				}
			}
		else
			{
			exhausted = false;
			}
		}
	if (exhausted == false)
		{
		player.AddBuff("Ultimate Power!", 1);
		}
	}

public void UseItemEffect(Player player, Rectangle rectangle)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 50, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
	Main.dust[dust].noGravity = false;
	if (exhausted == false && Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.R))
		{
		Projectile.NewProjectile(player.position.X + (player.width * 0.5f),player.position.Y + (player.height * 0.5f), 1, 1, "Atomic Buster", item.damage*10, 1);
		player.AddBuff("Exhausted", 7200);
		}
	}