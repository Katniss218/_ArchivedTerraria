//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) {
	player.meleeDamage += 0.10f;
}

public static void SetBonus(Player player) {
	player.setBonus = "+10% Melee Crit, +10% Melee Speed";
	player.meleeCrit += 10;
	player.meleeSpeed += 0.10f;
}

public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 200, color, 1.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = false;
	}
}