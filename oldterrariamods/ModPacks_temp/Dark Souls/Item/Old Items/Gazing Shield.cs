//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	player.noKnockback = true;
    player.moveSpeed -= 0.10f;
	player.fireWalk=true;
	player.manaCost += 0.50f;
    	player.magicDamage -= 0.85f;
    	player.rangedDamage -= 0.85f;
    	player.meleeDamage += 0.04f;
}

public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Gazing Shield"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Beholder Shield"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Beholder Shield II"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Enchanted Beholder Shield II"].type))
	{
		return false;
	}
	return true;
}