public void UseItemEffect(Player player, Rectangle rectangle)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 50, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
	Main.dust[dust].noGravity = false;
	}

public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
	{
    	if (Main.rand.Next(3) == 0)
		{
        	// Poison!
        	npc.AddBuff (20, 420);
    		}

	}