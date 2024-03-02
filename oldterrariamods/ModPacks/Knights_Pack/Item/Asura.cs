public void FrameEffect (Player player)
	{
	if (player.statLife <= player.statLifeMax * 0.25)
		{
		player.AddBuff("Demonic Rage", 1);
		}
	}

public void UseItemEffect(Player player, Rectangle rectangle)
	{
	Color color = new Color();
    	//This is the same general effect done with the Fiery Greatsword
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 60, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.1f);
	Main.dust[dust].noGravity = true;	
	}

public void DamageNPC (Player player, NPC npc, ref int damage, ref float knockback)
	{
	int T = Config.buffID["Demonic Rage"];
	for (int i = 0; i < 10; i++)
	{
    	if (player.buffTime[i] > 0)
		{
       		if (player.buffType[i] == T)
			{
			npc.AddBuff (24, 180);
			}
		else
		{
		if (Main.rand.Next(4) == 0)
			{
		        // Burn, baby!
		        npc.AddBuff (24, 120);
			}
		}
		}
	}
	}