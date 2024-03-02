#region AI
public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 4)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 4)
    {
        projectile.Kill();
        return;
    }
}
#endregion



#region AI
public void AI(Player player)
{
   Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec))
{

Main.player[Main.myPlayer].AddBuff(20, 1200, false);
Main.player[Main.myPlayer].AddBuff("Frozen", 1200, false);
Main.player[Main.myPlayer].AddBuff(33, 1200, false);
}
}
#endregion