//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
    player.ammoCost75 = true;
}

public static void SetBonus(Player player) {
	player.setBonus = "+20% Critical Ranged Chance, +20% Ranged Damage, +9 Life Regen";
    
    player.rangedDamage += 0.20f;
    player.rangedCrit += 20;
    player.lifeRegen += 9;
    
    
}