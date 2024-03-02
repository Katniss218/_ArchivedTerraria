public static int WINDEX = ModWorld.AddWingByTextureName("Arch Angel Wings"); //its static because there's no point to initialize this for every single item's instance
public void Effects(Player P)
{
    P.wings = WINDEX;

	if (P.velocity.X > 0 || P.velocity.X < -0)
	{
		Color color = new Color();
		int dust = Dust.NewDust(new Vector2((float) P.position.X, (float) P.position.Y), P.width, P.height, 63, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 100, color, 1f);
		Main.dust[dust].noGravity = true;
	}
}