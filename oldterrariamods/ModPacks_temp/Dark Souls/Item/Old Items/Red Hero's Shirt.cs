public static void SetBonus(Player player) {
	player.setBonus = "Harmonizes you with fire and water, plus a 14% boost to all stats";
    player.lavaImmune=true;
    player.fireWalk=true;
    player.accFlipper=true;
    player.accDivingHelm=true;
    player.waterWalk=true;
    player.noKnockback = true;
    player.meleeDamage += 0.14f;
    player.magicDamage += 0.14f;
    player.rangedDamage += 0.14f;
    player.rangedCrit += 14;
    player.meleeCrit += 14;
    player.magicCrit += 14;
    player.meleeSpeed += 0.14f;
    player.moveSpeed += 0.14f;
    player.manaCost -= 0.14f;

if (player.lavaWet)  {
 		player.lifeRegen += 4;
		player.detectCreature=true;
	}

if (player.wet)  {
 		player.lifeRegen += 2;
		player.detectCreature=true;
		
	}
   
}