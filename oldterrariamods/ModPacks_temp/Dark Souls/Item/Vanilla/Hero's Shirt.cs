public static void SetBonus(Player player) {
	player.setBonus = "Boosts all critical hits by 5%";
    
    player.rangedCrit += 5;
    player.meleeCrit += 5;
    player.magicCrit += 5;
    
}