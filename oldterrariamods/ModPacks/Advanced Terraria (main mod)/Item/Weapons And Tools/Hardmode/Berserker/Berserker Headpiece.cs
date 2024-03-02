public void Effects(Player player)
{
	player.rangedDamage += 0.3f;
	player.magicDamage += 0.3f;
	player.meleeDamage += 0.35f;
	player.meleeSpeed += 0.35f;
	player.pickSpeed += 0.20f;
	player.noKnockback = true;
	player.statManaMax2 += 240;
}