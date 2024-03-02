int effect = -1;

public void UseItem(Player player, int playerID)
{
	effect +=1;
	if (effect > 76) effect = 0;
	player.HealEffect(effect);
}

public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, effect, (player.velocity.X) + (player.direction * 3), player.velocity.Y, 100, color, 2.0f);
	Main.dust[dust].noGravity = true;
}
