//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
    player.meleeSpeed += 0.07f;
   
}

public static void SetBonus(Player player) {
	player.setBonus = "+10% melee damage, +20 mana";
    player.meleeDamage += 0.10f;
	player.statManaMax2 += 20;
}