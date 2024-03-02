public void VanityEffects(Player P)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Armageddon Pants"].type) && ModPlayer.HasItemInArmor(Config.itemDefs.byName["Armageddon Hat"].type))
	{
		P.ShadowAura = true;
		P.ShadowTail = true;
	}
}