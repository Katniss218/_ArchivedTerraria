//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
	player.noKnockback = true;
    player.AddBuff(22, 500, false);
    player.AddBuff(13, 500, false);
    player.rangedCrit *= 2;
    player.meleeCrit *= 2;
    player.magicCrit *= 2;
}