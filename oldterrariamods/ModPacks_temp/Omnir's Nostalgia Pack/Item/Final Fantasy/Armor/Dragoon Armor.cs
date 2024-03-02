//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.meleeSpeed += 0.20f;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+15% melee damage, +10 defense.";
    player.meleeDamage += 0.15f;
    player.statDefense += 10;

}