#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 6)
    {
        projectile.frame = 2;
        return;
    }
    Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y,
    projectile.width, projectile.height);
    Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player
    [Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);
    if (projrec.Intersects(prec))
    {
        Main.player[Main.myPlayer].AddBuff("Free Falling", 30, false);
        if(Main.player[Main.myPlayer].position.Y > (Main.rockLayer * 12.0))
        {
            Main.player[Main.myPlayer].position.Y -= (1000);
        }   
    }
}
#endregion