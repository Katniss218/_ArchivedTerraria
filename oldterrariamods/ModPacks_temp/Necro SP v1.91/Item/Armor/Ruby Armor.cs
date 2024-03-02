public static void SetBonus(Player player) {
	player.setBonus = "Mana Flower Effect, +100 Higher Mana Stat";
	player.manaFlower=true;
    player.statManaMax2 +=100;
}

public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 25, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 50, color, 1.0f);
	Main.dust[dust].noGravity = true;
	}
}