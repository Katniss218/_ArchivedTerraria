

public static void Effects(Player player) 
{
        //player.AddBuff("Blood Moon", 60, false);
	player.moveSpeed += 0.07f;
	player.meleeSpeed += 0.07f;
        player.lavaImmune=true;
        player.fireWalk=true;
        player.noKnockback = true;
        player.meleeDamage += 0.07f;
    	player.magicDamage += 0.07f;
    	player.rangedDamage += 0.07f;
        player.enemySpawns = true;
        player.rangedCrit += 7;
	player.magicCrit += 7;
	player.meleeCrit += 7;
}



