public static void Effects(Player player) {
    player.lightOrb=true;
    player.lavaImmune=true;
    player.noFallDmg=true;
    player.findTreasure=true;
    player.nightVision=true;
    player.accDepthMeter = 1;
    player.accWatch = 3;
    player.accFlipper=true; 
}

public static void VanityEffects(Player p) {
	Effects(p);
}