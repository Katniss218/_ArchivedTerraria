
public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 5, 0, 0, 50, Color.White, 1.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = true;
	}
}