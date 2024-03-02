public static void Effects(Player player) 
{
        player.fireWalk=true;
	player.meleeDamage += 0.1f;
        player.noKnockback = true;
        player.manaCost += 0.05f;
}