public static void Effects(Player player) {
	player.moveSpeed += 0.10f;
}

public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 0, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 0, color, 1.5f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = true;
	}
}