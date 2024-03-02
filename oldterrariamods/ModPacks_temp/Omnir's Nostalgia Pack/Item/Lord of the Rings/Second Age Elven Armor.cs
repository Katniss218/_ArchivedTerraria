//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.meleeSpeed += 0.4f;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+40% damage";
    player.meleeDamage += 0.4f;
    player.magicDamage += 0.4f;
    player.rangedDamage += 0.4f;
}