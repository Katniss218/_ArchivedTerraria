//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
    player.meleeSpeed += 0.15f;
    player.manaCost -= 0.15f;
    player.ammoCost80 = true;
}

public static void SetBonus(Player player) {
	player.setBonus = "+6% damage all types, +40 mana";
    player.meleeDamage += 0.06f;
    player.magicDamage += 0.06f;
    player.rangedDamage += 0.06f;
	player.statManaMax2 += 40;
}