
public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	//This is the same general effect done with the Fiery Greatsword
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 62, 0, 0, 100, Color.White, 2.0f);
	Main.dust[dust].noGravity = true;
}