//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
    
    player.manaCost -= 0.25f;
    
}

public static void SetBonus(Player player) {
	player.setBonus = "+20% Magic Crit, +100 mana, +3 mana regen";
    
    player.magicCrit += 20;
    
	player.statManaMax2 += 100;
	player.manaRegen += 3;
}