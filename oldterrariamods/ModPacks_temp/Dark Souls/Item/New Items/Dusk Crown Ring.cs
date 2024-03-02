public static void Effects(Player player) 
{
    
    player.statLifeMax2 /= 2;
	player.manaCost -= 0.5f;
	player.magicDamage *= 2;
	player.magicCrit += 50;
	
}

public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Healing Dusk Crown Ring"].type))
	{
		return false;
	}
	return true;
}