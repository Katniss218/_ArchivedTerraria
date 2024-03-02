//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes


public static void SetBonus(Player player) 
{
	player.setBonus = "+40% melee speed, +15% melee Dmg, -30% Rng & Mag Dmg";
	player.meleeSpeed += 0.40f;
	player.meleeDamage += 0.15f;
	player.enemySpawns = true;
	player.ShadowTail = true;
}