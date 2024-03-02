public static void Effects(Player player) {
	player.rangedDamage += 0.10f;
    player.rangedCrit += 15;
}

public static void SetBonus(Player player) {
    player.setBonus = "No fall Dam,Night vision, Creature Detect, +5% melee crit";
    player.meleeSpeed += 0.15f;
    player.socialShadow=true;
    player.noFallDmg=true;
    player.nightVision=true;
    player.detectCreature = true;
	player.ShadowTail = true;
    player.ShadowAura = true;
}