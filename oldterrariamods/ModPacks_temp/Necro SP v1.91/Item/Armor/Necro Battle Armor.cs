public static void Effects(Player player) {
    player.meleeDamage += 0.05f;
    player.rangedDamage += 0.05f;
}

public static void SetBonus(Player player) {
    player.setBonus = "No fall Dam,Night vision,and Creature Detect";
    player.meleeSpeed += 0.15f;
    player.socialShadow=true;
    player.noFallDmg=true;
    player.nightVision=true;
    player.detectCreature = true;
	player.ShadowTail = true;
}
