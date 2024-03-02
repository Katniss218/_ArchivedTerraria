//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.meleeSpeed += 0.07f;
    player.ammoCost80 = true;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+5% melee and ranged damage";
    player.meleeDamage += 0.05f;
    player.rangedDamage += 0.05f;
}