//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.meleeSpeed += 0.20f;
    player.manaCost -= 0.20f;
    player.ammoCost80 = true;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+20% damage, +80 mana";
    player.meleeDamage += 0.20f;
    player.magicDamage += 0.20f;
    player.rangedDamage += 0.20f;
	player.statManaMax2 += 80;
}