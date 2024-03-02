public static void Effects(Player player) {
    
//light cube effect - bright light at character position
int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
						int j2 = (int)(player.position.Y + 2f) / 16;
						Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);

if(player.statLife <= 120) {
				player.lifeRegen += 8;
				player.statDefense += 12; 
				player.manaRegenBuff = true;
				player.starCloak = true;
				player.magicCrit += 6;
				player.magicDamage += .10f;
				
				
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 21, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.White, 2.0f);
 Main.dust[dust].noGravity = true;

				}
				else { player.lifeRegen += 2;
					player.statDefense += 4; 
					player.starCloak = true;
					player.magicCrit += 3;
					player.magicDamage += .05f;


					}

}

