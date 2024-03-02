//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
player.manaCost -= 0.10f;


	if(player.statLife <= 60) {
				player.statDefense += 15;

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 60, (player.velocity.X) + (player.direction * 3), player.velocity.Y, 100, Color.Red, 3.0f);
 Main.dust[dust].noGravity = true;

				}
				else { player.statDefense += 0;
					}


}

