public static void Effects(Player player) {
    player.manaCost -= 0.10f;
    player.statManaMax2 +=20;
}

public static void SetBonus(Player player) {
	player.setBonus = "No fall Dam,Night vision,and Creature Detect";
    player.moveSpeed += 0.05f;
    player.socialShadow=true;
    player.noFallDmg=true;
    player.nightVision=true;
    player.detectCreature = true;
}