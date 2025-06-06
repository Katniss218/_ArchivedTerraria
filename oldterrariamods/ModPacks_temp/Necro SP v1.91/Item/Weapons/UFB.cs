
public static void UseItemEffect(Player player, Rectangle rectangle) 
{
    int dust = Dust.NewDust(
    new Vector2((float) rectangle.X, (float) rectangle.Y),     
    rectangle.Width,                                            
    rectangle.Height,                                           
    35,                                                         
    (player.velocity.X * 0.2f) + (player.direction * 3),       
    player.velocity.Y * 0.2f,                                   
    100,                                                       
    new Color(),                                               
    1.8f                                                      
    );
    Main.dust[dust].noGravity = true;
}




