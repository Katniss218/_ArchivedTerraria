public void Effects(Player player)
{
	int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
	int j2 = (int)(player.position.Y + 2f) / 16;
	Lighting.addLight(i2,j2,3,3,3);
	player.pStone = true;
	player.longInvince = true;
	player.findTreasure = true;
	player.kbGlove = true;
	player.detectCreature = true;
}

public void DealtPlayer(Player P,double DMG,NPC N)
{
	P.immuneTime += 40;
}
public static void SetBonus(Player player) 
{
	player.setBonus = "+20% melee speed, +10% melee Dmg";
	player.meleeSpeed += 0.20f;
	player.meleeDamage += 0.10f;
}