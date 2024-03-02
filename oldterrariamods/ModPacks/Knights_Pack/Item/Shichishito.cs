
public void UseItemEffect(Player player, Rectangle rectangle)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 76, (player.velocity.X * 0.2f) + (player.direction), 0f, 100, color, 0.8f);
	Main.dust[dust].noGravity = false;
	}

public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
	{
	if (Main.rand.Next(5) == 0)
		{
		npc.AddBuff ("Snowed", 240);
		}
	}