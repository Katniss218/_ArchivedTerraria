public static void Effects(Player p) {
    p.statDefense -= 6;
	p.meleeCrit += 3;
	p.meleeSpeed += 1.5f;
	p.meleeDamage += 1.5f;
	p.confused = true;
}