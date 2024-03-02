//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	player.rangedDamage += 0.10f;
}

public static void SetBonus(Player player) {
	player.setBonus = "20% chance to not consume ammo, 10% Increased Ranged Damage.";
	player.ammoCost80 = true;
	player.rangedDamage += 0.10f;
}