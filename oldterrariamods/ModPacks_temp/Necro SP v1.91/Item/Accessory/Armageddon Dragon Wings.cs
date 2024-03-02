public static int WINDEX = ModWorld.AddWingByTextureName("Armageddon Dragon Wings"); //its static because there's no point to initialize this for every single item's instance
public void Effects(Player P)
{
    P.wings = WINDEX;
    P.lavaImmune=true;
    P.rocketBoots = 1;
    P.rocketTimeMax = 1000;

	if (P.velocity.X > 0 || P.velocity.X < -0)
	{
		Color color = new Color();
		int dust = Dust.NewDust(new Vector2((float) P.position.X, (float) P.position.Y), P.width, P.height, 60, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 100, color, 2.0f);
		Main.dust[dust].noGravity = true;
	}
}

