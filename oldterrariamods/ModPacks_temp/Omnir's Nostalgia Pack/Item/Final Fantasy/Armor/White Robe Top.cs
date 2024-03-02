//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.manaCost -= 0.20f;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+25% magic damage";
    player.magicDamage += 0.25f;
}

//coding from Kjulo's mod
public void PlayerFrame(Player player)
{
	if (player.armor[0].name=="Grand Circlet")
    {
		if (player.armor[2].name=="White Robe Bottom")
		{
			int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
			int j2 = (int)(player.position.Y + 2f) / 16;
            Lighting.addLight(i2, j2, 1f, 1f, 1f);
        }
    }
}
