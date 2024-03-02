//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
   player.meleeSpeed += 0.20f;
    
}

public static void SetBonus(Player player) {
	player.setBonus = "+25% Melee damage, +17% Melee Crit";
            
        player.meleeDamage += 0.25f;
        player.meleeCrit += 17;
        
    
    
}