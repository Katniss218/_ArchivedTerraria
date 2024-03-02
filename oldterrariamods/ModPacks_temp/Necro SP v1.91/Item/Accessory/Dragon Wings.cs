public static int WINDEX = ModWorld.AddWingByTextureName("Dragon Wings"); //its static because there's no point to initialize this for every single item's instance
public void Effects(Player P)
{
    P.wings = WINDEX;
    P.lavaImmune=true;
	if (P.controlLeft)
	{
		if (P.velocity.X > -4) P.velocity.X -= 0.31f;
		if (P.velocity.X < -4 && P.velocity.X > -8)
		{
			P.velocity.X -= 0.29f;
		}
	}
	if (P.controlRight)
	{
		if (P.velocity.X < 4) P.velocity.X += 0.31f;
		if (P.velocity.X > 4 && P.velocity.X < 8)
		{
			P.velocity.X += 0.31f;
		}
	}
	if (P.velocity.X > 0 || P.velocity.X < -0)
	{
		Color color = new Color();
		int dust = Dust.NewDust(new Vector2((float) P.position.X, (float) P.position.Y), P.width, P.height, 37, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 100, color, 1f);
		Main.dust[dust].noGravity = true;
	}
}

