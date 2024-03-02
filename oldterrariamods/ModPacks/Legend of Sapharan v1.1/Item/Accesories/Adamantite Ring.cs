public static void Effects(Player player) 
{
    player.statDefense += 20;
	player.manaCost -= 0.15f;
	player.meleeDamage += 0.06f;
	player.rangedDamage += 0.06f;
	player.magicDamage += 0.06f;
	player.meleeCrit += 4;
	player.rangedCrit += 4;
	player.magicCrit += 4;
	player.moveSpeed += 0.05f;
	player.meleeSpeed += 0.1f;
	player.ammoCost80 = true;
}