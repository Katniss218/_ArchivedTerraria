//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	player.noKnockback = true;
	player.moveSpeed -= 0.25f;
	player.thorns = true; //player.AddBuff(14,100,false);
}