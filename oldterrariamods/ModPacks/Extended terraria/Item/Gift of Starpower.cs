public void Effects(Player player) {
	player.statManaMax2 += 40;
	player.manaCost -= 0.2f;
	player.manaFlower = true;
	player.magicDamage += 0.15f;
}
public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Starpower's Will"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Starpower's Will"].type)) return false;
	return true;
}