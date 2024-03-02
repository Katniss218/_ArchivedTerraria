public static void Effects(Player player) {
	
if(player.statLife <= 120) {
				
				player.manaRegenBuff = true;
				player.starCloak = true;
				player.magicCrit += 6;
				player.magicDamage += .10f;

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 65, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 100, Color.Blue, 2.0f);
 Main.dust[dust].noGravity = true;

				}
				else { 
					
					player.starCloak = true;
					player.magicCrit += 3;
					player.magicDamage += .05f;
					
					}

}
