public static void SetBonus(Player player) {
	player.setBonus = "You hold the power...";
	player.doubleJump = true;
	player.ShadowAura = true;
	player.ShadowTail = true;
	player.jumpBoost = true;
	player.longInvince = true;
	player.noKnockback = true;
	player.statManaMax2 += 40;
	player.fireWalk = true;
	player.pickSpeed -= 0.3f;
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 62, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.White, 0.6f);
	Main.dust[dust].noGravity = true;
}

public static void Effects(Player player) {
	player.meleeCrit += 14;
	player.magicCrit += 14;
	player.rangedCrit += 14;
}