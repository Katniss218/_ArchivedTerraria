public void FrameEffect (Player player)
	{
	for (int i = 0; i < 10; i++)
	{
	if (player.buffTime[i] > 0)
		{
        	if (player.buffType[i] == 31)
			{
			//This one grants immunity to confusion.
			player.DelBuff(31);
			}
		if (player.buffType[i] == 32)
			{
			//This one grants immunity to slow.
			player.DelBuff(32);
			}
		if (player.buffType[i] == 35)
			{
			//This one grants immunity to silence.
			player.DelBuff(35);
			}
		}
	}
	}

public void DamageNPC (Player player, NPC npc, ref int damage, ref float knockback)
	{
	if (Main.rand.Next(10) == 0)
		{
		// Confusion!
		npc.AddBuff (31, 60);
		}
	}