//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.ammoCost75 = true;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+30% ranged damage";
    player.rangedDamage += 0.30f;
}

//coding from Kjulo's mod
public void PlayerFrame(Player player)
{
	if (player.armor[0].name=="Red Hood")
    {
		if (player.armor[2].name=="Red Bottoms")
		{
			int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
			int j2 = (int)(player.position.Y + 2f) / 16;
            Lighting.addLight(i2, j2, 1.5f, 0.75f, 0.75f);
        }
    }
}
