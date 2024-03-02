//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.meleeSpeed += 0.02f;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+10% melee damage, 15% movement speed, Firewalking";
    player.moveSpeed += 0.15f;
    player.meleeDamage += 0.10f;
	player.fireWalk = true;
}