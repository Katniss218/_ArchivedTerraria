public static void SetBonus(Player player) {
	player.setBonus = "You're all shiny!";
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 62, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.White, 0.6f);
	Main.dust[dust].noGravity = true;
}

public static void Effects(Player player) {
	
}