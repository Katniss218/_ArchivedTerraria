//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.manaCost -= 0.12f;
    player.magicDamage += 0.05f;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+15% magic damage";
    player.magicDamage += 0.15f;
}