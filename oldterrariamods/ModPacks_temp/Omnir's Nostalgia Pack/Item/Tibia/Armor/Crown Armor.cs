//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void SetBonus(Player player) 
{
	player.setBonus = "+5% run speed, +3 defense";
	player.statDefense += 3;
    player.moveSpeed += 0.05f;
}