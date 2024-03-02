//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void SetBonus(Player player) 
{
	player.setBonus = "+5% damage and movement speed";
    player.moveSpeed += 0.05f;
    player.meleeDamage += 0.05f;
    player.magicDamage += 0.05f;
    player.rangedDamage += 0.05f;
}