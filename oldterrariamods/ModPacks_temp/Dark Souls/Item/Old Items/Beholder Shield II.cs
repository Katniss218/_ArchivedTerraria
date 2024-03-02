//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
	player.noKnockback = true;
	player.moveSpeed -= 0.20f;
	player.fireWalk=true;
	player.manaCost += 0.70f;
    player.magicDamage -= 1.5f;
    player.rangedDamage -= 1.5f;
    player.meleeDamage += 0.08f;

    for(int num39 = 0; num39 < 10; num39++)
    {
        if (player.buffType[num39] == 24)//On Fire
        {
            player.buffType[num39] = 0;
            player.buffTime[num39] = 0;

            break;
        }
    }
   
}

public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Gazing Shield"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Beholder Shield"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Beholder Shield II"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Enchanted Beholder Shield II"].type))
	{
		return false;
	}
	return true;
}