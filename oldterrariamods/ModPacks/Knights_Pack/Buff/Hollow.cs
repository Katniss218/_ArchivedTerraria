public void ModifyPlayerDrawColors(Player player,ref bool OF,ref float r,ref float g,ref float b,ref float a)
	{
	r *= 0.9f;
	g *= 0.9f;
	b *= 0.9f;
	}


public static void Effects (Player player)
	{
	player.lifeRegenTime = 0;
	player.boneArmor = true;
	}