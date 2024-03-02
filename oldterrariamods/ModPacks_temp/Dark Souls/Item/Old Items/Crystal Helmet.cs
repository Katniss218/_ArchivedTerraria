//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes


public static void Effects(Player player) {
	if(player.statLife <= 80) {

				player.rangedDamage += 0.20f;
				player.magicDamage -= 0.30f;
				player.meleeCrit += 5;

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 42, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 105, Color.Aqua, 1.0f);
 Main.dust[dust].noGravity = true;

					}
				
				else { 

				player.rangedDamage -= 0.30f;
				player.magicDamage -= 0.30f;
				player.meleeCrit += 5;

					}
				


}