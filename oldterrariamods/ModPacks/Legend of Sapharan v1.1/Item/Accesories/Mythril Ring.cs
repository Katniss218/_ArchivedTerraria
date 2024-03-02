public static void Effects(Player player) 
{
    player.statDefense += 18;
	player.manaCost -= 0.1f;
	player.meleeDamage += 0.05f;
	player.rangedDamage += 0.05f;
	player.magicDamage += 0.05f;
	player.meleeCrit += 5;
	player.rangedCrit += 5;
	player.magicCrit += 5;
	player.ammoCost80 = true;
}