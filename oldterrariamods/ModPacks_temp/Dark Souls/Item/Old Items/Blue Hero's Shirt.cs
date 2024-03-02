public static void SetBonus(Player player) {
	player.setBonus = "Grants extended breath & swimming plus 9% all stats Boost. Also gives +3 life regen, +200% movement and hunter vision while in water";
    	player.accFlipper=true;
    	player.accDivingHelm=true;
	player.meleeDamage += 0.09f;
    player.magicDamage += 0.09f;
    player.rangedDamage += 0.09f;
    player.rangedCrit += 9;
    player.meleeCrit += 9;
    player.magicCrit += 9;
    player.meleeSpeed += 0.09f;
    player.moveSpeed += 0.09f;
    player.manaCost -= 0.09f;
    player.ammoCost80 = true;

	if (player.wet)  {
 		player.lifeRegen += 3;
		player.detectCreature=true;
		player.moveSpeed *= 5f;
	}
   
}