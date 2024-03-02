public static void Effects(Player player) {
    player.magicDamage += 0.10f;
    player.magicCrit += 10;
}

public static void SetBonus(Player player) {
    player.setBonus = "Mereman/Werewolf Effect, Star cloak Effect, Mana Flower Effect, +100 Higher Mana Stat, and Philosopher's Stone Effect";
	player.manaFlower=true;
    player.statManaMax2 +=100;
	player.pStone=true;
	player.accMerman=true;
	player.wolfAcc=true;
	player.starCloak=true;
}