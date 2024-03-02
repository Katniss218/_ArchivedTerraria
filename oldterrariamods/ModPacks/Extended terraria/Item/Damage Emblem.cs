public void Effects(Player player) {
	player.meleeDamage += 0.15f;
	player.rangedDamage += 0.15f;
	player.magicDamage += 0.15f;
}
public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Mage Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Berserker Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Archer Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Overlord Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Ranger Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Warrior Emblem"].type) || ModPlayer.HasItemInArmor(Config.itemDefs.byName["Sorcerer Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Mage Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Berserker Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Archer Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Overlord Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Ranger Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Warrior Emblem"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Sorcerer Emblem"].type))
	{
		return false;
	}
	return true;
}