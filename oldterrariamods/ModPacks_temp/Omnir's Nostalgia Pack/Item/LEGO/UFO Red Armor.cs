//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void SetBonus(Player player) 
{
	player.setBonus = "+20% ranged damage, +25 defense";
    player.rangedDamage += 0.20f;
	player.statDefense += 25;
	player.spaceGun = true;
}