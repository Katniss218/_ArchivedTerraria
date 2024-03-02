//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.meleeSpeed += 0.30f;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+30% melee damage";
    player.meleeDamage += 0.30f;
}

//coding from Kjulo's mod
public void PlayerFrame(Player player)
{
	if ((player.armor[0].name=="Crystal Helmet") || (player.armor[0].name=="Crystal Full Helmet"))
    {
		if (player.armor[2].name=="Crystal Greaves")
		{
			int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
			int j2 = (int)(player.position.Y + 2f) / 16;
            Lighting.addLight(i2, j2, 1f, 1f, 1f);
        }
    }
}
