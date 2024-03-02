public static void SetBonus(Player player) {
	player.setBonus = "+20% Magic Crit, +30% Magic Damage, +60 mana + Mana Cloak Skill";

if(player.statLife <= 100) {
				player.manaCost -= 0.17f;
				player.manaRegenBuff = true;
				player.starCloak = true;
				player.magicCrit += 40;
				player.magicDamage += .60f;
				player.statManaMax2 += 60;

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 65, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 100, Color.Blue, 2.0f);
 Main.dust[dust].noGravity = true;

				}
				else { 
					
					player.manaCost -= 0.17f;
					player.magicCrit += 20;
					player.magicDamage += .30f;
					player.statManaMax2 += 60;
					
					
					}

}
