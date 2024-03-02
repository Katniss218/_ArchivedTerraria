public static void Effects(Player p) {
    p.moveSpeed -= 0.4f;
	p.brokenArmor = true;
	p.ShadowAura = true;
	p.ShadowTail = true;
	p.confused = true;
	p.poisoned = true;
}