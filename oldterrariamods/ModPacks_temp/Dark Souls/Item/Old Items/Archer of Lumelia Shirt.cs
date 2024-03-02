//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
    
    
    player.ammoCost75 = true;
}

public static void SetBonus(Player player) {
	player.setBonus = "+23% Ranged Crit, +15% Ranged Damage, Archery Skill";
    
        player.rangedCrit += 23;
	player.rangedDamage += 0.15f;
	player.archery=true;
    
	
}