public static void Effects(Player player) 
{
	player.moveSpeed += 0.10f;
	player.doubleJump = true;
	player.meleeCrit -= 2;
	player.rangedCrit -= 1;
	player.rangedDamage += 0.3f;
	player.meleeDamage += 0.10f;
	player.meleeSpeed += 0.5f;
	player.statManaMax2 += 20;
}