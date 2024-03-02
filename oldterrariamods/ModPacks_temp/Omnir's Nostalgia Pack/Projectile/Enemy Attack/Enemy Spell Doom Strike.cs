#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 10)
    {
        projectile.Kill();
        return;
    }
    Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y,
    projectile.width, projectile.height);
    Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player
    [Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);
    if (projrec.Intersects(prec))
    {
        if (Main.player[Main.myPlayer].statLife < 100)
        {
            Main.player[Main.myPlayer].statLife -= 100;
            if(Main.player[Main.myPlayer].statLife < 0) 
            {
                Main.player[Main.myPlayer].statLife =0;
                Main.player[Main.myPlayer].KillMe(10.0, 0, false, " was instantly killed by the spell 'Doom'");
            }
        }
    }
}
#endregion