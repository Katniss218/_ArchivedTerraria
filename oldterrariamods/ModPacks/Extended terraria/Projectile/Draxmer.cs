public void AI()
{
    projectile.AI(true);
    int dust = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    58,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    90,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;
}