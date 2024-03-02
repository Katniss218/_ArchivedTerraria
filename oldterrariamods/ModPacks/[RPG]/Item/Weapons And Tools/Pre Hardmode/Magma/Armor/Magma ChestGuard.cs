public static void SetBonus(Player player) {
	player.setBonus = "Immune to lava";
	player.lavaImmune=true;
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.White, 0.6f);
	Main.dust[dust].noGravity = true;	
}
public static void Effects(Player player) {
	player.meleeDamage += 0.10f;
} 