public static void Effects(Player player)
{
	player.rangedDamage += 0.25f;
}
public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Overlord Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Damage Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Overlord Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Damage Emblem"].type))
	{
		return false;
	}
	return true;
}