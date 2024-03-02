//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.ammoCost80 = true;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+20% ranged damage";
    player.rangedDamage += 0.20f;
}