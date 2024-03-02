public static void Effects(Player player) 
{
	player.moveSpeed += 0.35f;
	player.doubleJump = true;
	player.starCloak = true;
	player.meleeCrit -= 10;
	player.magicCrit -= 10;
	player.rangedCrit -= 10;
	player.rangedDamage += 0.3f;
	player.magicDamage += 0.3f;
	player.meleeDamage += 0.35f;
	player.meleeSpeed += 0.35f;
	player.statManaMax2 += 150;
}