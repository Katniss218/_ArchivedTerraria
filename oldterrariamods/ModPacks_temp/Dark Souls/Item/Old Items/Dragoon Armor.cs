public static int WINDEX = ModWorld.AddWingByTextureName("Dragon Wings"); //its static because there's no point to initialize this for every single item's instance
public static void SetBonus(Player player) {
	player.setBonus = "Harmonized with the four elements: fire, water, earth and air, including +2 life regen and 30% boost to all stats";
    player.lavaImmune=true;
    player.fireWalk=true;
    player.breath=9999999;
    player.waterWalk=true;
    player.noKnockback = true;
    player.meleeDamage += 0.30f;
    player.magicDamage += 0.30f;
    player.rangedDamage += 0.30f;
    player.rangedCrit += 30;
    player.meleeCrit += 30;
    player.magicCrit += 30;
    player.meleeSpeed += 0.30f;
    player.moveSpeed += 0.30f;
    player.manaCost -= 0.30f;
    player.lifeRegen += 2;
	player.wings = WINDEX;
    //player.wings = 2;
    player.ShadowAura = true;
    
}


