//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.meleeSpeed += 0.25f;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+25% melee damage";
    player.meleeDamage += 0.25f;
}