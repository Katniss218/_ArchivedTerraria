public static void Effects(Player player) 
{
    player.statDefense += 24;
	player.manaCost -= 0.2f;
	player.meleeDamage += 0.07f;
	player.rangedDamage += 0.07f;
	player.magicDamage += 0.07f;
	player.meleeCrit += 7;
	player.rangedCrit += 7;
	player.magicCrit += 7;
	player.moveSpeed += 0.1f;
	player.meleeSpeed += 0.1f;
	player.ammoCost75 = true;
}