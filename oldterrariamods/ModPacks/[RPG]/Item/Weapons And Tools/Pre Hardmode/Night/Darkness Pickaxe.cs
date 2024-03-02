public void UseItemEffect(Player player, Rectangle rectangle) //notes will be written to assist you further kingicarus
{
    int dust = Dust.NewDust(
    new Vector2((float) rectangle.X, (float) rectangle.Y),      //position
    rectangle.Width,                                            //box width
    rectangle.Height,                                           //box height
    27,                                                         //type
    (player.velocity.X * 0.2f) + (player.direction * 3),        //X velocity
    player.velocity.Y * 0.2f,                                   //Y velocity
    80,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;
}