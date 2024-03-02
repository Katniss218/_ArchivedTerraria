//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.meleeSpeed += 0.09f;
    player.manaCost -= 0.09f;
    player.ammoCost80 = true;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+8% damage, +40 mana";
    player.meleeDamage += 0.08f;
    player.magicDamage += 0.08f;
    player.rangedDamage += 0.08f;
	player.statManaMax2 += 40;

}