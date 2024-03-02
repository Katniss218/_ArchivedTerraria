//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
player.manaCost -= 0.30f;


	if(player.statLife <= 120) {
				player.statDefense += 15;
				}
				else { player.statDefense += 0;
					}


}

