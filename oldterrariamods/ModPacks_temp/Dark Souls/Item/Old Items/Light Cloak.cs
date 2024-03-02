public static void Effects(Player player) {
    

if(player.statLife <= 120) {
				player.lifeRegen += 8;
				
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 21, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.White, 1.0f);
 Main.dust[dust].noGravity = true;

				}
				else { player.lifeRegen += 2;
					}

}