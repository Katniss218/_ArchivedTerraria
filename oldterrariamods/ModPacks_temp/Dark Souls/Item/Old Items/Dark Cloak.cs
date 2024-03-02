public void Effects(Player player) {
	if(player.statLife <= 100) {
				player.statDefense += 12; 

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 54, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.Black, 3.0f);
 Main.dust[dust].noGravity = true;
					}
				
				else { player.statDefense += 4;
					}
				


}

