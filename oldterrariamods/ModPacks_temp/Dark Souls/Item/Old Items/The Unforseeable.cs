public static void Effects(Player player) {
    player.ammoCost75 = true;

if(player.statLife <= 100) {
				player.lifeRegen += 13;
				}
				else { player.lifeRegen += 2;
					}

}

public static void SetBonus(Player player) {
	player.setBonus = "Boosts all Ranged Stats & Movement by 30% + Archery Skill + No fall DMG";
    
    player.rangedDamage += 0.30f;
    player.rangedCrit += 30;
    player.moveSpeed += 0.30f;
	player.archery=true;
	player.noFallDmg=true;
    
}







