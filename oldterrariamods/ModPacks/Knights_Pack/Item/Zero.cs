public void FrameEffect (Player player)
	{
	player.AddBuff ("Hollow", 10800);
	}

public void UseItemEffect(Player player, Rectangle rectangle)
	{
	Color color = new Color();
    	//This is the same general effect done with the Fiery Greatsword
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 67, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.1f);
	Main.dust[dust].noGravity = true;
	}

public void DealtNPC(Player player, NPC npc, double damage)
	{
	player.statLife += (int)damage/5;
	}

public void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
	{
	myPlayer.statLife += (int)(damage*2)/5;
	}