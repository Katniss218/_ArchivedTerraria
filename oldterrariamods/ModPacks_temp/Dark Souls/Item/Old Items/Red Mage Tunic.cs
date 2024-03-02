//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
    player.manaCost -= 0.15f;
}

public static void SetBonus(Player player) {
	player.setBonus = "+8% magic damage, +20 mana";
    player.magicDamage += 0.08f;
	player.statManaMax2 += 20;
}