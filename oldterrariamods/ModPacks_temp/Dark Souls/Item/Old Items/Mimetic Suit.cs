//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	
if(player.statLife <= 120) {
				player.manaRegen += 5;

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 100, Color.Green, 1.0f);
 Main.dust[dust].noGravity = true;

				}
				else { player.manaRegen += 0;
					}



}

public static void SetBonus(Player player) {
	player.setBonus = "30% Reduced Mana Cost, +6% Magic Crit, +15% Magic Damage";
	player.manaCost -= 0.30f;
	player.magicDamage += 0.15f;
	player.magicCrit += 6;
}