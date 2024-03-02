//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
    player.moveSpeed += 0.12f;
	player.fireWalk = true;
    player.meleeDamage += 0.10f;
    player.magicDamage += 0.10f;
    player.rangedDamage += 0.10f;
}