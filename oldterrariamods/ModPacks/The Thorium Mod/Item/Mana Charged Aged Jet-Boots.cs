//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	if(player.statMana>0) {
		player.rocketBoots=1;
		if(player.rocketFrame) {
			if (Main.rand.Next(2)==0) {
				player.statMana-=2;
			}
			player.rocketTime = 1;
		}
	}
}