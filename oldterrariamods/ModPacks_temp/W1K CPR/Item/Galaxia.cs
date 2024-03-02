public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	//This is the same general effect done with the Fiery Greatsword
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 57, (player.velocity.X), player.velocity.Y, 200, color, 1f);
	Main.dust[dust].noGravity = false;
}