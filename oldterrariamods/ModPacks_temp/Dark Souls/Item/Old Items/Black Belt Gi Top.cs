//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
   player.doubleJump=true; 
	player.jumpBoost=true;
    
}

public static void SetBonus(Player player) {
	player.setBonus = "+20% Melee damage, +20% Melee Speed, Rapid Life Regeneration, +7% Melee Crit";
        player.meleeSpeed += 0.20f;    
        player.meleeDamage += 0.20f;
        player.meleeCrit += 7;
        player.lifeRegen += 13;
        player.ShadowAura = true;
    
}