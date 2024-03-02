public void Effects(Player player)
{
	float num30 = 1f;
	float num31 = (float)player.statLifeMax / 1100f * 0.85f + 0.15f;
	num30 *= num31;
	player.lifeRegen += (int)Math.Round((double)num30);
	player.lifeRegenCount += player.lifeRegen;
	while (player.lifeRegenCount >= 500)
	{
		player.lifeRegenCount -= 500;
		if (player.statLife < player.statLifeMax)
		{
			player.statLife++;
		}
		if (player.statLife > player.statLifeMax)
		{
			player.statLife = player.statLifeMax;
		}
	}
	player.manaCost -= 0.4f;
	player.statDefense += 5;
	player.statManaMax2 += 100;
	player.magicDamage += 0.2f;
	player.magicCrit += 2;
	player.pStone = true;
}
public bool CanEquip(Player P, int slot)
{
	if (ModPlayer.HasItemInArmor(Config.itemDefs.byName["Gift of Starpower"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Gift of Starpower"].type)) return false;
	return true;
}