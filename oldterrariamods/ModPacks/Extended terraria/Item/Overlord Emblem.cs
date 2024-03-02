public static void Effects(Player player) {
	player.meleeDamage += 0.25f;
	player.rangedDamage += 0.25f;
	player.magicDamage += 0.25f;
}
public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Mage Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Berserker Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Archer Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Damage Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Ranger Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Warrior Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Sorcerer Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Mage Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Berserker Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Archer Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Damage Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Ranger Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Warrior Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Sorcerer Emblem"].type))
	{
		return false;
	}
	return true;
}