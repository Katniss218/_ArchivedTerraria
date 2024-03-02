//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void SetBonus(Player player) 
{
	player.setBonus = "+25% ranged damage, +30 defense";
    player.rangedDamage += 0.25f;
	player.statDefense += 30;
	player.spaceGun = true;
}