public void AI()
{
    projectile.AI(true);
    int dust = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    54,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    100,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;
}

public void DamagePlayer(ref int damage, Player P)
{
	if (Main.rand.Next(4) == 0)
	{
		P.AddBuff("Dark Inferno", 240, false);
	}
}