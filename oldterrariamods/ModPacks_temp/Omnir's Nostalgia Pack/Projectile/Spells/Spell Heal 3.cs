int healTimer = 1;

#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 9)
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
        healTimer --;
    }
    if (healTimer == 0)
    {
        Main.player[Main.myPlayer].statLife += 20;
        if (Main.player[Main.myPlayer].statLife > Main.player[Main.myPlayer].statLifeMax)
        {
            Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax;
        }
        healTimer = 60;
    }
    if (healTimer <= 0)
    {
        healTimer = 60;
    }
}
#endregion