public static void Effects(Player player) {
    player.magicDamage += 0.10f;
    player.magicCrit += 10;
	player.rangedDamage += 0.10f;
    player.rangedCrit += 15;
    player.meleeDamage += 0.10f;
    player.meleeCrit += 15;
}

public static void SetBonus(Player player) {
    player.setBonus = "Mereman/Werewolf Effect, Star cloak Effect, Mana Flower Effect, +100 Higher Mana Stat, Philosopher's Stone Effect, No fall damage, Night vision effect, Creature detect effect, and +5% Melee crit";
	player.manaFlower=true;
    player.statManaMax2 +=100;
	player.pStone=true;
	player.accMerman=true;
	player.wolfAcc=true;
	player.starCloak=true;
    player.meleeSpeed += 0.15f;
    player.socialShadow=true;
    player.noFallDmg=true;
    player.nightVision=true;
    player.detectCreature = true;
	player.ShadowTail = true;
    player.ShadowAura = true;
	player.meleeCrit += 5;
}