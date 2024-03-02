public void Effects(Player player, int buffIndex, int buffType, int buffTime) {
	player.magicCrit += 5;
	player.rangedCrit += 5;
	player.meleeCrit += 5;
	player.meleeDamage += 0.2f;
	player.magicDamage += 0.2f;
	player.rangedDamage += 0.2f;
	player.meleeSpeed += 0.2f;
	player.pickSpeed += 0.2f;
	player.thorns = true;
	player.statDefense += 8;
	player.enemySpawns = true;
}
public void ModifyPlayerDrawColors(Player P, ref bool OverrideFire, ref float r, ref float g, ref float b, ref float a)
{
	OverrideFire = true;
	//g *= 0.76f;
	//b *= 0.0f;
	r *= 0.937f;
	g *= 0.8588f;
	b *= 0.0f;
}