public static void SetBonus(Player player) {
	player.setBonus = "+5% Magic Damage, -5% Mana Usage";
	player.magicDamage += 0.05f;
	player.manaCost -= 0.05f;
}

public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 200, color, 1.5f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = true;
	}
}