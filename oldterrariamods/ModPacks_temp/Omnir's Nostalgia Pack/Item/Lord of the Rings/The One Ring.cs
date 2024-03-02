//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
	player.noKnockback = true;
    player.rangedCrit *= 4;
    player.meleeCrit *= 4;
    player.magicCrit *= 4;
    player.meleeDamage *= 2;
    player.magicDamage *= 2;
    player.rangedDamage *= 2;
}

